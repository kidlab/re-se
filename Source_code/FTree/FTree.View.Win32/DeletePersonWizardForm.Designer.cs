namespace FTree.View.Win32
{
    partial class DeletePersonWizardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeletePersonWizardForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.gbxAction = new System.Windows.Forms.GroupBox();
            this.rbDelKeepChildren = new System.Windows.Forms.RadioButton();
            this.rbDelKeepSpouseChildren = new System.Windows.Forms.RadioButton();
            this.rbDelKeepSpouse = new System.Windows.Forms.RadioButton();
            this.rbDeleEntirelyPerson = new System.Windows.Forms.RadioButton();
            this.gbxAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::FTree.View.Win32.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(218, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.Image = global::FTree.View.Win32.Properties.Resources.ok;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(112, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(167, 13);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Please select an action to perform";
            // 
            // gbxAction
            // 
            this.gbxAction.Controls.Add(this.rbDelKeepChildren);
            this.gbxAction.Controls.Add(this.rbDelKeepSpouseChildren);
            this.gbxAction.Controls.Add(this.rbDelKeepSpouse);
            this.gbxAction.Controls.Add(this.rbDeleEntirelyPerson);
            this.gbxAction.Location = new System.Drawing.Point(12, 25);
            this.gbxAction.Name = "gbxAction";
            this.gbxAction.Size = new System.Drawing.Size(304, 121);
            this.gbxAction.TabIndex = 6;
            this.gbxAction.TabStop = false;
            this.gbxAction.Text = "Actions";
            // 
            // rbDelKeepChildren
            // 
            this.rbDelKeepChildren.AutoSize = true;
            this.rbDelKeepChildren.Location = new System.Drawing.Point(6, 88);
            this.rbDelKeepChildren.Name = "rbDelKeepChildren";
            this.rbDelKeepChildren.Size = new System.Drawing.Size(148, 17);
            this.rbDelKeepChildren.TabIndex = 3;
            this.rbDelKeepChildren.TabStop = true;
            this.rbDelKeepChildren.Text = "Delete all but keep chilren";
            this.rbDelKeepChildren.UseVisualStyleBackColor = true;
            // 
            // rbDelKeepSpouseChildren
            // 
            this.rbDelKeepSpouseChildren.AutoSize = true;
            this.rbDelKeepSpouseChildren.Location = new System.Drawing.Point(6, 65);
            this.rbDelKeepSpouseChildren.Name = "rbDelKeepSpouseChildren";
            this.rbDelKeepSpouseChildren.Size = new System.Drawing.Size(212, 17);
            this.rbDelKeepSpouseChildren.TabIndex = 2;
            this.rbDelKeepSpouseChildren.TabStop = true;
            this.rbDelKeepSpouseChildren.Text = "Delete all but keep spouse and children";
            this.rbDelKeepSpouseChildren.UseVisualStyleBackColor = true;
            // 
            // rbDelKeepSpouse
            // 
            this.rbDelKeepSpouse.AutoSize = true;
            this.rbDelKeepSpouse.Location = new System.Drawing.Point(6, 42);
            this.rbDelKeepSpouse.Name = "rbDelKeepSpouse";
            this.rbDelKeepSpouse.Size = new System.Drawing.Size(151, 17);
            this.rbDelKeepSpouse.TabIndex = 1;
            this.rbDelKeepSpouse.TabStop = true;
            this.rbDelKeepSpouse.Text = "Delete all but keep spouse";
            this.rbDelKeepSpouse.UseVisualStyleBackColor = true;
            // 
            // rbDeleEntirelyPerson
            // 
            this.rbDeleEntirelyPerson.AutoSize = true;
            this.rbDeleEntirelyPerson.Location = new System.Drawing.Point(6, 19);
            this.rbDeleEntirelyPerson.Name = "rbDeleEntirelyPerson";
            this.rbDeleEntirelyPerson.Size = new System.Drawing.Size(121, 17);
            this.rbDeleEntirelyPerson.TabIndex = 0;
            this.rbDeleEntirelyPerson.TabStop = true;
            this.rbDeleEntirelyPerson.Text = "Entirely delete peron";
            this.rbDeleEntirelyPerson.UseVisualStyleBackColor = true;
            // 
            // DeletePersonWizardForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(330, 213);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.gbxAction);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DeletePersonWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Delete Person Wizard";
            this.Load += new System.EventHandler(this.DeletePersonWizardForm_Load);
            this.gbxAction.ResumeLayout(false);
            this.gbxAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.GroupBox gbxAction;
        private System.Windows.Forms.RadioButton rbDelKeepChildren;
        private System.Windows.Forms.RadioButton rbDelKeepSpouseChildren;
        private System.Windows.Forms.RadioButton rbDelKeepSpouse;
        private System.Windows.Forms.RadioButton rbDeleEntirelyPerson;

    }
}