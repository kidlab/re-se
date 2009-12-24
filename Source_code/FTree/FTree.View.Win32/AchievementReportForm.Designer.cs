namespace FTree.View.Win32
{
    partial class AchievementReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AchievementReportForm));
            this.grbxInfo = new System.Windows.Forms.GroupBox();
            this.txtToYear = new System.Windows.Forms.MaskedTextBox();
            this.txtFromYear = new System.Windows.Forms.MaskedTextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblToYear = new System.Windows.Forms.Label();
            this.lblFromYear = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dgResult = new System.Windows.Forms.DataGridView();
            this.grbxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grbxInfo
            // 
            this.grbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbxInfo.Controls.Add(this.txtToYear);
            this.grbxInfo.Controls.Add(this.txtFromYear);
            this.grbxInfo.Controls.Add(this.btnSearch);
            this.grbxInfo.Controls.Add(this.lblToYear);
            this.grbxInfo.Controls.Add(this.lblFromYear);
            this.grbxInfo.Location = new System.Drawing.Point(12, 12);
            this.grbxInfo.Name = "grbxInfo";
            this.grbxInfo.Size = new System.Drawing.Size(424, 114);
            this.grbxInfo.TabIndex = 1;
            this.grbxInfo.TabStop = false;
            this.grbxInfo.Text = "Achievement Report";
            // 
            // txtToYear
            // 
            this.txtToYear.Location = new System.Drawing.Point(72, 74);
            this.txtToYear.Mask = "0000";
            this.txtToYear.Name = "txtToYear";
            this.txtToYear.Size = new System.Drawing.Size(100, 20);
            this.txtToYear.TabIndex = 6;
            // 
            // txtFromYear
            // 
            this.txtFromYear.Location = new System.Drawing.Point(72, 30);
            this.txtFromYear.Mask = "0000";
            this.txtFromYear.Name = "txtFromYear";
            this.txtFromYear.Size = new System.Drawing.Size(100, 20);
            this.txtFromYear.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(208, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblToYear
            // 
            this.lblToYear.AutoSize = true;
            this.lblToYear.Location = new System.Drawing.Point(20, 77);
            this.lblToYear.Name = "lblToYear";
            this.lblToYear.Size = new System.Drawing.Size(46, 13);
            this.lblToYear.TabIndex = 1;
            this.lblToYear.Text = "To year:";
            // 
            // lblFromYear
            // 
            this.lblFromYear.AutoSize = true;
            this.lblFromYear.Location = new System.Drawing.Point(10, 33);
            this.lblFromYear.Name = "lblFromYear";
            this.lblFromYear.Size = new System.Drawing.Size(56, 13);
            this.lblFromYear.TabIndex = 0;
            this.lblFromYear.Text = "From year:";
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
            this.dgResult.Location = new System.Drawing.Point(12, 132);
            this.dgResult.Name = "dgResult";
            this.dgResult.ReadOnly = true;
            this.dgResult.Size = new System.Drawing.Size(424, 255);
            this.dgResult.TabIndex = 2;
            this.toolTip.SetToolTip(this.dgResult, "Show list of Achievement");
            // 
            // AchievementReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 399);
            this.Controls.Add(this.dgResult);
            this.Controls.Add(this.grbxInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AchievementReportForm";
            this.Text = "Achievement Report";
            this.grbxInfo.ResumeLayout(false);
            this.grbxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbxInfo;
        private System.Windows.Forms.Label lblToYear;
        private System.Windows.Forms.Label lblFromYear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.MaskedTextBox txtFromYear;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MaskedTextBox txtToYear;
        private System.Windows.Forms.DataGridView dgResult;
    }
}