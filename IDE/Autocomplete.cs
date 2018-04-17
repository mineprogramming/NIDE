using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NIDE
{
    static class Autocomplete
    {
        static AutocompleteMenu menu;
        static DynamicCollection dynamic;
        static FastColoredTextBox textBox;
        static List<string> none = new List<string>();
        public static Dictionary<string, List<string>> UserItems = new Dictionary<string, List<string>>();

        private static bool enabled = false;
        public static bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                if (value)
                {
                    dynamic = new DynamicCollection(menu, textBox);
                    menu.Items.SetAutocompleteItems(dynamic);
                }
                else menu.Items.SetAutocompleteItems(none);
            }
        }

        public static IEnumerable<string> members
        {
            get
            {
                var items = UserItems.SelectMany(x => x.Value);
                return items;
            }
        }

        public static void SetAutoompleteMenu(FastColoredTextBox fctb)
        {
            menu = new AutocompleteMenu(fctb);
            textBox = fctb;
            menu.ImageList = LoadImages();
            menu.MinFragmentLength = 1;
            dynamic = new DynamicCollection(menu, textBox);
            menu.Items.SetAutocompleteItems(dynamic);
            menu.Selected += Menu_Selected;
        }

        private static void Menu_Selected(object sender, SelectedEventArgs e)
        {
            ProgramData.Project.OnAutocomplete(e.Item, e.Tb);
        }

        private static ImageList LoadImages()
        {
            ImageList images = new ImageList();
            try
            {
                for (int i = 0; i < 7; i++)
                {
                    Icon image = new Icon("icons\\" + i + ".ico");
                    images.Images.Add(image);
                }
            }
            catch
            {
                MessageBox.Show("Unable to load icons. Please, reinstall application to fix an issue");
                return null;
            }
            return images;
        }
    }
}