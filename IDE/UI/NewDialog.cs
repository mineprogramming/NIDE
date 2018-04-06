using System.Windows.Forms;

namespace NIDE.UI
{
    public partial class NewDialog : DialogForm
    {
        public ImageType type;
        public string name;

        public NewDialog(DialogType dialog)
        {
            InitializeComponent();
            switch (dialog)
            {
                case DialogType.SCRIPT:
                    rbItemsOpaque.Visible = false;
                    rbTerrainAtlas.Visible = false;
                    Text = "New script";
                    break;
                case DialogType.TEXTURE:
                    Height = 150;
                    rbItemsOpaque.Visible = true;
                    rbTerrainAtlas.Visible = true;
                    Text = "New texture";
                    break;
                case DialogType.LIBRARY:
                    rbItemsOpaque.Visible = false;
                    rbTerrainAtlas.Visible = false;
                    Text = "New library";
                    break;
            }
        }

        private void fDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            type = rbItemsOpaque.Checked ? ImageType.ITEMS_OPAQUE : ImageType.TERRAIN_ATLAS;
            name = tbFileName.Text;
        }
    }
}
