using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NIDE
{
    public partial class fNewProject : Form
    {
        public string path = "";
        public string name = "";
        public string source = "";
        public ProjectType type;
        private bool import;

        public fNewProject(bool import = false)
        {
            this.import = import;
            InitializeComponent();
            if (!import)
            {
                label3.Visible = false;
                tbSource.Visible = false;
                btnSource.Visible = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (tbPath.Text == "" || tbName.Text == "" || (import && tbSource.Text == ""))
            {
                MessageBox.Show("All fields are required!");
            }
            else if (!IsValidPath(tbName.Text)){
                MessageBox.Show("This is an invalid project name!");
            }
            else
            {
                path = tbPath.Text;
                name = tbName.Text;
                if (import)
                {
                    source = tbSource.Text;
                    type = ProjectType.MODPE;
                }
                if (rbModPE.Checked)
                    type = ProjectType.MODPE;
                else if (rbCoreEngine.Checked)
                    type = ProjectType.COREENGINE;
                else if (rbInnerCore.Checked)
                    type = ProjectType.INNERCORE;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = dlgFolder.SelectedPath + "\\" + tbName.Text;
            }
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            if(dlgOpen.ShowDialog() == DialogResult.OK)
            {
                tbSource.Text = dlgOpen.FileName;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            int ind = tbPath.Text.LastIndexOf("\\");
            if (ind >= 0)
            {
                tbPath.Text = tbPath.Text.Substring(0, tbPath.Text.LastIndexOf("\\") + 1) + tbName.Text;
            }
        }

        private bool IsValidPath(string path)
        {
            foreach(char ch in System.IO.Path.GetInvalidFileNameChars())
            {
                if (path.Contains(ch))
                    return false;
            }
            return true;
        }
    }
}
