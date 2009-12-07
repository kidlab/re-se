using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTree.View.Win32
{
    public partial class FTreeMainForm : Form
    {
        public FTreeMainForm()
        {
            InitializeComponent();
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
