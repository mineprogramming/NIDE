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
    public partial class fStartWindow : Form
    {
        public string result;
        public string path;

        public fStartWindow()
        {
            InitializeComponent();
            foreach(var item in ProgramData.Recent)
            {
                lvRecent.Items.Add(new ListViewItem(item));
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            result = "new";
            Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            result = "open";
            Close();
        }

        private void btnRecent_Click(object sender, EventArgs e)
        {
            if (lvRecent.SelectedItems.Count != 0)
                path = lvRecent.SelectedItems[0].Text;
            else
            {
                MessageBox.Show("Please, choose a project!");
                return;
            }
            DialogResult = DialogResult.OK;
            result = "recent";
            Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            result = "import";
            Close();
        }
    }
}
