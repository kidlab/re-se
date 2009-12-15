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
        private UIUtils.CountExistentEntryDelegate _countExistentEntry;

        /// <summary>
        /// The delagate used to check user input data valid or not.
        /// </summary>
        public UIUtils.CountExistentEntryDelegate CountExistentEntry
        {
            get { return _countExistentEntry; }
            set { _countExistentEntry = value; }
        }

        /// <summary>
        /// Initializes a new instance of SimpleEntryForm with the default settings.
        /// </summary>
        public SimpleEntryForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of SimpleEntryForm with an external validation method.
        /// </summary>
        /// <param name="validateDelegate"></param>
        public SimpleEntryForm(UIUtils.CountExistentEntryDelegate validateDelegate)
        {
            InitializeComponent();

            _countExistentEntry = validateDelegate;
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
            if (!ValidateInputData())
                return;
            this.DialogResult = DialogResult.OK;
        }

        #region IValidator Members

        public bool ValidateInputData()
        {
            string strData = this.txtName.Text.Trim();
            if (String.IsNullOrEmpty(strData))
            {
                _setErrorToolTip(txtName, Util.GetStringResource(StringResName.MSG_ENTER_DATA));
                return false;
            }

            if (_countExistentEntry != null)
            {
                // Call the external validation method.
                if (_countExistentEntry(strData) > 0)
                {
                    UIUtils.Warning(String.Format(Util.GetStringResource(StringResName.ERR_ENTRY_ALREADY_EXIST), strData));
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region UTILITY METHODS

        private void _setErrorToolTip(Control control, string message)
        {
            this.errorToolTip.SetToolTip(control, message);
            this.errorToolTip.Show(message, control, 3000);
        }

        #endregion  
    }
}
