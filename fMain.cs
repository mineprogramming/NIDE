using FastColoredTextBoxNS;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Yahoo.Yui.Compressor;
using System.Diagnostics;

namespace NIDE
{
    public partial class fMain : Form
    {
        private bool saved = true;
        private string[] args;

        public fMain(string[] args)
        {
            this.args = args;
            InitializeComponent();
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to open this project!");
                    Close();
                }
            }// Open with
            else
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
                    }
                }
                else
                {
                    Close();
                }
            }//StartScreen
        }

        private void fctbMain_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (fctbMain.Language == Language.JS && ProgramData.ProjectManager != null)
            {
                Highlighting.ResetStyles(e.ChangedRange);
                CodeAnalysisEngine.Update();
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
            string path = GetTreeViewPath(e.Node);
            string extension = Path.GetExtension(path).ToLower();
            if (extension == ".js" || extension == ".nproj")
            {
                OpenScript(path);
            }
            else if (extension == ".png")
            {
                var form = new fPngEditor(path);
                form.ShowDialog();
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
                return ProgramData.ProjectManager.SourceCodePath + path_relative;
            }
        }

        private void tsmiNewScript_Click(object sender, EventArgs e)
        {
            fDialog form = new fDialog();
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
            var form = new fDialog(true);
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

        private void tsmiDeleteTexture_Click(object sender, EventArgs e)
        {
            if (tvFolders.SelectedNode.Text != "main.js"
                && Path.GetExtension(tvFolders.SelectedNode.Text).ToLower() != ".nproj"
                && Path.GetExtension(tvFolders.SelectedNode.Text) != "")
            {
                try
                {
                    File.Delete(GetTreeViewPath(tvFolders.SelectedNode));
                    UpdateProject();
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

        //textworking
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            fctbMain.Undo();
        }

        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            fctbMain.Redo();
        }
        private void tsmiFind_Click(object sender, EventArgs e)
        {
            fctbMain.ShowFindDialog();
        }
        private void tsmiReplace_Click(object sender, EventArgs e)
        {
            fctbMain.ShowReplaceDialog();
        }
        private void ctsmiAutoIndent_Click(object sender, EventArgs e)
        {
            fctbMain.DoAutoIndent();
        }
        private void tsmiComment_Click(object sender, EventArgs e)
        {
            fctbMain.CommentSelected();
        }
        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            fctbMain.SelectAll();
        }
        private void tsbCut_Click(object sender, EventArgs e)
        {
            fctbMain.Cut();
        }
        private void tsbCopy_Click(object sender, EventArgs e)
        {
            fctbMain.Copy();
        }
        private void tsbPaste_Click(object sender, EventArgs e)
        {
            fctbMain.Paste();
        }


        //build
        private void tsmiRun_Click(object sender, EventArgs e)
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


        //inserts
        private void tsmiNewItem_Click(object sender, EventArgs e)
        {
            fJsonItem form = new fJsonItem();
            if (form.ShowDialog() != DialogResult.Cancel)
            {
                fctbMain.AppendText("\nSetTileFromJson(\"" + fJsonItem.name + ".json\");");
            }

        }

        private void craftRecipieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new fCraft();
            if (form.ShowDialog() == DialogResult.OK)
                fctbMain.AppendText("\n" + fCraft.recipie);
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            new fSettings().ShowDialog();
            Highlighting.ResetStyles(fctbMain.Range);
        }


        //new project system
        private void OpenProject(string FileName)
        {
            if (!CanChangeFile()) return;
            try
            {
                ProgramData.ProjectManager = new ProjectManager(FileName);
                OpenScript(ProgramData.ProjectManager.MainScriptPath);
                InitProject();
                saved = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured while opening an existing project");
            }
        }

        private void InitProject()
        {
            UpdateProject();
        }

        private void UpdateProject()
        {
            tvFolders.Nodes.Clear();
            tvFolders.Nodes.Add(ProgramData.ProjectManager.ProjectName);
            tvFolders.Nodes[0].Nodes.Add(Path.GetFileName(ProgramData.ProjectManager.ProjectFilePath));
            DirectoryRecursive(tvFolders.Nodes[0], new DirectoryInfo(ProgramData.ProjectManager.SourceCodePath));
            tvFolders.Nodes[0].Expand();
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
            else if (extension == ".nproj")
                InitNproj();
        }

        private void InitJS()
        {
            fctbMain.Language = Language.JS;
        }

        private void InitNproj()
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
            Application.Restart();
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramData.ProjectManager.build();
        }
    }
}