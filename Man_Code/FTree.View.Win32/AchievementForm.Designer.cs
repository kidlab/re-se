namespace FTree.View.Win32
{
    partial class AchievementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AchievementForm));
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblImage = new System.Windows.Forms.Label();
            this.gbxAchieveInfo = new System.Windows.Forms.GroupBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new FTree.View.Win32.Components.BaseTextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.achieveDatePicker = new System.Windows.Forms.DateTimePicker();
            this.lblType = new System.Windows.Forms.Label();
            this.cbAchievementType = new System.Windows.Forms.ComboBox();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.gbxAchieveInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(132, 13);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Assign an achievement to:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::FTree.View.Win32.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(344, 292);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.Image = global::FTree.View.Win32.Properties.Resources.ok;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(238, 292);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblImage
            // 
            this.lblImage.Image = global::FTree.View.Win32.Properties.Resources.achievement1;
            this.lblImage.Location = new System.Drawing.Point(11, 33);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(113, 110);
            this.lblImage.TabIndex = 7;
            // 
            // gbxAchieveInfo
            // 
            this.gbxAchieveInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAchieveInfo.Controls.Add(this.lblDescription);
            this.gbxAchieveInfo.Controls.Add(this.txtDescription);
            this.gbxAchieveInfo.Controls.Add(this.lblDate);
            this.gbxAchieveInfo.Controls.Add(this.achieveDatePicker);
            this.gbxAchieveInfo.Controls.Add(this.lblType);
            this.gbxAchieveInfo.Controls.Add(this.cbAchievementType);
            this.gbxAchieveInfo.Location = new System.Drawing.Point(141, 33);
            this.gbxAchieveInfo.Name = "gbxAchieveInfo";
            this.gbxAchieveInfo.Size = new System.Drawing.Size(303, 253);
            this.gbxAchieveInfo.TabIndex = 8;
            this.gbxAchieveInfo.TabStop = false;
            this.gbxAchieveInfo.Text = "Achievement Info";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(7, 97);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(70, 113);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(221, 134);
            this.txtDescription.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 60);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "Date:";
            // 
            // achieveDatePicker
            // 
            this.achieveDatePicker.Location = new System.Drawing.Point(70, 56);
            this.achieveDatePicker.Name = "achieveDatePicker";
            this.achieveDatePicker.Size = new System.Drawing.Size(221, 20);
            this.achieveDatePicker.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 22);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type:";
            // 
            // cbAchievementType
            // 
            this.cbAchievementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAchievementType.FormattingEnabled = true;
            this.cbAchievementType.Location = new System.Drawing.Point(70, 19);
            this.cbAchievementType.Name = "cbAchievementType";
            this.cbAchievementType.Size = new System.Drawing.Size(221, 21);
            this.cbAchievementType.TabIndex = 0;
            this.cbAchievementType.SelectedIndexChanged += new System.EventHandler(this.cbAchievementType_SelectedIndexChanged);
            // 
            // lblPersonName
            // 
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonName.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblPersonName.Location = new System.Drawing.Point(150, 9);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(82, 13);
            this.lblPersonName.TabIndex = 9;
            this.lblPersonName.Text = "Person Name";
            // 
            // AchievementForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(456, 336);
            this.Controls.Add(this.lblPersonName);
            this.Controls.Add(this.gbxAchieveInfo);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AchievementForm";
            this.Text = "Assign An Achievement";
            this.Load += new System.EventHandler(this.AchievementForm_Load);
            this.gbxAchieveInfo.ResumeLayout(false);
            this.gbxAchieveInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.GroupBox gbxAchieveInfo;
        private System.Windows.Forms.ComboBox cbAchievementType;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.DateTimePicker achieveDatePicker;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDescription;
        private FTree.View.Win32.Components.BaseTextBox txtDescription;
    }
}