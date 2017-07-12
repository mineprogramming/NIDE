using System;
using System.IO;
using System.Windows.Forms;

namespace NIDE
{
    public partial class fLibraries : Form
    {
        public fLibraries()
        {
            InitializeComponent();
            foreach (var dir in Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\libraries\\"))
            {
                var name = Path.GetFileName(dir);
                if (!File.Exists(dir + "\\guidisable"))
                {
                    if (ProgramData.ProjectManager.LibraryInstalled(name))
                    {

                        clbLibraries.Items.Add(name, true);
                    }
                    else
                    {
                        clbLibraries.Items.Add(name, false);
                    }
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbLibraries.Items.Count; i++)
            {
                var item = clbLibraries.Items[i];
                if (clbLibraries.GetItemChecked(i))
                {
                    ProgramData.ProjectManager.IncludeLibrary(item.ToString());
                }
                else
                {
                    ProgramData.ProjectManager.ExcludeLibrary(item.ToString());
                }
            }
            Close();
        }
    }
}
