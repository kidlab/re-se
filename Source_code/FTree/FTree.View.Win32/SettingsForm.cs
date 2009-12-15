using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTree.Common;
using FTree.Presenter;
using FTree.DTO;

namespace FTree.View.Win32
{
    public partial class SettingsForm : BaseDialogForm, ISettingsManagerView
    {
        #region VARIABLES

        private SettingsManagerPresenter _presenter;

        private RelationTypeDTO _currentRelationType = null;
        private IList<RelationTypeDTO> _relationTypes = null;

        private HomeTownDTO _currentHomeTown = null;
        private IList<HomeTownDTO> _homeTowns = null;

        /// <summary>
        /// To store previous value of a cell in DataGridView when the editing begins.
        /// </summary>
        private string _strOldData;

        private BindingSource _bindingSource;

        /// <summary>
        /// whenever a tab page finished loading data, 
        /// the assciate element in this array will be set to true.
        /// To ensure that the data is loaded only one time for each tab page.
        /// </summary>
        private bool[] _alreadyLoaded;

        #endregion

        #region CONSTRUCTOR

        public SettingsForm()
        {
            InitializeComponent();
            _alreadyLoaded = new bool[mainTabControl.TabPages.Count];
            _bindingSource = new BindingSource();

            _relationTypes = new List<RelationTypeDTO>();
            _homeTowns = new List<HomeTownDTO>();
        }

        #endregion

        #region UI EVENTS

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ThreadHelper.DoWork(_initPresenter);

            // Force the first tab be selected.
            this.mainTabControl.SelectedTab = this.mainTabControl.TabPages[0];
            _loadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                ThreadHelper.DoWork(_presenter.SaveAllChanges);
                this.DialogResult = DialogResult.OK;
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Warning(exc.Message);
            }
        }
        
        /// <summary>
        /// Only a tabpage is selected the associate data will be loaded.
        /// This method of loading data called "lazy-loading".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            _loadData();
        }

        #region TAB RELATION TYPE

        private void btnDeleteRelationType_Click(object sender, EventArgs e)
        {
            _deleteRelationType();
        }

        private void btnAddRelationType_Click(object sender, EventArgs e)
        {
            _addRelationType();
        }

        private void dgRelationTypes_SelectionChanged(object sender, EventArgs e)
        {
            if (_checkRelationTypesDataGrid())
            {

                string name = (string)dgRelationTypes.SelectedRows[0].Cells[FTreeConst.NAME_FIELD].Value;
                _currentRelationType =
                    _relationTypes.SingleOrDefault(type => type.Name == name);
            }
        }

        private void dgRelationTypes_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgRelationTypes.Columns[e.ColumnIndex].Name != FTreeConst.NAME_FIELD)
                return;

            _strOldData = dgRelationTypes[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dgRelationTypes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgRelationTypes.Columns[e.ColumnIndex].Name != FTreeConst.NAME_FIELD)
                    return;

                if (dgRelationTypes[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    UIUtils.Warning(Util.GetStringResource(StringResName.MSG_ENTER_DATA));
                    dgRelationTypes[e.ColumnIndex, e.RowIndex].Value = _strOldData;
                    return;
                }

                string strData = dgRelationTypes[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();

                if (String.IsNullOrEmpty(strData))
                {
                    UIUtils.Warning(Util.GetStringResource(StringResName.MSG_ENTER_DATA));
                    dgRelationTypes[e.ColumnIndex, e.RowIndex].Value = _strOldData;
                    return;
                }

                for (int currentRow = 0; currentRow < dgRelationTypes.Rows.Count; currentRow++)
                {
                    if (dgRelationTypes[e.ColumnIndex, currentRow].Value.ToString().Trim() == strData)
                    {
                        if (currentRow == e.RowIndex)
                        {
                            // Ensure that the dgRelationTypes_SelectionChanged catched the right object 
                            // (so we don't need to update its name here, because it was automatically updated by DataGridView).
                            if (_currentRelationType.State == DataState.Copied)
                                _currentRelationType.State = DataState.Modified;
                            return;
                        }
                        else
                            break;
                    }
                }

                if (_countRelationType(strData) > 1)
                {
                    UIUtils.Warning(String.Format(Util.GetStringResource(StringResName.ERR_RELATION_TYPE_ALREADY_EXIST), strData));
                    return;
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Warning(exc.ToString());
            }
        }

        #endregion

        #region TAB HOMETOWN

        private void btnAddHomeTown_Click(object sender, EventArgs e)
        {
            _addHomeTown();
        }

        private void btnDeleteHomeTown_Click(object sender, EventArgs e)
        {
            _deleteHomeTown();
        }

        private void dgHomeTowns_SelectionChanged(object sender, EventArgs e)
        {
            if (_checkHomeTownsDataGrid())
            {

                string name = (string)dgHomeTowns.SelectedRows[0].Cells[FTreeConst.NAME_FIELD].Value;
                _currentHomeTown =
                    _homeTowns.SingleOrDefault(entity => entity.Name == name);
            }
        }

        private void dgHomeTowns_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgHomeTowns.Columns[e.ColumnIndex].Name != FTreeConst.NAME_FIELD)
                return;

            _strOldData = dgHomeTowns[e.ColumnIndex, e.RowIndex].Value.ToString();
        }

        private void dgHomeTowns_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgHomeTowns.Columns[e.ColumnIndex].Name != FTreeConst.NAME_FIELD)
                    return;

                if (dgHomeTowns[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    UIUtils.Warning(Util.GetStringResource(StringResName.MSG_ENTER_DATA));
                    dgHomeTowns[e.ColumnIndex, e.RowIndex].Value = _strOldData;
                    return;
                }

                string strData = dgHomeTowns[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();

                if (String.IsNullOrEmpty(strData))
                {
                    UIUtils.Warning(Util.GetStringResource(StringResName.MSG_ENTER_DATA));
                    dgHomeTowns[e.ColumnIndex, e.RowIndex].Value = _strOldData;
                    return;
                }

                for (int currentRow = 0; currentRow < dgHomeTowns.Rows.Count; currentRow++)
                {
                    if (dgHomeTowns[e.ColumnIndex, currentRow].Value.ToString().Trim() == strData)
                    {
                        if (currentRow == e.RowIndex)
                        {
                            // Ensure that the dgRelationTypes_SelectionChanged catched the right object 
                            // (so we don't need to update its name here, because it was automatically updated by DataGridView).
                            if (_currentHomeTown.State == DataState.Copied)
                                _currentHomeTown.State = DataState.Modified;
                            return;
                        }
                        else
                            break;
                    }
                }

                if (_countHomeTown(strData) > 1)
                {
                    UIUtils.Warning(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), strData));
                    return;
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Warning(exc.ToString());
            }
        }

        #endregion

        #endregion

        #region CORE METHODS

        private void _loadData()
        {
            TabPage selectedTab = this.mainTabControl.SelectedTab;
            int selectedIndex = this.mainTabControl.SelectedIndex;                   

            if (selectedTab == tabRelation_Type)
            {
                // This tab was already loaded data, 
                // so it doesn't need to load again.
                if (!_alreadyLoaded[selectedIndex])
                {
                    _loadRelationTypes();
                    _alreadyLoaded[selectedIndex] = true;
                }
                _setRelationTypesDataBindings();
                _checkRelationTypesDataGrid();
                
            }
            else if (selectedTab == tabHomeTown)
            {
                if (!_alreadyLoaded[selectedIndex])
                {
                    _loadHomeTowns();
                    _alreadyLoaded[selectedIndex] = true;
                }

                _setHomeTownDataBindings();
                _checkHomeTownsDataGrid();
            }
            // Add all other tab pages here...
        }

        #region RELATION TYPE

        private void _loadRelationTypes()
        {
            try
            {
                // Run the operation in different thread to avoid freezing the GUI.
                ThreadHelper.DoWork(_presenter.LoadAllRelationTypes);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FamilyManagerForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        private void _addRelationType()
        {
            try
            {
                SimpleEntryForm frmAdd = new SimpleEntryForm(_countRelationType);
                if (frmAdd.ShowDialog(false) != DialogResult.OK)
                    return;
                _currentRelationType = new RelationTypeDTO { Name = frmAdd.Data };
                //ThreadHelper.DoWork(_presenter.AddRelationType);
                _relationTypes.Add(_currentRelationType);
                _bindingSource.ResetBindings(false);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_INSERT_RELATION_TYPE_FAILED));
            }
        }

        private void _deleteRelationType()
        {
            try
            {
                // Ask for confirm.
                DialogResult result = UIUtils.ConfirmOKCancel(Util.GetStringResource(StringResName.MSG_CONFIRM_DEL_ENTRY));

                if (result != DialogResult.OK)
                    return;

                // Run the operation in different thread to avoid freezing the GUI.
                ThreadHelper.DoWork(_presenter.DeleteRelationType);
                _relationTypes.Remove(_currentRelationType);
                _bindingSource.ResetBindings(false);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_DELETE_RELATION_TYPE_FAILED));
            }
        }

        #endregion

        #region HOMETOWN

        private void _loadHomeTowns()
        {
            try
            {
                // Run the operation in different thread to avoid freezing the GUI.
                ThreadHelper.DoWork(_presenter.LoadAllHomeTowns);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        private void _addHomeTown()
        {
            try
            {
                SimpleEntryForm frmAdd = new SimpleEntryForm(_countHomeTown);
                if (frmAdd.ShowDialog(false) != DialogResult.OK)
                    return;
                _currentHomeTown = new HomeTownDTO { Name = frmAdd.Data };
                //ThreadHelper.DoWork(_presenter.AddRelationType);
                _homeTowns.Add(_currentHomeTown);
                _bindingSource.ResetBindings(false);
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_INSERT_NEW_ENTRY_FAILED));
            }
        }

        private void _deleteHomeTown()
        {
            try
            {
                // Ask for confirm.
                DialogResult result = UIUtils.ConfirmOKCancel(Util.GetStringResource(StringResName.MSG_CONFIRM_DEL_ENTRY));

                if (result != DialogResult.OK)
                    return;

                // Run the operation in different thread to avoid freezing the GUI.
                ThreadHelper.DoWork(_presenter.DeleteHomeTown);
                _homeTowns.Remove(_currentHomeTown);
                _bindingSource.ResetBindings(false);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
        }

        #endregion

        #endregion

        #region UTILITTY METHODS

        private void _initPresenter()
        {
            _presenter = new SettingsManagerPresenter(this);
        }

        #region RELATION TYPE

        private void _setRelationTypesDataBindings()
        {
            _bindingSource.DataSource = _relationTypes;
            this.dgRelationTypes.DataSource = _bindingSource;

            foreach (DataGridViewColumn col in dgRelationTypes.Columns)
            {
                if (col.Name != FTreeConst.NAME_FIELD)
                    col.Visible = false;
            }
        }

        private bool _checkRelationTypesDataGrid()
        {
            bool enabled = true;
            if (dgRelationTypes.DataSource == null
                    || dgRelationTypes.Columns.Count <= 0
                    || dgRelationTypes.Rows.Count <= 0
                    || dgRelationTypes.SelectedRows.Count <= 0)
                enabled = false;

            this.btnDeleteRelationType.Enabled = enabled;

            return enabled;
        }

        private int _countRelationType(string name)
        {
            // Check in the list.
            var matches =
                from type in _relationTypes
                where type.Name.ToUpper() == name.Trim().ToUpper()
                select type;
            int count = matches.Count();
            if (count > 0)
            {
                return count;
            }

            // Check in DB.
            return _presenter.CountRelationTypeWithName(name);
        }

        #endregion

        #region HOMETOWN

        private void _setHomeTownDataBindings()
        {
            _bindingSource.DataSource = _homeTowns;
            this.dgHomeTowns.DataSource = _bindingSource;

            foreach (DataGridViewColumn col in dgHomeTowns.Columns)
            {
                if (col.Name != FTreeConst.NAME_FIELD)
                    col.Visible = false;
            }
        }

        private bool _checkHomeTownsDataGrid()
        {
            bool enabled = true;
            if (dgHomeTowns.DataSource == null
                    || dgHomeTowns.Columns.Count <= 0
                    || dgHomeTowns.Rows.Count <= 0
                    || dgHomeTowns.SelectedRows.Count <= 0)
                enabled = false;

            this.btnDeleteHomeTown.Enabled = enabled;

            return enabled;
        }

        private int _countHomeTown(string name)
        {
            // Check in the list.
            var matches =
                from entity in _homeTowns
                where entity.Name.ToUpper() == name.Trim().ToUpper()
                select entity;
            int count = matches.Count();
            if (count > 0)
            {
                return count;
            }

            // Check in DB.
            return _presenter.CountHomeTownWithName(name);
        }

        #endregion

        #endregion

        #region ISettingsManagerView Members

        public IList<FTree.DTO.RelationTypeDTO> RelationTypes
        {
            get
            {
                return _relationTypes;
            }
            set
            {
                if (value == _relationTypes)
                    return;

                _relationTypes = value;

                if (mainTabControl.SelectedTab == tabRelation_Type)
                    _setRelationTypesDataBindings();
            }
        }

        public FTree.DTO.RelationTypeDTO RelationType
        {
            get { return _currentRelationType; }
        }

        public IList<FTree.DTO.HomeTownDTO> HomeTowns
        {
            get
            {
                return _homeTowns;
            }
            set
            {
                if (value == _homeTowns)
                    return;

                _homeTowns = value;
                if (mainTabControl.SelectedTab == tabHomeTown)
                    _setHomeTownDataBindings();
            }
        }

        public FTree.DTO.HomeTownDTO HomeTown
        {
            get { return _currentHomeTown; }
        }

        public IList<FTree.DTO.JobDTO> Jobs
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

        public FTree.DTO.JobDTO Job
        {
            get { throw new NotImplementedException(); }
        }

        public IList<FTree.DTO.AchievementType> AchievementTypes
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

        public FTree.DTO.AchievementType AchievementType
        {
            get { throw new NotImplementedException(); }
        }

        public IList<FTree.DTO.DeathReasonDTO> DeathReasons
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

        public FTree.DTO.DeathReasonDTO DeathReason
        {
            get { throw new NotImplementedException(); }
        }

        public IList<FTree.DTO.BuryPlaceDTO> BuryPlaces
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

        public FTree.DTO.BuryPlaceDTO BuryPlace
        {
            get { throw new NotImplementedException(); }
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