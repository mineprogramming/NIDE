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
    public partial class fAutocompleteItems : Form
    {
        public fAutocompleteItems()
        {
            InitializeComponent();
            tbItems.Lines = Autocomplete.UserItems;
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            Autocomplete.UserItems = tbItems.Lines;
            Close();
        }

        private void tsmiCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
