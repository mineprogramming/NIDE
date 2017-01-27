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
    public partial class fDialog : Form
    {
        public ImageType Type;
        public string FileName;

        public fDialog(bool texture = false)
        {
            InitializeComponent();
            if (!texture)
            {
                rbItemsOpaque.Visible = false;
                rbTerrainAtlas.Visible = false;
                Text = "New script";
            }
            else
            {
                rbItemsOpaque.Visible = true;
                rbTerrainAtlas.Visible = true;
                Text = "New texture";
            }
        }

        private void fDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Type = rbItemsOpaque.Checked ? ImageType.ITEMS_OPAQUE : ImageType.TERRAIN_ATLAS;
            FileName = tbFileName.Text;
        }
    }
}
