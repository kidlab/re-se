namespace FTree.View.Win32
{
    partial class FamilyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamilyForm));
            this.lblFamilyName = new System.Windows.Forms.Label();
            this.txtFamilyName = new FTree.View.Win32.Components.BaseTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateFirstPerson = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFamilyName
            // 
            this.lblFamilyName.AutoSize = true;
            this.lblFamilyName.Location = new System.Drawing.Point(97, 18);
            this.lblFamilyName.Name = "lblFamilyName";
            this.lblFamilyName.Size = new System.Drawing.Size(70, 13);
            this.lblFamilyName.TabIndex = 0;
            this.lblFamilyName.Text = "Family Name:";
            // 
            // txtFamilyName
            // 
            this.txtFamilyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFamilyName.Location = new System.Drawing.Point(100, 34);
            this.txtFamilyName.Name = "txtFamilyName";
            this.txtFamilyName.Size = new System.Drawing.Size(228, 20);
            this.txtFamilyName.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.Image = global::FTree.View.Win32.Properties.Resources.ok;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(122, 175);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::FTree.View.Win32.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(228, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCreateFirstPerson
            // 
            this.btnCreateFirstPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateFirstPerson.AutoSize = true;
            this.btnCreateFirstPerson.Image = global::FTree.View.Win32.Properties.Resources.next;
            this.btnCreateFirstPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateFirstPerson.Location = new System.Drawing.Point(159, 60);
            this.btnCreateFirstPerson.Name = "btnCreateFirstPerson";
            this.btnCreateFirstPerson.Size = new System.Drawing.Size(169, 32);
            this.btnCreateFirstPerson.TabIndex = 5;
            this.btnCreateFirstPerson.Text = "Create First Person...";
            this.btnCreateFirstPerson.UseVisualStyleBackColor = true;
            this.btnCreateFirstPerson.Click += new System.EventHandler(this.btnCreateFirstPerson_Click);
            // 
            // lblImage
            // 
            this.lblImage.Image = global::FTree.View.Win32.Properties.Resources.family;
            this.lblImage.Location = new System.Drawing.Point(12, 9);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(79, 81);
            this.lblImage.TabIndex = 2;
            // 
            // FamilyForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(340, 219);
            this.Controls.Add(this.btnCreateFirstPerson);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.txtFamilyName);
            this.Controls.Add(this.lblFamilyName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FamilyForm";
            this.Text = "Create New Family";
            this.Load += new System.EventHandler(this.FamilyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFamilyName;
        private FTree.View.Win32.Components.BaseTextBox txtFamilyName;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCreateFirstPerson;
    }
}