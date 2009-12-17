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

        /// <summary>
        /// Create new instance of FamilyMemberForm with the default settings.
        /// </summary>
        public FamilyMemberForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create a new instance of FamilyMemberForm with a specific family object. 
        /// </summary>
        /// <param name="isCreatingRootPerson">Determines that the person if the root person of the family or not.</param>
        /// <param name="family">The family containing the person.</param>
        public FamilyMemberForm(bool isCreatingRootPerson, FamilyDTO family)
        {
            InitializeComponent();
            _isRootPerson = isCreatingRootPerson;
            _family = family;
        }

        /// <summary>
        /// Create a new instance of FamilyMemberForm with a specific family member object. 
        /// </summary>
        /// <param name="relativePerson">The person associate with this person.</param>
        public FamilyMemberForm(FamilyMemberDTO relativePerson)
        {
            InitializeComponent();
            _relativePerson = relativePerson;
            _family = _relativePerson.Family;
        }

        #endregion

        #region UI EVENTS

        private void FamilyMemberForm_Load(object sender, EventArgs e)
        {
            try
            {
                ThreadHelper.DoWork(_initPresenter);
                ThreadHelper.DoWork(_loadData);

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

                _generateDTO();

                // Insert new person.
                _addNewPerson();

                if (_isRootPerson)
                    _family.RootPerson = _currentMember;

                //UIUtils.Info("Person Added Successfully!");
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

        private void cbRelativePerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRelativePerson.SelectedItem != null)
                _relativePerson = cbRelativePerson.SelectedItem as FamilyMemberDTO;
        }

        private void cbRelationshipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRelationshipType.SelectedItem != null)
                _currentRelationType = cbRelationshipType.SelectedItem as RelationTypeDTO;
        }
        
        #endregion

        #region CORE METHODS

        private void _loadData()
        {
            try
            {                
                // Bind data to all controls here.
                if (!_isRootPerson)
                    _presenter.LoadRelativeMembers();

                _presenter.LoadAllParameters();

                if (_family != null)
                    lblFamilyName.Text = _family.Name;
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyMemberForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        private void _addNewPerson()
        {
            if (_isRootPerson)
                _currentMember.GenerationNumber = 1;

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

        private void _generateDTO()
        {
            if (_currentMember == null)
                _currentMember = new FamilyMemberDTO();

            _currentMember.Family = _family;
            _currentMember.FirstName = txtFirstname.Text.Trim();
            _currentMember.LastName = txtLastname.Text.Trim();
            _currentMember.IsFemale = rbFemale.Checked;

            if(!String.IsNullOrEmpty(txtAddress.Text.Trim()))
                _currentMember.Address = txtAddress.Text.Trim();

            if (cbHomeTown.SelectedItem != null)
                _currentMember.HomeTown = cbHomeTown.SelectedItem as HomeTownDTO;

            // Combines values of Birthday and Birthtime.
            DateTime birthday = new DateTime(
                birthdayPicker.Value.Year,
                birthdayPicker.Value.Month,
                birthdayPicker.Value.Day,
                birthtimePicker.Value.Hour,
                birthtimePicker.Value.Minute,
                birthtimePicker.Value.Second);

            _currentMember.Birthday = birthday;
            _currentMember.DateJointFamily = dateJointPicker.Value;

            if (cbOccupation.SelectedItem != null)
                _currentMember.Job = cbOccupation.SelectedItem as JobDTO;
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

            if (String.IsNullOrEmpty(txtLastname.Text.Trim()))
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

        public FamilyDTO Family
        {
            get
            {
                return _family;
            }
            set
            {
                _family = value;
            }
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

        public IList<HomeTownDTO> HomeTownsList
        {
            set
            {
                if (value == _homeTowns)
                    return;

                _homeTowns = value;
                cbHomeTown.DataSource = _homeTowns;
            }
        }

        public IList<JobDTO> CareersList
        {
            set
            {
                if (value == _careersList)
                    return;

                _careersList = value;
                cbOccupation.DataSource = _careersList;
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
                if (value == _familyMembers)
                    return;

                _familyMembers = value;
                cbRelativePerson.DataSource = _familyMembers;
            }
        }

        public IList<RelationTypeDTO> RelationTypesList
        {
            set
            {
                if (value == _relationTypesList)
                    return;

                _relationTypesList = value;
                cbRelationshipType.DataSource = _relationTypesList;
            }
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
