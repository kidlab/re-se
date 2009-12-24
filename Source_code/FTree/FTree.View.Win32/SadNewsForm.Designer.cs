namespace FTree.View.Win32
{
    partial class SadNewsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SadNewsForm));
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbxSadNews = new System.Windows.Forms.GroupBox();
            this.cbBuryPlace = new System.Windows.Forms.ComboBox();
            this.lblBuryPlace = new System.Windows.Forms.Label();
            this.deathTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblDeathTime = new System.Windows.Forms.Label();
            this.deathDayPicker = new System.Windows.Forms.DateTimePicker();
            this.lblDeathDate = new System.Windows.Forms.Label();
            this.cbDeathReasons = new System.Windows.Forms.ComboBox();
            this.lblDeathReason = new System.Windows.Forms.Label();
            this.gbxSadNews.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(111, 13);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Report a sad news of:";
            // 
            // lblPersonName
            // 
            this.lblPersonName.AutoSize = true;
            this.lblPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonName.ForeColor = System.Drawing.Color.Red;
            this.lblPersonName.Location = new System.Drawing.Point(129, 9);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(82, 13);
            this.lblPersonName.TabIndex = 10;
            this.lblPersonName.Text = "Person Name";
            // 
            // lblImage
            // 
            this.lblImage.Image = global::FTree.View.Win32.Properties.Resources.angel;
            this.lblImage.Location = new System.Drawing.Point(10, 32);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(144, 132);
            this.lblImage.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::FTree.View.Win32.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(378, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.Image = global::FTree.View.Win32.Properties.Resources.ok;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(272, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // gbxSadNews
            // 
            this.gbxSadNews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSadNews.Controls.Add(this.cbBuryPlace);
            this.gbxSadNews.Controls.Add(this.lblBuryPlace);
            this.gbxSadNews.Controls.Add(this.deathTimePicker);
            this.gbxSadNews.Controls.Add(this.lblDeathTime);
            this.gbxSadNews.Controls.Add(this.deathDayPicker);
            this.gbxSadNews.Controls.Add(this.lblDeathDate);
            this.gbxSadNews.Controls.Add(this.cbDeathReasons);
            this.gbxSadNews.Controls.Add(this.lblDeathReason);
            this.gbxSadNews.Location = new System.Drawing.Point(161, 32);
            this.gbxSadNews.Name = "gbxSadNews";
            this.gbxSadNews.Size = new System.Drawing.Size(317, 208);
            this.gbxSadNews.TabIndex = 14;
            this.gbxSadNews.TabStop = false;
            this.gbxSadNews.Text = "Sad News";
            // 
            // cbBuryPlace
            // 
            this.cbBuryPlace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBuryPlace.FormattingEnabled = true;
            this.cbBuryPlace.Location = new System.Drawing.Point(103, 116);
            this.cbBuryPlace.Name = "cbBuryPlace";
            this.cbBuryPlace.Size = new System.Drawing.Size(208, 21);
            this.cbBuryPlace.TabIndex = 13;
            this.cbBuryPlace.SelectedIndexChanged += new System.EventHandler(this.cbBuryPlace_SelectedIndexChanged);
            // 
            // lblBuryPlace
            // 
            this.lblBuryPlace.AutoSize = true;
            this.lblBuryPlace.Location = new System.Drawing.Point(6, 119);
            this.lblBuryPlace.Name = "lblBuryPlace";
            this.lblBuryPlace.Size = new System.Drawing.Size(61, 13);
            this.lblBuryPlace.TabIndex = 12;
            this.lblBuryPlace.Text = "Bury Place:";
            // 
            // deathTimePicker
            // 
            this.deathTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.deathTimePicker.Location = new System.Drawing.Point(103, 82);
            this.deathTimePicker.Name = "deathTimePicker";
            this.deathTimePicker.ShowUpDown = true;
            this.deathTimePicker.Size = new System.Drawing.Size(132, 20);
            this.deathTimePicker.TabIndex = 11;
            // 
            // lblDeathTime
            // 
            this.lblDeathTime.AutoSize = true;
            this.lblDeathTime.Location = new System.Drawing.Point(6, 86);
            this.lblDeathTime.Name = "lblDeathTime";
            this.lblDeathTime.Size = new System.Drawing.Size(77, 13);
            this.lblDeathTime.TabIndex = 10;
            this.lblDeathTime.Text = "Time of Death:";
            // 
            // deathDayPicker
            // 
            this.deathDayPicker.Location = new System.Drawing.Point(103, 46);
            this.deathDayPicker.Name = "deathDayPicker";
            this.deathDayPicker.Size = new System.Drawing.Size(208, 20);
            this.deathDayPicker.TabIndex = 9;
            // 
            // lblDeathDate
            // 
            this.lblDeathDate.AutoSize = true;
            this.lblDeathDate.Location = new System.Drawing.Point(6, 50);
            this.lblDeathDate.Name = "lblDeathDate";
            this.lblDeathDate.Size = new System.Drawing.Size(77, 13);
            this.lblDeathDate.TabIndex = 4;
            this.lblDeathDate.Text = "Date of Death:";
            // 
            // cbDeathReasons
            // 
            this.cbDeathReasons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeathReasons.FormattingEnabled = true;
            this.cbDeathReasons.Location = new System.Drawing.Point(103, 13);
            this.cbDeathReasons.Name = "cbDeathReasons";
            this.cbDeathReasons.Size = new System.Drawing.Size(208, 21);
            this.cbDeathReasons.TabIndex = 3;
            this.cbDeathReasons.SelectedIndexChanged += new System.EventHandler(this.cbDeathReasons_SelectedIndexChanged);
            // 
            // lblDeathReason
            // 
            this.lblDeathReason.AutoSize = true;
            this.lblDeathReason.Location = new System.Drawing.Point(6, 16);
            this.lblDeathReason.Name = "lblDeathReason";
            this.lblDeathReason.Size = new System.Drawing.Size(91, 13);
            this.lblDeathReason.TabIndex = 2;
            this.lblDeathReason.Text = "Reason of Death:";
            // 
            // SadNewsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(490, 290);
            this.Controls.Add(this.gbxSadNews);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblPersonName);
            this.Controls.Add(this.lblInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SadNewsForm";
            this.Text = "Sad News...";
            this.Load += new System.EventHandler(this.SadNewsForm_Load);
            this.gbxSadNews.ResumeLayout(false);
            this.gbxSadNews.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox gbxSadNews;
        private System.Windows.Forms.ComboBox cbDeathReasons;
        private System.Windows.Forms.Label lblDeathReason;
        private System.Windows.Forms.Label lblDeathDate;
        private System.Windows.Forms.DateTimePicker deathDayPicker;
        private System.Windows.Forms.DateTimePicker deathTimePicker;
        private System.Windows.Forms.Label lblDeathTime;
        private System.Windows.Forms.ComboBox cbBuryPlace;
        private System.Windows.Forms.Label lblBuryPlace;
    }
}