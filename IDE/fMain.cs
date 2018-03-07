using FastColoredTextBoxNS;
using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Net;
using NIDE.ProjectTypes;
using NIDE.adb;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NIDE
{
    public partial class fMain : Form
    {
        private bool saved = true;
        private string[] args;
        private string OldPath = "";

        private Highlighter highlighter;


        //Main form
        public fMain(string[] args)
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
            this.args = args;
            InitializeComponent();
            ProgramData.MainForm = this;
            CodeAnalysisEngine.Initialize(fctbMain);
            RegistryWorker.Load(this);
            highlighter = new Highlighter(fctbMain);
            Autocomplete.SetAutoompleteMenu(fctbMain);
            fctbMain.HighlightingRangeType = HighlightingRangeType.VisibleRange;
            try
            {
                ModPE.LoadData("modpescript_dump.txt");
                ZCore.LoadData("core.txt", "patterns.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to load ModPE or CoreEngine data");
                Close();
            }
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            CheckUpdates();
            SendStats();
            if (args.Length > 0)
            {
                try
                {
                    if (Path.GetExtension(args[0]).ToLower() == ".nproj")
                    {
                        OpenProject(args[0]);
                    }
                    else MessageBox.Show(args[0], "Unsupported file type!");
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
                            //ImportModpkg(true);
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

        private void fctbMain_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (fctbMain.Language == Language.JS && ProgramData.Project != null)
            {
                if (ProgramData.file.EndsWith(".js"))
                {
                    CodeAnalysisEngine.Update();
                    ProgramData.MainForm.UpdateHighlighting(e.ChangedRange);
                }
            }
            saved = false;
            if (!tsslFile.Text.EndsWith("*"))
                tsslFile.Text = tsslFile.Text + "*";
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CanChangeFile()) e.Cancel = true;
            RegistryWorker.Save(this);
        }
        
        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ADBWorker.Kill();
        }


        //Connections
        public int TextViewWidth { get { return tvFolders.Width; } set { tvFolders.Width = value; } }
        public int TextViewHeight { get { return mainSplit.SplitterDistance; } set { mainSplit.SplitterDistance = value; } }


        //Textworking
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


        //Inserts
        private void tsmiNewItem_Click(object sender, EventArgs e)
        {
            if (!ProgramData.Project.LibraryInstalled("ItemsEngine"))
            {
                var result = MessageBox.Show("You need to have ItemsEngine library to be installed!\nDo you want to install it now?",
                    "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
                else
                {
                    ProgramData.Project.IncludeLibrary("ItemsEngine");
                }
            }
            fJsonItem form = new fJsonItem();
            if (form.ShowDialog() != DialogResult.Cancel)
            {
                fctbMain.AppendText("\nItemsEngine.SetItemFromJson(\"" + fJsonItem.name + ".json\");");
                UpdateProject();
            }
        }

        private void tsmiNewCraft_Click(object sender, EventArgs e)
        {
            var form = new fCraft(ProgramData.Project.CraftPattern);
            if (form.ShowDialog() == DialogResult.OK)
                fctbMain.AppendText("\n" + fCraft.recipie);
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            new fSettings(highlighter).ShowDialog();
            highlighter.ResetStyles(fctbMain.Range);
        }

        private void tsmiNewScript_Click(object sender, EventArgs e)
        {
            fDialog form = new fDialog(DialogType.SCRIPT);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProgramData.Project.AddScript(form.name);
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
                    ProgramData.Project.AddTexture(form.name, form.type);
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
                    ProgramData.Project.AddLibrary(form.name);
                    UpdateProject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to create new library");
                }

            }
        }


        //Project and files system
        private void OpenProject(string FileName)
        {
            if (!CanChangeFile()) return;
            try
            {
                ProgramData.Project = Project.New(FileName);
                OpenScript(ProgramData.Project.MainScriptPath);
                InitProject();
                saved = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured while opening an existing project");
                throw new Exception();
            }
        }

        //private void ImportModpkg(bool closeIfNotChecked = false)
        //{
        //    var form = new fNewProject(true);
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            ProgramData.Project = new ProjectManager(form.source, form.path, form.name);
        //            OpenScript(ProgramData.ProjectManager.MainScriptPath);
        //            InitProject();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "An error occured while creating a new project");
        //        }
        //    }
        //    else if (closeIfNotChecked)
        //    {
        //        Close();
        //    }
        //}

        private void InitProject()
        {
            UpdateProject();
            tsbShowMain.Enabled = ProgramData.Project.ShowMainEnabled;
            if(ProgramData.Project.Type == ProjectType.COREENGINE || ProgramData.Project.Type == ProjectType.INNERCORE)
            {
                tsmiNewItem.Enabled = false;
                tsmiNewLibrary.Enabled = false;
                tsmiManageLibraries.Enabled = false;
            }
            else
            {
                tsmiNewItem.Enabled = true;
                tsmiNewLibrary.Enabled = true;
                tsmiManageLibraries.Enabled = true;
            }
            Text = ProgramData.Project.Name + " - NIDE 2018 build " + ProgramData.PROGRAM_VERSION;
        }

        private void UpdateProject()
        {
            tvFolders.Nodes.Clear();
            tvFolders.Nodes.Add(ProgramData.Project.Name);
            ProgramData.Project.Post_tree_reload(tvFolders.Nodes[0]);
            Util.FillDirectoryNodes(tvFolders.Nodes[0], new DirectoryInfo(ProgramData.Project.SourceCodePath));
            tvFolders.Nodes[0].Expand();
        }

        private void tsbShowMain_Click(object sender, EventArgs e)
        {
            if (CanChangeFile())
            {
                OpenScript((ProgramData.Project as ModPE).BuildPath + "main.js");
                fctbMain.ReadOnly = true;
            }
        }


        private void OpenScript(string FileName)
        {
            try
            {
                ProgramData.file = FileName;
                fctbMain.OpenFile(FileName, ProgramData.Encoding);
                fctbMain.ReadOnly = false;
                string extension = Path.GetExtension(FileName).ToLower();
                if (extension == ".js")
                    InitJS();
                else
                    InitOther();
                saved = true;
                tsslFile.Text = Path.GetFileName(FileName);
                highlighter.RefreshStyles();
            }
            catch (Exception e)
            {
                Log("FileSystem", "Unable to open script! " + e.Message);
            }
        }

        private void InitJS()
        {
            fctbMain.Language = Language.JS;
            Autocomplete.Enabled = true;
        }

        private void InitOther()
        {
            fctbMain.Language = Language.Custom;
            Autocomplete.Enabled = false;
        }


        private void NewProjectDlg(bool closeIfNotChecked = false)
        {
            var form = new fNewProject();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    switch (form.type)
                    {
                        case ProjectType.MODPE:
                            ProgramData.Project = new ModPE(form.path, form.name);
                            break;
                        case ProjectType.COREENGINE:
                            ProgramData.Project = new CoreEngine(form.path, form.name);
                            break;
                        case ProjectType.INNERCORE:
                            ProgramData.Project = new InnerCore(form.path, form.name);
                            break;
                    }

                    OpenScript(ProgramData.Project.MainScriptPath);
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
            File.WriteAllLines(ProgramData.file, fctbMain.Lines, ProgramData.Encoding);
            saved = true;
            tsslFile.Text = tsslFile.Text.Replace("*", "");
        }

        private void tsmiCloseProject_Click(object sender, EventArgs e)
        {
            if (!CanChangeFile()) return;
            ProgramData.Restart = true;
            Application.Restart();
        }

        private bool CanChangeFile()
        {
            if (fctbMain.ReadOnly || saved || fctbMain.Text == "") return true;
            var result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                fctbMain.SaveToFile(ProgramData.file, ProgramData.Encoding);
                return true;
            }
            else if (result == DialogResult.Cancel)
            {
                return false;
            }
            else return true;
        }


        //Log and errors
        private List<int> errorLines = new List<int>();

        public delegate void AddMessageDelegate(string source, string message);
        public delegate void ErrorDelegate(int source, string message);
        public delegate void ClearLogDelegate();
        public delegate void UpdateHighlightingDelegate(Range range);
        public void Log(string source, string message)
        {
            Invoke(new AddMessageDelegate(_log), new object[] { source, message });
        }
        public void Error(int line, string message)
        {
            Invoke(new ErrorDelegate(_error), new object[] { line, message });
        }
        public void ClearErrors()
        {
            Invoke(new ClearLogDelegate(_clear));
        }
        public void UpdateHighlighting(Range range)
        {
            Invoke(new UpdateHighlightingDelegate(highlighter.ResetStyles), range);
        }
        private void _log(string source, string message)
        {
            string format = "[{0}]: {1} \n";
            logger.AppendText(string.Format(format, source, message));
        }
        private void _error(int line, string message)
        {
            errors.AppendText("Line " + line + ": " + message + "\n");
        }
        private void _clear()
        {
            errors.Clear();
            errorLines.Clear();
        }
        public void HighlightError(int line)
        {
            errorLines.Add(line);
        }

        private void fctbMain_PaintLine(object sender, PaintLineEventArgs e)
        {
            if (errorLines.Contains(e.LineIndex))
            {
                highlighter.HighlightError(e);
            }
        }



        //Project managing
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            UpdateProject();
            ProgramData.Project.UpdateNlib();
        }

        private void tsmiManageLibraries_Click(object sender, EventArgs e)
        {
            new fLibraries().ShowDialog();
        }

        private void tsmiBuild_Click(object sender, EventArgs e)
        {
            fctbMain.SaveToFile(ProgramData.file, ProgramData.Encoding);
            saved = true;
            if(ProgramData.Project.Type != ProjectType.INNERCORE)
                ProgramData.Project.Build();
        }

        private void tsmiPush_Click(object sender, EventArgs e)
        {
            ADBWorker.Push(new DirectoryInfo(ProgramData.Project.PushPath));
        }

        private void tsbBuildPush_Click(object sender, EventArgs e)
        {
            tsmiBuild_Click(sender, e);
            tsmiPush_Click(sender, e);
        }

        private void tsmiRunJs_Click(object sender, EventArgs e)
        {

            new JsRunner(fctbMain.Text);
        }


        //Tree view
        private void tvFolders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = GetTreeViewPath(e.Node);
            if (Directory.Exists(path))
                return;
            if (!CanChangeFile()) return;
            string extension = Path.GetExtension(path).ToLower();
            if (extension == ".png")
            {
                Process.Start(Path.Combine(Directory.GetCurrentDirectory(), "bin\\NPixelPaint.exe"), "\"" + path + "\"");
            }
            else if (extension == ".json")
            {
                if (ProgramData.Project.Type == ProjectType.MODPE)
                    try
                    {
                        new fJsonItem(path).Show();
                    }
                    catch { OpenScript(path); }
                else OpenScript(path);
            }
            else if (Constants.TextExtensions.Contains(extension) || 
                MessageBox.Show("Do you want toopen is as a text file?", "Unknown file format!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OpenScript(path);
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

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            var node = tvFolders.SelectedNode;
            OldPath = GetTreeViewPath(node);
            tvFolders.LabelEdit = true;
            node.BeginEdit();
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

        private void tsmiOpenInExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(ProgramData.Project.Path);
        }

        private string GetTreeViewPath(TreeNode node)
        {
            if (node.Text == Path.GetFileName(ProgramData.Project.Nproj))
                return ProgramData.Project.Nproj;
            else
            {
                string path_relative = node.FullPath;
                path_relative = path_relative.Substring(path_relative.IndexOf('\\') + 1);
                return ProgramData.Project.SourceCodePath + "\\" + path_relative;
            }
        }

        private void tvFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvFolders.SelectedNode = e.Node;
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


        //Other
        private void tsmiVersion_Click(object sender, EventArgs e)
        {
            CheckUpdates();
        }

        private void CheckUpdates()
        {
            try
            {
                WebClient client = new WebClient();
                int version = Convert.ToInt32(client.DownloadString("http://api.mineprogramming.org/nide/version/"));
                client.Dispose();
                if (version > ProgramData.PROGRAM_VERSION)
                {
                    if (MessageBox.Show("Download it now?", "Update found!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = "CMD.exe";
                        process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                        process.StartInfo.Arguments = "/C \"cd /d \"" + Directory.GetCurrentDirectory() + "\" && cscript //D //Nologo update.vbs\"";
                        process.StartInfo.UseShellExecute = true;
                        process.StartInfo.Verb = "runas";
                        process.Start();
                        Close();
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message, "Unable to download update!"); }
        }

        private void SendStats()
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadString("http://api.mineprogramming.org/nide/counters/open.php");
                client.Dispose();

            }
            catch (Exception e) { }
        }

        private void tsmiCoreEngineDocs_Click(object sender, EventArgs e)
        {
            Process.Start("CoreEngine help.chm");
        }

        private void tsmiLinks_Click(object sender, EventArgs e)
        {
            Process.Start("links.html");
        }

        private void Ads_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = true;
            if (e.Url.ToString().StartsWith("http"))
                Process.Start(e.Url.ToString());
        }

        private void tsmiRenderer_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("bin\\RendererTool.exe"));
        }

        private void btnStartLog_Click(object sender, EventArgs e)
        {
            ADBWorker.StartLog();
        }

        private void btnStopLog_Click(object sender, EventArgs e)
        {
            ADBWorker.Kill();
        }
        
    }
}