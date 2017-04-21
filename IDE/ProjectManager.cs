using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Yahoo.Yui.Compressor;
using System.IO.Compression;

namespace NIDE
{
    class ProjectManager
    {
        public const int API_LEVEL = 1;

        private const string SOURCE_CODE_PATH = "\\source\\";
        private const string LIB_PATH = "\\source\\libs\\";
        private const string OUT_PATH = "\\out\\";
        private const string SCRIPTS_PATH = "\\source\\scripts\\";
        private const string ITEMS_OPAQUE_PATH = "\\source\\res\\images\\items-opaque\\";
        private const string TERRAIN_ATLAS_PATH = "\\source\\res\\images\\terrain-atlas\\";
        private const string RES_PATH = "\\source\\res\\images\\";
        private const string OTHER_RESOURCES_PATH = "\\source\\res\\images\\other\\";
        private const string BUILD_PATH = "\\build\\";

        private const string CE_ITEMS_OPAQUE_PATH = "\\assets\\items-opaque\\";
        private const string CE_TERRAIN_ATLAS_PATH = "\\assets\\terrain-atlas\\";
        private const string CE_RES_PATH = "\\assets\\";
        private const string CE_DEV_PATH = "\\dev\\";

        private const string TP_ITEMS_OPAQUE_PATH = "\\source\\textures\\items\\";
        private const string TP_TERRAIN_ATLAS_PATH = "\\source\\textures\\blocks\\";

        public readonly ProjectType projectType;
        public readonly string path;
        private string version;
        private bool compress;
        public string projectFile;
        private string projectName;
        private List<Library> Libraries = new List<Library>();
        private List<string> OutFiles = new List<string>();

        public string SourceCodePath
        {
            get
            {
                switch (projectType)
                {
                    case ProjectType.MODPE:
                        return path + SOURCE_CODE_PATH;
                    case ProjectType.BEHAVIOUR_PACK:
                    case ProjectType.COREENGINE:
                    case ProjectType.TEXTURE_PACK:
                        return path;
                    default: return null;
                }
            }
        }
        public string OtherResourcesPath { get { return path + OTHER_RESOURCES_PATH; } }
        public string ItemsOpaquePath
        {
            get
            {
                switch (projectType)
                {
                    case ProjectType.MODPE:
                        return path + ITEMS_OPAQUE_PATH;
                    case ProjectType.COREENGINE:
                        return path + CE_ITEMS_OPAQUE_PATH;
                    case ProjectType.TEXTURE_PACK:
                        return path + TP_ITEMS_OPAQUE_PATH;
                    default: return null;
                }
            }
        }
        public string TerrainAtlasPath
        {
            get
            {
                switch (projectType)
                {
                    case ProjectType.MODPE:
                        return path + TERRAIN_ATLAS_PATH;
                    case ProjectType.COREENGINE:
                        return path + CE_TERRAIN_ATLAS_PATH;
                    case ProjectType.TEXTURE_PACK:
                        return path + TP_TERRAIN_ATLAS_PATH;
                    default: return null;
                }

            }
        }
        public string ProjectFilePath { get { return projectFile; } }
        public string MainScriptPath
        {
            get
            {
                switch (projectType)
                {
                    case ProjectType.MODPE:
                        return path + SCRIPTS_PATH + "main.js";
                    case ProjectType.COREENGINE:
                        return path + CE_DEV_PATH + ".includes";
                    case ProjectType.BEHAVIOUR_PACK:
                    case ProjectType.TEXTURE_PACK:
                        return path + "\\source\\manifest.json";
                    default: return null;
                }

            }
        }
        public string BuildPath { get { return path + BUILD_PATH; } }
        private string ScriptsPath
        {
            get
            {
                switch (projectType)
                {
                    case ProjectType.MODPE:
                        return path + SCRIPTS_PATH;
                    case ProjectType.COREENGINE:
                        return path + CE_DEV_PATH;
                    default: return null;
                }

            }
        }
        public string LibrariesPath { get { return path + LIB_PATH; } }
        private string ResPath
        {
            get
            {
                switch (projectType)
                {
                    case ProjectType.MODPE:
                        return path + RES_PATH;
                    case ProjectType.COREENGINE:
                        return path + CE_RES_PATH;
                    default: return null;
                }

            }
        }
        private string OutPath { get { return path + OUT_PATH; } }

        public string ProjectName { get { return projectName; } }

        public ProjectManager(string projectFile)
        {
            this.projectFile = projectFile;
            path = Directory.GetParent(projectFile).FullName;
            foreach (var line in File.ReadAllLines(projectFile))
            {
                string[] keyValue = line.Split(':');
                if (keyValue.Length != 2)
                    continue;
                switch (keyValue[0])
                {
                    case "nide-api":
                        if (Convert.ToInt32(keyValue[1]) > API_LEVEL)
                            throw new Exception("Api level is not supported");
                        break;
                    case "project-type":
                        projectType = StringToProjectType(keyValue[1]);
                        break;
                }
            }
            UpdateNlib();
        }

        public ProjectManager(string path, ProjectType type, string projectName)
        {
            this.projectName = projectName;
            projectType = type;
            this.path = path;
            version = "1.0.0";
            compress = false;

            switch (projectType)
            {
                case ProjectType.MODPE:
                    CreateModPEFileSystem();
                    break;
                case ProjectType.COREENGINE:
                    CreateCoreEngineFileSystem();
                    break;
                case ProjectType.BEHAVIOUR_PACK:
                    CreateBehaviourPackFileSystem();
                    break;
                case ProjectType.TEXTURE_PACK:
                    CreateResourcePackFileSystem();
                    break;

            }

            projectFile = path + "\\" + projectName + ".nproj";
            string nproj = string.Format(
                "nide-api:{0}\nproject-name:{1}\nproject-version:1.0.0\nproject-type:{2}\nsettings-compress:false",
                API_LEVEL, projectName, ProjectTypeToString(type));
            File.WriteAllText(projectFile, nproj);
        }

        private void CreateResourcePackFileSystem()
        {
            CopyDirectory(Directory.GetCurrentDirectory() + "\\templates\\vanilla_texture", path + SOURCE_CODE_PATH);
        }

        private void CreateBehaviourPackFileSystem()
        {
            CopyDirectory(Directory.GetCurrentDirectory() + "\\templates\\vanilla_behaviour", path + SOURCE_CODE_PATH);
        }

        void CopyDirectory(string FromDir, string ToDir)
        {
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                CopyDirectory(s, ToDir + "\\" + Path.GetFileName(s));
            }
        }

        public ProjectManager(string source, string path, string projectName) : this(path, ProjectType.MODPE, projectName)
        {
            using (ZipArchive archive = ZipFile.OpenRead(source))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".js", StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(Path.Combine(ScriptsPath, entry.Name), true);
                    }
                    else if (entry.FullName.StartsWith("images"))
                    {
                        if (entry.Name == "")
                        {
                            Directory.CreateDirectory(Path.Combine(ResPath, entry.FullName.Substring(7)));
                        }
                        else
                            entry.ExtractToFile(Path.Combine(ResPath, entry.FullName.Substring(7)), true);
                    }
                }
            }
        }

        public void UpdateNlib()
        {
            Libraries.Clear();
            Autocomplete.UserItems.Clear();
            foreach (var line in File.ReadAllLines(projectFile))
            {
                string[] keyValue = line.Split(':');
                if (keyValue.Length != 2)
                    continue;
                switch (keyValue[0])
                {

                    case "project-name":
                        projectName = keyValue[1];
                        break;
                    case "project-version":
                        version = keyValue[1];
                        break;
                    case "settings-compress":
                        compress = Convert.ToBoolean(keyValue[1]);
                        break;
                    case "include-library":
                        try
                        {
                            var l = new Library(keyValue[1], LibrariesPath, Libraries, OutFiles);
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

        public void AddScript(string name)
        {
            name = name.ToLower().EndsWith(".js") ? name : name + ".js";
            string ScriptPath = ScriptsPath + name;
            File.CreateText(ScriptPath).Close();
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

        public void AddLibrary(string name)
        {
            string path = LibrariesPath + name + "\\";
            Directory.CreateDirectory(path);
            File.CreateText(path + "lib.js").Close();
            File.WriteAllText(path + "info.nlib", String.Format("nide-api:{0}\nlibrary-version:1.0", API_LEVEL));
            File.AppendAllText(projectFile, "\ninclude-library:project/" + name);
            UpdateNlib();
        }

        public void IncludeLibrary(string name)
        {
            if (!LibraryInstalled(name))
            {
                File.AppendAllText(projectFile, "\ninclude-library:nide/" + name);
                UpdateNlib();
            }
        }

        public void ExcludeLibrary(string name)
        {
            List<string> lines = new List<string>();
            lines.AddRange(File.ReadAllLines(projectFile));
            if (lines.Contains("include-library:nide/" + name))
                lines.Remove("include-library:nide/" + name);
            File.WriteAllLines(projectFile, lines);
            UpdateNlib();
        }

        public void build()
        {
            try
            {
                switch (projectType)
                {
                    case ProjectType.MODPE:
                        BuildModPE();
                        break;
                    case ProjectType.COREENGINE:
                        BuildCoreEngine();
                        break;
                    case ProjectType.BEHAVIOUR_PACK:
                    case ProjectType.TEXTURE_PACK:
                        BuildPack();
                        break;
                }
            } catch(Exception e)
            {
                ProgramData.Log("Build", "Unable to build " + ProjectTypeToString(projectType) + "; " + e.Message);
            }
        }

        private void BuildPack()
        {
            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectory(path + SOURCE_CODE_PATH);
                zip.Save(path + "\\" + ProjectName + ".mcpack");
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


        private void CreateModPEFileSystem()
        {
            foreach (string item in new string[]{
                SOURCE_CODE_PATH,
                "\\source\\res\\",
                RES_PATH,
                ITEMS_OPAQUE_PATH,
                TERRAIN_ATLAS_PATH,
                OTHER_RESOURCES_PATH,
                SCRIPTS_PATH,
                "\\source\\scripts\\main.js",
                LIB_PATH,
                BUILD_PATH,
                OUT_PATH
                })
            {
                if (item.EndsWith("\\"))
                    Directory.CreateDirectory(path + item);
                else File.CreateText(path + item).Close();
            }
        }

        private void CreateCoreEngineFileSystem()
        {
            foreach (string item in new string[]{
                "\\mod.info",
                "\\gui\\",
                "\\dev\\",
                "\\dev\\.includes",
                "\\assets\\",
                "\\assets\\items-opaque\\",
                "\\assets\\terrain-atlas\\"
            })
            {
                if (item.EndsWith("\\"))
                    Directory.CreateDirectory(path + item);
                else File.CreateText(path + item).Close();
            }
        }

        private void BuildModPE()
        {
            UpdateNlib();
            string outp = BuildPath + "main.js";
            File.Delete(outp);
            foreach (var library in Libraries)
            {
                string text = library.GetCode();
                File.AppendAllText(outp, "\n" + text);
            }
            foreach (var file in Directory.GetFiles(ScriptsPath))
            {
                string text = File.ReadAllText(file);
                File.AppendAllText(outp, "\n" + text);
            }
            if (compress)
            {
                JavaScriptCompressor compressor = new JavaScriptCompressor();
                File.WriteAllText(outp, compressor.Compress(File.ReadAllText(outp)));
            }

            foreach (var file in OutFiles)
            {
                File.Copy(file, BuildPath + Path.GetFileName(file), true);
                File.Copy(file, OutPath + Path.GetFileName(file), true);
            }

            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectoryByName("images");
                zip.AddDirectory(ResPath, "images");
                zip.Save(BuildPath + "resources.zip");
            }

            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectoryByName("scripts");
                zip.AddFile(outp, "scripts");
                zip.AddDirectoryByName("images");
                zip.AddDirectory(ResPath, "images");
                zip.Save(OutPath + projectName + ".modpkg");
            }
        }

        private void BuildCoreEngine()
        {
            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectoryByName("assets");
                zip.AddDirectory(ResPath, "assets");
                zip.Save(path + "\\resources.zip");
            }
        }


        private string ProjectTypeToString(ProjectType type)
        {
            switch (type)
            {
                case ProjectType.MODPE:
                    return "MODPE";
                case ProjectType.COREENGINE:
                    return "COREENGINE";
                case ProjectType.BEHAVIOUR_PACK:
                    return "BEHAVIOUR_PACK";
                case ProjectType.TEXTURE_PACK:
                    return "TEXTURE_PACK";
                default:
                    return null;
            }
        }

        private ProjectType StringToProjectType(string type)
        {
            switch (type)
            {
                case "MODPE":
                    return ProjectType.MODPE;
                case "COREENGINE":
                    return ProjectType.COREENGINE;
                case "BEHAVIOUR_PACK":
                    return ProjectType.BEHAVIOUR_PACK;
                case "TEXTURE_PACK":
                    return ProjectType.TEXTURE_PACK;
                default:
                    throw new ArgumentException("Unknown project type " + type);
            }
        }
    }
}
