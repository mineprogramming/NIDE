namespace NIDE.window
{
    partial class ProjectTree
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectTree));
            this.cmsTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiNewTexture = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewScript = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.cmsTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsTreeView
            // 
            this.cmsTreeView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewTexture,
            this.tsmiNewScript,
            this.tsmiNewFile,
            this.tsmiNewDirectory,
            this.tsmiRename,
            this.tsmiDelete,
            this.tsmiOpenInExplorer});
            this.cmsTreeView.Name = "contextMenuStrip1";
            this.cmsTreeView.Size = new System.Drawing.Size(190, 172);
            // 
            // tsmiNewTexture
            // 
            this.tsmiNewTexture.Name = "tsmiNewTexture";
            this.tsmiNewTexture.Size = new System.Drawing.Size(189, 24);
            this.tsmiNewTexture.Text = "New texture";
            this.tsmiNewTexture.Click += new System.EventHandler(this.tsmiNewTexture_Click);
            // 
            // tsmiNewScript
            // 
            this.tsmiNewScript.Name = "tsmiNewScript";
            this.tsmiNewScript.Size = new System.Drawing.Size(189, 24);
            this.tsmiNewScript.Text = "New script";
            this.tsmiNewScript.Click += new System.EventHandler(this.tsmiNewScript_Click);
            // 
            // tsmiNewFile
            // 
            this.tsmiNewFile.Name = "tsmiNewFile";
            this.tsmiNewFile.Size = new System.Drawing.Size(189, 24);
            this.tsmiNewFile.Text = "Create file";
            this.tsmiNewFile.Click += new System.EventHandler(this.tsmiNewFile_Click);
            // 
            // tsmiNewDirectory
            // 
            this.tsmiNewDirectory.Name = "tsmiNewDirectory";
            this.tsmiNewDirectory.Size = new System.Drawing.Size(189, 24);
            this.tsmiNewDirectory.Text = "Create directory";
            this.tsmiNewDirectory.Click += new System.EventHandler(this.tsmiNewDirectory_Click);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(189, 24);
            this.tsmiRename.Text = "Rename";
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(189, 24);
            this.tsmiDelete.Text = "Delete";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // tsmiOpenInExplorer
            // 
            this.tsmiOpenInExplorer.Name = "tsmiOpenInExplorer";
            this.tsmiOpenInExplorer.Size = new System.Drawing.Size(189, 24);
            this.tsmiOpenInExplorer.Text = "Open in explorer";
            this.tsmiOpenInExplorer.Click += new System.EventHandler(this.tsmiOpenInExplorer_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "if_8_2135932.png");
            this.imageList.Images.SetKeyName(1, "if_js_282802.png");
            this.imageList.Images.SetKeyName(2, "if_54_111138.png");
            this.imageList.Images.SetKeyName(3, "NIDE.png");
            this.imageList.Images.SetKeyName(4, "if_image_216246.png");
            // 
            // ProjectTree
            // 
            this.ContextMenuStrip = this.cmsTreeView;
            this.ImageIndex = 0;
            this.ImageList = this.imageList;
            this.LineColor = System.Drawing.Color.Black;
            this.SelectedImageIndex = 0;
            this.Size = new System.Drawing.Size(200, 97);
            this.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ProjectTree_AfterLabelEdit);
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTree_NodeMouseClick);
            this.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTree_NodeMouseDoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectTree_KeyDown);
            this.cmsTreeView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsTreeView;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewTexture;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewScript;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewDirectory;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenInExplorer;
        private System.Windows.Forms.ImageList imageList;
    }
}
