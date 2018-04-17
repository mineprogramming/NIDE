using NIDE.Editors;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NIDE.window
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

        public void UpdatePath(Path path)
        {
            if (path.Equals("")) return;
            path = path - ProgramData.Project.Path;
            string[] elements = path.Explode();
            TreeNode current = Nodes[0];
            foreach(string element in elements)
            {
                TreeNode[] res = current.Nodes
                    .Cast<TreeNode>()
                    .Where(x => x.Text == element)
                    .ToArray();
                if (res.Length > 0)
                {
                    current = res[0];
                }
                else
                {
                    TreeNode node = new TreeNode(element);
                    current.Nodes.Add(node);
                    current = node;
                    UpdateIcon(node);
                }
            }
            SelectedNode = current;
        }

        public void UpdateIcon(TreeNode n)
        {
            Path path = GetTreeViewPath(n);
            if (path.IsDirectory())
            {
                n.ImageIndex = 0;
                n.SelectedImageIndex = 0;
                return;
            }
            switch (path.GetExtension())
            {
                case ".js":
                    n.ImageIndex = 1;
                    n.SelectedImageIndex = 1;
                    break;
                case ".nproj":
                    n.ImageIndex = 3;
                    n.SelectedImageIndex = 3;
                    break;
                case ".png":
                    n.ImageIndex = 4;
                    n.SelectedImageIndex = 4;
                    break;
                default:
                    n.ImageIndex = 2;
                    n.SelectedImageIndex = 2;
                    break;
            }
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
                    UpdateIcon(node);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    node.Text = new Path(OldPath).GetName();
                }
            }
        }

        private void ProjectTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = GetTreeViewPath(e.Node);

            if (Directory.Exists(path))
                return;

            string extension = System.IO.Path.GetExtension(path).ToLower();
            if (extension == ".png")
            {
                Process.Start(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "bin\\NPixelPaint.exe"), "\"" + path + "\"");
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
                while (File.Exists(System.IO.Path.Combine(dir, fileName)))
                {
                    fileName = "file" + i + ".js";
                    i++;
                }
                Path path = (Path)dir + fileName;
                File.Create(System.IO.Path.Combine(dir, fileName)).Close();
                TreeNode node = new TreeNode(fileName);
                SelectedNode.Nodes.Add(node);
                UpdateIcon(node);
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
                while (Directory.Exists(System.IO.Path.Combine(dir, folderName)))
                {
                    folderName = "folder" + i;
                    i++;
                }
                Directory.CreateDirectory(System.IO.Path.Combine(dir, folderName));
                TreeNode node = new TreeNode(folderName);
                SelectedNode.Nodes.Add(node);
                UpdateIcon(node);
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
                && new Path(SelectedNode.Text).GetExtension() != ".nproj")
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
            Path path_relative = ((Path)node.FullPath).Explode().Skip(1).ToPath();
            return (string)(ProgramData.Project.Path + path_relative);
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
