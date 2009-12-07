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
        private HomeTownDTO _homeTown = new HomeTownDTO();
        private JobDTO _career = new JobDTO();
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
            _isRootPerson = true;
        }

        #endregion

        #region UI EVENTS

        private void FamilyMemberForm_Load(object sender, EventArgs e)
        {
            if (_family != null)
                lblFamilyName.Text = _family.Name;
            if (_isRootPerson)
            {
                this.lblRootPersonWarning.Visible = true;
                this.gbxRelationship.Enabled = false;
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

        #endregion

        #region CORE METHODS

        private void _addNewPerson()
        {
            if (_presenter == null)
                _presenter = new FamilyMemberPresenter(this);
            _presenter.Add();
        }

        #endregion

        #region UTILITY METHODS

        private void _setErrorToolTip(Control control, string message)
        {
            this.errorToolTip.SetToolTip(control, message);
            this.errorToolTip.Show(message, control, 3000);
        }

        #endregion        

        #region IFamilyMemberView Members

        public string FirstName
        {
            get
            {
                return this.txtFirstname.Text;
            }
            set
            {
                this.txtFirstname.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.txtLastname.Text;
            }
            set
            {
                this.txtLastname.Text = value;
            }
        }

        public bool IsFemale
        {
            get
            {
                return this.rbFemale.Checked;
            }
            set
            {
                this.rbFemale.Checked = value;
            }
        }

        public IList<HomeTownDTO> HomeTownsList
        {
            set
            {
                this.cbHomeTown.DataSource = value;
            }
        }

        public HomeTownDTO HomeTown
        {
            get
            {
                return _homeTown;
            }
            set
            {
                _homeTown = value;
            }
        }

        public IList<JobDTO> CareersList
        {
            set
            {
                this.cbOccupation.DataSource = value;
            }
        }

        public JobDTO Career
        {
            get
            {
                return _career;
            }
            set
            {
                _career = value;
            }
        }

        public string Address
        {
            get
            {
                return this.txtAddress.Text;
            }
            set
            {
                this.txtAddress.Text = value;
            }
        }

        public DateTime DateJoinFamily
        {
            get
            {
                return this.dateJointPicker.Value;
            }
            set
            {
                this.dateJointPicker.Value = value;
            }
        }

        public DateTime BirthDay
        {
            get
            {
                // Combines values of Birthday and Birthtime.
                DateTime birthday = new DateTime(
                    birthdayPicker.Value.Year,
                    birthdayPicker.Value.Month,
                    birthdayPicker.Value.Day,
                    birthtimePicker.Value.Hour,
                    birthtimePicker.Value.Minute,
                    birthtimePicker.Value.Second);
                return birthday;
            }
            set
            {
                this.birthdayPicker.Value = value;
                this.birthtimePicker.Value = value;
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
                this.cbRelativePerson.DataSource = value;
            }
        }

        public IList<RelationTypeDTO> RelationTypesList
        {
            set
            {
                this.cbRelativePerson.DataSource = value;
            }
        }

        public RelationTypeDTO RelationType
        {
            get
            {
                return this.cbRelativePerson.SelectedItem as RelationTypeDTO;
            }
            set
            {
                this.cbRelativePerson.SelectedItem = value;
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

    }
}
