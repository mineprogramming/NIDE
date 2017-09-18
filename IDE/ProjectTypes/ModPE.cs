using System.Collections.Generic;
using System.Linq;
using System.IO;
using FastColoredTextBoxNS;
using System;
using NIDE.Languages;
using Yahoo.Yui.Compressor;
using System.Windows.Forms;

namespace NIDE.ProjectTypes
{
    class ModPE : Project
    {
        public static List<string> global = new List<string>();
        public static Dictionary<string, List<string>> Members = new Dictionary<string, List<string>>();
        public static List<string> namespaces = new List<string>() { "android", "java" };
        public static List<string> hooks = new List<string>();
        public static List<string> hooks_autocomplete = new List<string>();

        public static IEnumerable<string> members
        {
            get
            {
                var items = Members.SelectMany(x => x.Value);
                return items;
            }
        }

        public static string ADBPath;

        public override ProjectType Type => ProjectType.MODPE;

        public override string CraftPattern => "Item.addShapedRecipe({0}, {1}, {2}, {3}, {4});";
        public override bool ShowMainEnabled => true;
        public override string ADBPushPath { get { return ADBPath; } set { ADBPath = value; } }

        public override string LibraryPath => Path + "\\source\\libs\\";
        public override string ItemsOpaquePath => Path + "\\source\\res\\images\\items-opaque\\";
        public override string TerrainAtlasPath => Path + "\\source\\res\\images\\terrain-atlas\\";
        public override string ScriptsPath => Path + "\\source\\scripts\\";
        public override string OtherResourcesPath => Path + "\\source\\res\\images\\other\\";
        public override string MainScriptPath => Path + "\\source\\scripts\\main.js";
        public override string SourceCodePath => Path + "\\source\\";
        public override string PushPath => BuildPath;

        public override string[] Filesystem => new string[] {
                "\\source\\",
                "\\source\\res\\",
                "\\source\\res\\images\\",
                "\\source\\res\\images\\items-opaque\\",
                "\\source\\res\\images\\terrain-atlas\\",
                "\\source\\res\\images\\other\\",
                "\\source\\scripts\\",
                "\\source\\scripts\\main.js",
                "\\source\\libs\\",
                "\\build\\",
                "\\out\\"
            };

        public string BuildPath => Path + "\\build\\";
        private string OutPath => Path + "\\out\\";
        private string ResPath => Path + "\\source\\res\\images\\";
        
        public static void LoadData(string path)
        {
            foreach (var key in JavaScript.Modules.Keys)
                Members.Add(key, JavaScript.Modules[key]);
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.Length == 0 || line.StartsWith("//"))
                    continue;
                string[] functions = line.Split(' ');
                if (functions[0] == "function")
                {
                    string hook = "";
                    for (int i = 1; i < functions.Length; i++)
                    {
                        hook += functions[i];
                    }
                    hook += " {\n\n}";
                    string hook_name = hook.Split('(')[0];
                    hooks.Add(hook_name);
                    hooks_autocomplete.Add(hook);
                    continue;
                }
                functions = line.Split('.');
                if (functions.Length < 2)
                {
                    string method_name = line.Split('(')[0];
                    global.Add(method_name);
                    continue;
                }
                if (line.IndexOf('(') == -1)
                {
                    functions[1] = functions[1].Substring(0, functions[1].Length - 1);
                    if (!global.Contains(functions[0]))
                        global.Add(functions[0]);
                    if (Members.ContainsKey(functions[0]))
                        Members[functions[0]].Add(functions[1]);
                    else
                        Members.Add(functions[0], new List<string>() { functions[1] });
                    continue;
                }
                if (!namespaces.Contains(functions[0]))
                    namespaces.Add(functions[0]);
                functions[1] = functions[1].Split('(')[0];
                if (Members.ContainsKey(functions[0]))
                    Members[functions[0]].Add(functions[1]);
                else
                    Members.Add(functions[0], new List<string>() { functions[1] });
            }
        }

        public ModPE(string projectFile)
        {
            Nproj = projectFile;
            Path = Directory.GetParent(projectFile).FullName;
            UpdateNlib();
        }

        public ModPE(string path, string projectName) : base(path, projectName)
        {
            string nproj = string.Format(
                "nide-api:{0}\nproject-name:{1}\nproject-version:1.0.0\nproject-type:MODPE\nsettings-compress:false",
                ProgramData.API_LEVEL, projectName);
            File.WriteAllText(Nproj, nproj, ProgramData.Encoding);
        }

        public override List<AutocompleteItem> GetDefaultList()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            foreach (var item in JavaScript.Items)
                items.Add(new AutocompleteItem(item, 0));
            foreach (var item in hooks_autocomplete)
                items.Add(new AutocompleteItem(item, 4, hooks[hooks_autocomplete.IndexOf(item)]));
            foreach (var item in global)
                items.Add(new AutocompleteItem(item, 1));
            foreach (var item in namespaces)
                items.Add(new AutocompleteItem(item, 3));
            return items;
        }

        public override List<AutocompleteItem> GetListByClassName(string className)
        {
            List<string> result;
            if (Members.TryGetValue(className, out result))
            {
                int icon = namespaces.Contains(className) ? 2 : 6;
                List<AutocompleteItem> acList = new List<AutocompleteItem>();
                foreach (var item in result)
                {
                    MethodAutocompleteItem it = new MethodAutocompleteItem(item);
                    it.ImageIndex = icon;
                    acList.Add(it);
                }
                return acList;
            }
            else
            {
                return GetDefaultList();
            }
        }

        public override void Build()
        {
            UpdateNlib();
            string outp = BuildPath + "main.js";
            File.Delete(outp);
            foreach (var library in Libraries)
            {
                string text = library.GetCode();
                File.AppendAllText(outp, "\n" + text, ProgramData.Encoding);
            }
            foreach (var file in Directory.GetFiles(ScriptsPath))
            {
                string text = File.ReadAllText(file, ProgramData.Encoding);
                File.AppendAllText(outp, "\n" + text, ProgramData.Encoding);
            }
            if (Compress)
            {
                JavaScriptCompressor compressor = new JavaScriptCompressor();
                File.WriteAllText(outp, compressor.Compress(File.ReadAllText(outp, ProgramData.Encoding)), ProgramData.Encoding);
            }

            foreach (var file in OutFiles)
            {
                File.Copy(file, BuildPath + System.IO.Path.GetFileName(file), true);
                File.Copy(file, OutPath + System.IO.Path.GetFileName(file), true);
            }

            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectoryByName("images");
                zip.AddDirectory(ResPath, "images");
                zip.Save(BuildPath + "resources.zip");
            }

            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectoryByName("script");
                zip.AddFile(outp, "script");
                zip.AddDirectoryByName("images");
                zip.AddDirectory(ResPath, "images");
                zip.Save(OutPath + Name + ".modpkg");
            }
        }

        public override void AddLibrary(string name)
        {
            string path = LibraryPath + name + "\\";
            Directory.CreateDirectory(path);
            File.CreateText(path + "lib.js").Close();
            File.WriteAllText(path + "info.nlib", String.Format("nide-api:{0}\nlibrary-version:1.0", ProgramData.API_LEVEL), ProgramData.Encoding);
            File.AppendAllText(Nproj, "\ninclude-library:project/" + name, ProgramData.Encoding);
            UpdateNlib();
        }

        public override void IncludeLibrary(string name)
        {
            if (!LibraryInstalled(name))
            {
                File.AppendAllText(Nproj, "\ninclude-library:nide/" + name, ProgramData.Encoding);
                UpdateNlib();
            }
        }

        public override void ExcludeLibrary(string name)
        {
            List<string> lines = new List<string>();
            lines.AddRange(File.ReadAllLines(Nproj, ProgramData.Encoding));
            if (lines.Contains("include-library:nide/" + name))
                lines.Remove("include-library:nide/" + name);
            File.WriteAllLines(Nproj, lines, ProgramData.Encoding);
            UpdateNlib();
        }


        public override void Post_init() { }

        public override void Post_add_script(string name) { }

        public override void Post_tree_reload(TreeNode node)
        {
            node.Nodes.Add(System.IO.Path.GetFileName(ProgramData.Project.Nproj));
        }
    }
}