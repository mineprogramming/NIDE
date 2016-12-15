using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (Path != "") ;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
