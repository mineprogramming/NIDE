using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NIDE.Languages;
using System.Windows.Forms;
using System;

namespace NIDE.ProjectTypes.MCPEModding.ZCore
{
    abstract class ZCore : Project
    {
        public static List<string> Items;
        public static Dictionary<string, List<string>> Members;
        public static Dictionary<string, string> Patterns;

        static ZCore()
        {
            try
            {
                LoadData("core.txt", "patterns.txt");
            } catch(Exception e)
            {
                ProgramData.Log("ZCore", "Cannot load ZCore data: " + e.Message);
            }
            
        }

        private int lastLine = 0;
        private bool pattern = false;

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

        public static string ADBPath;

        public static void LoadData(string path, string pattern)
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
            Patterns = new Dictionary<string, string>();
            string text = File.ReadAllText(pattern);
            string[] patterns = text.Split(';');
            for (int i = 1; i < patterns.Length; i += 2)
                Patterns.Add(patterns[i - 1].Trim(' ', '\n', '\r') + ";", patterns[i].Trim(' ', '\n', '\r'));
        }

        public ZCore(string projectFile) : base(projectFile) { }

        public ZCore(string path, string projectName) : base(path, projectName) { }

        public override List<AutocompleteItem> GetListByClassName(string className)
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

        public override List<AutocompleteItem> GetDefaultList()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            foreach (var item in JavaScript.Items)
                items.Add(new AutocompleteItem(item, 0));
            foreach (var item in Items)
                items.Add(new AutocompleteItem(item, 5));
            foreach (var key in Patterns.Keys)
                items.Add(new AutocompleteItem(key, 4, Patterns[key]));
            return items;
        }

        public override string CraftPattern => "Recipes.addShaped({{id: {0}, count: {1}, data: {2}}}, {3}, {4});";
        public override string ADBPushPath { get { return ADBPath; } set { ADBPath = value; } }

        public override string LibraryPath => Path + "\\lib\\";
        public override string ItemsOpaquePath => Path + "\\assets\\items-opaque\\";
        public override string TerrainAtlasPath => Path + "\\assets\\terrain-atlas\\";
        public override string ScriptsPath => Path + "\\dev\\";
        public override string CodePath => ScriptsPath;
        public override string OtherResourcesPath => Path + "\\assets\\other\\";
        public override string MainScriptPath => Path + "\\dev\\.includes";
        public override string SourceCodePath => Path;
        public override string PushPath => Path;
        public string ResPath => Path + "\\assets\\";
        public override string BuiltScriptPath => Path + "\\main.js";

        public override void Post_add_script(string name)
        {
            List<string> files = new List<string>();
            files.AddRange(File.ReadAllLines(MainScriptPath, ProgramData.Encoding));

            string newpath = GetPath(name);

            for (int i = 1; i < files.Count; i++)
            {
                string path = GetPath(files[i]);
                if (GetPath(files[i - 1]) == newpath && GetPath(files[i]) != newpath)
                {
                    files.Insert(i, name);
                    break;
                }
            }
            if (!files.Contains(name)) files.Add(name);

            File.WriteAllLines(MainScriptPath, files);
        }

        private string GetPath(string name)
        {
            return name.Contains('/') ? name.Substring(0, name.IndexOf('/')) : "/";
        }

        public override void Post_tree_reload(TreeNode node) { }

        public override void AddLibrary(string name)
        {
            //TODO: implement
        }

        public override void IncludeLibrary(string name)
        {
            //TODO: implement
        }

        public override void ExcludeLibrary(string name)
        {
            //TODO: implement
        }

        public override void OnAutocomplete(AutocompleteItem item, FastColoredTextBox textBox)
        {
            pattern = true;
            lastLine = 0;
            OnEnter(textBox);
        }

        public override bool OnEnter(FastColoredTextBox textBox)
        {
            if (pattern)
            {
                for (int i = lastLine; i < textBox.Lines.Count; i++)
                {
                    int ind = textBox.Lines[i].IndexOf("~c~");
                    if (ind != -1)
                    {
                        lastLine = i;
                        textBox.Selection.Start = new Place(ind, i);
                        textBox.Selection.End = new Place(ind + 3, i);
                        SendKeys.Send("{BS}");
                        return true;
                    }
                }
            }
            pattern = false;
            return false;
        }
    }
}
