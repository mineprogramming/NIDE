namespace NIDE
{
    partial class fMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiFind = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiAutoIndent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiComment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInserts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.craftRecipieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCoreEngineDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.cmsTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewTexture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteTexture = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitter = new System.Windows.Forms.Splitter();
            this.fctbMain = new FastColoredTextBoxNS.FastColoredTextBox();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbCreate = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.cmsMain.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.cmsTreeView.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbMain)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctsmiUndo,
            this.ctsmiRedo,
            this.ctsmiFind,
            this.ctsmiReplace,
            this.ctsmiAutoIndent});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(135, 114);
            // 
            // ctsmiUndo
            // 
            this.ctsmiUndo.Name = "ctsmiUndo";
            this.ctsmiUndo.Size = new System.Drawing.Size(134, 22);
            this.ctsmiUndo.Text = "Undo";
            this.ctsmiUndo.Click += new System.EventHandler(this.tsmiUndo_Click);
            // 
            // ctsmiRedo
            // 
            this.ctsmiRedo.Name = "ctsmiRedo";
            this.ctsmiRedo.Size = new System.Drawing.Size(134, 22);
            this.ctsmiRedo.Text = "Redo";
            this.ctsmiRedo.Click += new System.EventHandler(this.tsmiRedo_Click);
            // 
            // ctsmiFind
            // 
            this.ctsmiFind.Name = "ctsmiFind";
            this.ctsmiFind.Size = new System.Drawing.Size(134, 22);
            this.ctsmiFind.Text = "Find";
            this.ctsmiFind.Click += new System.EventHandler(this.tsmiFind_Click);
            // 
            // ctsmiReplace
            // 
            this.ctsmiReplace.Name = "ctsmiReplace";
            this.ctsmiReplace.Size = new System.Drawing.Size(134, 22);
            this.ctsmiReplace.Text = "Replace";
            this.ctsmiReplace.Click += new System.EventHandler(this.tsmiReplace_Click);
            // 
            // ctsmiAutoIndent
            // 
            this.ctsmiAutoIndent.Name = "ctsmiAutoIndent";
            this.ctsmiAutoIndent.Size = new System.Drawing.Size(134, 22);
            this.ctsmiAutoIndent.Text = "AutoIndent";
            this.ctsmiAutoIndent.Click += new System.EventHandler(this.ctsmiAutoIndent_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit,
            this.tsmiInserts,
            this.tsmiDebug,
            this.tsmiOptions,
            this.tsmiHelp});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(660, 24);
            this.MenuStrip.TabIndex = 1;
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewProject,
            this.tsmiOpenProject,
            this.tsmiOpenRecent,
            this.tsmiSave});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "File";
            // 
            // tsmiNewProject
            // 
            this.tsmiNewProject.Name = "tsmiNewProject";
            this.tsmiNewProject.Size = new System.Drawing.Size(152, 22);
            this.tsmiNewProject.Text = "New projet";
            this.tsmiNewProject.Click += new System.EventHandler(this.tsmiNewProject_Click);
            // 
            // tsmiOpenProject
            // 
            this.tsmiOpenProject.Name = "tsmiOpenProject";
            this.tsmiOpenProject.Size = new System.Drawing.Size(152, 22);
            this.tsmiOpenProject.Text = "Open project";
            this.tsmiOpenProject.Click += new System.EventHandler(this.tsmiOpenProject_Click);
            // 
            // tsmiOpenRecent
            // 
            this.tsmiOpenRecent.Name = "tsmiOpenRecent";
            this.tsmiOpenRecent.Size = new System.Drawing.Size(152, 22);
            this.tsmiOpenRecent.Text = "Open recent";
            this.tsmiOpenRecent.Click += new System.EventHandler(this.tsmiOpenRecent_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(152, 22);
            this.tsmiSave.Text = "Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUndo,
            this.tsmiRedo,
            this.tss2,
            this.tsmiFind,
            this.tsmiReplace,
            this.tss3,
            this.tsmiComment,
            this.tsmiSelectAll});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(39, 20);
            this.tsmiEdit.Text = "Edit";
            // 
            // tsmiUndo
            // 
            this.tsmiUndo.Name = "tsmiUndo";
            this.tsmiUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmiUndo.Size = new System.Drawing.Size(202, 22);
            this.tsmiUndo.Text = "Undo";
            this.tsmiUndo.Click += new System.EventHandler(this.tsmiUndo_Click);
            // 
            // tsmiRedo
            // 
            this.tsmiRedo.Name = "tsmiRedo";
            this.tsmiRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmiRedo.Size = new System.Drawing.Size(202, 22);
            this.tsmiRedo.Text = "Redo";
            this.tsmiRedo.Click += new System.EventHandler(this.tsmiRedo_Click);
            // 
            // tss2
            // 
            this.tss2.Name = "tss2";
            this.tss2.Size = new System.Drawing.Size(199, 6);
            // 
            // tsmiFind
            // 
            this.tsmiFind.Name = "tsmiFind";
            this.tsmiFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiFind.Size = new System.Drawing.Size(202, 22);
            this.tsmiFind.Text = "Find";
            this.tsmiFind.Click += new System.EventHandler(this.tsmiFind_Click);
            // 
            // tsmiReplace
            // 
            this.tsmiReplace.Name = "tsmiReplace";
            this.tsmiReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tsmiReplace.Size = new System.Drawing.Size(202, 22);
            this.tsmiReplace.Text = "Replace";
            this.tsmiReplace.Click += new System.EventHandler(this.tsmiReplace_Click);
            // 
            // tss3
            // 
            this.tss3.Name = "tss3";
            this.tss3.Size = new System.Drawing.Size(199, 6);
            // 
            // tsmiComment
            // 
            this.tsmiComment.Name = "tsmiComment";
            this.tsmiComment.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.tsmiComment.Size = new System.Drawing.Size(202, 22);
            this.tsmiComment.Text = "Comment";
            this.tsmiComment.Click += new System.EventHandler(this.tsmiComment_Click);
            // 
            // tsmiSelectAll
            // 
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            this.tsmiSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmiSelectAll.Size = new System.Drawing.Size(202, 22);
            this.tsmiSelectAll.Text = "Select all";
            this.tsmiSelectAll.Click += new System.EventHandler(this.tsmiSelectAll_Click);
            // 
            // tsmiInserts
            // 
            this.tsmiInserts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewItem,
            this.craftRecipieToolStripMenuItem});
            this.tsmiInserts.Name = "tsmiInserts";
            this.tsmiInserts.Size = new System.Drawing.Size(53, 20);
            this.tsmiInserts.Text = "Inserts";
            // 
            // tsmiNewItem
            // 
            this.tsmiNewItem.Name = "tsmiNewItem";
            this.tsmiNewItem.Size = new System.Drawing.Size(138, 22);
            this.tsmiNewItem.Text = "New item";
            this.tsmiNewItem.Click += new System.EventHandler(this.tsmiNewItem_Click);
            // 
            // craftRecipieToolStripMenuItem
            // 
            this.craftRecipieToolStripMenuItem.Name = "craftRecipieToolStripMenuItem";
            this.craftRecipieToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.craftRecipieToolStripMenuItem.Text = "Craft recipie";
            this.craftRecipieToolStripMenuItem.Click += new System.EventHandler(this.craftRecipieToolStripMenuItem_Click);
            // 
            // tsmiDebug
            // 
            this.tsmiDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCheck,
            this.buildToolStripMenuItem});
            this.tsmiDebug.Name = "tsmiDebug";
            this.tsmiDebug.Size = new System.Drawing.Size(54, 20);
            this.tsmiDebug.Text = "Debug";
            // 
            // tsmiCheck
            // 
            this.tsmiCheck.Name = "tsmiCheck";
            this.tsmiCheck.Size = new System.Drawing.Size(136, 22);
            this.tsmiCheck.Text = "Check code";
            this.tsmiCheck.Click += new System.EventHandler(this.tsmiRun_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // tsmiOptions
            // 
            this.tsmiOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings});
            this.tsmiOptions.Name = "tsmiOptions";
            this.tsmiOptions.Size = new System.Drawing.Size(61, 20);
            this.tsmiOptions.Text = "Options";
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(116, 22);
            this.tsmiSettings.Text = "Settings";
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCoreEngineDocs});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmiHelp.Text = "Help";
            // 
            // tsmiCoreEngineDocs
            // 
            this.tsmiCoreEngineDocs.Name = "tsmiCoreEngineDocs";
            this.tsmiCoreEngineDocs.Size = new System.Drawing.Size(220, 22);
            this.tsmiCoreEngineDocs.Text = "CoreEngine documentation";
            this.tsmiCoreEngineDocs.Click += new System.EventHandler(this.tsmiCoreEngineDocs_Click);
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "*.js";
            this.dlgSave.FileName = "*.js";
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "nproj";
            // 
            // cmsTreeView
            // 
            this.cmsTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewScript,
            this.tsmiNewTexture,
            this.tsmiDeleteTexture,
            this.openProjectInExplorerToolStripMenuItem});
            this.cmsTreeView.Name = "contextMenuStrip1";
            this.cmsTreeView.Size = new System.Drawing.Size(202, 92);
            // 
            // tsmiNewScript
            // 
            this.tsmiNewScript.Name = "tsmiNewScript";
            this.tsmiNewScript.Size = new System.Drawing.Size(201, 22);
            this.tsmiNewScript.Text = "New script";
            this.tsmiNewScript.Click += new System.EventHandler(this.tsmiNewScript_Click);
            // 
            // tsmiNewTexture
            // 
            this.tsmiNewTexture.Name = "tsmiNewTexture";
            this.tsmiNewTexture.Size = new System.Drawing.Size(201, 22);
            this.tsmiNewTexture.Text = "New texture";
            this.tsmiNewTexture.Click += new System.EventHandler(this.tsmiNewTexture_Click);
            // 
            // tsmiDeleteTexture
            // 
            this.tsmiDeleteTexture.Name = "tsmiDeleteTexture";
            this.tsmiDeleteTexture.Size = new System.Drawing.Size(201, 22);
            this.tsmiDeleteTexture.Text = "Delete";
            this.tsmiDeleteTexture.Click += new System.EventHandler(this.tsmiDeleteTexture_Click);
            // 
            // openProjectInExplorerToolStripMenuItem
            // 
            this.openProjectInExplorerToolStripMenuItem.Name = "openProjectInExplorerToolStripMenuItem";
            this.openProjectInExplorerToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openProjectInExplorerToolStripMenuItem.Text = "Open project in explorer";
            this.openProjectInExplorerToolStripMenuItem.Click += new System.EventHandler(this.openProjectInExplorerToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.StatusStrip);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitter);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.fctbMain);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tvFolders);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(660, 284);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(660, 309);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.ToolStrip);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslFile});
            this.StatusStrip.Location = new System.Drawing.Point(118, 262);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(542, 22);
            this.StatusStrip.TabIndex = 8;
            this.StatusStrip.Text = "Status";
            // 
            // tsslFile
            // 
            this.tsslFile.Name = "tsslFile";
            this.tsslFile.Size = new System.Drawing.Size(0, 17);
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(115, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 284);
            this.splitter.TabIndex = 7;
            this.splitter.TabStop = false;
            // 
            // fctbMain
            // 
            this.fctbMain.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctbMain.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fctbMain.BackBrush = null;
            this.fctbMain.CharHeight = 14;
            this.fctbMain.CharWidth = 8;
            this.fctbMain.ContextMenuStrip = this.cmsMain;
            this.fctbMain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbMain.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctbMain.IsReplaceMode = false;
            this.fctbMain.LineNumberColor = System.Drawing.Color.RoyalBlue;
            this.fctbMain.Location = new System.Drawing.Point(115, 0);
            this.fctbMain.Name = "fctbMain";
            this.fctbMain.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbMain.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbMain.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbMain.ServiceColors")));
            this.fctbMain.Size = new System.Drawing.Size(545, 284);
            this.fctbMain.TabIndex = 5;
            this.fctbMain.Zoom = 100;
            this.fctbMain.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbMain_TextChanged);
            // 
            // tvFolders
            // 
            this.tvFolders.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tvFolders.ContextMenuStrip = this.cmsTreeView;
            this.tvFolders.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvFolders.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvFolders.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tvFolders.Location = new System.Drawing.Point(0, 0);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(115, 284);
            this.tvFolders.TabIndex = 6;
            this.tvFolders.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolders_NodeMouseDoubleClick);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreate,
            this.toolStripButton1,
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator,
            this.tsbCut,
            this.tsbCopy,
            this.tsbPaste});
            this.ToolStrip.Location = new System.Drawing.Point(3, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(179, 25);
            this.ToolStrip.TabIndex = 0;
            // 
            // tsbCreate
            // 
            this.tsbCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCreate.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreate.Image")));
            this.tsbCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreate.Name = "tsbCreate";
            this.tsbCreate.Size = new System.Drawing.Size(23, 22);
            this.tsbCreate.Text = "&Создать";
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "&Открыть";
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "&Сохранить";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCut
            // 
            this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCut.Image = ((System.Drawing.Image)(resources.GetObject("tsbCut.Image")));
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(23, 22);
            this.tsbCut.Text = "В&ырезать";
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(23, 22);
            this.tsbCopy.Text = "&Копировать";
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(23, 22);
            this.tsbPaste.Text = "Вст&авка";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 333);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "fMain";
            this.Text = "NIDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.cmsMain.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.cmsTreeView.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbMain)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiUndo;
        private System.Windows.Forms.ToolStripMenuItem tsmiRedo;
        private System.Windows.Forms.ToolStripMenuItem tsmiFind;
        private System.Windows.Forms.ToolStripMenuItem tsmiReplace;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem ctsmiUndo;
        private System.Windows.Forms.ToolStripMenuItem ctsmiRedo;
        private System.Windows.Forms.ToolStripMenuItem ctsmiFind;
        private System.Windows.Forms.ToolStripMenuItem ctsmiReplace;
        private System.Windows.Forms.ToolStripMenuItem ctsmiAutoIndent;
        private System.Windows.Forms.ContextMenuStrip cmsTreeView;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewTexture;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteTexture;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebug;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheck;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiComment;
        private System.Windows.Forms.ToolStripSeparator tss2;
        private System.Windows.Forms.ToolStripSeparator tss3;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiCoreEngineDocs;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenRecent;
        private System.Windows.Forms.ToolStripMenuItem tsmiInserts;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem craftRecipieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewProject;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenProject;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslFile;
        private System.Windows.Forms.Splitter splitter;
        private FastColoredTextBoxNS.FastColoredTextBox fctbMain;
        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton tsbCreate;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbCut;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

