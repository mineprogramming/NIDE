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
            this.container = new System.Windows.Forms.ToolStripContainer();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.fctbMain = new FastColoredTextBoxNS.FastColoredTextBox();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctsmiUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiFind = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiReplace = new System.Windows.Forms.ToolStripMenuItem();
            this.ctsmiAutoIndent = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerLogs = new System.Windows.Forms.SplitContainer();
            this.gbErrors = new System.Windows.Forms.GroupBox();
            this.errors = new System.Windows.Forms.TextBox();
            this.gbLogger = new System.Windows.Forms.GroupBox();
            this.btnStopLog = new System.Windows.Forms.Button();
            this.btnStartLog = new System.Windows.Forms.Button();
            this.logger = new System.Windows.Forms.TextBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ProgressBarStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitter = new System.Windows.Forms.Splitter();
            this.panel = new System.Windows.Forms.Panel();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.cmsTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewTexture2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewScript2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.Ads = new System.Windows.Forms.WebBrowser();
            this.toolStripGeneral = new System.Windows.Forms.ToolStrip();
            this.tsbCreate = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbNewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripEdit = new System.Windows.Forms.ToolStrip();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbRedo = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.tsbRenderer = new System.Windows.Forms.ToolStripButton();
            this.toolStripProject = new System.Windows.Forms.ToolStrip();
            this.tsbBuildPush = new System.Windows.Forms.ToolStripButton();
            this.tsbBuild = new System.Windows.Forms.ToolStripButton();
            this.tsbPush = new System.Windows.Forms.ToolStripButton();
            this.tsbRun = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbShowMain = new System.Windows.Forms.ToolStripButton();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCloseProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tss4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRenderer = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tsmiCraftRecipie = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewTexture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProject = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewLibrary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageLibraries = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRunJs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPush = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBuildAndPush = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCoreEngineDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLinks = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.container.ContentPanel.SuspendLayout();
            this.container.TopToolStripPanel.SuspendLayout();
            this.container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctbMain)).BeginInit();
            this.cmsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLogs)).BeginInit();
            this.splitContainerLogs.Panel1.SuspendLayout();
            this.splitContainerLogs.Panel2.SuspendLayout();
            this.splitContainerLogs.SuspendLayout();
            this.gbErrors.SuspendLayout();
            this.gbLogger.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.panel.SuspendLayout();
            this.cmsTreeView.SuspendLayout();
            this.toolStripGeneral.SuspendLayout();
            this.toolStripEdit.SuspendLayout();
            this.toolStripProject.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            // 
            // container.ContentPanel
            // 
            this.container.ContentPanel.Controls.Add(this.mainSplit);
            this.container.ContentPanel.Controls.Add(this.StatusStrip);
            this.container.ContentPanel.Controls.Add(this.splitter);
            this.container.ContentPanel.Controls.Add(this.panel);
            resources.ApplyResources(this.container.ContentPanel, "container.ContentPanel");
            resources.ApplyResources(this.container, "container");
            this.container.Name = "container";
            // 
            // container.TopToolStripPanel
            // 
            this.container.TopToolStripPanel.Controls.Add(this.toolStripGeneral);
            this.container.TopToolStripPanel.Controls.Add(this.toolStripEdit);
            this.container.TopToolStripPanel.Controls.Add(this.toolStripProject);
            // 
            // mainSplit
            // 
            resources.ApplyResources(this.mainSplit, "mainSplit");
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.fctbMain);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.splitContainerLogs);
            // 
            // fctbMain
            // 
            this.fctbMain.AutoCompleteBrackets = true;
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
            this.fctbMain.AutoIndentChars = false;
            this.fctbMain.AutoIndentExistingLines = false;
            resources.ApplyResources(this.fctbMain, "fctbMain");
            this.fctbMain.BackBrush = null;
            this.fctbMain.CharHeight = 14;
            this.fctbMain.CharWidth = 8;
            this.fctbMain.ContextMenuStrip = this.cmsMain;
            this.fctbMain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctbMain.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctbMain.HighlightingRangeType = FastColoredTextBoxNS.HighlightingRangeType.VisibleRange;
            this.fctbMain.IsReplaceMode = false;
            this.fctbMain.LineNumberColor = System.Drawing.Color.RoyalBlue;
            this.fctbMain.Name = "fctbMain";
            this.fctbMain.Paddings = new System.Windows.Forms.Padding(0);
            this.fctbMain.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctbMain.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctbMain.ServiceColors")));
            this.fctbMain.Zoom = 100;
            this.fctbMain.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctbMain_TextChanged);
            this.fctbMain.PaintLine += new System.EventHandler<FastColoredTextBoxNS.PaintLineEventArgs>(this.fctbMain_PaintLine);
            this.fctbMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fctbMain_KeyDown);
            // 
            // cmsMain
            // 
            this.cmsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctsmiUndo,
            this.ctsmiRedo,
            this.ctsmiFind,
            this.ctsmiReplace,
            this.ctsmiAutoIndent});
            this.cmsMain.Name = "cmsMain";
            resources.ApplyResources(this.cmsMain, "cmsMain");
            // 
            // ctsmiUndo
            // 
            this.ctsmiUndo.Name = "ctsmiUndo";
            resources.ApplyResources(this.ctsmiUndo, "ctsmiUndo");
            this.ctsmiUndo.Click += new System.EventHandler(this.tsmiUndo_Click);
            // 
            // ctsmiRedo
            // 
            this.ctsmiRedo.Name = "ctsmiRedo";
            resources.ApplyResources(this.ctsmiRedo, "ctsmiRedo");
            this.ctsmiRedo.Click += new System.EventHandler(this.tsmiRedo_Click);
            // 
            // ctsmiFind
            // 
            this.ctsmiFind.Name = "ctsmiFind";
            resources.ApplyResources(this.ctsmiFind, "ctsmiFind");
            this.ctsmiFind.Click += new System.EventHandler(this.tsmiFind_Click);
            // 
            // ctsmiReplace
            // 
            this.ctsmiReplace.Name = "ctsmiReplace";
            resources.ApplyResources(this.ctsmiReplace, "ctsmiReplace");
            this.ctsmiReplace.Click += new System.EventHandler(this.tsmiReplace_Click);
            // 
            // ctsmiAutoIndent
            // 
            this.ctsmiAutoIndent.Name = "ctsmiAutoIndent";
            resources.ApplyResources(this.ctsmiAutoIndent, "ctsmiAutoIndent");
            this.ctsmiAutoIndent.Click += new System.EventHandler(this.ctsmiAutoIndent_Click);
            // 
            // splitContainerLogs
            // 
            resources.ApplyResources(this.splitContainerLogs, "splitContainerLogs");
            this.splitContainerLogs.Name = "splitContainerLogs";
            // 
            // splitContainerLogs.Panel1
            // 
            this.splitContainerLogs.Panel1.Controls.Add(this.gbErrors);
            // 
            // splitContainerLogs.Panel2
            // 
            this.splitContainerLogs.Panel2.Controls.Add(this.gbLogger);
            // 
            // gbErrors
            // 
            this.gbErrors.Controls.Add(this.errors);
            resources.ApplyResources(this.gbErrors, "gbErrors");
            this.gbErrors.Name = "gbErrors";
            this.gbErrors.TabStop = false;
            // 
            // errors
            // 
            resources.ApplyResources(this.errors, "errors");
            this.errors.Name = "errors";
            this.errors.ReadOnly = true;
            // 
            // gbLogger
            // 
            this.gbLogger.Controls.Add(this.btnStopLog);
            this.gbLogger.Controls.Add(this.btnStartLog);
            this.gbLogger.Controls.Add(this.logger);
            resources.ApplyResources(this.gbLogger, "gbLogger");
            this.gbLogger.Name = "gbLogger";
            this.gbLogger.TabStop = false;
            // 
            // btnStopLog
            // 
            resources.ApplyResources(this.btnStopLog, "btnStopLog");
            this.btnStopLog.Name = "btnStopLog";
            this.btnStopLog.UseVisualStyleBackColor = true;
            this.btnStopLog.Click += new System.EventHandler(this.btnStopLog_Click);
            // 
            // btnStartLog
            // 
            resources.ApplyResources(this.btnStartLog, "btnStartLog");
            this.btnStartLog.Name = "btnStartLog";
            this.btnStartLog.UseVisualStyleBackColor = true;
            this.btnStartLog.Click += new System.EventHandler(this.btnStartLog_Click);
            // 
            // logger
            // 
            resources.ApplyResources(this.logger, "logger");
            this.logger.Name = "logger";
            this.logger.ReadOnly = true;
            // 
            // StatusStrip
            // 
            this.StatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBarStatus,
            this.tsslFile});
            resources.ApplyResources(this.StatusStrip, "StatusStrip");
            this.StatusStrip.Name = "StatusStrip";
            // 
            // ProgressBarStatus
            // 
            this.ProgressBarStatus.Name = "ProgressBarStatus";
            resources.ApplyResources(this.ProgressBarStatus, "ProgressBarStatus");
            // 
            // tsslFile
            // 
            this.tsslFile.Name = "tsslFile";
            resources.ApplyResources(this.tsslFile, "tsslFile");
            // 
            // splitter
            // 
            resources.ApplyResources(this.splitter, "splitter");
            this.splitter.Name = "splitter";
            this.splitter.TabStop = false;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.tvFolders);
            this.panel.Controls.Add(this.Ads);
            resources.ApplyResources(this.panel, "panel");
            this.panel.Name = "panel";
            // 
            // tvFolders
            // 
            this.tvFolders.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tvFolders.ContextMenuStrip = this.cmsTreeView;
            this.tvFolders.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.tvFolders, "tvFolders");
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvFolders_AfterLabelEdit);
            this.tvFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolders_NodeMouseClick);
            this.tvFolders.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolders_NodeMouseDoubleClick);
            // 
            // cmsTreeView
            // 
            this.cmsTreeView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewTexture2,
            this.tsmiNewScript2,
            this.tsmiNewFile,
            this.tsmiNewDirectory,
            this.tsmiRename,
            this.tsmiDelete,
            this.tsmiOpenInExplorer});
            this.cmsTreeView.Name = "contextMenuStrip1";
            resources.ApplyResources(this.cmsTreeView, "cmsTreeView");
            // 
            // tsmiNewTexture2
            // 
            this.tsmiNewTexture2.Name = "tsmiNewTexture2";
            resources.ApplyResources(this.tsmiNewTexture2, "tsmiNewTexture2");
            this.tsmiNewTexture2.Click += new System.EventHandler(this.tsmiNewTexture_Click);
            // 
            // tsmiNewScript2
            // 
            this.tsmiNewScript2.Name = "tsmiNewScript2";
            resources.ApplyResources(this.tsmiNewScript2, "tsmiNewScript2");
            this.tsmiNewScript2.Click += new System.EventHandler(this.tsmiNewScript_Click);
            // 
            // tsmiNewFile
            // 
            this.tsmiNewFile.Name = "tsmiNewFile";
            resources.ApplyResources(this.tsmiNewFile, "tsmiNewFile");
            this.tsmiNewFile.Click += new System.EventHandler(this.tsmiNewFile_Click);
            // 
            // tsmiNewDirectory
            // 
            this.tsmiNewDirectory.Name = "tsmiNewDirectory";
            resources.ApplyResources(this.tsmiNewDirectory, "tsmiNewDirectory");
            this.tsmiNewDirectory.Click += new System.EventHandler(this.tsmiNewDirectory_Click);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            resources.ApplyResources(this.tsmiRename, "tsmiRename");
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            resources.ApplyResources(this.tsmiDelete, "tsmiDelete");
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiOpenInExplorer
            // 
            this.tsmiOpenInExplorer.Name = "tsmiOpenInExplorer";
            resources.ApplyResources(this.tsmiOpenInExplorer, "tsmiOpenInExplorer");
            this.tsmiOpenInExplorer.Click += new System.EventHandler(this.tsmiOpenInExplorer_Click);
            // 
            // Ads
            // 
            this.Ads.AllowWebBrowserDrop = false;
            resources.ApplyResources(this.Ads, "Ads");
            this.Ads.IsWebBrowserContextMenuEnabled = false;
            this.Ads.Name = "Ads";
            this.Ads.ScrollBarsEnabled = false;
            this.Ads.Url = new System.Uri("http://api.mineprogramming.org/nide/ads/index.php", System.UriKind.Absolute);
            this.Ads.WebBrowserShortcutsEnabled = false;
            this.Ads.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.Ads_Navigating);
            // 
            // toolStripGeneral
            // 
            resources.ApplyResources(this.toolStripGeneral, "toolStripGeneral");
            this.toolStripGeneral.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCreate,
            this.tsbOpen,
            this.tsbSave,
            this.tsbNewFile,
            this.toolStripSeparator,
            this.tsbCut,
            this.tsbCopy,
            this.tsbPaste});
            this.toolStripGeneral.Name = "toolStripGeneral";
            this.toolStripGeneral.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // tsbCreate
            // 
            this.tsbCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbCreate, "tsbCreate");
            this.tsbCreate.Name = "tsbCreate";
            this.tsbCreate.Click += new System.EventHandler(this.tsmiNewProject_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbOpen, "tsbOpen");
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Click += new System.EventHandler(this.tsmiOpenProject_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbSave, "tsbSave");
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsbNewFile
            // 
            this.tsbNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbNewFile, "tsbNewFile");
            this.tsbNewFile.Name = "tsbNewFile";
            this.tsbNewFile.Click += new System.EventHandler(this.tsmiNewScript_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // tsbCut
            // 
            this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbCut, "tsbCut");
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Click += new System.EventHandler(this.tsbCut_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbCopy, "tsbCopy");
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbPaste, "tsbPaste");
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            // 
            // toolStripEdit
            // 
            resources.ApplyResources(this.toolStripEdit, "toolStripEdit");
            this.toolStripEdit.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUndo,
            this.tsbRedo,
            this.tsbSettings,
            this.tsbRenderer});
            this.toolStripEdit.Name = "toolStripEdit";
            this.toolStripEdit.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbUndo, "tsbUndo");
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Click += new System.EventHandler(this.tsmiUndo_Click);
            // 
            // tsbRedo
            // 
            this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbRedo, "tsbRedo");
            this.tsbRedo.Name = "tsbRedo";
            this.tsbRedo.Click += new System.EventHandler(this.tsmiRedo_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbSettings, "tsbSettings");
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsbRenderer
            // 
            this.tsbRenderer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbRenderer, "tsbRenderer");
            this.tsbRenderer.Name = "tsbRenderer";
            this.tsbRenderer.Click += new System.EventHandler(this.tsmiRenderer_Click);
            // 
            // toolStripProject
            // 
            resources.ApplyResources(this.toolStripProject, "toolStripProject");
            this.toolStripProject.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBuildPush,
            this.tsbBuild,
            this.tsbPush,
            this.tsbRun,
            this.tsbUpdate,
            this.tsbShowMain});
            this.toolStripProject.Name = "toolStripProject";
            this.toolStripProject.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // tsbBuildPush
            // 
            this.tsbBuildPush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbBuildPush, "tsbBuildPush");
            this.tsbBuildPush.Name = "tsbBuildPush";
            this.tsbBuildPush.Click += new System.EventHandler(this.tsbBuildPush_Click);
            // 
            // tsbBuild
            // 
            this.tsbBuild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbBuild, "tsbBuild");
            this.tsbBuild.Name = "tsbBuild";
            this.tsbBuild.Click += new System.EventHandler(this.tsmiBuild_Click);
            // 
            // tsbPush
            // 
            this.tsbPush.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbPush, "tsbPush");
            this.tsbPush.Name = "tsbPush";
            this.tsbPush.Click += new System.EventHandler(this.tsmiPush_Click);
            // 
            // tsbRun
            // 
            this.tsbRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbRun, "tsbRun");
            this.tsbRun.Name = "tsbRun";
            this.tsbRun.Click += new System.EventHandler(this.tsmiRunJs_Click);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbUpdate, "tsbUpdate");
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsbShowMain
            // 
            this.tsbShowMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbShowMain, "tsbShowMain");
            this.tsbShowMain.Name = "tsbShowMain";
            this.tsbShowMain.Click += new System.EventHandler(this.tsbShowMain_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit,
            this.tsmiInserts,
            this.tsmiProject,
            this.tsmiRun,
            this.tsmiOptions,
            this.tsmiHelp});
            resources.ApplyResources(this.MenuStrip, "MenuStrip");
            this.MenuStrip.Name = "MenuStrip";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewProject,
            this.tsmiOpenProject,
            this.tsmiSave,
            this.tsmiCloseProject,
            this.tss4,
            this.tsmiRenderer});
            this.tsmiFile.Name = "tsmiFile";
            resources.ApplyResources(this.tsmiFile, "tsmiFile");
            // 
            // tsmiNewProject
            // 
            this.tsmiNewProject.Name = "tsmiNewProject";
            resources.ApplyResources(this.tsmiNewProject, "tsmiNewProject");
            this.tsmiNewProject.Click += new System.EventHandler(this.tsmiNewProject_Click);
            // 
            // tsmiOpenProject
            // 
            this.tsmiOpenProject.Name = "tsmiOpenProject";
            resources.ApplyResources(this.tsmiOpenProject, "tsmiOpenProject");
            this.tsmiOpenProject.Click += new System.EventHandler(this.tsmiOpenProject_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            resources.ApplyResources(this.tsmiSave, "tsmiSave");
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiCloseProject
            // 
            this.tsmiCloseProject.Name = "tsmiCloseProject";
            resources.ApplyResources(this.tsmiCloseProject, "tsmiCloseProject");
            this.tsmiCloseProject.Click += new System.EventHandler(this.tsmiCloseProject_Click);
            // 
            // tss4
            // 
            this.tss4.Name = "tss4";
            resources.ApplyResources(this.tss4, "tss4");
            // 
            // tsmiRenderer
            // 
            this.tsmiRenderer.Name = "tsmiRenderer";
            resources.ApplyResources(this.tsmiRenderer, "tsmiRenderer");
            this.tsmiRenderer.Click += new System.EventHandler(this.tsmiRenderer_Click);
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
            resources.ApplyResources(this.tsmiEdit, "tsmiEdit");
            // 
            // tsmiUndo
            // 
            this.tsmiUndo.Name = "tsmiUndo";
            resources.ApplyResources(this.tsmiUndo, "tsmiUndo");
            this.tsmiUndo.Click += new System.EventHandler(this.tsmiUndo_Click);
            // 
            // tsmiRedo
            // 
            this.tsmiRedo.Name = "tsmiRedo";
            resources.ApplyResources(this.tsmiRedo, "tsmiRedo");
            this.tsmiRedo.Click += new System.EventHandler(this.tsmiRedo_Click);
            // 
            // tss2
            // 
            this.tss2.Name = "tss2";
            resources.ApplyResources(this.tss2, "tss2");
            // 
            // tsmiFind
            // 
            this.tsmiFind.Name = "tsmiFind";
            resources.ApplyResources(this.tsmiFind, "tsmiFind");
            this.tsmiFind.Click += new System.EventHandler(this.tsmiFind_Click);
            // 
            // tsmiReplace
            // 
            this.tsmiReplace.Name = "tsmiReplace";
            resources.ApplyResources(this.tsmiReplace, "tsmiReplace");
            this.tsmiReplace.Click += new System.EventHandler(this.tsmiReplace_Click);
            // 
            // tss3
            // 
            this.tss3.Name = "tss3";
            resources.ApplyResources(this.tss3, "tss3");
            // 
            // tsmiComment
            // 
            this.tsmiComment.Name = "tsmiComment";
            resources.ApplyResources(this.tsmiComment, "tsmiComment");
            this.tsmiComment.Click += new System.EventHandler(this.tsmiComment_Click);
            // 
            // tsmiSelectAll
            // 
            this.tsmiSelectAll.Name = "tsmiSelectAll";
            resources.ApplyResources(this.tsmiSelectAll, "tsmiSelectAll");
            this.tsmiSelectAll.Click += new System.EventHandler(this.tsmiSelectAll_Click);
            // 
            // tsmiInserts
            // 
            this.tsmiInserts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewItem,
            this.tsmiCraftRecipie,
            this.tsmiNewScript,
            this.tsmiNewTexture});
            this.tsmiInserts.Name = "tsmiInserts";
            resources.ApplyResources(this.tsmiInserts, "tsmiInserts");
            // 
            // tsmiNewItem
            // 
            this.tsmiNewItem.Name = "tsmiNewItem";
            resources.ApplyResources(this.tsmiNewItem, "tsmiNewItem");
            this.tsmiNewItem.Click += new System.EventHandler(this.tsmiNewItem_Click);
            // 
            // tsmiCraftRecipie
            // 
            this.tsmiCraftRecipie.Name = "tsmiCraftRecipie";
            resources.ApplyResources(this.tsmiCraftRecipie, "tsmiCraftRecipie");
            this.tsmiCraftRecipie.Click += new System.EventHandler(this.tsmiNewCraft_Click);
            // 
            // tsmiNewScript
            // 
            this.tsmiNewScript.Name = "tsmiNewScript";
            resources.ApplyResources(this.tsmiNewScript, "tsmiNewScript");
            this.tsmiNewScript.Click += new System.EventHandler(this.tsmiNewScript_Click);
            // 
            // tsmiNewTexture
            // 
            this.tsmiNewTexture.Name = "tsmiNewTexture";
            resources.ApplyResources(this.tsmiNewTexture, "tsmiNewTexture");
            this.tsmiNewTexture.Click += new System.EventHandler(this.tsmiNewTexture_Click);
            // 
            // tsmiProject
            // 
            this.tsmiProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdate,
            this.tsmiNewLibrary,
            this.tsmiManageLibraries});
            this.tsmiProject.Name = "tsmiProject";
            resources.ApplyResources(this.tsmiProject, "tsmiProject");
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            resources.ApplyResources(this.tsmiUpdate, "tsmiUpdate");
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiNewLibrary
            // 
            this.tsmiNewLibrary.Name = "tsmiNewLibrary";
            resources.ApplyResources(this.tsmiNewLibrary, "tsmiNewLibrary");
            this.tsmiNewLibrary.Click += new System.EventHandler(this.tsmiLibrary_Click);
            // 
            // tsmiManageLibraries
            // 
            this.tsmiManageLibraries.Name = "tsmiManageLibraries";
            resources.ApplyResources(this.tsmiManageLibraries, "tsmiManageLibraries");
            this.tsmiManageLibraries.Click += new System.EventHandler(this.tsmiManageLibraries_Click);
            // 
            // tsmiRun
            // 
            this.tsmiRun.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBuild,
            this.tsmiRunJs,
            this.tsmiPush,
            this.tsmiBuildAndPush});
            this.tsmiRun.Name = "tsmiRun";
            resources.ApplyResources(this.tsmiRun, "tsmiRun");
            // 
            // tsmiBuild
            // 
            this.tsmiBuild.Name = "tsmiBuild";
            resources.ApplyResources(this.tsmiBuild, "tsmiBuild");
            this.tsmiBuild.Click += new System.EventHandler(this.tsmiBuild_Click);
            // 
            // tsmiRunJs
            // 
            this.tsmiRunJs.Name = "tsmiRunJs";
            resources.ApplyResources(this.tsmiRunJs, "tsmiRunJs");
            this.tsmiRunJs.Click += new System.EventHandler(this.tsmiRunJs_Click);
            // 
            // tsmiPush
            // 
            this.tsmiPush.Name = "tsmiPush";
            resources.ApplyResources(this.tsmiPush, "tsmiPush");
            this.tsmiPush.Click += new System.EventHandler(this.tsmiPush_Click);
            // 
            // tsmiBuildAndPush
            // 
            this.tsmiBuildAndPush.Name = "tsmiBuildAndPush";
            resources.ApplyResources(this.tsmiBuildAndPush, "tsmiBuildAndPush");
            this.tsmiBuildAndPush.Click += new System.EventHandler(this.tsbBuildPush_Click);
            // 
            // tsmiOptions
            // 
            this.tsmiOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSettings});
            this.tsmiOptions.Name = "tsmiOptions";
            resources.ApplyResources(this.tsmiOptions, "tsmiOptions");
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            resources.ApplyResources(this.tsmiSettings, "tsmiSettings");
            this.tsmiSettings.Click += new System.EventHandler(this.tsmiSettings_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVersion,
            this.tsmiCoreEngineDocs,
            this.tsmiLinks});
            this.tsmiHelp.Name = "tsmiHelp";
            resources.ApplyResources(this.tsmiHelp, "tsmiHelp");
            // 
            // tsmiVersion
            // 
            this.tsmiVersion.Name = "tsmiVersion";
            resources.ApplyResources(this.tsmiVersion, "tsmiVersion");
            this.tsmiVersion.Click += new System.EventHandler(this.tsmiVersion_Click);
            // 
            // tsmiCoreEngineDocs
            // 
            this.tsmiCoreEngineDocs.Name = "tsmiCoreEngineDocs";
            resources.ApplyResources(this.tsmiCoreEngineDocs, "tsmiCoreEngineDocs");
            this.tsmiCoreEngineDocs.Click += new System.EventHandler(this.tsmiCoreEngineDocs_Click);
            // 
            // tsmiLinks
            // 
            this.tsmiLinks.Name = "tsmiLinks";
            resources.ApplyResources(this.tsmiLinks, "tsmiLinks");
            this.tsmiLinks.Click += new System.EventHandler(this.tsmiLinks_Click);
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
            // fMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.container);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "fMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.container.ContentPanel.ResumeLayout(false);
            this.container.ContentPanel.PerformLayout();
            this.container.TopToolStripPanel.ResumeLayout(false);
            this.container.TopToolStripPanel.PerformLayout();
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fctbMain)).EndInit();
            this.cmsMain.ResumeLayout(false);
            this.splitContainerLogs.Panel1.ResumeLayout(false);
            this.splitContainerLogs.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLogs)).EndInit();
            this.splitContainerLogs.ResumeLayout(false);
            this.gbErrors.ResumeLayout(false);
            this.gbErrors.PerformLayout();
            this.gbLogger.ResumeLayout(false);
            this.gbLogger.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.cmsTreeView.ResumeLayout(false);
            this.toolStripGeneral.ResumeLayout(false);
            this.toolStripGeneral.PerformLayout();
            this.toolStripEdit.ResumeLayout(false);
            this.toolStripEdit.PerformLayout();
            this.toolStripProject.ResumeLayout(false);
            this.toolStripProject.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiRun;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewScript2;
        private System.Windows.Forms.ToolStripMenuItem tsmiComment;
        private System.Windows.Forms.ToolStripSeparator tss2;
        private System.Windows.Forms.ToolStripSeparator tss3;
        private System.Windows.Forms.ToolStripMenuItem tsmiSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiCoreEngineDocs;
        private System.Windows.Forms.ToolStripMenuItem tsmiInserts;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenInExplorer;
        private System.Windows.Forms.ToolStripMenuItem tsmiCraftRecipie;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewProject;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenProject;
        private System.Windows.Forms.ToolStripMenuItem tsmiBuild;
        private System.Windows.Forms.ToolStripContainer container;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslFile;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.ToolStrip toolStripGeneral;
        private System.Windows.Forms.ToolStripButton tsbCreate;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbCut;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripButton tsbNewFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiCloseProject;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewTexture;
        private System.Windows.Forms.ToolStripMenuItem tsmiRunJs;
        private System.Windows.Forms.TextBox errors;
        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.ToolStrip toolStripProject;
        private System.Windows.Forms.ToolStripButton tsbRun;
        private System.Windows.Forms.ToolStripButton tsbBuild;
        private System.Windows.Forms.ToolStripMenuItem tsmiPush;
        private System.Windows.Forms.ToolStripButton tsbPush;
        public System.Windows.Forms.ToolStripProgressBar ProgressBarStatus;
        public FastColoredTextBoxNS.FastColoredTextBox fctbMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiProject;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewLibrary;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageLibraries;
        private System.Windows.Forms.ToolStripButton tsbBuildPush;
        private System.Windows.Forms.ToolStripMenuItem tsmiBuildAndPush;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewTexture2;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewDirectory;
        private System.Windows.Forms.ToolStripMenuItem tsmiLinks;
        private System.Windows.Forms.ToolStripMenuItem tsmiVersion;
        private System.Windows.Forms.ToolStripButton tsbShowMain;
        private System.Windows.Forms.TextBox logger;
        private System.Windows.Forms.SplitContainer splitContainerLogs;
        private System.Windows.Forms.GroupBox gbErrors;
        private System.Windows.Forms.GroupBox gbLogger;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.WebBrowser Ads;
        private System.Windows.Forms.ToolStrip toolStripEdit;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripButton tsbRedo;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.ToolStripButton tsbRenderer;
        private System.Windows.Forms.ToolStripSeparator tss4;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenderer;
        private System.Windows.Forms.Button btnStopLog;
        private System.Windows.Forms.Button btnStartLog;
    }
}

