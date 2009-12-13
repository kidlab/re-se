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
using FTree.Presenter.ViewModel;
using FTree.DTO;

namespace FTree.View.Win32
{
    public partial class FTreeMainForm : Form
    {
        #region CONSTRUCTOR

        public FTreeMainForm()
        {
            InitializeComponent();

            this.familyTreeView.InternalTreeView.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(InternalTreeView_SelectedItemChanged);
        }

        #endregion

        #region UI EVENTS

        // Generate dummy data for testing.
        ObservableCollection<FamilyViewModel> fs = new ObservableCollection<FamilyViewModel>();

        private void FTreeMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _generateDummyData();
            }
            catch (Exception exc)
            {
                Tracer.Log(typeof(FTreeMainForm), exc);
            }
        }

        Random _dummyRand = new Random();
        private void _generateDummyData()
        {
            for (int i = 0; i < 2; i++)
            {
                FamilyDTO f = new FamilyDTO();
                f.Name = "Family " + i.ToString();
                f.RootPerson = _dummyPerson();
                fs.Add(new FamilyViewModel(f));
            }
            this.familyTreeView.SetDataBinding(fs);
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


        private void InternalTreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue != null && e.NewValue is FamilyViewModel)
            {
                FamilyViewModel tmpFamily = e.NewValue as FamilyViewModel;
                tmpFamily.IsExpanded = true;                
                this.visualFamilyTreeView.SetDataBinding(tmpFamily);
                //tmpFamily.IsExpanded = false;
            }
        }

        private void addFamilyToolStripButton_Click(object sender, EventArgs e)
        {
            _showFamilyForm(DataFormMode.CreateNew);
        }

        private void addPersonToolStripButton_Click(object sender, EventArgs e)
        {
            _showAddMemberForm();
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

        #endregion
        
        #region UTILITY METHODS

        private void _showFamilyForm(DataFormMode mode)
        {
            FamilyForm frmFamily = new FamilyForm(mode);
            frmFamily.ShowDialog(false);
            if (frmFamily.DialogResult == DialogResult.OK
                    && frmFamily.AcquireAddFirstPerson)
                _showAddMemberForm();
        }

        private void _showFamilyManager()
        {
            FamilyManagerForm frmFamilyManger = new FamilyManagerForm();
            frmFamilyManger.ShowDialog(false);
        }

        private void _showAddMemberForm()
        {
            FamilyMemberForm frmMember = new FamilyMemberForm();
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

        #endregion
    }
}
