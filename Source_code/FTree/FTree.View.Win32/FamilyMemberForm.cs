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
        private CareerDTO _career = new CareerDTO();

        #endregion

        #region CONSTRUCTOR

        public FamilyMemberForm()
        {
            InitializeComponent();
            _presenter = new FamilyMemberPresenter(this);
        }

        #endregion

        #region UTILITY METHODS

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
                throw new NotImplementedException();
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

        public IList<CareerDTO> CareersList
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public CareerDTO Career
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
                return this.birthdayPicker.Value;
            }
            set
            {
                this.birthdayPicker.Value = value;
            }
        }

        public FamilyMemberDTO RelativePerson
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<RelationTypeDTO> RelationTypesList
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public RelationTypeDTO RelationType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
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

        #region UI EVENTS

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateInputData())
                    return;

                _presenter.Add();

                UIUtils.Info("Person Added Successfully!");

               
                this.DialogResult = DialogResult.OK;
            }
            catch (FTreePresenterException exc)
            {
                UIUtils.Error(exc.ToString());
            }
        }

        #endregion


        #region IValidator Members

        public bool ValidateInputData()
        {
            // Test only :)
            return true;
        }

        #endregion
    }
}
