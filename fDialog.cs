using System.Windows.Forms;

namespace NIDE
{
    public partial class fDialog : Form
    {
        public ImageType type;
        public string name;

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
            type = rbItemsOpaque.Checked ? ImageType.ITEMS_OPAQUE : ImageType.TERRAIN_ATLAS;
            name = tbFileName.Text;
        }
    }
}
