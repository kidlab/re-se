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
            this.personInfoTab = new System.Windows.Forms.TabPage();
            this.btnDeleteDeathInfo = new System.Windows.Forms.Button();
            this.lblDeathInfo = new System.Windows.Forms.Label();
            this.btnShowDeathInfo = new System.Windows.Forms.Button();
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
            this.lblMarriageDate = new System.Windows.Forms.Label();
            this.marriageDatePicker = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new FTree.View.Win32.Components.BaseTextBox();
            this.cbRelationshipType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRelativePerson = new System.Windows.Forms.ComboBox();
            this.lblRelativePerson = new System.Windows.Forms.Label();
            this.achievementTab = new System.Windows.Forms.TabPage();
            this.gbxAchievements = new System.Windows.Forms.GroupBox();
            this.dgAchievements = new System.Windows.Forms.DataGridView();
            this.btnEditAchievement = new System.Windows.Forms.Button();
            this.btnAddAchievement = new System.Windows.Forms.Button();
            this.btnDeleteAchievement = new System.Windows.Forms.Button();
            this.errorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.personInfoTabControl.SuspendLayout();
            this.personInfoTab.SuspendLayout();
            this.gbxProfile.SuspendLayout();
            this.gbxRelationship.SuspendLayout();
            this.achievementTab.SuspendLayout();
            this.gbxAchievements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAchievements)).BeginInit();
            this.SuspendLayout();
            // 
            // personInfoTabControl
            // 
            this.personInfoTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.personInfoTabControl.Controls.Add(this.personInfoTab);
            this.personInfoTabControl.Controls.Add(this.achievementTab);
            this.personInfoTabControl.Location = new System.Drawing.Point(12, 12);
            this.personInfoTabControl.Name = "personInfoTabControl";
            this.personInfoTabControl.SelectedIndex = 0;
            this.personInfoTabControl.Size = new System.Drawing.Size(565, 514);
            this.personInfoTabControl.TabIndex = 0;
            this.personInfoTabControl.SelectedIndexChanged += new System.EventHandler(this.personInfoTabControl_SelectedIndexChanged);
            // 
            // personInfoTab
            // 
            this.personInfoTab.Controls.Add(this.btnDeleteDeathInfo);
            this.personInfoTab.Controls.Add(this.lblDeathInfo);
            this.personInfoTab.Controls.Add(this.btnShowDeathInfo);
            this.personInfoTab.Controls.Add(this.lblRootPersonWarning);
            this.personInfoTab.Controls.Add(this.lblFamilyName);
            this.personInfoTab.Controls.Add(this.lblInfo);
            this.personInfoTab.Controls.Add(this.dateJointPicker);
            this.personInfoTab.Controls.Add(this.label2);
            this.personInfoTab.Controls.Add(this.gbxProfile);
            this.personInfoTab.Controls.Add(this.gbxRelationship);
            this.personInfoTab.Location = new System.Drawing.Point(4, 22);
            this.personInfoTab.Name = "personInfoTab";
            this.personInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.personInfoTab.Size = new System.Drawing.Size(557, 488);
            this.personInfoTab.TabIndex = 0;
            this.personInfoTab.Text = "Person Info";
            this.personInfoTab.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDeathInfo
            // 
            this.btnDeleteDeathInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDeathInfo.Enabled = false;
            this.btnDeleteDeathInfo.Image = global::FTree.View.Win32.Properties.Resources.delete;
            this.btnDeleteDeathInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteDeathInfo.Location = new System.Drawing.Point(304, 453);
            this.btnDeleteDeathInfo.Name = "btnDeleteDeathInfo";
            this.btnDeleteDeathInfo.Size = new System.Drawing.Size(144, 28);
            this.btnDeleteDeathInfo.TabIndex = 23;
            this.btnDeleteDeathInfo.Text = "Delete Death Info";
            this.btnDeleteDeathInfo.UseVisualStyleBackColor = true;
            this.btnDeleteDeathInfo.Visible = false;
            this.btnDeleteDeathInfo.Click += new System.EventHandler(this.btnDeleteDeathInfo_Click);
            // 
            // lblDeathInfo
            // 
            this.lblDeathInfo.AutoSize = true;
            this.lblDeathInfo.Enabled = false;
            this.lblDeathInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeathInfo.ForeColor = System.Drawing.Color.Red;
            this.lblDeathInfo.Location = new System.Drawing.Point(13, 461);
            this.lblDeathInfo.Name = "lblDeathInfo";
            this.lblDeathInfo.Size = new System.Drawing.Size(135, 13);
            this.lblDeathInfo.TabIndex = 22;
            this.lblDeathInfo.Text = "This person was dead.";
            this.lblDeathInfo.Visible = false;
            // 
            // btnShowDeathInfo
            // 
            this.btnShowDeathInfo.Enabled = false;
            this.btnShowDeathInfo.Image = global::FTree.View.Win32.Properties.Resources.death_info22;
            this.btnShowDeathInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowDeathInfo.Location = new System.Drawing.Point(154, 453);
            this.btnShowDeathInfo.Name = "btnShowDeathInfo";
            this.btnShowDeathInfo.Size = new System.Drawing.Size(144, 28);
            this.btnShowDeathInfo.TabIndex = 21;
            this.btnShowDeathInfo.Text = "Show Death Info...";
            this.btnShowDeathInfo.UseVisualStyleBackColor = true;
            this.btnShowDeathInfo.Visible = false;
            this.btnShowDeathInfo.Click += new System.EventHandler(this.btnShowDeathInfo_Click);
            // 
            // lblRootPersonWarning
            // 
            this.lblRootPersonWarning.AutoSize = true;
            this.lblRootPersonWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRootPersonWarning.ForeColor = System.Drawing.Color.Red;
            this.lblRootPersonWarning.Location = new System.Drawing.Point(13, 34);
            this.lblRootPersonWarning.Name = "lblRootPersonWarning";
            this.lblRootPersonWarning.Size = new System.Drawing.Size(207, 13);
            this.lblRootPersonWarning.TabIndex = 4;
            this.lblRootPersonWarning.Text = "This is the root person of the family";
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
            this.dateJointPicker.Location = new System.Drawing.Point(132, 418);
            this.dateJointPicker.Name = "dateJointPicker";
            this.dateJointPicker.Size = new System.Drawing.Size(200, 20);
            this.dateJointPicker.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 422);
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
            this.gbxProfile.Size = new System.Drawing.Size(545, 235);
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
            this.gbxRelationship.Controls.Add(this.lblMarriageDate);
            this.gbxRelationship.Controls.Add(this.marriageDatePicker);
            this.gbxRelationship.Controls.Add(this.btnSearch);
            this.gbxRelationship.Controls.Add(this.txtSearch);
            this.gbxRelationship.Controls.Add(this.cbRelationshipType);
            this.gbxRelationship.Controls.Add(this.label1);
            this.gbxRelationship.Controls.Add(this.cbRelativePerson);
            this.gbxRelationship.Controls.Add(this.lblRelativePerson);
            this.gbxRelationship.Location = new System.Drawing.Point(6, 55);
            this.gbxRelationship.Name = "gbxRelationship";
            this.gbxRelationship.Size = new System.Drawing.Size(545, 98);
            this.gbxRelationship.TabIndex = 0;
            this.gbxRelationship.TabStop = false;
            this.gbxRelationship.Text = "Relationship";
            // 
            // lblMarriageDate
            // 
            this.lblMarriageDate.AutoSize = true;
            this.lblMarriageDate.Location = new System.Drawing.Point(381, 56);
            this.lblMarriageDate.Name = "lblMarriageDate";
            this.lblMarriageDate.Size = new System.Drawing.Size(74, 13);
            this.lblMarriageDate.TabIndex = 10;
            this.lblMarriageDate.Text = "Marriage Date";
            // 
            // marriageDatePicker
            // 
            this.marriageDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.marriageDatePicker.Location = new System.Drawing.Point(384, 72);
            this.marriageDatePicker.Name = "marriageDatePicker";
            this.marriageDatePicker.Size = new System.Drawing.Size(104, 20);
            this.marriageDatePicker.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(317, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search Person";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(13, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(298, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // cbRelationshipType
            // 
            this.cbRelationshipType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelationshipType.FormattingEnabled = true;
            this.cbRelationshipType.Location = new System.Drawing.Point(231, 73);
            this.cbRelationshipType.Name = "cbRelationshipType";
            this.cbRelationshipType.Size = new System.Drawing.Size(147, 21);
            this.cbRelationshipType.TabIndex = 3;
            this.cbRelationshipType.SelectedIndexChanged += new System.EventHandler(this.cbRelationshipType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 57);
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
            this.cbRelativePerson.Size = new System.Drawing.Size(212, 21);
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
            // achievementTab
            // 
            this.achievementTab.Controls.Add(this.gbxAchievements);
            this.achievementTab.Controls.Add(this.btnEditAchievement);
            this.achievementTab.Controls.Add(this.btnAddAchievement);
            this.achievementTab.Controls.Add(this.btnDeleteAchievement);
            this.achievementTab.Location = new System.Drawing.Point(4, 22);
            this.achievementTab.Name = "achievementTab";
            this.achievementTab.Padding = new System.Windows.Forms.Padding(3);
            this.achievementTab.Size = new System.Drawing.Size(557, 488);
            this.achievementTab.TabIndex = 1;
            this.achievementTab.Text = "Ahievements";
            this.achievementTab.UseVisualStyleBackColor = true;
            // 
            // gbxAchievements
            // 
            this.gbxAchievements.Controls.Add(this.dgAchievements);
            this.gbxAchievements.Location = new System.Drawing.Point(6, 16);
            this.gbxAchievements.Name = "gbxAchievements";
            this.gbxAchievements.Size = new System.Drawing.Size(445, 464);
            this.gbxAchievements.TabIndex = 17;
            this.gbxAchievements.TabStop = false;
            this.gbxAchievements.Text = "All achievements of this person";
            // 
            // dgAchievements
            // 
            this.dgAchievements.AllowUserToAddRows = false;
            this.dgAchievements.AllowUserToDeleteRows = false;
            this.dgAchievements.AllowUserToOrderColumns = true;
            this.dgAchievements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAchievements.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgAchievements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAchievements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAchievements.Location = new System.Drawing.Point(3, 16);
            this.dgAchievements.MultiSelect = false;
            this.dgAchievements.Name = "dgAchievements";
            this.dgAchievements.ReadOnly = true;
            this.dgAchievements.RowHeadersVisible = false;
            this.dgAchievements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgAchievements.Size = new System.Drawing.Size(439, 445);
            this.dgAchievements.TabIndex = 16;
            this.dgAchievements.SelectionChanged += new System.EventHandler(this.dgAchievements_SelectionChanged);
            // 
            // btnEditAchievement
            // 
            this.btnEditAchievement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAchievement.Image = global::FTree.View.Win32.Properties.Resources.edit;
            this.btnEditAchievement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditAchievement.Location = new System.Drawing.Point(462, 70);
            this.btnEditAchievement.Name = "btnEditAchievement";
            this.btnEditAchievement.Size = new System.Drawing.Size(89, 32);
            this.btnEditAchievement.TabIndex = 14;
            this.btnEditAchievement.Text = "Edit";
            this.btnEditAchievement.UseVisualStyleBackColor = true;
            this.btnEditAchievement.Click += new System.EventHandler(this.btnEditAchievement_Click);
            // 
            // btnAddAchievement
            // 
            this.btnAddAchievement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAchievement.Image = global::FTree.View.Win32.Properties.Resources.add;
            this.btnAddAchievement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAchievement.Location = new System.Drawing.Point(462, 32);
            this.btnAddAchievement.Name = "btnAddAchievement";
            this.btnAddAchievement.Size = new System.Drawing.Size(89, 32);
            this.btnAddAchievement.TabIndex = 13;
            this.btnAddAchievement.Text = "Add";
            this.btnAddAchievement.UseVisualStyleBackColor = true;
            this.btnAddAchievement.Click += new System.EventHandler(this.btnAddAchievement_Click);
            // 
            // btnDeleteAchievement
            // 
            this.btnDeleteAchievement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAchievement.Image = global::FTree.View.Win32.Properties.Resources.delete;
            this.btnDeleteAchievement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteAchievement.Location = new System.Drawing.Point(462, 108);
            this.btnDeleteAchievement.Name = "btnDeleteAchievement";
            this.btnDeleteAchievement.Size = new System.Drawing.Size(89, 32);
            this.btnDeleteAchievement.TabIndex = 15;
            this.btnDeleteAchievement.Text = "Delete";
            this.btnDeleteAchievement.UseVisualStyleBackColor = true;
            this.btnDeleteAchievement.Click += new System.EventHandler(this.btnDeleteAchievement_Click);
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
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.AutoSize = true;
            this.btnOK.Image = global::FTree.View.Win32.Properties.Resources.ok;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(367, 532);
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
            this.btnCancel.Location = new System.Drawing.Point(473, 532);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FamilyMemberForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(589, 576);
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
            this.personInfoTab.ResumeLayout(false);
            this.personInfoTab.PerformLayout();
            this.gbxProfile.ResumeLayout(false);
            this.gbxProfile.PerformLayout();
            this.gbxRelationship.ResumeLayout(false);
            this.gbxRelationship.PerformLayout();
            this.achievementTab.ResumeLayout(false);
            this.gbxAchievements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAchievements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl personInfoTabControl;
        private System.Windows.Forms.TabPage personInfoTab;
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
        private System.Windows.Forms.Label lblDeathInfo;
        private System.Windows.Forms.Button btnShowDeathInfo;
        private System.Windows.Forms.TabPage achievementTab;
        private System.Windows.Forms.DataGridView dgAchievements;
        private System.Windows.Forms.Button btnAddAchievement;
        private System.Windows.Forms.Button btnDeleteAchievement;
        private System.Windows.Forms.Button btnEditAchievement;
        private System.Windows.Forms.GroupBox gbxAchievements;
        private System.Windows.Forms.Button btnDeleteDeathInfo;
        private System.Windows.Forms.DateTimePicker marriageDatePicker;
        private System.Windows.Forms.Label lblMarriageDate;
    }
}