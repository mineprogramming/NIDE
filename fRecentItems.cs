using System;
using System.Windows.Forms;

namespace ModPE_editor
{
    public partial class fRecentItems : Form
    {
        public static string Path;

        public fRecentItems()
        {
            InitializeComponent();
            lbMain.Items.AddRange(ProgramData.Recent);
        }

        private void lvMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Path = Convert.ToString(lbMain.SelectedItem);
            if (Path != "")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
