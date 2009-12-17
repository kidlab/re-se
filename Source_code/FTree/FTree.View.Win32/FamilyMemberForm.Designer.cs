namespace FTree.View.Win32
{
    partial class FamilyMemberForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamilyMemberForm));
            this.personInfoTabControl = new System.Windows.Forms.TabControl();
            this.personInfoTabPage = new System.Windows.Forms.TabPage();
            this.lblRootPersonWarning = new System.Windows.Forms.Label();
            this.lblFamilyName = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.dateJointPicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxProfile = new System.Windows.Forms.GroupBox();
            this.birthtimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblBirthTime = new System.Windows.Forms.Label();
            this.txtAddress = new FTree.View.Win32.Components.BaseTextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.cbOccupation = new System.Windows.Forms.ComboBox();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.cbHomeTown = new System.Windows.Forms.ComboBox();
            this.lblHomeTown = new System.Windows.Forms.Label();
            this.birthdayPicker = new System.Windows.Forms.DateTimePicker();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.txtLastname = new FTree.View.Win32.Components.BaseTextBox();
            this.lblLastname = new System.Windows.Forms.Label();
            this.txtFirstname = new FTree.View.Win32.Components.BaseTextBox();
            this.lblFirstname = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.gbxRelationship = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new FTree.View.Win32.Components.BaseTextBox();
            this.cbRelationshipType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRelativePerson = new System.Windows.Forms.ComboBox();
            this.lblRelativePerson = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.personInfoTabControl.SuspendLayout();
            this.personInfoTabPage.SuspendLayout();
            this.gbxProfile.SuspendLayout();
            this.gbxRelationship.SuspendLayout();
            this.SuspendLayout();
            // 
            // personInfoTabControl
            // 
            this.personInfoTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.personInfoTabControl.Controls.Add(this.personInfoTabPage);
            this.personInfoTabControl.Location = new System.Drawing.Point(12, 12);
            this.personInfoTabControl.Name = "personInfoTabControl";
            this.personInfoTabControl.SelectedIndex = 0;
            this.personInfoTabControl.Size = new System.Drawing.Size(565, 504);
            this.personInfoTabControl.TabIndex = 0;
            // 
            // personInfoTabPage
            // 
            this.personInfoTabPage.Controls.Add(this.lblRootPersonWarning);
            this.personInfoTabPage.Controls.Add(this.lblFamilyName);
            this.personInfoTabPage.Controls.Add(this.lblInfo);
            this.personInfoTabPage.Controls.Add(this.dateJointPicker);
            this.personInfoTabPage.Controls.Add(this.label2);
            this.personInfoTabPage.Controls.Add(this.gbxProfile);
            this.personInfoTabPage.Controls.Add(this.gbxRelationship);
            this.personInfoTabPage.Location = new System.Drawing.Point(4, 22);
            this.personInfoTabPage.Name = "personInfoTabPage";
            this.personInfoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.personInfoTabPage.Size = new System.Drawing.Size(557, 478);
            this.personInfoTabPage.TabIndex = 0;
            this.personInfoTabPage.Text = "Person Info";
            this.personInfoTabPage.UseVisualStyleBackColor = true;
            // 
            // lblRootPersonWarning
            // 
            this.lblRootPersonWarning.AutoSize = true;
            this.lblRootPersonWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRootPersonWarning.ForeColor = System.Drawing.Color.Red;
            this.lblRootPersonWarning.Location = new System.Drawing.Point(13, 34);
            this.lblRootPersonWarning.Name = "lblRootPersonWarning";
            this.lblRootPersonWarning.Size = new System.Drawing.Size(249, 13);
            this.lblRootPersonWarning.TabIndex = 4;
            this.lblRootPersonWarning.Text = "This person is the root person of the family";
            this.lblRootPersonWarning.Visible = false;
            // 
            // lblFamilyName
            // 
            this.lblFamilyName.AutoSize = true;
            this.lblFamilyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamilyName.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblFamilyName.Location = new System.Drawing.Point(153, 15);
            this.lblFamilyName.Name = "lblFamilyName";
            this.lblFamilyName.Size = new System.Drawing.Size(78, 13);
            this.lblFamilyName.TabIndex = 20;
            this.lblFamilyName.Text = "Family Name";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(13, 15);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(143, 13);
            this.lblInfo.TabIndex = 19;
            this.lblInfo.Text = "Add new person to family of::";
            // 
            // dateJointPicker
            // 
            this.dateJointPicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateJointPicker.Location = new System.Drawing.Point(129, 449);
            this.dateJointPicker.Name = "dateJointPicker";
            this.dateJointPicker.Size = new System.Drawing.Size(200, 20);
            this.dateJointPicker.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Date Joint Family:";
            // 
            // gbxProfile
            // 
            this.gbxProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxProfile.Controls.Add(this.birthtimePicker);
            this.gbxProfile.Controls.Add(this.lblBirthTime);
            this.gbxProfile.Controls.Add(this.txtAddress);
            this.gbxProfile.Controls.Add(this.lblAddress);
            this.gbxProfile.Controls.Add(this.cbOccupation);
            this.gbxProfile.Controls.Add(this.lblOccupation);
            this.gbxProfile.Controls.Add(this.cbHomeTown);
            this.gbxProfile.Controls.Add(this.lblHomeTown);
            this.gbxProfile.Controls.Add(this.birthdayPicker);
            this.gbxProfile.Controls.Add(this.lblBirthday);
            this.gbxProfile.Controls.Add(this.txtLastname);
            this.gbxProfile.Controls.Add(this.lblLastname);
            this.gbxProfile.Controls.Add(this.txtFirstname);
            this.gbxProfile.Controls.Add(this.lblFirstname);
            this.gbxProfile.Controls.Add(this.lblGender);
            this.gbxProfile.Controls.Add(this.rbFemale);
            this.gbxProfile.Controls.Add(this.rbMale);
            this.gbxProfile.Location = new System.Drawing.Point(6, 177);
            this.gbxProfile.Name = "gbxProfile";
            this.gbxProfile.Size = new System.Drawing.Size(545, 247);
            this.gbxProfile.TabIndex = 1;
            this.gbxProfile.TabStop = false;
            this.gbxProfile.Text = "Profile";
            // 
            // birthtimePicker
            // 
            this.birthtimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.birthtimePicker.Location = new System.Drawing.Point(126, 117);
            this.birthtimePicker.Name = "birthtimePicker";
            this.birthtimePicker.ShowUpDown = true;
            this.birthtimePicker.Size = new System.Drawing.Size(113, 20);
            this.birthtimePicker.TabIndex = 10;
            // 
            // lblBirthTime
            // 
            this.lblBirthTime.AutoSize = true;
            this.lblBirthTime.Location = new System.Drawing.Point(10, 121);
            this.lblBirthTime.Name = "lblBirthTime";
            this.lblBirthTime.Size = new System.Drawing.Size(50, 13);
            this.lblBirthTime.TabIndex = 9;
            this.lblBirthTime.Text = "Birthtime:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(126, 197);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(291, 20);
            this.txtAddress.TabIndex = 16;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(10, 200);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 15;
            this.lblAddress.Text = "Address:";
            // 
            // cbOccupation
            // 
            this.cbOccupation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOccupation.FormattingEnabled = true;
            this.cbOccupation.Location = new System.Drawing.Point(126, 170);
            this.cbOccupation.Name = "cbOccupation";
            this.cbOccupation.Size = new System.Drawing.Size(200, 21);
            this.cbOccupation.TabIndex = 14;
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Location = new System.Drawing.Point(10, 173);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(65, 13);
            this.lblOccupation.TabIndex = 13;
            this.lblOccupation.Text = "Occupation:";
            // 
            // cbHomeTown
            // 
            this.cbHomeTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHomeTown.FormattingEnabled = true;
            this.cbHomeTown.Location = new System.Drawing.Point(126, 143);
            this.cbHomeTown.Name = "cbHomeTown";
            this.cbHomeTown.Size = new System.Drawing.Size(200, 21);
            this.cbHomeTown.TabIndex = 12;
            // 
            // lblHomeTown
            // 
            this.lblHomeTown.AutoSize = true;
            this.lblHomeTown.Location = new System.Drawing.Point(10, 146);
            this.lblHomeTown.Name = "lblHomeTown";
            this.lblHomeTown.Size = new System.Drawing.Size(68, 13);
            this.lblHomeTown.TabIndex = 11;
            this.lblHomeTown.Text = "Home Town:";
            // 
            // birthdayPicker
            // 
            this.birthdayPicker.Location = new System.Drawing.Point(126, 91);
            this.birthdayPicker.Name = "birthdayPicker";
            this.birthdayPicker.Size = new System.Drawing.Size(200, 20);
            this.birthdayPicker.TabIndex = 8;
            // 
            // lblBirthday
            // 
            this.lblBirthday.AutoSize = true;
            this.lblBirthday.Location = new System.Drawing.Point(10, 95);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(48, 13);
            this.lblBirthday.TabIndex = 7;
            this.lblBirthday.Text = "Birthday:";
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(126, 67);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(291, 20);
            this.txtLastname.TabIndex = 6;
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Location = new System.Drawing.Point(10, 70);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(56, 13);
            this.lblLastname.TabIndex = 5;
            this.lblLastname.Text = "Lastname:";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(126, 41);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(291, 20);
            this.txtFirstname.TabIndex = 4;
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.Location = new System.Drawing.Point(10, 44);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(55, 13);
            this.lblFirstname.TabIndex = 3;
            this.lblFirstname.Text = "Firstname:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(10, 20);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Gender:";
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(180, 18);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(59, 17);
            this.rbFemale.TabIndex = 1;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(126, 19);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(48, 17);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // gbxRelationship
            // 
            this.gbxRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRelationship.Controls.Add(this.btnSearch);
            this.gbxRelationship.Controls.Add(this.txtSearch);
            this.gbxRelationship.Controls.Add(this.cbRelationshipType);
            this.gbxRelationship.Controls.Add(this.label1);
            this.gbxRelationship.Controls.Add(this.cbRelativePerson);
            this.gbxRelationship.Controls.Add(this.lblRelativePerson);
            this.gbxRelationship.Location = new System.Drawing.Point(6, 55);
            this.gbxRelationship.Name = "gbxRelationship";
            this.gbxRelationship.Size = new System.Drawing.Size(545, 104);
            this.gbxRelationship.TabIndex = 0;
            this.gbxRelationship.TabStop = false;
            this.gbxRelationship.Text = "Relationship";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(248, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(13, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(226, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // cbRelationshipType
            // 
            this.cbRelationshipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelationshipType.FormattingEnabled = true;
            this.cbRelationshipType.Location = new System.Drawing.Point(270, 73);
            this.cbRelationshipType.Name = "cbRelationshipType";
            this.cbRelationshipType.Size = new System.Drawing.Size(147, 21);
            this.cbRelationshipType.TabIndex = 3;
            this.cbRelationshipType.SelectedIndexChanged += new System.EventHandler(this.cbRelationshipType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Relationship Type";
            // 
            // cbRelativePerson
            // 
            this.cbRelativePerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelativePerson.FormattingEnabled = true;
            this.cbRelativePerson.Location = new System.Drawing.Point(13, 73);
            this.cbRelativePerson.Name = "cbRelativePerson";
            this.cbRelativePerson.Size = new System.Drawing.Size(226, 21);
            this.cbRelativePerson.TabIndex = 1;
            this.cbRelativePerson.SelectedIndexChanged += new System.EventHandler(this.cbRelativePerson_SelectedIndexChanged);
            // 
            // lblRelativePerson
            // 
            this.lblRelativePerson.AutoSize = true;
            this.lblRelativePerson.Location = new System.Drawing.Point(10, 57);
            this.lblRelativePerson.Name = "lblRelativePerson";
            this.lblRelativePerson.Size = new System.Drawing.Size(82, 13);
            this.lblRelativePerson.TabIndex = 0;
            this.lblRelativePerson.Text = "Relative Person";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.Image = global::FTree.View.Win32.Properties.Resources.ok;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(367, 522);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 1;
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
            this.btnCancel.Location = new System.Drawing.Point(473, 522);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorToolTip
            // 
            this.errorToolTip.AutomaticDelay = 10;
            this.errorToolTip.AutoPopDelay = 400;
            this.errorToolTip.ForeColor = System.Drawing.Color.Red;
            this.errorToolTip.InitialDelay = 10;
            this.errorToolTip.IsBalloon = true;
            this.errorToolTip.ReshowDelay = 2;
            this.errorToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // FamilyMemberForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(589, 566);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.personInfoTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FamilyMemberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Person";
            this.Load += new System.EventHandler(this.FamilyMemberForm_Load);
            this.personInfoTabControl.ResumeLayout(false);
            this.personInfoTabPage.ResumeLayout(false);
            this.personInfoTabPage.PerformLayout();
            this.gbxProfile.ResumeLayout(false);
            this.gbxProfile.PerformLayout();
            this.gbxRelationship.ResumeLayout(false);
            this.gbxRelationship.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl personInfoTabControl;
        private System.Windows.Forms.TabPage personInfoTabPage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbxRelationship;
        private System.Windows.Forms.Label lblRelativePerson;
        private System.Windows.Forms.ComboBox cbRelationshipType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRelativePerson;
        private System.Windows.Forms.GroupBox gbxProfile;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label lblFirstname;
        private FTree.View.Win32.Components.BaseTextBox txtLastname;
        private System.Windows.Forms.Label lblLastname;
        private FTree.View.Win32.Components.BaseTextBox txtFirstname;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.DateTimePicker birthdayPicker;
        private System.Windows.Forms.Label lblHomeTown;
        private System.Windows.Forms.ComboBox cbHomeTown;
        private System.Windows.Forms.ComboBox cbOccupation;
        private System.Windows.Forms.Label lblOccupation;
        private FTree.View.Win32.Components.BaseTextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.DateTimePicker dateJointPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker birthtimePicker;
        private System.Windows.Forms.Label lblBirthTime;
        private System.Windows.Forms.ToolTip errorToolTip;
        private System.Windows.Forms.Label lblFamilyName;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblRootPersonWarning;
        private FTree.View.Win32.Components.BaseTextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}