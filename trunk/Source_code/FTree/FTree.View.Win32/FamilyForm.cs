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
    public partial class FamilyForm : BaseDialogForm, IFamilyView, IValidator
    {
        #region VARIABLES

        private FamilyPresenter _presenter;
        private DataFormMode _mode = DataFormMode.CreateNew;
        private bool _needAddFirstPerson = false;
        private FamilyDTO _family;
        
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

        public DataFormMode Mode
        {
            get { return _mode; }
        }

        #endregion

        #region CONSTRUCTOR

        public FamilyForm(DataFormMode mode)
        {
            InitializeComponent();
            _mode = mode;
            _family = new FamilyDTO();
            bool isEdit = _mode == DataFormMode.CreateNew;
            this.btnCreateFirstPerson.Enabled = isEdit;
            this.btnCreateFirstPerson.Visible = isEdit;
        }

        #endregion

        #region UI EVENTS

        private void FamilyForm_Load(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case DataFormMode.Edit:
                    if (this.Family != null)
                        this.txtFamilyName.Text = Family.Name;
                    this.Text = "Edit Family Name";
                    break;
                default:
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputData())
                    return;

                // Insert new Family.
                if (_presenter == null)
                    _presenter = new FamilyPresenter(this);

                switch (_mode)
                {
                    case DataFormMode.CreateNew:
                        _presenter.Add();
                        break;
                    case DataFormMode.Edit:
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

                // Insert new Family.
                if (_presenter == null)
                    _presenter = new FamilyPresenter(this);

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

        #region IFamilyView Members

        public FamilyDTO Family
        {
            get
            {
                _family.Name = this.txtFamilyName.Text.Trim();
                return _family;
            }
            set
            {
                _family = value;

                if(_family != null)
                    this.txtFamilyName.Text = _family.Name;
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
