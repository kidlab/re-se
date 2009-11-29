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
            frmMember.ShowDialog();
        }
    }
}
