using FastColoredTextBoxNS;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Yahoo.Yui.Compressor;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace NIDE
{
    public partial class fMain : Form
    {
        private bool saved = true;
        private string[] args;
        private string OldPath = "";

        public fMain(string[] args)
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
            this.args = args;
            InitializeComponent();
            ProgramData.MainForm = this;
            CodeAnalysisEngine.Initialize(fctbMain);
            RegisterWorker.Load(this);
            Autocomplete.SetAutoompleteMenu(fctbMain);
            fctbMain.HighlightingRangeType = HighlightingRangeType.VisibleRange;

            try
            {
                ModPe.LoadModPeData("modpescript_dump.txt");
                CoreEngine.LoadCoreEngineData("core.dump");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load ModPE or CoreEngine data");
                Close();
            }
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            if (args.Length > 0)
            {
                try
                {
                    if (Path.GetExtension(args[0]).ToLower() == ".nproj")
                    {
                        OpenProject(args[0]);
                    }
                    else if (Path.GetExtension(args[0]).ToLower() == ".js")
                    {
                        InitFileOnly(args[0]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open this project!");
                    Close();
                }
            }
            else if (ProgramData.LoadLast && ProgramData.Last != "")
            {
                try
                {
                    OpenProject(ProgramData.Last);
                }
                catch { ShowStartWindow(); }
            }
            else
            {
                ShowStartWindow();
            }
        }

        private void ShowStartWindow()
        {
            try
            {
                fStartWindow form = new fStartWindow();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    switch (form.result)
                    {
                        case "recent":
                            OpenProject(form.path);
                            break;
                        case "new":
                            NewProjectDlg(true);
                            break;
                        case "open":
                            OpenProjectDlg(true);
                            break;
                        case "import":
                            ImportModpkg(true);
                            break;
                    }
                }
                else
                {
                    Close();
                }
            }
            catch { ShowStartWindow(); }
        }

        private void ImportModpkg(bool closeIfNotChecked = false)
        {
            var form = new fNewProject(true);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProgramData.ProjectManager = new ProjectManager(form.source, form.path, form.name);
                    OpenScript(ProgramData.ProjectManager.MainScriptPath);
                    InitProject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error occured while creating a new project");
                }
            }
            else if (closeIfNotChecked)
            {
                Close();
            }
        }

        private void fctbMain_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (fctbMain.Language == Language.JS && ProgramData.ProjectManager != null)
            {
                if (ProgramData.file.EndsWith(".js"))
                {
                    Highlighting.ResetStyles(e.ChangedRange, fctbMain.Range);
                    CodeAnalysisEngine.Update();
                }
            }
            saved = false;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanChangeFile()) e.Cancel = true;
            RegisterWorker.Save(this);
        }

        private void tvFolders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = GetTreeViewPath(e.Node);
            if (Directory.Exists(path))
                return;
            if (!saved)
            {
                var result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    fctbMain.SaveToFile(ProgramData.file, Encoding.UTF8);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            string extension = Path.GetExtension(path).ToLower();
            if (Constants.TextExtensions.Contains(extension))
            {
                OpenScript(path);
            }
            else if (extension == ".png")
            {
                Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "bin\\NPixelPaint.exe"), "\"" + path + "\"");
            }
            else if (extension == ".json")
            {
                try
                {
                    new fJsonItem(GetTreeViewPath(e.Node)).Show();
                }
                catch { }
            }
        }

        private string GetTreeViewPath(TreeNode node)
        {
            if (node.Text == Path.GetFileName(ProgramData.ProjectManager.ProjectFilePath))
                return ProgramData.ProjectManager.ProjectFilePath;
            else
            {
                string path_relative = node.FullPath;
                path_relative = path_relative.Substring(path_relative.IndexOf('\\') + 1);
                return ProgramData.ProjectManager.SourceCodePath + "\\" + path_relative;
            }
        }


        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (tvFolders.SelectedNode.Text != "main.js"
                && Path.GetExtension(tvFolders.SelectedNode.Text).ToLower() != ".nproj")
            {
                try
                {
                    string path = GetTreeViewPath(tvFolders.SelectedNode);
                    if (File.Exists(path))
                        File.Delete(path);
                    else if (Directory.Exists(path))
                        Directory.Delete(path, true);
                    tvFolders.SelectedNode.Remove();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot delete this file");
                }
            }
        }

        private void tsmiCoreEngineDocs_Click(object sender, EventArgs e)
        {
            Process.Start("CoreEngine help.chm");
        }

        private void openProjectInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(ProgramData.ProjectManager.path);
        }

        //connections
        public int TextViewWidth { get { return tvFolders.Width; } set { tvFolders.Width = value; } }
        public int TextViewHeight { get { return mainSplit.SplitterDistance; } set { mainSplit.SplitterDistance = value; } }

        //textworking
        private void tsmiUndo_Click(object sender, EventArgs e) { fctbMain.Undo(); }
        private void tsmiRedo_Click(object sender, EventArgs e) { fctbMain.Redo(); }
        private void tsmiFind_Click(object sender, EventArgs e) { fctbMain.ShowFindDialog(); }
        private void tsmiReplace_Click(object sender, EventArgs e) { fctbMain.ShowReplaceDialog(); }
        private void ctsmiAutoIndent_Click(object sender, EventArgs e) { fctbMain.DoAutoIndent(); }
        private void tsmiComment_Click(object sender, EventArgs e) { fctbMain.CommentSelected(); }
        private void tsmiSelectAll_Click(object sender, EventArgs e) { fctbMain.SelectAll(); }
        private void tsbCut_Click(object sender, EventArgs e) { fctbMain.Cut(); }
        private void tsbCopy_Click(object sender, EventArgs e) { fctbMain.Copy(); }
        private void tsbPaste_Click(object sender, EventArgs e) { fctbMain.Paste(); }

        //inserts
        private void tsmiNewItem_Click(object sender, EventArgs e)
        {
            if (!ProgramData.ProjectManager.LibraryInstalled("ItemsEngine"))
            {
                MessageBox.Show("You need to have nide/ItemsEngine library to be installed!");
                return;
            }
            fJsonItem form = new fJsonItem();
            if (form.ShowDialog() != DialogResult.Cancel)
            {
                fctbMain.AppendText("\nItemsEngine.SetItemFromJson(\"" + fJsonItem.name + ".json\");");
            }
        }

        private void tsmiNewCraft_Click(object sender, EventArgs e)
        {
            var form = new fCraft(ProgramData.FileOnly ? ProjectType.MODPE : ProgramData.ProjectManager.projectType);
            if (form.ShowDialog() == DialogResult.OK)
                fctbMain.AppendText("\n" + fCraft.recipie);
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            new fSettings().ShowDialog();
            Highlighting.ResetStyles(fctbMain.Range, fctbMain.Range);
        }

        private void tsmiNewScript_Click(object sender, EventArgs e)
        {
            fDialog form = new fDialog(DialogType.SCRIPT);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProgramData.ProjectManager.AddScript(form.name);
                    UpdateProject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to add script");
                }
            }
        }

        private void tsmiNewTexture_Click(object sender, EventArgs e)
        {
            var form = new fDialog(DialogType.TEXTURE);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProgramData.ProjectManager.AddTexture(form.name, form.type);
                    UpdateProject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to create new texture");
                }

            }
        }

        private void tsmiLibrary_Click(object sender, EventArgs e)
        {
            var form = new fDialog(DialogType.LIBRARY);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProgramData.ProjectManager.AddLibrary(form.name);
                    UpdateProject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to create new library");
                }

            }
        }


        //new project system
        private void OpenProject(string FileName)
        {
            if (!CanChangeFile()) return;
            try
            {
                ProgramData.FileOnly = false;
                ProgramData.ProjectManager = new ProjectManager(FileName);
                OpenScript(ProgramData.ProjectManager.MainScriptPath);
                InitProject();
                saved = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured while opening an existing project");
                throw new Exception();
            }
        }

        private void InitProject()
        {
            tsmiInserts.Enabled = true;
            tsmiNewItem.Enabled = true;
            tsmiNewLibrary.Enabled = true;
            tsmiManageLibraries.Enabled = true;
            tsmiBuild.Enabled = true;
            tsmiBuildAndPush.Enabled = true;
            tsbBuildPush.Enabled = true;
            tsbPush.Enabled = true;
            tvFolders.ContextMenuStrip = cmsTreeView;
            UpdateProject();
            switch (ProgramData.ProjectManager.projectType)
            {
                case ProjectType.MODPE:
                    break;
                case ProjectType.COREENGINE:
                    tsmiNewItem.Enabled = false;
                    tsmiNewLibrary.Enabled = false;
                    tsmiManageLibraries.Enabled = false;
                    tsmiPush.Enabled = false;
                    tsmiBuildAndPush.Enabled = false;
                    tsbBuildPush.Enabled = false;
                    tsbPush.Enabled = false;
                    break;
                case ProjectType.BEHAVIOUR_PACK:
                    tsmiInserts.Enabled = false;
                    tsmiNewLibrary.Enabled = false;
                    tsmiManageLibraries.Enabled = false;
                    tsmiPush.Enabled = false;
                    tsmiBuildAndPush.Enabled = false;
                    tsbBuildPush.Enabled = false;
                    tsbPush.Enabled = false;
                    break;
                case ProjectType.TEXTURE_PACK:
                    tsmiInserts.Enabled = false;
                    tsmiNewLibrary.Enabled = false;
                    tsmiManageLibraries.Enabled = false;
                    tsmiPush.Enabled = false;
                    tsmiBuildAndPush.Enabled = false;
                    tsbBuildPush.Enabled = false;
                    tsbPush.Enabled = false;
                    break;

            }
        }

        private void UpdateProject()
        {
            tvFolders.Nodes.Clear();
            tvFolders.Nodes.Add(ProgramData.ProjectManager.ProjectName);
            if(ProgramData.ProjectManager.projectType == ProjectType.MODPE)
                tvFolders.Nodes[0].Nodes.Add(Path.GetFileName(ProgramData.ProjectManager.ProjectFilePath));
            DirectoryRecursive(tvFolders.Nodes[0], new DirectoryInfo(ProgramData.ProjectManager.SourceCodePath));
            tvFolders.Nodes[0].Expand();
        }

        private void InitFileOnly(string filename)
        {
            ProgramData.FileOnly = true;
            OpenScript(filename);
            tsmiNewItem.Enabled = false;
            tsmiNewScript.Enabled = false;
            tsmiNewTexture.Enabled = false;
            tsmiNewLibrary.Enabled = false;
            tsmiBuild.Enabled = false;
            tsbBuild.Enabled = false;
            tvFolders.ContextMenuStrip = null;
        }

        private void DirectoryRecursive(TreeNode node, DirectoryInfo dir)
        {
            try
            {
                foreach (var subdir in dir.GetDirectories())
                    DirectoryRecursive(node.Nodes.Add(subdir.Name), subdir);
                foreach (var file in dir.GetFiles())
                    node.Nodes.Add(file.Name);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to load filesystem");
            }
        }

        private void OpenScript(string FileName)
        {
            ProgramData.file = FileName;
            tsslFile.Text = Path.GetFileName(FileName);
            fctbMain.OpenFile(FileName);
            string extension = Path.GetExtension(FileName).ToLower();
            if (extension == ".js")
                InitJS();
            else if (extension == ".nproj" || extension == ".includes" || extension == ".info" || extension == ".nlib")
                InitOther();
            Highlighting.ResetStyles(fctbMain.Range, fctbMain.Range);
        }

        private void InitJS()
        {
            fctbMain.Language = Language.JS;
        }

        private void InitOther()
        {
            fctbMain.Language = Language.Custom;
        }


        private void NewProjectDlg(bool closeIfNotChecked = false)
        {
            var form = new fNewProject();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProgramData.ProjectManager = new ProjectManager(form.path, form.type, form.name);
                    OpenScript(ProgramData.ProjectManager.MainScriptPath);
                    InitProject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "An error occured while creating a new project");
                }
            }
            else if (closeIfNotChecked)
            {
                Close();
            }
        }

        private void OpenProjectDlg(bool closeIfNotChecked = false)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                OpenProject(dlgOpen.FileName);
            }
            else if (closeIfNotChecked)
            {
                Close();
            }
        }


        private void tsmiNewProject_Click(object sender, EventArgs e)
        {
            NewProjectDlg();
        }

        private void tsmiOpenProject_Click(object sender, EventArgs e)
        {
            OpenProjectDlg();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            fctbMain.SaveToFile(ProgramData.file, Encoding.UTF8);
            saved = true;
        }

        private bool CanChangeFile()
        {
            if (!saved && fctbMain.Text != "")
            {
                var result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    fctbMain.SaveToFile(ProgramData.file, Encoding.UTF8);
                    return true;
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
                else return true;
            }
            else return true;
        }

        private void tsmiCloseProject_Click(object sender, EventArgs e)
        {
            if (!CanChangeFile()) return;
            ProgramData.Restart = true;
            Application.Restart();
        }

        private void tsmiBuild_Click(object sender, EventArgs e)
        {
            fctbMain.SaveToFile(ProgramData.file, Encoding.UTF8);
            saved = true;
            ProgramData.ProjectManager.build();
        }

        private void tsmiCheck_Click(object sender, EventArgs e)
        {
            if (fctbMain.Text != "")
                try
                {
                    JavaScriptCompressor compressor = new JavaScriptCompressor();
                    string compressed = compressor.Compress(fctbMain.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error in your Javascript code found!");
                }
        }

        private void tsmiRunJs_Click(object sender, EventArgs e)
        {
            new JsRunner(fctbMain.Text);
        }


        public void Log(string source, string message)
        {
            Invoke(new AddMessageDelegate(_log), new object[] { source, message });

        }

        private void _log(string source, string message)
        {
            string format = "[{0}]:{1} \n";
            console.AppendText(string.Format(format, source, message));
        }

        public delegate void AddMessageDelegate(string source, string message);
        public delegate void ClearLogDelegate();

        public void ClearLog()
        {
            Invoke(new ClearLogDelegate(console.Clear));
        }

        public void HighlightError(int line)
        {
            Highlighting.HighlightError(new Range(fctbMain, line));
        }

        private void tsmiPush_Click(object sender, EventArgs e)
        {
            ADBWorker.Push(ProgramData.ProjectManager.BuildPath + "main.js",
                ProgramData.ProjectManager.BuildPath + "resources.zip");
        }
        
        private void tsmiManageLibraries_Click(object sender, EventArgs e)
        {
            new fLibraries().ShowDialog();
        }

        private void tsbBuildPush_Click(object sender, EventArgs e)
        {
            tsmiBuild_Click(sender, e);
            tsmiPush_Click(sender, e);
        }

        private void tvFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvFolders.SelectedNode = e.Node;
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            UpdateProject();
            ProgramData.ProjectManager.UpdateNlib();
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            var node = tvFolders.SelectedNode;
            OldPath = GetTreeViewPath(node);
            tvFolders.LabelEdit = true;
            node.BeginEdit();
        }

        private void tvFolders_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            BeginInvoke(new Action(() => afterAfterEdit(e.Node)));
        }

        private void afterAfterEdit(TreeNode node)
        {
            tvFolders.LabelEdit = false;
            string path = GetTreeViewPath(node);
            if (node.Parent != null && !OldPath.EndsWith(".nproj", StringComparison.OrdinalIgnoreCase) && path != OldPath)
            {
                try
                {
                    if (File.Exists(OldPath))
                        File.Move(OldPath, path);
                    if (Directory.Exists(OldPath))
                        Directory.Move(OldPath, path);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void tsmiNewFile_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = GetTreeViewPath(tvFolders.SelectedNode);
                if (!Directory.Exists(dir))
                    return;
                string fileName = "file.js";
                int i = 1;
                while (File.Exists(Path.Combine(dir, fileName)))
                {
                    fileName = "file" + i + ".js";
                    i++;
                }
                File.Create(Path.Combine(dir, fileName)).Close();
                TreeNode node = new TreeNode(fileName);
                tvFolders.SelectedNode.Nodes.Add(node);
                tvFolders.SelectedNode.Expand();
                OldPath = GetTreeViewPath(node);
                tvFolders.LabelEdit = true;
                node.BeginEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmiNewDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = GetTreeViewPath(tvFolders.SelectedNode);
                if (!Directory.Exists(dir))
                    return;
                string folderName = "folder";
                int i = 1;
                while (Directory.Exists(Path.Combine(dir, folderName)))
                {
                    folderName = "folder" + i;
                    i++;
                }
                Directory.CreateDirectory(Path.Combine(dir, folderName));
                TreeNode node = new TreeNode(folderName);
                tvFolders.SelectedNode.Nodes.Add(node);
                tvFolders.SelectedNode.Expand();
                OldPath = GetTreeViewPath(node);
                tvFolders.LabelEdit = true;
                node.BeginEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsmiLinks_Click(object sender, EventArgs e)
        {
            Process.Start("links.html");
        }

        private void tsmiVersion_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                int version = Convert.ToInt32(client.DownloadString("http://api.mineprogramming.org/nide-version/"));
                client.Dispose();
                if (version > ProgramData.PROGRAM_VERSION)
                {
                    if (MessageBox.Show("Download it now?", "Update found!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start("https://www.mineprogramming.org/nide/");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot connect to the service!");
            }
        }
    }
}