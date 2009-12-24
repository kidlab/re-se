namespace FTree.View.Win32
{
    partial class FamilyReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamilyReportForm));
            this.gbxInfo = new System.Windows.Forms.GroupBox();
            this.lblToYear = new System.Windows.Forms.Label();
            this.lblFromYear = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtToYear = new System.Windows.Forms.MaskedTextBox();
            this.txtFromYear = new System.Windows.Forms.MaskedTextBox();
            this.dgResult = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.gbxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxInfo
            // 
            this.gbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxInfo.Controls.Add(this.lblToYear);
            this.gbxInfo.Controls.Add(this.lblFromYear);
            this.gbxInfo.Controls.Add(this.btnSearch);
            this.gbxInfo.Controls.Add(this.txtToYear);
            this.gbxInfo.Controls.Add(this.txtFromYear);
            this.gbxInfo.Location = new System.Drawing.Point(12, 12);
            this.gbxInfo.Name = "gbxInfo";
            this.gbxInfo.Size = new System.Drawing.Size(453, 124);
            this.gbxInfo.TabIndex = 0;
            this.gbxInfo.TabStop = false;
            this.gbxInfo.Text = "Family Report";
            // 
            // lblToYear
            // 
            this.lblToYear.AutoSize = true;
            this.lblToYear.Location = new System.Drawing.Point(16, 76);
            this.lblToYear.Name = "lblToYear";
            this.lblToYear.Size = new System.Drawing.Size(46, 13);
            this.lblToYear.TabIndex = 6;
            this.lblToYear.Text = "To year:";
            // 
            // lblFromYear
            // 
            this.lblFromYear.AutoSize = true;
            this.lblFromYear.Location = new System.Drawing.Point(6, 32);
            this.lblFromYear.Name = "lblFromYear";
            this.lblFromYear.Size = new System.Drawing.Size(56, 13);
            this.lblFromYear.TabIndex = 5;
            this.lblFromYear.Text = "From year:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(203, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtToYear
            // 
            this.txtToYear.Location = new System.Drawing.Point(68, 73);
            this.txtToYear.Mask = "0000";
            this.txtToYear.Name = "txtToYear";
            this.txtToYear.Size = new System.Drawing.Size(100, 20);
            this.txtToYear.TabIndex = 3;
            // 
            // txtFromYear
            // 
            this.txtFromYear.Location = new System.Drawing.Point(68, 29);
            this.txtFromYear.Mask = "0000";
            this.txtFromYear.Name = "txtFromYear";
            this.txtFromYear.Size = new System.Drawing.Size(100, 20);
            this.txtFromYear.TabIndex = 2;
            // 
            // dgResult
            // 
            this.dgResult.AllowUserToAddRows = false;
            this.dgResult.AllowUserToDeleteRows = false;
            this.dgResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgResult.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResult.Location = new System.Drawing.Point(12, 155);
            this.dgResult.MultiSelect = false;
            this.dgResult.Name = "dgResult";
            this.dgResult.ReadOnly = true;
            this.dgResult.Size = new System.Drawing.Size(453, 184);
            this.dgResult.TabIndex = 1;
            // 
            // FamilyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 351);
            this.Controls.Add(this.dgResult);
            this.Controls.Add(this.gbxInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FamilyReportForm";
            this.Text = "Family Report";
            this.Load += new System.EventHandler(this.FamilyReport_Load);
            this.gbxInfo.ResumeLayout(false);
            this.gbxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxInfo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox txtToYear;
        private System.Windows.Forms.MaskedTextBox txtFromYear;
        private System.Windows.Forms.DataGridView dgResult;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblToYear;
        private System.Windows.Forms.Label lblFromYear;
    }
}