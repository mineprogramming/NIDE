using NIDE.Editors;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NIDE.components
{
    public partial class ProjectTree : TreeView
    {
        private string OldPath = "";

        public ProjectTree()
        {
            InitializeComponent();
            NodeMouseDoubleClick += ProjectTree_NodeMouseDoubleClick;
            AfterLabelEdit += ProjectTree_AfterLabelEdit;
            NodeMouseClick += ProjectTree_NodeMouseClick;
        }

        private void ProjectTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedNode = e.Node;
        }

        private void ProjectTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            BeginInvoke(new Action(() => afterAfterEdit(e.Node)));
        }

        private void afterAfterEdit(TreeNode node)
        {
            LabelEdit = false;
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

        private void ProjectTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = GetTreeViewPath(e.Node);

            if (Directory.Exists(path))
                return;

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
                    catch { EditorsManager.GetEditor(path).Edit(); }
                else EditorsManager.GetEditor(path).Edit();
            }
            else
            {
                Editor editor = EditorsManager.GetEditor(path);
                editor.Edit();
            }
        }

        

        private void tsmiNewFile_Click(object sender, System.EventArgs e)
        {
            try
            {
                SelectDirectory();
                string dir = GetTreeViewPath(SelectedNode);
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
                SelectedNode.Nodes.Add(node);
                SelectedNode.Expand();
                OldPath = GetTreeViewPath(node);
                LabelEdit = true;
                node.BeginEdit();
            }
            catch (Exception ex)
            {
                ProgramData.Log("ProjectTree", ex.Message);
            }
        }

        private void tsmiNewDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                SelectDirectory();
                string dir = GetTreeViewPath(SelectedNode);
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
                SelectedNode.Nodes.Add(node);
                SelectedNode.Expand();
                OldPath = GetTreeViewPath(node);
                LabelEdit = true;
                node.BeginEdit();
            }
            catch (Exception ex)
            {
                ProgramData.Log("ProjectTree", ex.Message);
            }
        }

        private void tsmiRename_Click(object sender, EventArgs e)
        {
            var node = SelectedNode;
            OldPath = GetTreeViewPath(node);
            LabelEdit = true;
            node.BeginEdit();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (SelectedNode.Text != "main.js"
                && Path.GetExtension(SelectedNode.Text).ToLower() != ".nproj")
            {
                try
                {
                    string path = GetTreeViewPath(SelectedNode);
                    if (File.Exists(path))
                        File.Delete(path);
                    else if (Directory.Exists(path))
                        Directory.Delete(path, true);
                    SelectedNode.Remove();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot delete this file");
                }
            }
        }

        private void tsmiOpenInExplorer_Click(object sender, EventArgs e)
        {
            Process.Start(GetTreeViewPath(GetDirectory()));
        }

        private void tsmiNewScript_Click(object sender, EventArgs e)
        {
            ProgramData.MainForm.NewScript();
        }

        private void tsmiNewTexture_Click(object sender, EventArgs e)
        {
            ProgramData.MainForm.NewTexture();
        }

        private string GetTreeViewPath(TreeNode node)
        {
            if (node == Nodes[0])
                return ProgramData.Project.Path;
            string path_relative = node.FullPath;
            path_relative = path_relative.Substring(path_relative.IndexOf('\\') + 1);
            return ProgramData.Project.Path + "\\" + path_relative;
        }

        private void SelectDirectory()
        {
            SelectedNode = GetDirectory();
        }

        private TreeNode GetDirectory()
        {
            if (File.Exists(GetTreeViewPath(SelectedNode)))
                return SelectedNode.Parent;
            else return SelectedNode;
        }
    }
}
