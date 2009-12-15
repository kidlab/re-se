using System;
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

        private RelationTypeDTO _currentRelationType= null;
        private IList<RelationTypeDTO> _relationTypes = null;
        private SettingsManagerPresenter _presenter;

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

            _relationTypes = new List<RelationTypeDTO>();
            _bindingSource = new BindingSource();
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

        #endregion

        #region CORE METHODS

        private void _loadData()
        {
            TabPage selectedTab = this.mainTabControl.SelectedTab;
            int selectedIndex = this.mainTabControl.SelectedIndex;

            // This tab was already loaded data, 
            // so it doesn't need to load again.
            if (_alreadyLoaded[selectedIndex])
                return;

            if (selectedTab == tabRelation_Type)
            {
                _loadRelationTypes();
                _checkRelationTypesDataGrid();
                _alreadyLoaded[selectedIndex] = true;
            }
            else if (selectedTab == tabHomeTown)
            {
                _loadHomeTowns();
            }
            // Add all other tab pages here...
        }

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

        private void _loadHomeTowns()
        {
            try
            {

            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(SettingsForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        private void _addRelationType()
        {
            try
            {
                SimpleEntryForm frmAdd = new SimpleEntryForm();
                if (frmAdd.ShowDialog() != DialogResult.OK)
                    return;
                _currentRelationType = new RelationTypeDTO { Name = frmAdd.Data };
                ThreadHelper.DoWork(_presenter.AddRelationType);
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

        #region UTILITTY METHODS

        private void _initPresenter()
        {
            _presenter = new SettingsManagerPresenter(this);
        }
        
        private void _setRelationTypesDataBindings()
        {
            _bindingSource.DataSource = _relationTypes;
            this.dgRelationTypes.DataSource = _bindingSource;

            foreach (DataGridViewColumn col in dgRelationTypes.Columns)
            {
                if (col.Name != "Name")
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

                if(mainTabControl.SelectedTab == tabRelation_Type)
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
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public FTree.DTO.HomeTownDTO HomeTown
        {
            get { throw new NotImplementedException(); }
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
