using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FTree.Common;

namespace FTree.View.Win32
{
    public partial class SimpleEntryForm : BaseDialogForm, IValidator
    {
        public SimpleEntryForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Gets or sets the data in the text box.
        /// </summary>
        public string Data
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateInputData())
                this.DialogResult = DialogResult.OK;
        }

        #region IValidator Members

        public bool ValidateInputData()
        {
            if (String.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                UIUtils.Info(Util.GetStringResource(StringResName.MSG_ENTER_DATA));
                return false;
            }
            return true;
        }

        #endregion
    }
}
