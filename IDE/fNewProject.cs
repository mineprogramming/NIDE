using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = dlgFolder.SelectedPath;
            }
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            if(dlgOpen.ShowDialog() == DialogResult.OK)
            {
                tbSource.Text = dlgOpen.FileName;
            }
        }
    }
}
