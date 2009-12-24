using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTree.Presenter;
using FTree.Common;
using FTree.DTO;

namespace FTree.View.Win32
{
    public partial class AchievementForm : BaseDialogForm, IAchievementView, IValidator
    {
        #region VARIABLES

        private AchievementPresenter _presenter;

        private FamilyMemberDTO _person;
        private IList<AchievementType> _achievementTypeList;
        private AchievementType _selectedAchievementType;
        private AchievementInfo _achievementInfo;

        private DataFormMode _mode = DataFormMode.CreateNew;
        private bool _autoSave = true;

        #endregion

        #region CONTRUCTOR

        /// <summary>
        /// Creates a new instance of AchievementForm to assign an achievement or event to a person.
        /// </summary>
        /// <param name="person">An object of FamilyMemberDTO.</param>
        public AchievementForm(FamilyMemberDTO person)
        {
            InitializeComponent();
            _person = person;
        }

        /// <summary>
        /// Creates an instance of AchievementForm to update or edit the achievement information of a person.
        /// </summary>
        /// <param name="person">An object of FamilyMemberDTO.</param>
        /// <param name="achievementInfo">The achievement or event needs updating.</param>
        public AchievementForm(FamilyMemberDTO person, AchievementInfo achievementInfo)
        {
            InitializeComponent();
            _person = person;
            _achievementInfo = achievementInfo;
            _mode = DataFormMode.Edit;
        }

        #endregion

        #region UI EVENTS

        private void AchievementForm_Load(object sender, EventArgs e)
        {
            try
            {
                #region Check person was died but was added achievement.

                if (_mode == DataFormMode.CreateNew
                        && _person != null
                        && _person.IsDead)
                {
                    string message = Util.GetStringResource(StringResName.MSG_ACTION_ON_DIED_PERSON);
                    DialogResult result =
                        UIUtils.ConfirmOKCancel(message);
                    if (result == DialogResult.Cancel)
                    {
                        this.DialogResult = DialogResult.Cancel;
                        return;
                    }
                }

                #endregion

                ThreadHelper.DoWork(_initPresenter);
                ThreadHelper.DoWork(_loadData);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementForm), exc);
                UIUtils.Error(exc.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case DataFormMode.CreateNew:
                    ThreadHelper.DoWork(_addAchievement);
                    break;

                case DataFormMode.Edit:
                    ThreadHelper.DoWork(_updateAchievement);
                    break;

                default:
                    return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void cbAchievementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAchievementType.SelectedItem != null)
                _selectedAchievementType = cbAchievementType.SelectedItem as AchievementType;
        }

        #endregion

        #region CORE METHODS

        private void _addAchievement()
        {
            try
            {
                _achievementInfo = new AchievementInfo();
                _achievementInfo.AchievementType = _selectedAchievementType;
                _achievementInfo.AchievementDate = achieveDatePicker.Value;
                _achievementInfo.Description = txtDescription.Text.Trim();

                _presenter.Add();
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(AchievementForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        private void _updateAchievement()
        {
            try
            {
                _achievementInfo.AchievementType = _selectedAchievementType;
                _achievementInfo.AchievementDate = achieveDatePicker.Value;
                _achievementInfo.Description = txtDescription.Text.Trim();                

                _presenter.Update();
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(AchievementForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        private void _loadData()
        {
            try
            {
                _presenter.LoadAllAchievementTypes();

                if (_mode == DataFormMode.Edit
                        && _achievementInfo != null)
                {
                    this.Invoke(new ThreadHelper.VoidDelegate(_loadAchievementInfo));
                }

                this.lblPersonName.Text = _person.ToString();
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(AchievementForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(AchievementForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        private void _loadAchievementInfo()
        {
            if (_achievementInfo == null)
                return;

            // Cannot directly set the SelectedItem for Combobox, 
            // because it doesn't contain the object of _achievementInfo.AchievementType.
            // So, we must search in the DataSource of the Combobox: the _achievementTypeList.
            IEnumerable<AchievementType> aTypes =
                from type in _achievementTypeList
                where type.Name == _achievementInfo.AchievementType.Name
                select type;

            AchievementType aType = aTypes.Single();

            this.cbAchievementType.SelectedItem = aType;

            this.achieveDatePicker.Value = _achievementInfo.AchievementDate;
            this.txtDescription.Text = _achievementInfo.Description;
        }

        #endregion

        #region UTILITY METHODS

        private void _initPresenter()
        {
            _presenter = new AchievementPresenter(this);
            _presenter.AutoSubmitChanges = _autoSave;
        }

        /// <summary>
        /// Determinies that the presenter will automatically submit all changes to DB or not. 
        /// The default value is True.
        /// </summary>
        /// <remarks>If False, you need to call SaveAllChanges after finishing all works.</remarks>
        /// <param name="autoSave"></param>
        public void SetAutoSave(bool autoSave)
        {
            _autoSave = autoSave;
            if (_presenter != null)
                _presenter.AutoSubmitChanges = autoSave;
        }

        #endregion

        #region IAchievementView Members

        public FamilyMemberDTO Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
            }
        }

        public IList<AchievementType> AchievementTypeList
        {
            get
            {
                return _achievementTypeList;
            }
            set
            {
                _achievementTypeList = value;
                cbAchievementType.DataSource = _achievementTypeList;
            }
        }

        public AchievementType SelectedAchievementType
        {
            get { return _selectedAchievementType; }
        }

        public AchievementInfo AchievementInfo
        {
            get
            {
                return _achievementInfo;
            }
            set
            {
                _achievementInfo = value;
            }
        }

        #endregion

        #region IView Members

        public string ViewName
        {
            get { return this.ToString(); }
        }

        #endregion

        #region IValidator Members

        public bool ValidateInputData()
        {
            return true;
        }

        #endregion
    }
}
