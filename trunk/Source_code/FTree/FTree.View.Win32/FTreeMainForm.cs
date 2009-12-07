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

        private void addPersonToolStripButton_Click(object sender, EventArgs e)
        {
            FamilyMemberForm frmMember = new FamilyMemberForm();
            frmMember.ShowDialog(false);
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void achivementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AchievementReportForm ach = new AchievementReportForm();
            ach.ShowDialog(false);
        }

        private void familyMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FamilyReportForm ach = new FamilyReportForm();
            ach.ShowDialog(false);
        }
    }
}
