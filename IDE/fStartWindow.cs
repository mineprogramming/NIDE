using System;
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

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            if(lvRecent.SelectedItems.Count > 0)
            {
                ProgramData.Recent.Remove(lvRecent.SelectedItems[0].Text);
                lvRecent.Items.Remove(lvRecent.SelectedItems[0]);
            }
        }

        private void lvRecent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRecent.SelectedItems.Count > 0)
            {
                path = lvRecent.SelectedItems[0].Text;
                DialogResult = DialogResult.OK;
                result = "recent";
                Close();
            }
        }
    }
}
