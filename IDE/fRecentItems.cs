using System;
using System.Windows.Forms;

namespace NIDE
{
    public partial class fRecentItems : Form
    {
        public string path;

        public fRecentItems()
        {
            InitializeComponent();
            lbMain.Items.AddRange(ProgramData.Recent);
        }

        private void lvMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            path = Convert.ToString(lbMain.SelectedItem);
            if (path != "")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
