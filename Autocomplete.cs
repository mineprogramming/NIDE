using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ModPE_editor
{
    static class Autocomplete
    {
        static AutocompleteMenu menu;
        static DynamicCollection dynamic;
        static FastColoredTextBox textBox;
        public static string[] UserItems = new string[0];

        public static void SetAutoompleteMenu(FastColoredTextBox fctb)
        {
            menu = new AutocompleteMenu(fctb);
            textBox = fctb;
            menu.ImageList = LoadImages();
            menu.MinFragmentLength = 1;
            dynamic = new DynamicCollection(menu, textBox);
            menu.Items.SetAutocompleteItems(dynamic);
        }

        public static void FindVars()
        {
            dynamic?.findVars();
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
        private List<AutocompleteItem> vars = new List<AutocompleteItem>();

        public DynamicCollection(AutocompleteMenu menu, FastColoredTextBox tb)
        {
            this.menu = menu;
            this.tb = tb;
            findVars();
        }

        public void findVars()
        {
            vars.Clear();
            Regex regex = new Regex(@"\b(var)\s+(?<range>[\w_]+?)\b");
            foreach (Match match in regex.Matches(tb.Text))
                vars.Add(new AutocompleteItem(match.Value.Split(' ')[1]));
            regex = new Regex(@"\bfunction\b");
            foreach(var line in tb.Lines)
                if (regex.IsMatch(line) && line.IndexOf('(') != -1 && line.IndexOf(')') != -1)
                {
                    string params_line = line.Split('(')[1].Split(')')[0];
                    foreach (var param in params_line.Split(','))
                        vars.Add(new AutocompleteItem(param));
                }
        }

        public IEnumerator<AutocompleteItem> GetEnumerator()
        {
            var text = menu.Fragment.Text;
            var parts = text.Split('.');
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            foreach (var item in Autocomplete.UserItems)
                items.Add(new AutocompleteItem(item));
            if (ProgramData.Mode == WorkMode.CORE_ENGINE)
            {
                if (parts.Length < 2)
                {
                    items.AddRange(CoreEngine.GetDefaultList());
                    items.AddRange(vars);
                    foreach (var item in items)
                        yield return item;
                }
                else
                {
                    var className = parts[parts.Length - 2];
                    foreach (var methodName in CoreEngine.GetListByClassName(className))
                        yield return methodName;
                }
            }
            else
            {
                if (parts.Length < 2)
                {
                    items.AddRange(ModPe.GetDefaultList());
                    items.AddRange(vars);
                    foreach (var item in items)
                        yield return item;
                }
                else
                {
                    var className = parts[parts.Length - 2];
                    foreach (var methodName in ModPe.GetListByClassName(className))
                        yield return methodName;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}