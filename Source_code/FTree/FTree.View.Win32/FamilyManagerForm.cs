using System;
using System.Collections;
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
    public partial class FamilyManagerForm : BaseDialogForm, IFamilyMangerView
    {
        private FamilyDTO _currentFamily = null;
        private IList<FamilyDTO> _families = null;
        private FamilyManagerPresenter _presenter;

        public FamilyManagerForm()
        {
            InitializeComponent();
            _presenter = new FamilyManagerPresenter(this);
        }

        #region UI EVENT

        private void FamilyManagerForm_Load(object sender, EventArgs e)
        {
            _loadAllFamilies();
            _checkDataGrid();
        }

        private void btnCreateFamily_Click(object sender, EventArgs e)
        {
            _showFamilyForm(DataFormMode.CreateNew);
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            _showFamilyForm(DataFormMode.Edit);
        }

        private void btnLoadFamily_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteFamily_Click(object sender, EventArgs e)
        {
            _deleteFamily();
        }

        #endregion

        #region UTILITY METHODS

        private void _loadAllFamilies()
        {
            try
            {
                // Run the operation in different thread to avoid freezing the GUI.
                ThreadHelper.VoidDelegate del = _presenter.LoadAllFamilies;
                ThreadHelper.DoWork(del);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_FAMILIES_FAILED));
            }
        }

        private void _deleteFamily()
        {
            try
            {
                // Ask for confirm.
                DialogResult result = UIUtils.ConfirmOKCancel(String.Format(Util.GetStringResource(StringResName.MSG_CONFIRM_DEL_FAMILY), _currentFamily.Name));
                
                if (result != DialogResult.OK)
                    return;

                // Run the operation in different thread to avoid freezing the GUI.
                ThreadHelper.VoidDelegate del = _presenter.Delete;
                ThreadHelper.DoWork(del);

                _loadAllFamilies();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_DELETE_FAMILY_FAILED));
            }
        }

        private void _showFamilyForm(DataFormMode mode)
        {
            FamilyForm frmFamily = new FamilyForm(mode);

            if (mode == DataFormMode.Edit)
                frmFamily.Family = _currentFamily;

            DialogResult result = frmFamily.ShowDialog(false);
            if (result == DialogResult.OK)
                _loadAllFamilies();

            if (mode == DataFormMode.CreateNew
                    && frmFamily.AcquireAddFirstPerson)
            {
                _currentFamily = frmFamily.Family;
                _showAddMemberForm(true);
            }
        }

        private void _showAddMemberForm(bool isAddingRootPerson)
        {
            FamilyMemberForm frmMember = new FamilyMemberForm(isAddingRootPerson);
            frmMember.Family = _currentFamily;
            frmMember.ShowDialog(false);
        }

        private bool _checkDataGrid()
        {
            bool enabled = true;
            if(dgFamilies.DataSource == null 
                    || dgFamilies.Columns.Count <= 0
                    || dgFamilies.Rows.Count <= 0
                    || dgFamilies.SelectedRows.Count <= 0)
                enabled = false;
         
            this.btnChangeName.Enabled = enabled;
            this.btnDeleteFamily.Enabled = enabled;
            this.btnLoadFamily.Enabled = enabled;

            return enabled;
        }

        #endregion
        
        #region IFamilyMangerView Members

        public IList<FamilyDTO> Families
        {
            get
            {
                return _families;
            }
            set
            {
                _families = value;
                this.dgFamilies.DataSource = _families;
                
                foreach (DataGridViewColumn col in dgFamilies.Columns)
                {
                    if (col.Name != "Name")
                        col.Visible = false;
                }
            }
        }

        public FamilyDTO CurrentFamily
        {
            get
            {
                return _currentFamily;
            }
        }

        #endregion

        #region IView Members

        public string ViewName
        {
            get { return this.Text; }
        }

        #endregion

        private void dgFamilies_SelectionChanged(object sender, EventArgs e)
        {
            if (_checkDataGrid())
            {

                int familyID = (int)dgFamilies.SelectedRows[0].Cells["ID"].Value;
                _currentFamily =
                    _families.SingleOrDefault(family => family.ID == familyID);
            }
        }
    }
}
