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
            foreach(var dir in Directory.GetDirectories(Directory.GetCurrentDirectory() + "\\libraries\\"))
            {
                var name = Path.GetFileName(dir);
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            foreach(var item in clbLibraries.CheckedItems)
            {
                if (!ProgramData.ProjectManager.LibraryInstalled(item.ToString()))
                {
                    ProgramData.ProjectManager.IncludeLibrary(item.ToString());
                }
            }
            Close();
        }
    }
}
