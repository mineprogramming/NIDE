using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NIDE
{
    static class CoreEngine
    {
        public static List<string> Items;
        public static Dictionary<string, List<string>> Members;

        public static List<AutocompleteItem> GetListByClassName(string className)
        {
            List<string> result;
            List<AutocompleteItem> acList = new List<AutocompleteItem>();
            if (Members.TryGetValue(className, out result))
            {
                foreach (var item in result)
                {
                    MethodAutocompleteItem it = new MethodAutocompleteItem(item);
                    it.ImageIndex = 5;
                    acList.Add(it);
                }
                return acList;
            }
            else
            {
                return GetDefaultList();
            }
        }

        public static List<AutocompleteItem> GetDefaultList()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            foreach (var item in ModPe.JSitems)
                items.Add(new AutocompleteItem(item, 0));
            foreach (var item in Items)
                items.Add(new AutocompleteItem(item, 5));
            return items;
        }

        public static void LoadCoreEngineData(string path)
        {
            Items = new List<string>();
            Members = new Dictionary<string, List<string>>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line == "")
                    continue;
                string item = line.Split('[')[0].Trim();
                item = item.Split('(')[0].Trim();
                item = item.Split('=')[0].Trim();
                item = item.Trim('.');
                if (item.IndexOf('.') < 0)
                {
                    Items.Add(item);
                }
                else
                {
                    string[] splitted = item.Split('.');
                    if (!Items.Contains(splitted[0]))
                        Items.Add(splitted[0]);
                    string[] newString = splitted.Skip(1).ToArray();
                    BuildListRecursive(newString, splitted[0]);
                }
            }
        }

        private static void BuildListRecursive(string[] rest, string key)
        {
            if (!Members.ContainsKey(key))
                Members.Add(key, new List<string>() { rest[0] });
            else if (!Members[key].Contains(rest[0]))
                Members[key].Add(rest[0]);
            if (rest.Count() == 1)
            {
                return;
            }
            else
            {
                string[] newString = rest.Skip(1).ToArray();
                BuildListRecursive(newString, rest[0]);
            }
        }

        public static IEnumerable<string> members
        {
            get
            {
                var items = Members.SelectMany(x => x.Value);
                return items;
            }
        }
    }
}