using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTree.Presenter;
using FTree.DTO;
using FTree.Common;

namespace FTree.View.Win32
{
    public partial class FamilyMemberForm : BaseDialogForm, IFamilyMemberView, IValidator
    {
        #region VARIABLES

        private FamilyMemberPresenter _presenter;

        private IList<HomeTownDTO> _homeTowns;
        private IList<JobDTO> _careersList;
        private FamilyMemberDTO _currentMember;
        private IList<FamilyMemberDTO> _familyMembers;
        private IList<RelationTypeDTO> _relationTypesList;
        private RelationTypeDTO _currentRelationType;
        private FamilyMemberDTO _relativePerson;
        private bool _isRootPerson = false;
        private FamilyDTO _family;

        #endregion

        #region CONSTRUCTOR

        public FamilyMemberForm()
        {
            InitializeComponent();
        }

        public FamilyMemberForm(bool isCreatingRootPerson)
        {
            InitializeComponent();
            _isRootPerson = isCreatingRootPerson;
        }

        #endregion

        #region UI EVENTS

        private void FamilyMemberForm_Load(object sender, EventArgs e)
        {
            try
            {
                ThreadHelper.DoWork(_initPresenter);

                if (_family != null)
                    lblFamilyName.Text = _family.Name;
                if (_isRootPerson)
                {
                    this.lblRootPersonWarning.Visible = true;
                    this.gbxRelationship.Enabled = false;
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(exc.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateInputData())
                    return;

                // Insert new person.
                _addNewPerson();

                if (_isRootPerson)
                    _family.RootPerson = _currentMember;

                UIUtils.Info("Person Added Successfully!");
                this.DialogResult = DialogResult.OK;
            }
            catch (FTreePresenterException exc)
            {
                UIUtils.Error(exc.Message);            
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_INSERT_PERSON_FAILED));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region CORE METHODS

        private void _addNewPerson()
        {            
            _presenter.Add();
        }

        #endregion

        #region UTILITY METHODS

        private void _setErrorToolTip(Control control, string message)
        {
            this.errorToolTip.SetToolTip(control, message);
            this.errorToolTip.Show(message, control, 3000);
        }

        private void _initPresenter()
        {
            _presenter = new FamilyMemberPresenter(this);
        }

        private void _bindData()
        {
            if (_currentMember == null)
                return;
        }

        #endregion        

        #region IView Members

        public string ViewName
        {
            get
            {
                return this.ToString();
            }
        }

        #endregion

        #region IValidator Members

        public bool ValidateInputData()
        {
            if (!_isRootPerson)
            {
                if (this.cbRelativePerson.SelectedIndex < 0
                    && (this.cbRelationshipType.SelectedIndex < 0
                            || this.cbRelationshipType.SelectedIndex >= 0))
                {
                    _setErrorToolTip(cbRelativePerson, Util.GetStringResource(StringResName.MSG_FINISH_RELATIONSHIP));
                    return false;
                }

                if (this.cbRelationshipType.SelectedIndex < 0
                    && (this.cbRelativePerson.SelectedIndex < 0
                            || this.cbRelativePerson.SelectedIndex >= 0))
                {
                    _setErrorToolTip(cbRelativePerson, Util.GetStringResource(StringResName.MSG_FINISH_RELATIONSHIP));
                    return false;
                }
            }

            if (!rbFemale.Checked && !rbMale.Checked)
            {
                _setErrorToolTip(rbMale, Util.GetStringResource(StringResName.MSG_SELECT_GENDER));
                return false;
            }

            if (String.IsNullOrEmpty(txtFirstname.Text.Trim()))
            {
                _setErrorToolTip(txtFirstname, Util.GetStringResource(StringResName.MSG_ENTER_FIRSTNAME));
                return false;
            }

            if ( String.IsNullOrEmpty(txtLastname.Text.Trim()))
            {
                _setErrorToolTip(txtLastname, Util.GetStringResource(StringResName.MSG_ENTER_LASTNAME));
                return false;
            }

            if (birthdayPicker.Value.Date.CompareTo(DateTime.Now.Date) > 0)
            {
                _setErrorToolTip(birthdayPicker, Util.GetStringResource(StringResName.ERR_INVALID_BIRTHDAY));
                return false;
            }

            if ((dateJointPicker.Value.Date.CompareTo(DateTime.Now.Date) > 0)
                    || (dateJointPicker.Value.Date.CompareTo(birthdayPicker.Value.Date) < 0))
            {
                _setErrorToolTip(birthdayPicker, Util.GetStringResource(StringResName.ERR_INVALID_DATE));
                return false;
            }

            return true;
        }

        #endregion

        #region IFamilyMemberView Members

        public FamilyMemberDTO FamilyMember
        {
            get
            {
                return _currentMember;
            }
            set
            {
                _currentMember = value;
            }
        }

        public IList<HomeTownDTO> HomeTownsList
        {
            set { _homeTowns = value; }
        }

        public IList<JobDTO> CareersList
        {
            set { _careersList = value; }
        }

        public FamilyMemberDTO RelativePerson
        {
            get
            {
                return _relativePerson;
            }
            set
            {
                _relativePerson = value;
            }
        }

        public IList<FamilyMemberDTO> FamilyMembers
        {
            get
            {
                return _familyMembers;
            }
            set
            {
                _familyMembers = value;
            }
        }

        public IList<RelationTypeDTO> RelationTypesList
        {
            set { _relationTypesList = value; }
        }

        public RelationTypeDTO RelationType
        {
            get
            {
                return _currentRelationType;
            }
            set
            {
                _currentRelationType = value;
            }
        }

        #endregion

    }
}
