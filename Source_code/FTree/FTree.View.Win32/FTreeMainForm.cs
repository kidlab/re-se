using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using FTree.Common;
using FTree.Presenter;
using FTree.Presenter.ViewModel;
using FTree.DTO;

namespace FTree.View.Win32
{
    public partial class FTreeMainForm : Form, IFamilyMangerView
    {
        #region VARIABLES

        private FamilyManagerPresenter _presenter;

        // Current selected Family on the treeview.
        private FamilyDTO _currentFamily;

        // Current selected FamilyMember on the treeview.
        private FamilyMemberDTO _currentPerson;

        // Current relative person of the  selected FamilyMember on the treeview.
        private FamilyMemberDTO _currentRelativePerson;

        private IList<FamilyDTO> _families;
        private ObservableCollection<FamilyViewModel> _familyViewModels;

        private System.Windows.Controls.TreeViewItem _currentRightClickedItem;

        #endregion

        #region CONSTRUCTOR

        public FTreeMainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            _families = new List<FamilyDTO>();

            this.familyTreeView.InternalTreeView.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(InternalTreeView_SelectedItemChanged);

            this.familyTreeView.ItemMouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(familyTreeView_ItemMouseRightButtonUp);

            this.visualFamilyTreeView.ItemMouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(visualFamilyTreeView_ItemMouseRightButtonUp);

            this.visualFamilyTreeView.ItemMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(visualFamilyTreeView_ItemMouseLeftButtonUp);

            this.visualFamilyTreeView.InternalVisualTreeView.MouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(InternalVisualTreeView_MouseRightButtonUp);
        }

        #endregion

        #region UI EVENTS

        private void FTreeMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ThreadHelper.DoWork(_loadData);

                _generateViewModels();
                _enablePersonControls();
            }
            catch (FTreePresenterException exc)
            {
                Tracer.Log(typeof(FTreeMainForm), exc);
                UIUtils.Error(exc.Message);
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FTreeMainForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_LOAD_DATA_FAILED));
            }
        }

        #region DUMMY DATA FOR TESTING

        Random _dummyRand = new Random();
        private void _generateDummyData()
        {
            for (int i = 0; i < 2; i++)
            {
                FamilyDTO f = new FamilyDTO();
                f.Name = "Family " + i.ToString();
                f.RootPerson = _dummyPerson();
                _familyViewModels.Add(new FamilyViewModel(f));
            }
            
            this.familyTreeView.SetDataBinding(_familyViewModels);
        }

        private FamilyMemberDTO _dummyPerson()
        {
            FamilyMemberDTO p = new FamilyMemberDTO();
            p.FirstName = _dummyFirstName();
            p.LastName = _dummyLastName();
            
            FamilyMemberDTO p1 = new FamilyMemberDTO();
            p1.FirstName = _dummyFirstName();
            p1.LastName = _dummyLastName();

            p.Descendants.Add(p1);
            return p;
        }

        private string _dummyLastName()
        {
            string[] lastnames = new string[] {"Tran", "Nguyen", "Vuong" };
            int i = _dummyRand.Next() % lastnames.Length;
            return lastnames[i];
        }        
            
        private string _dummyFirstName()
        {
            string[] firstnames = new string[] { "Teo", "Ti", "To" };
            int i = _dummyRand.Next() % firstnames.Length;
            return firstnames[i];
        }

        #endregion

        private void InternalTreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
                return;

            if (e.NewValue is FamilyViewModel)
            {
                FamilyViewModel tmpFamily = e.NewValue as FamilyViewModel;
                tmpFamily.IsExpanded = true;
         
                this.visualFamilyTreeView.SetDataBinding(tmpFamily);
                //tmpFamily.IsExpanded = false;

                _currentFamily = tmpFamily.Family;
                _currentPerson = null;
                _currentRelativePerson = null;
            }
            else if (e.NewValue is PersonViewModel)
            {
                PersonViewModel tmpPerson = e.NewValue as PersonViewModel;
                tmpPerson.IsExpanded = true;
                _currentPerson = tmpPerson.Person;
                tmpPerson.IsSelected = true;
                if (tmpPerson.Parent is PersonViewModel)
                {
                    PersonViewModel relativeVM = tmpPerson.Parent as PersonViewModel;
                    _currentRelativePerson = relativeVM.Person;

                    FamilyViewModel familyVM = _getFamilyFrom(relativeVM);

                    if (familyVM != visualFamilyTreeView.Family)
                        this.visualFamilyTreeView.SetDataBinding(familyVM);                   
                }
                else if (tmpPerson.Parent is FamilyViewModel)   // This is the root person of the family.
                {
                    FamilyViewModel tmpFamily = tmpPerson.Parent as FamilyViewModel;
                    _currentFamily = tmpFamily.Family;

                    if (tmpFamily != visualFamilyTreeView.Family)
                        this.visualFamilyTreeView.SetDataBinding(tmpFamily);

                    if (_currentFamily.RootPerson != null
                            && !_isLoadedData(_currentFamily.RootPerson.Tag))
                    {
                        // Load the full tree structure.
                        ThreadHelper.DoWork(_presenter.LoadFamilyTree);

                        // Set a flag to specifiy that the node was already loaded data,
                        // so it isn't necessary to load data next time.
                        _currentFamily.RootPerson.Tag = true;

                        _updateViewModels(_currentFamily);
                    }

                    _currentRelativePerson = null;
                }

                this.visualFamilyTreeView.SelectPerson(tmpPerson);
            }

            _enablePersonControls();
        }

        private void familyTreeView_ItemMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _currentRightClickedItem = sender 
                as System.Windows.Controls.TreeViewItem;
            
            if (familyTreeView.InternalTreeView.Items.Count <= 0
                    || _currentRightClickedItem == null
                    || _currentRightClickedItem.Header == null)
                return;            

            if (_currentRightClickedItem.Header is FamilyViewModel)
            {
                FamilyViewModel familyVM = _currentRightClickedItem.Header as FamilyViewModel;
                _currentFamily = familyVM.Family;

                bool enable = 
                    (familyVM.Family == null) 
                    || (familyVM.Family.RootPerson == null);

                addRootPersonToolStripMenuItem.Enabled = enable;
                addRootPersonToolStripMenuItem.Visible = enable;

                addPersonToolStripMenuItem.Enabled = !enable;
                addPersonToolStripMenuItem.Visible = !enable;

                propertiesToolStripMenuItem.Enabled = false;
                propertiesToolStripMenuItem.Visible = false;
                propertyBottomSeparator.Visible = false;

                _currentPerson = null;
                _currentRelativePerson = null;
            }
            else if (_currentRightClickedItem.Header is PersonViewModel)
            {
                PersonViewModel personVM = _currentRightClickedItem.Header as PersonViewModel;
                _currentPerson = personVM.Person;

                if (personVM.Parent is PersonViewModel)
                {
                    PersonViewModel relativeVM = personVM.Parent as PersonViewModel;
                    _currentRelativePerson = relativeVM.Person;
                }
                else
                    _currentRelativePerson = null;

                // Not need to add root person.
                addRootPersonToolStripMenuItem.Enabled = false;
                addRootPersonToolStripMenuItem.Visible = false;

                addPersonToolStripMenuItem.Enabled = true;
                addPersonToolStripMenuItem.Visible = true;

                propertiesToolStripMenuItem.Enabled = true;
                propertiesToolStripMenuItem.Visible = true;
                propertyBottomSeparator.Visible = true;
            }
            
            // Show the suitable context menu.
            System.Windows.Point point = e.GetPosition(familyTreeView);
            contextMenuStrip.Show(wpfTreeViewHost, (int)point.X, (int)point.Y);
        }

        private void InternalVisualTreeView_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _currentRightClickedItem = sender
               as System.Windows.Controls.TreeViewItem;

            if (visualFamilyTreeView.InternalVisualTreeView.Items.Count > 0)
                return;

            if (_currentFamily == null)
                return;

            if (_currentFamily.RootPerson == null)
            {
                addRootPersonToolStripMenuItem.Enabled = true;
                addRootPersonToolStripMenuItem.Visible = true;

                addPersonToolStripMenuItem.Enabled = false;
                addPersonToolStripMenuItem.Visible = false;

                propertiesToolStripMenuItem.Enabled = false;
                propertiesToolStripMenuItem.Visible = false;
                propertyBottomSeparator.Visible = false;

                // Show the suitable context menu.
                System.Windows.Point point = e.GetPosition(visualFamilyTreeView);
                contextMenuStrip.Show(wpfVisualFTreeHost, (int)point.X, (int)point.Y);
            }
            else
            {
                addPersonToolStripMenuItem.Enabled = true;
                addPersonToolStripMenuItem.Visible = true;
            }
        }

        private void visualFamilyTreeView_ItemMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _currentRightClickedItem = sender
                as System.Windows.Controls.TreeViewItem;

            if (_currentRightClickedItem != null
                    && _currentRightClickedItem.Header is PersonViewModel)
            {
                PersonViewModel personVM = _currentRightClickedItem.Header as PersonViewModel;
                _currentPerson = personVM.Person;

                if (personVM.Parent is PersonViewModel)
                {
                    PersonViewModel relativeVM = personVM.Parent as PersonViewModel;
                    _currentRelativePerson = relativeVM.Person;
                }
                else
                    _currentRelativePerson = null;

                _enablePersonControls();
            }
        }

        private void visualFamilyTreeView_ItemMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _currentRightClickedItem = sender
                as System.Windows.Controls.TreeViewItem;

            if (visualFamilyTreeView.InternalVisualTreeView.Items.Count <= 0
                    || _currentRightClickedItem == null
                    || _currentRightClickedItem.Header == null)
                return;

            if (_currentRightClickedItem.Header is PersonViewModel)
            {
                PersonViewModel personVM = _currentRightClickedItem.Header as PersonViewModel;
                _currentPerson = personVM.Person;

                if (personVM.Parent is PersonViewModel)
                {
                    PersonViewModel relativeVM = personVM.Parent as PersonViewModel;
                    _currentRelativePerson = relativeVM.Person; ;
                }
                else
                    _currentRelativePerson = null;

                // Not need to add root person.
                addRootPersonToolStripMenuItem.Enabled = false;
                addRootPersonToolStripMenuItem.Visible = false;

                addPersonToolStripMenuItem.Enabled = true;
                addPersonToolStripMenuItem.Visible = true;

                propertiesToolStripMenuItem.Enabled = true;
                propertiesToolStripMenuItem.Visible = true;
                propertyBottomSeparator.Visible = true;
            }

            // Show the suitable context menu.
            System.Windows.Point point = e.GetPosition(visualFamilyTreeView);
            contextMenuStrip.Show(wpfVisualFTreeHost, (int)point.X, (int)point.Y);
        }        

        private void addFamilyToolStripButton_Click(object sender, EventArgs e)
        {
            _showFamilyForm();
        }

        private void addPersonToolStripButton_Click(object sender, EventArgs e)
        {
            _showAddMemberForm(addRootPersonMainMenuItem.Enabled);
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripButton_Click(object sender, EventArgs e)
        {
            _showSettingsForm();
        }

        private void achieveToolStripButton_Click(object sender, EventArgs e)
        {
            _showAchievementForm();
        }

        private void reportDeathToolStripButton_Click(object sender, EventArgs e)
        {
            _showSadNewsForm();
        }

        private void reportToolStripSplitButton_ButtonClick(object sender, EventArgs e)
        {
            _showMemberReportForm();
        }

        private void familyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showMemberReportForm();
        }

        private void achievementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showAchievementReportForm();
        }
        
        private void familyManagerToolStripButton_Click(object sender, EventArgs e)
        {
            _showFamilyManager();
        }

        private void memToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showMemberlistForm();
        }

        #region CONTEXT MENU STRIP

        private void addRootPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showAddMemberForm(addRootPersonToolStripMenuItem.Enabled);
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentPerson != null)
                _showAddMemberForm();
            else if (_currentFamily != null)
                _showAddMemberForm(false);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _showPersonProfile();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _deleteEntry();
        }

        private void addRootPersonMainMenuItem_Click(object sender, EventArgs e)
        {
            _showAddMemberForm(addRootPersonMainMenuItem.Enabled);
        }

        private void addPersonMainMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentPerson != null)
                _showAddMemberForm();
            else if (_currentFamily != null)
                _showAddMemberForm(false);
        }

        #endregion

        #endregion

        #region CORE METHODS

        private void _loadData()
        {
            _initPresenter();
            _presenter.LoadAllFamilies();
        }

        #endregion

        #region UTILITY METHODS

        private void _showMemberlistForm()
        {
            if (_currentFamily == null)
                return;
            MemberListForm frmList = new MemberListForm(_currentFamily);
            frmList.ShowDialog(false);
        }

        private void _showFamilyForm()
        {
            FamilyForm frmFamily = new FamilyForm();

            if (frmFamily.ShowDialog(false) == DialogResult.OK)
            {
                _currentFamily = frmFamily.CurrentFamily;
                _families.Add(_currentFamily);
                _familyViewModels.Add(new FamilyViewModel(_currentFamily));

                if (frmFamily.AcquireAddFirstPerson)
                    _showAddMemberForm(true);                
            }
        }

        private void _showFamilyManager()
        {
            FamilyManagerForm frmFamilyManger = new FamilyManagerForm(_families);
            if (frmFamilyManger.ShowDialog(false) == DialogResult.OK)
            {
                _generateViewModels();
            }
        }

        private void _showAddMemberForm(bool isAddingRootPerson)
        {
            FamilyMemberForm frmMember = new FamilyMemberForm(isAddingRootPerson, _currentFamily);
            if (frmMember.ShowDialog(false) == DialogResult.OK)
            {
                if (!isAddingRootPerson)
                {
                    //if (!_isLoadedData(_currentFamily.RootPerson))
                    //{
                        // Load the full tree structure.
                        ThreadHelper.DoWork(_presenter.LoadFamilyTree);
                        _currentFamily.RootPerson.Tag = true;
                    //}

                    // Search the person was updated.
                    _currentPerson = _presenter.SearchInCurrentFamily(frmMember.RelativePerson.ID);

                    //if (_currentPerson != null)
                    //    frmMember.UpdateRelationship(_currentPerson);
                }
                //_generateViewModels();
                _updateViewModels(_currentFamily);
            }
        }

        private void _showAddMemberForm()
        {
            FamilyMemberForm frmMember = new FamilyMemberForm(_currentPerson);
            if (frmMember.ShowDialog(false) == DialogResult.OK)
            {
                frmMember.UpdateRelationship(_currentPerson);
                //_generateViewModels();
                _updateViewModels(_currentFamily);
            }
        }

        private void _showPersonProfile()
        {
            FamilyMemberForm frmMember = new FamilyMemberForm(_currentRelativePerson, _currentPerson);
            if (frmMember.ShowDialog(false) == DialogResult.OK)
                _updateViewModels(_currentFamily);
        }

        private void _showAchievementForm()
        {
            AchievementForm frmAchievement = new AchievementForm(_currentPerson);
            frmAchievement.ShowDialog(false);
        }

        private void _showSadNewsForm()
        {
            SadNewsForm frmSadNews = new SadNewsForm(_currentPerson, true);
            frmSadNews.ShowDialog(false);
        }

        private void _showMemberReportForm()
        {
            FamilyReportForm frmFamilyReport = new FamilyReportForm();
            frmFamilyReport.ShowDialog(false);
        }

        private void _showAchievementReportForm()
        {
            AchievementReportForm frmAchievement = new AchievementReportForm();
            frmAchievement.ShowDialog(false);
        }

        private void _showSettingsForm()
        {
            SettingsForm frmSetting = new SettingsForm();
            frmSetting.ShowDialog(false);
        }

        /// <summary>
        /// Genrate View-Model objects to map all FamilyDTOs to the treeview
        /// </summary>
        private void _generateViewModels()
        {
            //_familyViewModels = new ObservableCollection<FamilyViewModel>();
            ObservableCollection<FamilyViewModel> familyVMs = new ObservableCollection<FamilyViewModel>();

            foreach (FamilyDTO dto in _families)
            {
                FamilyViewModel familyVM = new FamilyViewModel(dto);

                if (dto == _currentFamily)
                {
                    familyVM.IsSelected = true;
                    familyVM.IsExpanded = true;
                }
                familyVMs.Add(familyVM);
            }

            _familyViewModels = familyVMs;

            this.familyTreeView.SetDataBinding(_familyViewModels);
        }

        private void _updateViewModels(FamilyDTO familyDto)
        {
            if (familyDto == null)
                return;

            // Because of the object-reference feature of C#, 
            // and the parameter 'familyDto' may not belong to the Family collection in this form,
            // we should find the object existing in the collection that macthes the 'familyDto',
            // then update it.
            int fIndex = -1;
            bool found = false;
            for (fIndex = 0; fIndex < _families.Count; fIndex++)
            {
                if (_families[fIndex].ID == familyDto.ID)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                return;

            // Update the object in the collection.
            _families[fIndex] = familyDto;

            int fvmIndex = -1;
            found = false;
            for (fvmIndex = 0; fvmIndex < _familyViewModels.Count; fvmIndex++)
            {
                if (_familyViewModels[fvmIndex].Family.ID == _families[fIndex].ID)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                return;

            // Update the View-Model object
            _familyViewModels[fvmIndex] = new FamilyViewModel(_families[fIndex]);

            this.familyTreeView.SetDataBinding(_familyViewModels);
        }

        private void _initPresenter()
        {
            _presenter = new FamilyManagerPresenter(this);
            _presenter.AutoSubmitChanges = true;
        }

        private void _enablePersonControls()
        {
            if (familyTreeView.InternalTreeView.SelectedItem == null)
            {
                addPersonToolStripButton.Enabled = false;
                achieveToolStripButton.Enabled = false;
                reportDeathToolStripButton.Enabled = false;
            }
            else if (_currentFamily != null && _currentPerson == null)
            {
                addPersonToolStripButton.Enabled = true;
                achieveToolStripButton.Enabled = false;
                reportDeathToolStripButton.Enabled = false;

                if (_currentFamily.RootPerson == null)
                {
                    addRootPersonMainMenuItem.Visible = true;
                    addRootPersonMainMenuItem.Enabled = true;
                }
                else
                {
                    addRootPersonMainMenuItem.Visible = false;
                    addRootPersonMainMenuItem.Enabled = false;
                }
            }
            else if (_currentPerson != null)
            {
                addPersonToolStripButton.Enabled = true;
                achieveToolStripButton.Enabled = true;

                if (_currentPerson.IsDead)
                    reportDeathToolStripButton.Enabled = false;
                else
                    reportDeathToolStripButton.Enabled = true;

                addRootPersonMainMenuItem.Visible = false;
                addRootPersonMainMenuItem.Enabled = false;
            }
        }

        /// <summary>
        /// Detect the specific FamilyMemberDTO object was loaded data or not.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        private bool _isLoadedData(object tag)
        {
            if (tag != null
                    && tag is bool)
                return (bool)(tag);

            else 
                return false;
        }

        private FamilyViewModel _getFamilyFrom(PersonViewModel person)
        {
            if (person == null)
                return null;
           TreeViewItemViewModel currentItem = person;
            
            while (true)
            {
                if (currentItem == null)
                    break;

                if (currentItem.Parent != null && currentItem.Parent is FamilyViewModel)
                    return currentItem.Parent as FamilyViewModel;
                else if (currentItem != null && currentItem is FamilyViewModel)
                    return currentItem as FamilyViewModel;
          
                currentItem = currentItem.Parent;
            }

            return null;
        }

        private void _deleteEntry()
        {
            try
            {
                if (_currentRightClickedItem == null
                        || _currentRightClickedItem.Header == null)
                    return;

                if (_currentRightClickedItem.Header is FamilyViewModel)
                {
                    // Ask for confirm.
                    DialogResult result = UIUtils.ConfirmOKCancel(String.Format(Util.GetStringResource(StringResName.MSG_CONFIRM_DEL_FAMILY), _currentFamily.Name));

                    if (result != DialogResult.OK)
                        return;

                    ThreadHelper.DoWork(_presenter.Delete);
                    _families.Remove(_currentFamily);
                    _generateViewModels();
                }
                else if (_currentRightClickedItem.Header is PersonViewModel)
                {
                    DeletePersonWizardForm frmDelete = new DeletePersonWizardForm(_currentPerson);
                    if (frmDelete.ShowDialog(false) == DialogResult.OK)
                    {
                        ThreadHelper.DoWork(_presenter.LoadAllFamilies);
                        _generateViewModels();
                        _enablePersonControls();
                    }
                }
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FTreeMainForm), exc);
                UIUtils.Error(Util.GetStringResource(StringResName.ERR_DELETE_ENTRY_FAILED));
            }
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
            }
        }

        public FamilyDTO CurrentFamily
        {
            get { return _currentFamily; }
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
