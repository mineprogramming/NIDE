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

    class DynamicCollection : IEnumerable<AutocompleteItem>
    {
        private AutocompleteMenu menu;
        private FastColoredTextBox tb;

        public DynamicCollection(AutocompleteMenu menu, FastColoredTextBox tb)
        {
            this.menu = menu;
            this.tb = tb;
        }

        public IEnumerator<AutocompleteItem> GetEnumerator()
        {
            var text = menu.Fragment.Text;
            var parts = text.Split('.');
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            foreach (var item in Autocomplete.UserItems.Keys)
                items.Add(new AutocompleteItem(item));
            if (ProgramData.ProjectManager != null && ProgramData.ProjectManager.projectType == ProjectType.COREENGINE)
            {
                if (parts.Length < 2)
                {
                    items.AddRange(CoreEngine.GetDefaultList());
                    foreach (var item in CodeAnalysisEngine.Variables)
                        items.Add(new AutocompleteItem(item));
                    foreach (var item in items)
                        yield return item;
                }
                else
                {
                    var className = parts[parts.Length - 2];
                    foreach (var methodName in CoreEngine.GetListByClassName(className))
                        yield return methodName;
                    if (Autocomplete.UserItems.ContainsKey(className))
                        foreach (var methodName in Autocomplete.UserItems[className])
                            yield return new MethodAutocompleteItem(methodName);
                }
            }
            else
            {
                if (parts.Length < 2)
                {
                    items.AddRange(ModPe.GetDefaultList());
                    foreach (var item in CodeAnalysisEngine.Variables)
                        items.Add(new AutocompleteItem(item));
                    foreach (var item in items)
                        yield return item;
                }
                else
                {
                    var className = parts[parts.Length - 2];
                    foreach (var methodName in ModPe.GetListByClassName(className))
                        yield return methodName;
                    if (Autocomplete.UserItems.ContainsKey(className))
                        foreach (var methodName in Autocomplete.UserItems[className])
                            yield return new MethodAutocompleteItem(methodName);
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}