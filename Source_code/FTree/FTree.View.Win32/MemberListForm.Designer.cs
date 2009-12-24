namespace FTree.View.Win32
{
    partial class MemberListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberListForm));
            this.dgMember = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new FTree.View.Win32.Components.BaseTextBox();
            this.lblFamilyName = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgMember)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMember
            // 
            this.dgMember.AllowUserToAddRows = false;
            this.dgMember.AllowUserToDeleteRows = false;
            this.dgMember.AllowUserToResizeColumns = false;
            this.dgMember.AllowUserToResizeRows = false;
            this.dgMember.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgMember.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMember.Location = new System.Drawing.Point(12, 69);
            this.dgMember.MultiSelect = false;
            this.dgMember.Name = "dgMember";
            this.dgMember.RowHeadersVisible = false;
            this.dgMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgMember.Size = new System.Drawing.Size(489, 319);
            this.dgMember.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(316, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search Person";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(298, 20);
            this.txtSearch.TabIndex = 7;
            // 
            // lblFamilyName
            // 
            this.lblFamilyName.AutoSize = true;
            this.lblFamilyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFamilyName.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblFamilyName.Location = new System.Drawing.Point(93, 9);
            this.lblFamilyName.Name = "lblFamilyName";
            this.lblFamilyName.Size = new System.Drawing.Size(78, 13);
            this.lblFamilyName.TabIndex = 22;
            this.lblFamilyName.Text = "Family Name";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(75, 13);
            this.lblInfo.TabIndex = 21;
            this.lblInfo.Text = "Family\'s name:";
            // 
            // MemberListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 400);
            this.Controls.Add(this.lblFamilyName);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgMember);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MemberListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Member List";
            this.Load += new System.EventHandler(this.MemberListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgMember)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMember;
        private System.Windows.Forms.Button btnSearch;
        private FTree.View.Win32.Components.BaseTextBox txtSearch;
        private System.Windows.Forms.Label lblFamilyName;
        private System.Windows.Forms.Label lblInfo;
    }
}