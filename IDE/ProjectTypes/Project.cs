using FastColoredTextBoxNS;
using NIDE.ProjectTypes.ZCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NIDE.ProjectTypes
{
    abstract class Project
    {

        public string Name { get; set; }
        public string Version { get; set; }
        public bool Compress { get; set; }
        public string Nproj { get; set; }
        public string Path { get; protected set; }
        public abstract ProjectType Type { get; }

        protected List<Library> Libraries = new List<Library>();
        protected List<string> OutFiles = new List<string>();

        public abstract string CraftPattern { get; }
        public abstract bool ShowMainEnabled { get; }
        public abstract string ADBPushPath { get; set; }
        public abstract string ProgramPackage { get; }
        public abstract string DefaultNproj { get; }

        public abstract string LibraryPath { get; }
        public abstract string ItemsOpaquePath { get; }
        public abstract string TerrainAtlasPath { get; }
        public abstract string ScriptsPath { get; }
        public abstract string CodePath { get; }
        public abstract string OtherResourcesPath { get; }
        public abstract string MainScriptPath { get; }
        public abstract string SourceCodePath { get; }
        public abstract string PushPath { get; }
        public abstract string BuiltScriptPath { get; }

        public abstract string[] Filesystem { get; }
        
        public abstract void Post_init();
        public abstract void Post_tree_reload(TreeNode node);
        public abstract void Post_add_script(string name);
        public abstract void Build();
        public abstract void AddLibrary(string name);
        public abstract void IncludeLibrary(string name);
        public abstract void ExcludeLibrary(string name);
        public abstract void OnAutocomplete(AutocompleteItem item, FastColoredTextBox textBox);
        public abstract bool OnEnter(FastColoredTextBox textBox);

        public abstract List<AutocompleteItem> GetDefaultList();
        public abstract List<AutocompleteItem> GetListByClassName(string className);

        public static Project New(string projectFile)
        {
            foreach (var line in File.ReadAllLines(projectFile, ProgramData.Encoding))
            {
                string[] keyValue = line.Split(':');
                if (keyValue.Length != 2)
                    continue;
                switch (keyValue[0])
                {
                    case "nide-api":
                        if (Convert.ToInt32(keyValue[1]) > ProgramData.API_LEVEL)
                            throw new Exception("Api level is not supported");
                        break;
                    case "project-type":
                        switch (Util.StringToProjectType(keyValue[1])) {
                            case ProjectType.MODPE:
                                return new ModPE(projectFile);
                            case ProjectType.COREENGINE:
                                return new CoreEngine(projectFile);
                            case ProjectType.INNERCORE:
                                return new InnerCore(projectFile);
                        }
                        break;
                }
            }
            throw new Exception("Project type is not defined in .nproj");
        }

        protected Project(string projectFile) {
            Nproj = projectFile;
            Path = Directory.GetParent(projectFile).FullName;
            UpdateNlib();
        }

        protected Project(string path, string projectName)
        {
            Name = projectName;
            Path = path;
            Version = "1.0.0";
            Compress = false;
            Nproj = path + "\\" + projectName + ".nproj";
            CreateFileSystem();
            string nproj = string.Format(DefaultNproj, ProgramData.API_LEVEL, projectName);
            File.WriteAllText(Nproj, nproj, ProgramData.Encoding);
        }

        public void CreateFileSystem()
        {
            foreach(var item in Filesystem)
            {
                Directory.CreateDirectory(Path);
                if (item.EndsWith("\\"))
                    Directory.CreateDirectory(Path + item);
                else File.CreateText(Path + item).Close();
            }
            Post_init();
        }

        public void UpdateNlib()
        {
            Libraries.Clear();
            Autocomplete.UserItems.Clear();
            foreach (var line in File.ReadAllLines(Nproj, ProgramData.Encoding))
            {
                string[] keyValue = line.Split(':');
                if (keyValue.Length != 2)
                    continue;
                switch (keyValue[0])
                {

                    case "project-name":
                        Name = keyValue[1];
                        break;
                    case "project-version":
                        Version = keyValue[1];
                        break;
                    case "settings-compress":
                        Compress = Convert.ToBoolean(keyValue[1]);
                        break;
                    case "include-library":
                        try
                        {
                            var l = new Library(keyValue[1], LibraryPath, Libraries, OutFiles);
                            if (!LibraryInstalled(l.name))
                                Libraries.Add(l);
                        }
                        catch (Exception e)
                        {
                            ProgramData.Log("ProjectManager", e.Message);
                        }
                        break;
                }

            }
        }

        public bool LibraryInstalled(string name)
        {
            foreach (var library in Libraries)
            {
                if (library.name == name) return true;
            }
            return false;
        }

        public void AddTexture(string name, ImageType type)
        {
            name = name.ToLower().EndsWith(".png") ? name : name + ".png";
            string TexturePath = (type == ImageType.ITEMS_OPAQUE ? ItemsOpaquePath : TerrainAtlasPath) + name;
            Bitmap png = new Bitmap(16, 16);
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    png.SetPixel(i, j, Color.Transparent);
                }
            }
            png.Save(TexturePath);
        }

        public void AddScript(string name)
        {
            name = name.ToLower().EndsWith(".js") ? name : name + ".js";
            string backslashed = name.Replace('/', '\\');
            string ScriptPath = ScriptsPath + backslashed;
            int ind = ScriptPath.LastIndexOf('\\');
            if (ind != -1)
            {
                Directory.CreateDirectory(ScriptPath.Substring(0, ind));
            }
            File.CreateText(ScriptPath).Close();
            Post_add_script(name);
        }
    }
}
