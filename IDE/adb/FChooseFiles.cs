using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NIDE.adb
{
    public partial class FChooseFiles : Form
    {
        private static List<string> files = new List<string>();
        private static bool ask = true;

        private string basedir = ProgramData.Project.PushPath;
        public List<string> Files => files;


        //incapsulate parent's ShowDialog implementations
        new private DialogResult ShowDialog() { return base.ShowDialog(); }
        new private DialogResult ShowDialog(IWin32Window owner) { return base.ShowDialog(owner); }


        public FChooseFiles()
        {
            InitializeComponent();
        }

        private void FChooseFiles_Load(object sender, EventArgs e)
        {
            var pathes = Util.GetFileList(new DirectoryInfo(basedir));
            var files = pathes.Relative(basedir);
            for (int i = 0; i < files.Count; i++)
            {
                bool check = Files.Contains(pathes[i]);
                AddRecursive(tvFiles.Nodes, files[i]).Checked = check;
            }
        }

        private TreeNode AddRecursive(TreeNodeCollection collection, string path)
        {
            int index = path.IndexOf('\\');
            if(index == -1)
            {
                return collection.Add(path);
            } else
            {
                string key = path.Split('\\')[0];
                if (collection.ContainsKey(key))
                {
                    return AddRecursive(collection[key].Nodes, path.Substring(index + 1));
                } else
                {
                    return AddRecursive(collection.Add(key, key).Nodes, path.Substring(index + 1));
                }
            }
        }
        
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        public DialogResult ShowDialog(bool force = false)
        {
            if (force)
                return base.ShowDialog();
            else if (ask)
                return base.ShowDialog();
            else
                return DialogResult.OK;
        }

        private void BtnPush_Click(object sender, EventArgs e)
        {
            Files.Clear();
            BuildFileList(tvFiles.Nodes);
            ask = !CBDontAsk.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BuildFileList(TreeNodeCollection collection)
        {
            foreach (TreeNode node in collection)
            {
                if (node.Nodes.Count == 0 && node.Checked)
                {
                    Files.Add(System.IO.Path.Combine(basedir, node.FullPath));
                } else if(node.Nodes.Count != 0)
                {
                    BuildFileList(node.Nodes);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tvFiles_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(e.Node, e.Node.Checked);
                }
            }
        }
    }
}
