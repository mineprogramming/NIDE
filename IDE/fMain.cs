using FastColoredTextBoxNS;
using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using NIDE.ProjectTypes;
using NIDE.adb;
using NIDE.window;
using NIDE.Editors;
using NIDE.UI;
using NIDE.Highlighting;
using System.Threading;
using static NIDE.window.SearchListBox;
using NIDE.ProjectTypes.MCPEModding.ZCore;
using NIDE.ProjectTypes.MCPEModding;

namespace NIDE
{
    public partial class fMain : Form
    {
        private const int LEFT_PANEL_MIN_SIZE = 150;
        private const int BOTTOM_PANEL_MIN_SIZE = 80;

        private string[] args;

        private Highlighter highlighter;

        public FastColoredTextBox fctbMain { get { return currentTab.TextBox; } }
        public CodeEditor CurrentEditor { get { return currentTab.Editor; } }
        private EditorTab currentTab;


        #region Main form
        public fMain(string[] args)
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
            this.args = args;
            InitializeComponent();
            ProgramData.MainForm = this;
            RegistryWorker.Load();
            highlighter = new Highlighter();
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            CheckUpdates();
            SendStats();
            
            if (args.Length > 0 && args[0] == "update")
            {
                string[] toDelete = { "update.vbs", "update.zip" };
                foreach(string file in toDelete)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }

            if (args.Length > 0 && args[0] != "update")
            {
                try
                {
                    if (System.IO.Path.GetExtension(args[0]).ToLower() == ".nproj")
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
            CurrentEditor.Update(e.ChangedRange);
        }

        private void fctbMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProgramData.Project.OnEnter(fctbMain);
            }
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (EditorTab tab in tabControl.TabPages)
            {
                if (!tab.CanClose()) e.Cancel = true;
            }
            RegistryWorker.Save();
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ADBWorker.Kill();
            Environment.Exit(0);
        }

        //Connections
        public int TextViewWidth { get { return projectTree.Width; } set { projectTree.Width = value; } }
        public int TextViewHeight { get { return mainSplit.SplitterDistance; } set { mainSplit.SplitterDistance = value; } }
        #endregion
        

        #region Edit
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
        #endregion


        #region Insert
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
        
        public void NewScript() => tsmiNewScript.PerformClick();
        private void tsmiNewScript_Click(object sender, EventArgs e)
        {
            NewDialog form = new NewDialog(DialogType.SCRIPT);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = ProgramData.Project.AddScript(form.name);
                    projectTree.UpdatePath(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to add script");
                }
            }
        }

        public void NewTexture() => tsmiNewTexture.PerformClick();
        private void tsmiNewTexture_Click(object sender, EventArgs e)
        {
            var form = new NewDialog(DialogType.TEXTURE);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = ProgramData.Project.AddTexture(form.name, form.type);
                    projectTree.UpdatePath(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to create new texture");
                }

            }
        }

        private void tsmiLibrary_Click(object sender, EventArgs e)
        {
            var form = new NewDialog(DialogType.LIBRARY);
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
        #endregion


        #region Project
        private void OpenProject(string FileName)
        {
            if (!CanChangeFile()) return;
            try
            {
                ProgramData.Project = Project.New(FileName);
                CodeEditor editor = (CodeEditor)EditorsManager.GetEditor(ProgramData.Project.MainScriptPath);
                editor.EditBlank = true;
                editor.Edit();
                InitProject();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured while opening an existing project");
                throw new Exception();
            }
        }

        private void InitProject()
        {
            UpdateProject();
            tsbShowMain.Enabled = ProgramData.Project.ShowMainEnabled;
            if (ProgramData.Project.Type == ProjectType.COREENGINE || ProgramData.Project.Type == ProjectType.INNERCORE)
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
            projectTree.Nodes.Clear();
            projectTree.Nodes.Add(ProgramData.Project.Name);
            ProgramData.Project.Post_tree_reload(projectTree.Nodes[0]);
            Util.FillDirectoryNodes(projectTree.Nodes[0], new DirectoryInfo(ProgramData.Project.Path));
            projectTree.Nodes[0].Expand();
        }
        #endregion


        #region Project UI
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
                    Editor editor = EditorsManager.GetEditor(ProgramData.Project.MainScriptPath);
                    editor.Edit();
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

        private void tsmiCloseProject_Click(object sender, EventArgs e)
        {
            if (!CanChangeFile()) return;
            ProgramData.Restart = true;
            Application.Restart();
        }
        #endregion


        #region Files
        private void tsbShowMain_Click(object sender, EventArgs e)
        {
            if (CanChangeFile())
            {
                Editor editor = EditorsManager.GetEditor(ProgramData.Project.BuiltScriptPath);
                editor.Edit();
                fctbMain.ReadOnly = true;
            }
        }

        public EditorTab OpenScript(string FileName, CodeEditor editor, bool blank = false)
        {
            try
            {
                if (blank)
                    currentTab = tabControl.LoadBlank(FileName, editor);
                else
                    currentTab = tabControl.Load(FileName, editor);
                highlighter.RefreshStyles();
                fctbMain.TextChanged += fctbMain_TextChanged;
                fctbMain.KeyDown += fctbMain_KeyDown;
                fctbMain.PaintLine += fctbMain_PaintLine;
                return currentTab;
            }
            catch (Exception e)
            {
                Log("FileSystem", "Unable to open script! " + e.Message);
                return null;
            }
        }

        private bool CanChangeFile()
        {
            return tabControl.TabCount == 0 || currentTab.CanClose();
        }
        #endregion


        #region Files UI
        private void tsmiSave_Click(object sender, EventArgs e)
        {
            currentTab.Save();
            tabControl.Refresh();
        }
        #endregion


        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            new fSettings(highlighter).ShowDialog();
            highlighter.ResetStyles(fctbMain.Range);
        }

        //Log and errors
        public void Log(string source, string message)
        {
            try
            {
                Invoke(new Action(() => {
                    string format = "[{0}]: {1} \r\n";
                    logger.AppendText(string.Format(format, source, message));
                }));
            }
            catch { }

        }
        public void Error(int line, string message)
        {
            Invoke(new Action(() =>
            {
                errors.AppendText("Line " + line + ": " + message + "\n");
            }));
        }
        public void ClearErrors()
        {
            Invoke( new Action(() => {
                errors.Clear();
                CurrentEditor.Errors.Clear();
            }));
        }
        public void UpdateHighlighting(Range range)
        {
            Invoke(new Action(() => {
                highlighter.ResetStyles(range);
            }));
        }
        public void HighlightError(int line)
        {
            CurrentEditor.Errors.Add(line);
        }


        public void StartProgress(int total)
        {
            Invoke(new Action(() =>
            {
                ProgressBarStatus.Visible = true;
                ProgressBarStatus.Maximum = total;
            }));
        }
        public void Progress(int progress)
        {
            Invoke(new Action(() =>
            {
                ProgressBarStatus.Value = progress;
            }));
        }
        public void StopProgress()
        {
            Invoke(new Action(() =>
            {
                ProgressBarStatus.Visible = false;
                PushButtonsEnabled = true;
            }));
        }

        private void fctbMain_PaintLine(object sender, PaintLineEventArgs e)
        {
            if (CurrentEditor.Errors.Contains(e.LineIndex))
            {
                highlighter.HighlightError(e);
            }
        }



        //Project managing
        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            UpdateProject();
            ProgramData.Project.UpdateNlib();
            tabControl.ReloadTabs();
        }

        private void tsmiManageLibraries_Click(object sender, EventArgs e)
        {
            new fLibraries().ShowDialog();
        }

        private void tsmiBuild_Click(object sender, EventArgs e)
        {
            foreach (EditorTab tab in tabControl.TabPages)
            {
                tab.Save();
            }
            try
            {
                ProgramData.Project.Build();
                Log("Build", "Project successfully built");
            }
            catch (Exception ex)
            {
                Log("Build", "Unable to build project: " + ex.Message);
            }

        }

        private void TsbBuildPush_Click(object sender, EventArgs e)
        {
            tsmiBuild_Click(sender, e);
            TsbPush_ButtonClick(sender, e);
        }

        private void tsmiRunJs_Click(object sender, EventArgs e)
        {
            new JsRunner(fctbMain.Text);
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
                        Process.Start("bin\\Updater.exe");
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
            catch{ }
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

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTab = (EditorTab)tabControl.SelectedTab;
            try { CurrentEditor.Focus(); } catch { }; //TODO: КОСТЫЛЬ!!!
        }

        private void tsmiSaveAll_Click(object sender, EventArgs e)
        {
            foreach (EditorTab tab in tabControl.TabPages)
            {
                tab.Save();
            }
        }


        #region ADB buttons

        private bool PushButtonsEnabled
        {
            get
            {
                return tsbPush.Enabled;
            }
            set
            {
                ToolStripItem[] items = new ToolStripItem[] { tsmiBuildAndPush, tsmiPush, tsbBuildPush, tsbPush };
                foreach (var btn in items)
                    btn.Enabled = value;
            }
        }

        private void TogglePushButton(object sender)
        {
            if (tsbPush != sender)
            {
                tsbPush.Tag = sender;
                tsbPush.Text = (sender as ToolStripMenuItem).Text;
            }
        }

        private void TsbPush_ButtonClick(object sender, EventArgs e)
        {
            (tsbPush.Tag as ToolStripMenuItem).PerformClick();
        }

        private void TsbPushEverything_Click(object sender, EventArgs e)
        {
            PushButtonsEnabled = false;
            TogglePushButton(sender);
            ADBWorker.Push(new DirectoryInfo(ProgramData.Project.PushPath));
        }

        private void TsbPushCode_Click(object sender, EventArgs e)
        {
            PushButtonsEnabled = false;
            TogglePushButton(sender);
            ADBWorker.Push(new DirectoryInfo(ProgramData.Project.CodePath), "dev/");
        }

        private void PushChosen(bool forceWindow = false)
        {
            FChooseFiles form = new FChooseFiles();
            if (form.ShowDialog(forceWindow) == DialogResult.OK)
            {
                PushButtonsEnabled = false;
                TogglePushButton(tsbPushFiles);
                ADBWorker.Push(form.Files, ProgramData.Project.PushPath);
            }
        }

        private void TsbPushFiles_Click(object sender, EventArgs e)
        {
            PushChosen();
        }

        private void TsmiChooseFiles_Click(object sender, EventArgs e)
        {
            PushChosen(true);
        }

        private void btnStartLog_Click(object sender, EventArgs e)
        {
            ADBWorker.StartLog();
        }

        private void btnStopLog_Click(object sender, EventArgs e)
        {
            ADBWorker.StopLog();
        }
        #endregion

        #region Panels
        private void btnHideTree_Click(object sender, EventArgs e)
        {
            if(splitter.SplitPosition == 1)
            {
                splitter.MinSize = LEFT_PANEL_MIN_SIZE;
                splitter.SplitPosition = LEFT_PANEL_MIN_SIZE;
                btnHideTree.Text = "◄";
            }
            else
            {
                splitter.MinSize = 0;
                splitter.SplitPosition = 1;
                btnHideTree.Text = "►";
            }
        }

        private void splitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if(splitter.SplitPosition > 1 && splitter.SplitPosition < LEFT_PANEL_MIN_SIZE)
            {
                splitter.MinSize = LEFT_PANEL_MIN_SIZE;
                splitter.SplitPosition = LEFT_PANEL_MIN_SIZE;
                btnHideTree.Text = "◄";
            }
        }

        private void btnHideBottomPanel_Click(object sender, EventArgs e)
        {
            if (mainSplit.Height - mainSplit.SplitterDistance == 4)
            {
                mainSplit.Panel2MinSize = BOTTOM_PANEL_MIN_SIZE;
                mainSplit.SplitterDistance = mainSplit.Height - BOTTOM_PANEL_MIN_SIZE;
                btnHideBottomPanel.Text = "▼";
            }
            else
            {
                mainSplit.Panel2MinSize = 0;
                mainSplit.SplitterDistance = mainSplit.Height - 1;
                btnHideBottomPanel.Text = "▲";
            }
        }

        private void mainSplit_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            if (mainSplit.SplitterDistance > 1 && mainSplit.SplitterDistance < BOTTOM_PANEL_MIN_SIZE)
            {
                mainSplit.Panel2MinSize = BOTTOM_PANEL_MIN_SIZE;
                mainSplit.SplitterDistance = mainSplit.Height - BOTTOM_PANEL_MIN_SIZE;
                btnHideBottomPanel.Text = "▼";
            }
        }
        #endregion

        Thread searchThread = null;
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            lbSearchResults.Items.Clear();
            if (tbSearch.Text == "")
                return;
            if (searchThread != null)
                searchThread.Abort();
            searchThread = new Thread(() => Search(tbSearch.Text, true));
            searchThread.Start();
        }

        private void Search(string pattern, bool caseInsensitive)
        {
            if (caseInsensitive)
                pattern = pattern.ToLower();
            string[] files = Directory.GetFiles(ProgramData.Project.CodePath, "*.js");
            foreach(string file in files)
            {
                string[] lines = File.ReadAllLines(file);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (caseInsensitive)
                        lines[i] = lines[i].ToLower();
                    if (lines[i].Contains(pattern))
                    {
                        Invoke(new Action(() =>
                        {
                            lbSearchResults.Items.Add(new SearchListItem(file, i, lines[i]));
                        }));
                    }
                }
            }
        }

        

        private void lbSearchResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbSearchResults.SelectedItem != null)
            {
                SearchListItem item = (SearchListItem)lbSearchResults.SelectedItem;
                CodeEditor editor = (CodeEditor)EditorsManager.GetEditor(item.File.ToString());
                editor.Edit();
                editor.ToLine(item.Line);
            }
        }
    }
}