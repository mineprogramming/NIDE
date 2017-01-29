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
        public ProjectType type;

        public fNewProject()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(tbPath.Text == "" || tbName.Text == "")
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                path = tbPath.Text;
                name = tbName.Text;
                if (rbModPE.Checked)
                    type = ProjectType.MODPE;
                else if (rbCoreEngine.Checked)
                    type = ProjectType.COREENGINE;
                else
                    type = ProjectType.LIBRARY;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if(dlgFolder.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = dlgFolder.SelectedPath;
            }
        }
    }
}
