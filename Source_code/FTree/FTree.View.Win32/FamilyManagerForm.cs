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
        #region VARIABLES

        private FamilyDTO _currentFamily = null;
        private IList<FamilyDTO> _families = null;
        private FamilyManagerPresenter _presenter;
        private string _strOldData;
        private BindingSource _bindingSource;

        #endregion

        #region CONSTRUCTOR

        public FamilyManagerForm()
        {
            InitializeComponent();
            _bindingSource = new BindingSource();
        }

        public FamilyManagerForm(IList<FamilyDTO> families)
        {
            InitializeComponent();
            _families = families;
            _bindingSource = new BindingSource();
        }

        #endregion

        #region UI EVENT

        private void FamilyManagerForm_Load(object sender, EventArgs e)
        {
            ThreadHelper.DoWork(_initPresenter);

            if (_families == null || _families.Count <= 0)
                _loadAllFamilies();

            _setFamiliesDataBindings();
            _checkDataGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_presenter.AutoSubmitChanges)
                {
                    ThreadHelper.DoWork(_presenter.SaveAllChanges);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(FamilyManagerForm), exc);
                UIUtils.Warning(exc.Message);
            }
        }

        private void btnCreateFamily_Click(object sender, EventArgs e)
        {
            _showFamilyForm();
        }

        private void btnDeleteFamily_Click(object sender, EventArgs e)
        {
            _deleteFamily();
        }

        private void dgFamilies_SelectionChanged(object sender, EventArgs e)
        {
            if (_checkDataGrid())
            {                
                int familyID = (int)dgFamilies.SelectedRows[0].Cells[FTreeConst.ID_FIELD].Value;
                _currentFamily =
                    _families.SingleOrDefault(family => family.ID == familyID);
            }
        }

        private void dgFamilies_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgFamilies.Columns[e.ColumnIndex].Name != FTreeConst.NAME_FIELD)
                return;

            _strOldData = dgFamilies[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dgFamilies_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgFamilies.Columns[e.ColumnIndex].Name != FTreeConst.NAME_FIELD)
                    return;

                if (dgFamilies[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    UIUtils.Warning(Util.GetStringResource(StringResName.MSG_ENTER_DATA));
                    dgFamilies[e.ColumnIndex, e.RowIndex].Value = _strOldData;
                    return;
                }

                string strData = dgFamilies[e.ColumnIndex, e.RowIndex].Value.ToString();

                // No Change, so return.
                if (strData == _strOldData)
                    return;

                if (String.IsNullOrEmpty(strData.Trim()))
                {
                    UIUtils.Warning(Util.GetStringResource(StringResName.MSG_ENTER_DATA));
                    dgFamilies[e.ColumnIndex, e.RowIndex].Value = _strOldData;
                    return;
                }

                int count = _countFamily(strData);

                if (count > 1)
                {
                    UIUtils.Warning(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), strData));
                    dgFamilies[e.ColumnIndex, e.RowIndex].Value = _strOldData;
                    return;
                }
                else
                {
                    // Ensure that the dgRelationTypes_SelectionChanged catched the right object 
                    // (so we don't need to update its name here, because it was automatically updated by DataGridView).
                    if (_currentFamily.State == DataState.Copied)
                        _currentFamily.State = DataState.Modified;

                    if (_presenter.AutoSubmitChanges)
                        _presenter.Update();
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerForm), exc);
                UIUtils.Warning(exc.ToString());
            }
        }

        #endregion

        #region UTILITY METHODS

        private void _initPresenter()
        {
            _presenter = new FamilyManagerPresenter(this);
            _presenter.AutoSubmitChanges = true;
        }

        private void _loadAllFamilies()
        {
            try
            {
                // Run the operation in different thread to avoid freezing the GUI.
                ThreadHelper.DoWork(_presenter.LoadAllFamilies);
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
                ThreadHelper.DoWork(_presenter.Delete);

                _loadAllFamilies();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_DELETE_FAMILY_FAILED));
            }
        }

        private void _updateFamily()
        {
            try
            {
                // Run the operation in different thread to avoid freezing the GUI.
                ThreadHelper.DoWork(_presenter.Update);}
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_UPDATE_FAMILY_FAILED));
            }
        }

        private void _showFamilyForm()
        {
            FamilyForm frmFamily = new FamilyForm();

            DialogResult result = frmFamily.ShowDialog(false);
            if (result != DialogResult.OK)
                return;            

            _currentFamily = frmFamily.CurrentFamily;
            _families.Add(_currentFamily);
            _bindingSource.ResetBindings(false);

            // Selects the family has just been added.
            dgFamilies.Rows[dgFamilies.Rows.Count - 1].Selected = true;

            if (frmFamily.AcquireAddFirstPerson)
                _showAddMemberForm(true);
        }

        private void _showAddMemberForm(bool isAddingRootPerson)
        {
            FamilyMemberForm frmMember = new FamilyMemberForm(isAddingRootPerson, _currentFamily);
            frmMember.ShowDialog(false);
        }

        private void _setFamiliesDataBindings()
        {
            _bindingSource.DataSource = _families;
            this.dgFamilies.DataSource = _bindingSource;

            foreach (DataGridViewColumn col in dgFamilies.Columns)
            {
                if (col.Name != FTreeConst.NAME_FIELD)
                    col.Visible = false;
            }
        }

        private bool _checkDataGrid()
        {
            bool enabled = true;
            if(dgFamilies.DataSource == null 
                    || dgFamilies.Columns.Count <= 0
                    || dgFamilies.Rows.Count <= 0
                    || dgFamilies.SelectedRows.Count <= 0)
                enabled = false;
         
            this.btnDeleteFamily.Enabled = enabled;
            
            return enabled;
        }

        private int _countFamily(string name)
        {
            // Check in the list.
            var matches =
                from entity in _families
                where entity.Name.ToUpper() == name.Trim().ToUpper()
                select entity;
            int count = matches.Count();
            if (count > 0)
            {
                return count;
            }

            // Check in DB.
            return _presenter.CountFamilyWithName(name);
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
                if (value == _families)
                    return;

                _families = value;
                dgFamilies.DataSource = _families;
                _setFamiliesDataBindings();                
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

    }
}
