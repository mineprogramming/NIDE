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
            this.fctbMain = new FastColoredTextBoxNS.FastColoredTextBox();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiFind = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiAutoIndent = new System.Windows.Forms.ToolStripMenuItem();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewJS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewJSFromModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiNewModpkg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewModpkgFromModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tss5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiNewCoreEngine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenJS = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenModpkg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenCoreEngine = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFind = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiComment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tss4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiAutocompleteItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInserts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.craftRecipieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCoreEngineDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.cmsTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewTexture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteTexture = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.fctbMain)).BeginInit();
            this.cmsMain.SuspendLayout();
            this.msMain.SuspendLayout();
            this.cmsTreeView.SuspendLayout();
            this.SuspendLayout();
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
            this.fctbMain.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctbMain.IsReplaceMode = false;
            this.fctbMain.LineNumberColor = System.Drawing.Color.RoyalBlue;
            this.fctbMain.Location = new System.Drawing.Point(115, 24);
            this.fctbMain.Name = "fctbMain";
            this.fctbMain.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbMain.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbMain.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbMain.ServiceColors")));
            this.fctbMain.Size = new System.Drawing.Size(545, 309);
            this.fctbMain.TabIndex = 0;
            this.fctbMain.Zoom = 100;
            this.fctbMain.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbMain_TextChanged);
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
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit,
            this.tsmiInserts,
            this.tsmiDebug,
            this.tsmiOptions,
            this.tsmiHelp});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(660, 24);
            this.msMain.TabIndex = 1;
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiOpen,
            this.tsmiOpenRecent,
            this.tsmiSave,
            this.tsmiSaveAs});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "File";
            // 
            // tsmiNew
            // 
            this.tsmiNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewJS,
            this.tsmiNewJSFromModel,
            this.tss1,
            this.tsmiNewModpkg,
            this.tsmiNewModpkgFromModel,
            this.tss5,
            this.tsmiNewCoreEngine});
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(186, 22);
            this.tsmiNew.Text = "Create new ->";
            // 
            // tsmiNewJS
            // 
            this.tsmiNewJS.Name = "tsmiNewJS";
            this.tsmiNewJS.Size = new System.Drawing.Size(175, 22);
            this.tsmiNewJS.Text = "ModPE script";
            this.tsmiNewJS.Click += new System.EventHandler(this.tsmiNewJS_Click);
            // 
            // tsmiNewJSFromModel
            // 
            this.tsmiNewJSFromModel.Name = "tsmiNewJSFromModel";
            this.tsmiNewJSFromModel.Size = new System.Drawing.Size(175, 22);
            this.tsmiNewJSFromModel.Text = "From model";
            this.tsmiNewJSFromModel.Click += new System.EventHandler(this.tsmiNewJSFromModel_Click);
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(172, 6);
            // 
            // tsmiNewModpkg
            // 
            this.tsmiNewModpkg.Name = "tsmiNewModpkg";
            this.tsmiNewModpkg.Size = new System.Drawing.Size(175, 22);
            this.tsmiNewModpkg.Text = ".modpkg";
            this.tsmiNewModpkg.Click += new System.EventHandler(this.tsmiNewModpkg_Click);
            // 
            // tsmiNewModpkgFromModel
            // 
            this.tsmiNewModpkgFromModel.Name = "tsmiNewModpkgFromModel";
            this.tsmiNewModpkgFromModel.Size = new System.Drawing.Size(175, 22);
            this.tsmiNewModpkgFromModel.Text = "From model";
            this.tsmiNewModpkgFromModel.Click += new System.EventHandler(this.tsmiNewModpkgFromModel_Click);
            // 
            // tss5
            // 
            this.tss5.Name = "tss5";
            this.tss5.Size = new System.Drawing.Size(172, 6);
            // 
            // tsmiNewCoreEngine
            // 
            this.tsmiNewCoreEngine.Name = "tsmiNewCoreEngine";
            this.tsmiNewCoreEngine.Size = new System.Drawing.Size(175, 22);
            this.tsmiNewCoreEngine.Text = "CoreEngine project";
            this.tsmiNewCoreEngine.Click += new System.EventHandler(this.tsmiNewCoreEngine_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenJS,
            this.tsmiOpenModpkg,
            this.tsmiOpenCoreEngine});
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(186, 22);
            this.tsmiOpen.Text = "Open ->";
            // 
            // tsmiOpenJS
            // 
            this.tsmiOpenJS.Name = "tsmiOpenJS";
            this.tsmiOpenJS.Size = new System.Drawing.Size(175, 22);
            this.tsmiOpenJS.Text = "ModPE script";
            this.tsmiOpenJS.Click += new System.EventHandler(this.tsmiOpenJS_Click);
            // 
            // tsmiOpenModpkg
            // 
            this.tsmiOpenModpkg.Name = "tsmiOpenModpkg";
            this.tsmiOpenModpkg.Size = new System.Drawing.Size(175, 22);
            this.tsmiOpenModpkg.Text = ".modpkg";
            this.tsmiOpenModpkg.Click += new System.EventHandler(this.tsmiOpenModpkg_Click);
            // 
            // tsmiOpenCoreEngine
            // 
            this.tsmiOpenCoreEngine.Name = "tsmiOpenCoreEngine";
            this.tsmiOpenCoreEngine.Size = new System.Drawing.Size(175, 22);
            this.tsmiOpenCoreEngine.Text = "CoreEngine project";
            this.tsmiOpenCoreEngine.Click += new System.EventHandler(this.tsmiOpenCoreEngine_Click);
            // 
            // tsmiOpenRecent
            // 
            this.tsmiOpenRecent.Name = "tsmiOpenRecent";
            this.tsmiOpenRecent.Size = new System.Drawing.Size(186, 22);
            this.tsmiOpenRecent.Text = "Open recent";
            this.tsmiOpenRecent.Click += new System.EventHandler(this.tsmiOpenRecent_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(186, 22);
            this.tsmiSave.Text = "Save";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.tsmiSaveAs.Size = new System.Drawing.Size(186, 22);
            this.tsmiSaveAs.Text = "Save As";
            this.tsmiSaveAs.Click += new System.EventHandler(this.tsmiSaveAs_Click);
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
            this.tsmiSelectAll,
            this.tss4,
            this.tsmiAutocompleteItems});
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
            // tss4
            // 
            this.tss4.Name = "tss4";
            this.tss4.Size = new System.Drawing.Size(199, 6);
            // 
            // tsmiAutocompleteItems
            // 
            this.tsmiAutocompleteItems.Name = "tsmiAutocompleteItems";
            this.tsmiAutocompleteItems.Size = new System.Drawing.Size(202, 22);
            this.tsmiAutocompleteItems.Text = "User autocomlete items";
            this.tsmiAutocompleteItems.Click += new System.EventHandler(this.tsmiAutocompleteItems_Click);
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
            this.tsmiCheck});
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
            this.dlgOpen.DefaultExt = "*.js";
            this.dlgOpen.FileName = "*.js";
            // 
            // tvFolders
            // 
            this.tvFolders.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tvFolders.ContextMenuStrip = this.cmsTreeView;
            this.tvFolders.Cursor = System.Windows.Forms.Cursors.Default;
            this.tvFolders.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvFolders.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tvFolders.Location = new System.Drawing.Point(0, 24);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(115, 309);
            this.tvFolders.TabIndex = 2;
            this.tvFolders.Visible = false;
            this.tvFolders.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolders_NodeMouseDoubleClick);
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
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(115, 24);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 309);
            this.splitter.TabIndex = 3;
            this.splitter.TabStop = false;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 333);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.fctbMain);
            this.Controls.Add(this.tvFolders);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "fMain";
            this.Text = "NIDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fctbMain)).EndInit();
            this.cmsMain.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.cmsTreeView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctbMain;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
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
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.ContextMenuStrip cmsTreeView;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewTexture;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteTexture;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewJS;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewModpkg;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenJS;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenModpkg;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewJSFromModel;
        private System.Windows.Forms.ToolStripSeparator tss1;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewModpkgFromModel;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebug;
        private System.Windows.Forms.ToolStripMenuItem tsmiCheck;
        private System.Windows.Forms.ToolStripSeparator tss5;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCoreEngine;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenCoreEngine;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiComment;
        private System.Windows.Forms.ToolStripSeparator tss2;
        private System.Windows.Forms.ToolStripSeparator tss3;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiCoreEngineDocs;
        private System.Windows.Forms.ToolStripMenuItem tsmiAutocompleteItems;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenRecent;
        private System.Windows.Forms.ToolStripSeparator tss4;
        private System.Windows.Forms.ToolStripMenuItem tsmiInserts;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectInExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem craftRecipieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.TreeView tvFolders;
    }
}

