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

        // Current selecetd FamilyMember on the treeview.
        private FamilyMemberDTO _currentPerson;

        private IList<FamilyDTO> _families;
        private ObservableCollection<FamilyViewModel> _familyViewModels;

        #endregion

        #region CONSTRUCTOR

        public FTreeMainForm()
        {
            InitializeComponent();

            _families = new List<FamilyDTO>();

            this.familyTreeView.InternalTreeView.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(InternalTreeView_SelectedItemChanged);

            this.familyTreeView.ItemMouseRightButtonUp += new System.Windows.Input.MouseButtonEventHandler(familyTreeView_ItemMouseRightButtonUp);
        } 

        #endregion

        #region UI EVENTS

        // Generate dummy data for testing.        

        private void FTreeMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ThreadHelper.DoWork(_initPresenter);
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
            }
            else if (e.NewValue is PersonViewModel)
            {
                PersonViewModel tmpPerson = e.NewValue as PersonViewModel;
                _currentPerson = tmpPerson.Person;
            }

            _enablePersonControls();
        }

        private void familyTreeView_ItemMouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Controls.TreeViewItem item = sender 
                as System.Windows.Controls.TreeViewItem;
            
            if (familyTreeView.InternalTreeView.Items.Count <= 0
                    || item == null
                    || item.Header == null)
                return;

            if (item.Header is FamilyViewModel)
            {
                FamilyViewModel familyVM = item.Header as FamilyViewModel;
                
                bool enable = 
                    (familyVM.Family == null) 
                    || (familyVM.Family.RootPerson == null);

                addRootPersonToolStripMenuItem.Enabled = enable;
                addRootPersonToolStripMenuItem.Visible = enable;

                propertiesToolStripMenuItem.Enabled = false;
                propertiesToolStripMenuItem.Visible = false;
                propertyBottomSeparator.Visible = false;
            }
            else if (item.Header is PersonViewModel)
            {
                // Not need to add root person.
                addRootPersonToolStripMenuItem.Enabled = false;
                addRootPersonToolStripMenuItem.Visible = false;

                propertiesToolStripMenuItem.Enabled = true;
                propertiesToolStripMenuItem.Visible = true;
                propertyBottomSeparator.Visible = true;
            }
            
            // Show the suitable context menu.
            System.Windows.Point point = e.GetPosition(familyTreeView);
            contextMenuStrip.Tag = item.Header;
            contextMenuStrip.Show(wpfTreeViewHost, (int)point.X, (int)point.Y);
        }

        private void addFamilyToolStripButton_Click(object sender, EventArgs e)
        {
            _showFamilyForm();
        }

        private void addPersonToolStripButton_Click(object sender, EventArgs e)
        {
            _showAddMemberForm(false);
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

        #region CONTEXT MENU STRIP

        private void addRootPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addRootPersonMainMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPersonMainMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region CORE METHODS

        private void _loadData()
        {
            _presenter.LoadAllFamilies();
        }

        #endregion

        #region UTILITY METHODS

        private void _showFamilyForm()
        {
            FamilyForm frmFamily = new FamilyForm();
            if (frmFamily.ShowDialog(false) == DialogResult.OK
                    && frmFamily.AcquireAddFirstPerson)
                _showAddMemberForm(true);
        }

        private void _showFamilyManager()
        {
            FamilyManagerForm frmFamilyManger = new FamilyManagerForm(_families);
            frmFamilyManger.ShowDialog(false);

            _families = frmFamilyManger.Families;
            _generateViewModels();
        }

        private void _showAddMemberForm(bool isAddingRootPerson)
        {
            FamilyMemberForm frmMember = new FamilyMemberForm(isAddingRootPerson, _currentFamily);
            frmMember.ShowDialog(false);
        }

        private void _showAchievementForm()
        {
            AchievementForm frmAchievement = new AchievementForm();
            frmAchievement.ShowDialog(false);
        }

        private void _showSadNewsForm()
        {
            SadNewsForm frmSadNews = new SadNewsForm();
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

        private void _generateViewModels()
        {
            _familyViewModels = new ObservableCollection<FamilyViewModel>();
            
            foreach (FamilyDTO dto in _families)
            {
                _familyViewModels.Add(new FamilyViewModel(dto));
            }

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
                reportDeathToolStripButton.Enabled = true;

                addRootPersonMainMenuItem.Visible = false;
                addRootPersonMainMenuItem.Enabled = false;
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
