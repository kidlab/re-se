namespace FTree.View.Win32
{
    partial class FamilyManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamilyManagerForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgFamilies = new System.Windows.Forms.DataGridView();
            this.btnCreateFamily = new System.Windows.Forms.Button();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.btnLoadFamily = new System.Windows.Forms.Button();
            this.btnDeleteFamily = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgFamilies)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgFamilies);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 358);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Families";
            // 
            // dgFamilies
            // 
            this.dgFamilies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFamilies.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgFamilies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFamilies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFamilies.Location = new System.Drawing.Point(3, 16);
            this.dgFamilies.MultiSelect = false;
            this.dgFamilies.Name = "dgFamilies";
            this.dgFamilies.ReadOnly = true;
            this.dgFamilies.RowHeadersVisible = false;
            this.dgFamilies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgFamilies.Size = new System.Drawing.Size(282, 339);
            this.dgFamilies.TabIndex = 0;
            this.dgFamilies.SelectionChanged += new System.EventHandler(this.dgFamilies_SelectionChanged);
            // 
            // btnCreateFamily
            // 
            this.btnCreateFamily.Image = global::FTree.View.Win32.Properties.Resources.family_add;
            this.btnCreateFamily.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateFamily.Location = new System.Drawing.Point(328, 28);
            this.btnCreateFamily.Name = "btnCreateFamily";
            this.btnCreateFamily.Size = new System.Drawing.Size(155, 32);
            this.btnCreateFamily.TabIndex = 7;
            this.btnCreateFamily.Text = "Create New Family";
            this.btnCreateFamily.UseVisualStyleBackColor = true;
            this.btnCreateFamily.Click += new System.EventHandler(this.btnCreateFamily_Click);
            // 
            // btnChangeName
            // 
            this.btnChangeName.Image = global::FTree.View.Win32.Properties.Resources.edit;
            this.btnChangeName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeName.Location = new System.Drawing.Point(328, 66);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(155, 32);
            this.btnChangeName.TabIndex = 8;
            this.btnChangeName.Text = "Change Family Name";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // btnLoadFamily
            // 
            this.btnLoadFamily.Image = global::FTree.View.Win32.Properties.Resources.load;
            this.btnLoadFamily.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadFamily.Location = new System.Drawing.Point(328, 104);
            this.btnLoadFamily.Name = "btnLoadFamily";
            this.btnLoadFamily.Size = new System.Drawing.Size(155, 32);
            this.btnLoadFamily.TabIndex = 9;
            this.btnLoadFamily.Text = "Load Family";
            this.btnLoadFamily.UseVisualStyleBackColor = true;
            this.btnLoadFamily.Click += new System.EventHandler(this.btnLoadFamily_Click);
            // 
            // btnDeleteFamily
            // 
            this.btnDeleteFamily.Image = global::FTree.View.Win32.Properties.Resources.trash;
            this.btnDeleteFamily.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteFamily.Location = new System.Drawing.Point(328, 167);
            this.btnDeleteFamily.Name = "btnDeleteFamily";
            this.btnDeleteFamily.Size = new System.Drawing.Size(155, 32);
            this.btnDeleteFamily.TabIndex = 10;
            this.btnDeleteFamily.Text = "Delete Family";
            this.btnDeleteFamily.UseVisualStyleBackColor = true;
            this.btnDeleteFamily.Click += new System.EventHandler(this.btnDeleteFamily_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::FTree.View.Win32.Properties.Resources.cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(383, 338);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // FamilyManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(495, 382);
            this.Controls.Add(this.btnDeleteFamily);
            this.Controls.Add(this.btnLoadFamily);
            this.Controls.Add(this.btnChangeName);
            this.Controls.Add(this.btnCreateFamily);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FamilyManagerForm";
            this.Text = "Family Manager";
            this.Load += new System.EventHandler(this.FamilyManagerForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgFamilies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgFamilies;
        private System.Windows.Forms.Button btnCreateFamily;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.Button btnLoadFamily;
        private System.Windows.Forms.Button btnDeleteFamily;
    }
}