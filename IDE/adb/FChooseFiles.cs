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
            var pathes = Util.GetFileList(new DirectoryInfo(basedir));
            var files = pathes.Relative(basedir);
            for (int i = 0; i < files.Count; i++)
            {
                bool check = Files.Contains(pathes[i]);
                ClbFiles.Items.Add(files[i], check);
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
            foreach(string file in ClbFiles.CheckedItems)
            {
                Files.Add(System.IO.Path.Combine(basedir, file));
            }
            ask = !CBDontAsk.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
