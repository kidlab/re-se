﻿namespace FTree.View.Win32
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabRelation_Type = new System.Windows.Forms.TabPage();
            this.btnAddRelationType = new System.Windows.Forms.Button();
            this.btnDeleteRelationType = new System.Windows.Forms.Button();
            this.gbxRelationTypes = new System.Windows.Forms.GroupBox();
            this.dgRelationTypes = new System.Windows.Forms.DataGridView();
            this.tabHomeTown = new System.Windows.Forms.TabPage();
            this.gbxHomeTowns = new System.Windows.Forms.GroupBox();
            this.dgHomeTown = new System.Windows.Forms.DataGridView();
            this.tabOccupation = new System.Windows.Forms.TabPage();
            this.gbxCarrers = new System.Windows.Forms.GroupBox();
            this.dgCareers = new System.Windows.Forms.DataGridView();
            this.tabAchievements = new System.Windows.Forms.TabPage();
            this.gbxAchievement = new System.Windows.Forms.GroupBox();
            this.dgAchievements = new System.Windows.Forms.DataGridView();
            this.tabDeathReason = new System.Windows.Forms.TabPage();
            this.gbxDeathReasons = new System.Windows.Forms.GroupBox();
            this.dgDeathReasons = new System.Windows.Forms.DataGridView();
            this.tabBuryPlace = new System.Windows.Forms.TabPage();
            this.gbxBuryPlaces = new System.Windows.Forms.GroupBox();
            this.dgBuryPlaces = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.tabRelation_Type.SuspendLayout();
            this.gbxRelationTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRelationTypes)).BeginInit();
            this.tabHomeTown.SuspendLayout();
            this.gbxHomeTowns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHomeTown)).BeginInit();
            this.tabOccupation.SuspendLayout();
            this.gbxCarrers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCareers)).BeginInit();
            this.tabAchievements.SuspendLayout();
            this.gbxAchievement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAchievements)).BeginInit();
            this.tabDeathReason.SuspendLayout();
            this.gbxDeathReasons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeathReasons)).BeginInit();
            this.tabBuryPlace.SuspendLayout();
            this.gbxBuryPlaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBuryPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.tabRelation_Type);
            this.mainTabControl.Controls.Add(this.tabHomeTown);
            this.mainTabControl.Controls.Add(this.tabOccupation);
            this.mainTabControl.Controls.Add(this.tabAchievements);
            this.mainTabControl.Controls.Add(this.tabDeathReason);
            this.mainTabControl.Controls.Add(this.tabBuryPlace);
            this.mainTabControl.Location = new System.Drawing.Point(12, 12);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(583, 414);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // tabRelation_Type
            // 
            this.tabRelation_Type.Controls.Add(this.btnAddRelationType);
            this.tabRelation_Type.Controls.Add(this.btnDeleteRelationType);
            this.tabRelation_Type.Controls.Add(this.gbxRelationTypes);
            this.tabRelation_Type.Location = new System.Drawing.Point(4, 22);
            this.tabRelation_Type.Name = "tabRelation_Type";
            this.tabRelation_Type.Padding = new System.Windows.Forms.Padding(3);
            this.tabRelation_Type.Size = new System.Drawing.Size(575, 388);
            this.tabRelation_Type.TabIndex = 0;
            this.tabRelation_Type.Text = "Relation Types";
            this.tabRelation_Type.UseVisualStyleBackColor = true;
            // 
            // btnAddRelationType
            // 
            this.btnAddRelationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRelationType.Image = global::FTree.View.Win32.Properties.Resources.add;
            this.btnAddRelationType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRelationType.Location = new System.Drawing.Point(304, 19);
            this.btnAddRelationType.Name = "btnAddRelationType";
            this.btnAddRelationType.Size = new System.Drawing.Size(89, 32);
            this.btnAddRelationType.TabIndex = 12;
            this.btnAddRelationType.Text = "Add";
            this.btnAddRelationType.UseVisualStyleBackColor = true;
            this.btnAddRelationType.Click += new System.EventHandler(this.btnAddRelationType_Click);
            // 
            // btnDeleteRelationType
            // 
            this.btnDeleteRelationType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteRelationType.Image = global::FTree.View.Win32.Properties.Resources.delete;
            this.btnDeleteRelationType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteRelationType.Location = new System.Drawing.Point(304, 57);
            this.btnDeleteRelationType.Name = "btnDeleteRelationType";
            this.btnDeleteRelationType.Size = new System.Drawing.Size(89, 32);
            this.btnDeleteRelationType.TabIndex = 11;
            this.btnDeleteRelationType.Text = "Delete";
            this.btnDeleteRelationType.UseVisualStyleBackColor = true;
            this.btnDeleteRelationType.Click += new System.EventHandler(this.btnDeleteRelationType_Click);
            // 
            // gbxRelationTypes
            // 
            this.gbxRelationTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxRelationTypes.Controls.Add(this.dgRelationTypes);
            this.gbxRelationTypes.Location = new System.Drawing.Point(3, 3);
            this.gbxRelationTypes.Name = "gbxRelationTypes";
            this.gbxRelationTypes.Size = new System.Drawing.Size(295, 331);
            this.gbxRelationTypes.TabIndex = 0;
            this.gbxRelationTypes.TabStop = false;
            this.gbxRelationTypes.Text = "Available Relation Types";
            // 
            // dgRelationTypes
            // 
            this.dgRelationTypes.AllowUserToAddRows = false;
            this.dgRelationTypes.AllowUserToDeleteRows = false;
            this.dgRelationTypes.AllowUserToResizeColumns = false;
            this.dgRelationTypes.AllowUserToResizeRows = false;
            this.dgRelationTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRelationTypes.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgRelationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRelationTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRelationTypes.Location = new System.Drawing.Point(3, 16);
            this.dgRelationTypes.Name = "dgRelationTypes";
            this.dgRelationTypes.RowHeadersVisible = false;
            this.dgRelationTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRelationTypes.Size = new System.Drawing.Size(289, 312);
            this.dgRelationTypes.TabIndex = 1;
            this.dgRelationTypes.SelectionChanged += new System.EventHandler(this.dgRelationTypes_SelectionChanged);
            // 
            // tabHomeTown
            // 
            this.tabHomeTown.Controls.Add(this.gbxHomeTowns);
            this.tabHomeTown.Location = new System.Drawing.Point(4, 22);
            this.tabHomeTown.Name = "tabHomeTown";
            this.tabHomeTown.Padding = new System.Windows.Forms.Padding(3);
            this.tabHomeTown.Size = new System.Drawing.Size(575, 388);
            this.tabHomeTown.TabIndex = 1;
            this.tabHomeTown.Text = "Home Towns";
            this.tabHomeTown.UseVisualStyleBackColor = true;
            // 
            // gbxHomeTowns
            // 
            this.gbxHomeTowns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxHomeTowns.Controls.Add(this.dgHomeTown);
            this.gbxHomeTowns.Location = new System.Drawing.Point(3, 3);
            this.gbxHomeTowns.Name = "gbxHomeTowns";
            this.gbxHomeTowns.Size = new System.Drawing.Size(295, 331);
            this.gbxHomeTowns.TabIndex = 1;
            this.gbxHomeTowns.TabStop = false;
            this.gbxHomeTowns.Text = "Available Home Towns";
            // 
            // dgHomeTown
            // 
            this.dgHomeTown.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHomeTown.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgHomeTown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHomeTown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHomeTown.Location = new System.Drawing.Point(3, 16);
            this.dgHomeTown.MultiSelect = false;
            this.dgHomeTown.Name = "dgHomeTown";
            this.dgHomeTown.ReadOnly = true;
            this.dgHomeTown.RowHeadersVisible = false;
            this.dgHomeTown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgHomeTown.Size = new System.Drawing.Size(289, 312);
            this.dgHomeTown.TabIndex = 2;
            // 
            // tabOccupation
            // 
            this.tabOccupation.Controls.Add(this.gbxCarrers);
            this.tabOccupation.Location = new System.Drawing.Point(4, 22);
            this.tabOccupation.Name = "tabOccupation";
            this.tabOccupation.Size = new System.Drawing.Size(575, 388);
            this.tabOccupation.TabIndex = 2;
            this.tabOccupation.Text = "Occupations";
            this.tabOccupation.UseVisualStyleBackColor = true;
            // 
            // gbxCarrers
            // 
            this.gbxCarrers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxCarrers.Controls.Add(this.dgCareers);
            this.gbxCarrers.Location = new System.Drawing.Point(3, 3);
            this.gbxCarrers.Name = "gbxCarrers";
            this.gbxCarrers.Size = new System.Drawing.Size(295, 331);
            this.gbxCarrers.TabIndex = 1;
            this.gbxCarrers.TabStop = false;
            this.gbxCarrers.Text = "Available Careers";
            // 
            // dgCareers
            // 
            this.dgCareers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCareers.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgCareers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCareers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCareers.Location = new System.Drawing.Point(3, 16);
            this.dgCareers.MultiSelect = false;
            this.dgCareers.Name = "dgCareers";
            this.dgCareers.ReadOnly = true;
            this.dgCareers.RowHeadersVisible = false;
            this.dgCareers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCareers.Size = new System.Drawing.Size(289, 312);
            this.dgCareers.TabIndex = 3;
            // 
            // tabAchievements
            // 
            this.tabAchievements.Controls.Add(this.gbxAchievement);
            this.tabAchievements.Location = new System.Drawing.Point(4, 22);
            this.tabAchievements.Name = "tabAchievements";
            this.tabAchievements.Size = new System.Drawing.Size(575, 388);
            this.tabAchievements.TabIndex = 3;
            this.tabAchievements.Text = "Achievements";
            this.tabAchievements.UseVisualStyleBackColor = true;
            // 
            // gbxAchievement
            // 
            this.gbxAchievement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxAchievement.Controls.Add(this.dgAchievements);
            this.gbxAchievement.Location = new System.Drawing.Point(3, 3);
            this.gbxAchievement.Name = "gbxAchievement";
            this.gbxAchievement.Size = new System.Drawing.Size(295, 331);
            this.gbxAchievement.TabIndex = 1;
            this.gbxAchievement.TabStop = false;
            this.gbxAchievement.Text = "Available Achievemen Types";
            // 
            // dgAchievements
            // 
            this.dgAchievements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAchievements.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgAchievements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAchievements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAchievements.Location = new System.Drawing.Point(3, 16);
            this.dgAchievements.MultiSelect = false;
            this.dgAchievements.Name = "dgAchievements";
            this.dgAchievements.ReadOnly = true;
            this.dgAchievements.RowHeadersVisible = false;
            this.dgAchievements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAchievements.Size = new System.Drawing.Size(289, 312);
            this.dgAchievements.TabIndex = 4;
            // 
            // tabDeathReason
            // 
            this.tabDeathReason.Controls.Add(this.gbxDeathReasons);
            this.tabDeathReason.Location = new System.Drawing.Point(4, 22);
            this.tabDeathReason.Name = "tabDeathReason";
            this.tabDeathReason.Size = new System.Drawing.Size(575, 388);
            this.tabDeathReason.TabIndex = 4;
            this.tabDeathReason.Text = "Death Reasons";
            this.tabDeathReason.UseVisualStyleBackColor = true;
            // 
            // gbxDeathReasons
            // 
            this.gbxDeathReasons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxDeathReasons.Controls.Add(this.dgDeathReasons);
            this.gbxDeathReasons.Location = new System.Drawing.Point(3, 3);
            this.gbxDeathReasons.Name = "gbxDeathReasons";
            this.gbxDeathReasons.Size = new System.Drawing.Size(295, 331);
            this.gbxDeathReasons.TabIndex = 1;
            this.gbxDeathReasons.TabStop = false;
            this.gbxDeathReasons.Text = "Available Death Reasons";
            // 
            // dgDeathReasons
            // 
            this.dgDeathReasons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDeathReasons.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgDeathReasons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeathReasons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDeathReasons.Location = new System.Drawing.Point(3, 16);
            this.dgDeathReasons.MultiSelect = false;
            this.dgDeathReasons.Name = "dgDeathReasons";
            this.dgDeathReasons.ReadOnly = true;
            this.dgDeathReasons.RowHeadersVisible = false;
            this.dgDeathReasons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDeathReasons.Size = new System.Drawing.Size(289, 312);
            this.dgDeathReasons.TabIndex = 5;
            // 
            // tabBuryPlace
            // 
            this.tabBuryPlace.Controls.Add(this.gbxBuryPlaces);
            this.tabBuryPlace.Location = new System.Drawing.Point(4, 22);
            this.tabBuryPlace.Name = "tabBuryPlace";
            this.tabBuryPlace.Size = new System.Drawing.Size(575, 388);
            this.tabBuryPlace.TabIndex = 5;
            this.tabBuryPlace.Text = "Bury Places";
            this.tabBuryPlace.UseVisualStyleBackColor = true;
            // 
            // gbxBuryPlaces
            // 
            this.gbxBuryPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxBuryPlaces.Controls.Add(this.dgBuryPlaces);
            this.gbxBuryPlaces.Location = new System.Drawing.Point(3, 3);
            this.gbxBuryPlaces.Name = "gbxBuryPlaces";
            this.gbxBuryPlaces.Size = new System.Drawing.Size(295, 331);
            this.gbxBuryPlaces.TabIndex = 1;
            this.gbxBuryPlaces.TabStop = false;
            this.gbxBuryPlaces.Text = "Available Bury Places";
            // 
            // dgBuryPlaces
            // 
            this.dgBuryPlaces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBuryPlaces.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgBuryPlaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBuryPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBuryPlaces.Location = new System.Drawing.Point(3, 16);
            this.dgBuryPlaces.MultiSelect = false;
            this.dgBuryPlaces.Name = "dgBuryPlaces";
            this.dgBuryPlaces.ReadOnly = true;
            this.dgBuryPlaces.RowHeadersVisible = false;
            this.dgBuryPlaces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBuryPlaces.Size = new System.Drawing.Size(289, 312);
            this.dgBuryPlaces.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::FTree.View.Win32.Properties.Resources.cancel;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(495, 432);
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
            this.btnOK.Location = new System.Drawing.Point(389, 432);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(607, 476);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.mainTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings Manager";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.mainTabControl.ResumeLayout(false);
            this.tabRelation_Type.ResumeLayout(false);
            this.gbxRelationTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRelationTypes)).EndInit();
            this.tabHomeTown.ResumeLayout(false);
            this.gbxHomeTowns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgHomeTown)).EndInit();
            this.tabOccupation.ResumeLayout(false);
            this.gbxCarrers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCareers)).EndInit();
            this.tabAchievements.ResumeLayout(false);
            this.gbxAchievement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAchievements)).EndInit();
            this.tabDeathReason.ResumeLayout(false);
            this.gbxDeathReasons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDeathReasons)).EndInit();
            this.tabBuryPlace.ResumeLayout(false);
            this.gbxBuryPlaces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBuryPlaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabRelation_Type;
        private System.Windows.Forms.TabPage tabHomeTown;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabPage tabOccupation;
        private System.Windows.Forms.TabPage tabAchievements;
        private System.Windows.Forms.TabPage tabDeathReason;
        private System.Windows.Forms.TabPage tabBuryPlace;
        private System.Windows.Forms.GroupBox gbxRelationTypes;
        private System.Windows.Forms.GroupBox gbxHomeTowns;
        private System.Windows.Forms.GroupBox gbxCarrers;
        private System.Windows.Forms.GroupBox gbxAchievement;
        private System.Windows.Forms.GroupBox gbxDeathReasons;
        private System.Windows.Forms.GroupBox gbxBuryPlaces;
        private System.Windows.Forms.DataGridView dgRelationTypes;
        private System.Windows.Forms.DataGridView dgHomeTown;
        private System.Windows.Forms.DataGridView dgCareers;
        private System.Windows.Forms.DataGridView dgAchievements;
        private System.Windows.Forms.DataGridView dgDeathReasons;
        private System.Windows.Forms.DataGridView dgBuryPlaces;
        private System.Windows.Forms.Button btnDeleteRelationType;
        private System.Windows.Forms.Button btnAddRelationType;
    }
}