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
    public partial class ProgressForm : BaseDialogForm
    {
        private bool isClosed;

        /// <summary>
        /// Initializez a new instance of ProgressForm with the default settings.
        /// </summary>
        public ProgressForm()
        {
            InitializeComponent();
            this.lblMessage.Text = "Please wait...";
            Control.CheckForIllegalCrossThreadCalls = false;
            this.timer.Interval = 50;
            this.timer.Enabled = true;
            this.isClosed  = false;
        }
        
                /// <summary>
        /// Initializez a new instance of ProgressForm with a "waiting" message (or any message :) needs showing.
        /// </summary>
        /// <param name="message">The message need showing to the screen.</param>
        public ProgressForm(string message)
        {
            InitializeComponent();
            this.lblMessage.Text = message;
            Control.CheckForIllegalCrossThreadCalls = false;
            this.timer.Interval = 50;
            this.timer.Enabled = true;
            this.isClosed = false;
        }

        /// <summary>
        /// Gets or sets the current message shown on this form.
        /// </summary>
        public string ProgressMessage
        {
            get { return this.lblMessage.Text; }
            set { this.lblMessage.Text = value; }
        }

        /// <summary>
        /// Closes this dialog.
        /// </summary>
        public void CloseDialog()
        {
            this.isClosed = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.isClosed)
                this.Close();
        }
    }
}
