namespace FTree.View.Win32
{
    partial class FTreeMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTreeMainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.familyManagerToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addFamilyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addPersonToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.achieveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.reportDeathToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.reportToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
            this.familyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.achievementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.contentSplitContainer = new System.Windows.Forms.SplitContainer();
            this.wpfTreeViewHost = new System.Windows.Forms.Integration.ElementHost();
            this.familyTreeView = new FTree.View.Win32.Components.Wpf.FamilyTreeView();
            this.wpfVisualFTreeHost = new System.Windows.Forms.Integration.ElementHost();
            this.visualFamilyTreeView = new FTree.View.Win32.Components.Wpf.VisualFamilyTreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRootPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.mainLayoutPanel.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.contentSplitContainer.Panel1.SuspendLayout();
            this.contentSplitContainer.Panel2.SuspendLayout();
            this.contentSplitContainer.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Enabled = false;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(750, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "Main Menu Bar";
            this.mainMenuStrip.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(136, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(136, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Controls.Add(this.mainToolStrip, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.contentSplitContainer, 0, 1);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 2;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(750, 522);
            this.mainLayoutPanel.TabIndex = 1;
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.familyManagerToolStripButton,
            this.addFamilyToolStripButton,
            this.addPersonToolStripButton,
            this.achieveToolStripButton,
            this.reportDeathToolStripButton,
            this.toolStripSeparator1,
            this.reportToolStripSplitButton,
            this.settingsToolStripButton,
            this.toolStripSeparator5,
            this.exitToolStripButton});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(750, 68);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "Main Tool Strip";
            // 
            // familyManagerToolStripButton
            // 
            this.familyManagerToolStripButton.Image = global::FTree.View.Win32.Properties.Resources.family_manger;
            this.familyManagerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.familyManagerToolStripButton.Name = "familyManagerToolStripButton";
            this.familyManagerToolStripButton.Size = new System.Drawing.Size(80, 65);
            this.familyManagerToolStripButton.Text = "Family Manger";
            this.familyManagerToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.familyManagerToolStripButton.Click += new System.EventHandler(this.familyManagerToolStripButton_Click);
            // 
            // addFamilyToolStripButton
            // 
            this.addFamilyToolStripButton.Image = global::FTree.View.Win32.Properties.Resources.family;
            this.addFamilyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFamilyToolStripButton.Name = "addFamilyToolStripButton";
            this.addFamilyToolStripButton.Size = new System.Drawing.Size(77, 65);
            this.addFamilyToolStripButton.Text = "Create Family";
            this.addFamilyToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addFamilyToolStripButton.Click += new System.EventHandler(this.addFamilyToolStripButton_Click);
            // 
            // addPersonToolStripButton
            // 
            this.addPersonToolStripButton.Image = global::FTree.View.Win32.Properties.Resources.person_add;
            this.addPersonToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addPersonToolStripButton.Name = "addPersonToolStripButton";
            this.addPersonToolStripButton.Size = new System.Drawing.Size(78, 65);
            this.addPersonToolStripButton.Text = "Add Person";
            this.addPersonToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addPersonToolStripButton.ButtonClick += new System.EventHandler(this.addPersonToolStripButton_Click);
            // 
            // achieveToolStripButton
            // 
            this.achieveToolStripButton.Image = global::FTree.View.Win32.Properties.Resources.achievement;
            this.achieveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.achieveToolStripButton.Name = "achieveToolStripButton";
            this.achieveToolStripButton.Size = new System.Drawing.Size(61, 65);
            this.achieveToolStripButton.Text = "Achieve...";
            this.achieveToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.achieveToolStripButton.Click += new System.EventHandler(this.achieveToolStripButton_Click);
            // 
            // reportDeathToolStripButton
            // 
            this.reportDeathToolStripButton.Image = global::FTree.View.Win32.Properties.Resources.face_angel;
            this.reportDeathToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reportDeathToolStripButton.Name = "reportDeathToolStripButton";
            this.reportDeathToolStripButton.Size = new System.Drawing.Size(70, 65);
            this.reportDeathToolStripButton.Text = "Sad News...";
            this.reportDeathToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.reportDeathToolStripButton.Click += new System.EventHandler(this.reportDeathToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 68);
            // 
            // reportToolStripSplitButton
            // 
            this.reportToolStripSplitButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.familyToolStripMenuItem,
            this.achievementToolStripMenuItem});
            this.reportToolStripSplitButton.Image = global::FTree.View.Win32.Properties.Resources.report;
            this.reportToolStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reportToolStripSplitButton.Name = "reportToolStripSplitButton";
            this.reportToolStripSplitButton.Size = new System.Drawing.Size(64, 65);
            this.reportToolStripSplitButton.Text = "Report";
            this.reportToolStripSplitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.reportToolStripSplitButton.ButtonClick += new System.EventHandler(this.reportToolStripSplitButton_ButtonClick);
            // 
            // familyToolStripMenuItem
            // 
            this.familyToolStripMenuItem.Image = global::FTree.View.Win32.Properties.Resources.member_report;
            this.familyToolStripMenuItem.Name = "familyToolStripMenuItem";
            this.familyToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.familyToolStripMenuItem.Text = "Family";
            this.familyToolStripMenuItem.Click += new System.EventHandler(this.familyToolStripMenuItem_Click);
            // 
            // achievementToolStripMenuItem
            // 
            this.achievementToolStripMenuItem.Image = global::FTree.View.Win32.Properties.Resources.achievement_report;
            this.achievementToolStripMenuItem.Name = "achievementToolStripMenuItem";
            this.achievementToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.achievementToolStripMenuItem.Text = "Achievement";
            this.achievementToolStripMenuItem.Click += new System.EventHandler(this.achievementToolStripMenuItem_Click);
            // 
            // settingsToolStripButton
            // 
            this.settingsToolStripButton.Image = global::FTree.View.Win32.Properties.Resources.settings;
            this.settingsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsToolStripButton.Name = "settingsToolStripButton";
            this.settingsToolStripButton.Size = new System.Drawing.Size(62, 65);
            this.settingsToolStripButton.Text = "Settings...";
            this.settingsToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.settingsToolStripButton.Click += new System.EventHandler(this.settingsToolStripButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 68);
            // 
            // exitToolStripButton
            // 
            this.exitToolStripButton.Image = global::FTree.View.Win32.Properties.Resources.exit;
            this.exitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitToolStripButton.Name = "exitToolStripButton";
            this.exitToolStripButton.Size = new System.Drawing.Size(52, 65);
            this.exitToolStripButton.Text = "Exit";
            this.exitToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitToolStripButton.Click += new System.EventHandler(this.exitToolStripButton_Click);
            // 
            // contentSplitContainer
            // 
            this.contentSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentSplitContainer.Location = new System.Drawing.Point(3, 71);
            this.contentSplitContainer.Name = "contentSplitContainer";
            // 
            // contentSplitContainer.Panel1
            // 
            this.contentSplitContainer.Panel1.Controls.Add(this.wpfTreeViewHost);
            // 
            // contentSplitContainer.Panel2
            // 
            this.contentSplitContainer.Panel2.Controls.Add(this.wpfVisualFTreeHost);
            this.contentSplitContainer.Size = new System.Drawing.Size(744, 448);
            this.contentSplitContainer.SplitterDistance = 231;
            this.contentSplitContainer.TabIndex = 1;
            // 
            // wpfTreeViewHost
            // 
            this.wpfTreeViewHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpfTreeViewHost.Location = new System.Drawing.Point(0, 0);
            this.wpfTreeViewHost.Name = "wpfTreeViewHost";
            this.wpfTreeViewHost.Size = new System.Drawing.Size(231, 448);
            this.wpfTreeViewHost.TabIndex = 0;
            this.wpfTreeViewHost.Text = "wpfTreeViewHost";
            this.wpfTreeViewHost.Child = this.familyTreeView;
            // 
            // wpfVisualFTreeHost
            // 
            this.wpfVisualFTreeHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpfVisualFTreeHost.Location = new System.Drawing.Point(0, 0);
            this.wpfVisualFTreeHost.Name = "wpfVisualFTreeHost";
            this.wpfVisualFTreeHost.Size = new System.Drawing.Size(509, 448);
            this.wpfVisualFTreeHost.TabIndex = 0;
            this.wpfVisualFTreeHost.Text = "wpfVisualFTreeHost";
            this.wpfVisualFTreeHost.Child = this.visualFamilyTreeView;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRootPersonToolStripMenuItem,
            this.addPersonToolStripMenuItem,
            this.toolStripMenuItem1,
            this.propertiesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(156, 126);
            // 
            // addRootPersonToolStripMenuItem
            // 
            this.addRootPersonToolStripMenuItem.Name = "addRootPersonToolStripMenuItem";
            this.addRootPersonToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addRootPersonToolStripMenuItem.Text = "Add Root Person";
            // 
            // addPersonToolStripMenuItem
            // 
            this.addPersonToolStripMenuItem.Name = "addPersonToolStripMenuItem";
            this.addPersonToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addPersonToolStripMenuItem.Text = "Add Person";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // FTreeMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 522);
            this.Controls.Add(this.mainLayoutPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "FTreeMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTree - Family Tree Manager";
            this.Load += new System.EventHandler(this.FTreeMainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.contentSplitContainer.Panel1.ResumeLayout(false);
            this.contentSplitContainer.Panel2.ResumeLayout(false);
            this.contentSplitContainer.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton exitToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton settingsToolStripButton;
        private System.Windows.Forms.ToolStripButton addFamilyToolStripButton;
        private System.Windows.Forms.ToolStripSplitButton addPersonToolStripButton;
        private System.Windows.Forms.ToolStripButton achieveToolStripButton;
        private System.Windows.Forms.ToolStripButton reportDeathToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSplitButton reportToolStripSplitButton;
        private System.Windows.Forms.ToolStripMenuItem familyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem achievementToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton familyManagerToolStripButton;
        private System.Windows.Forms.SplitContainer contentSplitContainer;
        private System.Windows.Forms.Integration.ElementHost wpfTreeViewHost;
        private FTree.View.Win32.Components.Wpf.FamilyTreeView familyTreeView;
        private System.Windows.Forms.Integration.ElementHost wpfVisualFTreeHost;
        private FTree.View.Win32.Components.Wpf.VisualFamilyTreeView visualFamilyTreeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addRootPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

