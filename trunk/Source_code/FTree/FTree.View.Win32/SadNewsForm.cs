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
    public partial class SadNewsForm : BaseDialogForm, IDeathInfoView
    {
        #region VARIABLES

        private DeathInfoPresenter _presenter;

        private FamilyMemberDTO _person;
        private IList<DeathReasonDTO> _deathReasonsList;
        private DeathReasonDTO _deathReason;
        private IList<BuryPlaceDTO> _buryPlacesList;
        private BuryPlaceDTO _buryPlace;
        private DeathInfo _deathInfo;

        private DataFormMode _mode;
        private bool _autoSave = true;

        #endregion

        #region CONTRUCTOR

        /// <summary>
        /// Creates an instance of SadNewsForm.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="onCreateNew">Determines </param>
        public SadNewsForm(FamilyMemberDTO person, bool onCreateNew)
        {
            InitializeComponent();
            _person = person;

            if (onCreateNew)
                _mode = DataFormMode.CreateNew;
            else
            {
                _deathInfo = _person.DeathInfo;
                _mode = DataFormMode.Edit;
            }
        }

        #endregion

        #region UI EVENTS

        private void SadNewsForm_Load(object sender, EventArgs e)
        {
            try
            {
                ThreadHelper.DoWork(_initPresenter);
                ThreadHelper.DoWork(_loadData);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SadNewsForm), exc);
                UIUtils.Error(exc.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case DataFormMode.CreateNew:
                    ThreadHelper.DoWork(_addDeathInfo);
                    break;

                case DataFormMode.Edit:
                    ThreadHelper.DoWork(_updateDeathInfo);
                    break;

                default:
                    return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void cbDeathReasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDeathReasons.SelectedItem != null)
                _deathReason = cbDeathReasons.SelectedItem as DeathReasonDTO;
        }

        private void cbBuryPlace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBuryPlace.SelectedItem != null)
                _buryPlace = cbBuryPlace.SelectedItem as BuryPlaceDTO;
        }

        #endregion

        #region CORE METHODS

        private void _addDeathInfo()
        {
            try
            {
                _deathInfo = new DeathInfo();
                _deathInfo.Reason = _deathReason;
                _deathInfo.BuryPlace = _buryPlace;
                _deathInfo.DeathDay = deathDayPicker.Value;

                _presenter.Add();
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(SadNewsForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SadNewsForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        private void _updateDeathInfo()
        {
            try
            {
                _deathInfo.Reason = _deathReason;
                _deathInfo.BuryPlace = _buryPlace;

                DateTime deathTime = new DateTime(
                deathDayPicker.Value.Year,
                deathDayPicker.Value.Month,
                deathDayPicker.Value.Day,
                deathTimePicker.Value.Hour,
                deathTimePicker.Value.Minute,
                deathTimePicker.Value.Second);

                _deathInfo.DeathDay = deathTime;

                _presenter.Update();
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(SadNewsForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SadNewsForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_UPDATE_ENTRY_FAILED));
            }
        }

        private void _loadData()
        {
            try
            {
                _presenter.LoadAllDeathReasons();
                _presenter.LoadAllBuryPlaces();

                if (_mode == DataFormMode.Edit
                        && _deathInfo != null)
                {
                    this.Invoke(new ThreadHelper.VoidDelegate(_loadDeathInfo));
                }

                this.lblPersonName.Text = _person.ToString();
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(SadNewsForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SadNewsForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        private void _loadDeathInfo()
        {
            if (_deathInfo == null)
                return;

            // Cannot directly set the SelectedItem for Combobox, 
            // because it doesn't contain the object of _deathInfo.Reason.
            // So, we must search in the DataSource of the Combobox: the _deathReasonsList.
            IEnumerable<DeathReasonDTO> reasons =
                from reason in _deathReasonsList
                where reason.Name == _deathInfo.Reason.Name
                select reason;
            DeathReasonDTO deathReason = reasons.Single();
            this.cbDeathReasons.SelectedItem = deathReason;

            IEnumerable<BuryPlaceDTO> places =
                from place in _buryPlacesList
                where place.Name == _deathInfo.BuryPlace.Name
                select place;
            BuryPlaceDTO deathPlace = places.Single();
            this.cbBuryPlace.SelectedItem = deathPlace;

            this.deathDayPicker.Value = _deathInfo.DeathDay;
            this.deathTimePicker.Value = _deathInfo.DeathDay;
        }

        #endregion

        #region UTILITY METHODS

        private void _initPresenter()
        {
            _presenter = new DeathInfoPresenter(this);
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

        #region IDeathInfoView Members

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

        public DateTime DeathTime
        {
            get
            {
                return deathDayPicker.Value;
            }
            set
            {
                deathDayPicker.Value = value;
            }
        }

        public IList<DeathReasonDTO> DeathReasonsList
        {
            get
            {
                return _deathReasonsList;
            }
            set
            {
                _deathReasonsList = value;
                cbDeathReasons.DataSource = _deathReasonsList;
            }
        }

        public DeathReasonDTO DeathReason
        {
            get
            {
                return _deathReason;
            }
            set
            {
                _deathReason = value;
            }
        }

        public IList<BuryPlaceDTO> BuryPlacesList
        {
            get
            {
                return _buryPlacesList;
            }
            set
            {
                _buryPlacesList = value;
                cbBuryPlace.DataSource = _buryPlacesList;
            }
        }

        public BuryPlaceDTO BuryPlace
        {
            get
            {
                return _buryPlace;
            }
            set
            {
                _buryPlace = value;
            }
        }

        public DeathInfo DeathInfo
        {
            get
            {
                return _deathInfo;
            }
            set
            {
                _deathInfo = value;
            }
        }

        #endregion

        #region IView Members

        public string ViewName
        {
            get { return this.ToString(); }
        }

        #endregion
    }
}
