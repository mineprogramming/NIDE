using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using NIDE.Languages;
using System.Windows.Forms;

namespace NIDE.ProjectTypes
{
    class CoreEngine : Project
    {
        public static List<string> Items;
        public static Dictionary<string, List<string>> Members;

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

        public static void LoadData(string path)
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

        public CoreEngine(string projectFile)
        {
            Nproj = projectFile;
            Path = Directory.GetParent(projectFile).FullName;
            UpdateNlib();
        }

        public CoreEngine(string path, string projectName): base(path, projectName)
        {
            string nproj = string.Format(
                "nide-api:{0}\nproject-name:{1}\nproject-version:1.0.0\nproject-type:COREENGINE\nsettings-compress:false",
                ProgramData.API_LEVEL, projectName);
            File.WriteAllText(Nproj, nproj, ProgramData.Encoding);
        }

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
            return items;
        }

        public override ProjectType Type => ProjectType.COREENGINE;

        public override string CraftPattern => "Recipes.addShaped({{id: {0}, count: {1}, data: {2}}}, {3}, {4});";
        public override bool ShowMainEnabled => false;
        public override string ADBPushPath { get { return ADBPath; } set { ADBPath = value; } }
        public override string ProgramPackage => "com.zhekasmirnov.innercore";

        public override string LibraryPath => Path + "\\lib\\";
        public override string ItemsOpaquePath => Path + "\\assets\\items-opaque\\";
        public override string TerrainAtlasPath => Path + "\\assets\\terrain-atlas\\";
        public override string ScriptsPath => Path + "\\dev\\";
        public override string OtherResourcesPath => Path + "\\assets\\other\\";
        public override string MainScriptPath => Path + "\\dev\\.includes";
        public override string SourceCodePath => Path;
        public override string PushPath => Path;

        public override string[] Filesystem => new string[]{
                "\\gui\\",
                "\\dev\\",
                "\\dev\\.includes",
                "\\assets\\",
                "\\assets\\items-opaque\\",
                "\\assets\\terrain-atlas\\"
            };
        
        private string ResPath => Path + "\\assets\\";
        

        public override void Build()
        {
            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectoryByName("assets");
                zip.AddDirectory(ResPath, "assets");
                zip.Save(Path + "\\resources.zip");
            }
        }

        public override void Post_init(){}

        public override void Post_add_script(string name){
            File.AppendAllText(MainScriptPath, "\n" + name, ProgramData.Encoding);
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
    }
}