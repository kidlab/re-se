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
    public partial class FamilyForm : BaseDialogForm, IFamilyMangerView, IValidator
    {
        #region VARIABLES

        private FamilyManagerPresenter _presenter;
        private bool _needAddFirstPerson = false;
        private FamilyDTO _family;
        private DataFormMode _mode;

        /// <summary>
        /// Specify that the user want to create the first generation for the new family.
        /// </summary>
        public bool AcquireAddFirstPerson
        {
            get
            {
                return _needAddFirstPerson;
            }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Create an instance of FamilyForm.
        /// </summary>
        public FamilyForm()
        {
            InitializeComponent();
            _mode = DataFormMode.CreateNew;
        }

        /// <summary>
        /// Create an instance of FamilyForm with a specific FamilyDTO.
        /// It means that the form is in edit-mode 
        /// (show to allow modify the FamilyDTO object).
        /// </summary>
        /// <param name="family">An instance of FamilyDTO.</param>
        public FamilyForm(FamilyDTO family)
        {
            InitializeComponent();
            _family = family;
            _mode = DataFormMode.Edit;
        }

        #endregion

        #region UI EVENTS

        private void FamilyForm_Load(object sender, EventArgs e)
        {
            if (_family != null)
            {
                this.btnCreateFirstPerson.Enabled = false;
                this.btnCreateFirstPerson.Visible = false;

                txtFamilyName.Text = _family.Name;
            }

            ThreadHelper.DoWork(_initPresenter);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputData())
                    return;
                switch (_mode)
                {
                    case DataFormMode.CreateNew:
                        _initFamilyDTO();
                        _presenter.Add();
                        break;
                    case DataFormMode.Edit:
                        _family.Name = this.txtFamilyName.Text.Trim();
                        _presenter.Update();
                        break;
                    default:
                        return;
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (FTreePresenterException exc)
            {
                UIUtils.Warning(exc.Message);
            }
        }

        private void btnCreateFirstPerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputData())
                    return;
                _initFamilyDTO();
                _presenter.Add();
                this._needAddFirstPerson = true;

                this.DialogResult = DialogResult.OK;
            }
            catch (FTreePresenterException exc)
            {
                UIUtils.Warning(exc.Message);
            }
        }

        #endregion

        #region CORE METHODS

        private void _initPresenter()
        {
            _presenter = new FamilyManagerPresenter(this);
            _presenter.AutoSubmitChanges = true;
        }

        private void _initFamilyDTO()
        {
            _family = new FamilyDTO { Name = txtFamilyName.Text.Trim() };
        }

        #endregion

        #region IValidator Members

        public bool ValidateInputData()
        {
            if (String.IsNullOrEmpty(this.txtFamilyName.Text.Trim()))
            {
                UIUtils.Warning(Util.GetStringResource(StringResName.MSG_ENTER_FAMILY_NAME));
                return false;
            }
            return true;
        }

        #endregion

        #region IView Members

        public string ViewName
        {
            get { return this.ToString(); }
        }

        #endregion

        #region IFamilyMangerView Members

        /// <summary>
        /// (Not supported) Gets or sets a list of famiies.
        /// If ypu try to access this property, a NotSupportedException will be thrown.
        /// </summary>
        public IList<FamilyDTO> Families
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public FamilyDTO CurrentFamily
        {
            get { return _family; }
        }

        #endregion
    }
}