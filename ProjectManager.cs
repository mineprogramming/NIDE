using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Yahoo.Yui.Compressor;

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

        public readonly ProjectType projectType;
        public readonly string path;
        private string version;
        private bool compress;
        public string projectFile;
        private string projectName;
        private List<Library> libraries = new List<Library>();

        public string SourceCodePath { get { return path + SOURCE_CODE_PATH; } }
        public string OtherResourcesPath { get { return path + OTHER_RESOURCES_PATH; } }
        public string ItemsOpaquePath { get { return path + ITEMS_OPAQUE_PATH; } }
        public string TerrainAtlasPath { get { return path + TERRAIN_ATLAS_PATH; } }
        public string ProjectFilePath { get { return projectFile; } }
        public string MainScriptPath { get { return path + SCRIPTS_PATH + "main.js"; } }
        private string BuildPath { get { return path + BUILD_PATH; } }
        private string ScriptsPath { get { return path + SCRIPTS_PATH; } }
        public string LibrariesPath { get { return path + LIB_PATH; } }
        private string ResPath { get { return path + RES_PATH; } }
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
                    case "project-version":
                        version = keyValue[1];
                        break;
                    case "project-type":
                        projectType = StringToProjectType(keyValue[1]);
                        break;
                    case "settings-compress":
                        compress = Convert.ToBoolean(keyValue[1]);
                        break;
                    case "include-library":
                        libraries.Add(new Library(keyValue[1], LibrariesPath));
                        break;
                    case "project-name":
                        projectName = keyValue[1];
                        break;
                }
            }
        }

        public ProjectManager(string path, ProjectType type, string projectName)
        {
            this.projectName = projectName;
            projectType = type;
            this.path = path;
            version = "1.0.0";
            compress = false;
            foreach (string item in new string[]{
                SOURCE_CODE_PATH,
                "\\source\\res\\",
                "\\source\\res\\images\\",
                ITEMS_OPAQUE_PATH,
                TERRAIN_ATLAS_PATH,
                OTHER_RESOURCES_PATH,
                SCRIPTS_PATH,
                "\\source\\scripts\\main.js",
                "\\source\\libs\\",
                BUILD_PATH,
                "\\out\\"
                })
            {
                if (item.EndsWith("\\"))
                    Directory.CreateDirectory(path + item);
                else File.CreateText(path + item).Close();
            }
            projectFile = path + "\\" + projectName + ".nproj";
            string nproj = string.Format(
                "nide-api:{0}\nproject-name:{1}\nproject-version:1.0.0\nproject-type:{2}\nsettings-compress:false",
                API_LEVEL, projectName, ProjectTypeToString(type));
            if (type == ProjectType.MODPE)
                nproj += "\nsettings-mode:modpkg";
            File.WriteAllText(projectFile, nproj);
        }

        public void AddScript(string name)
        {
            name = name.ToLower().EndsWith(".js") ? name : name + ".js";
            string ScriptPath = path + SCRIPTS_PATH + name;
            File.CreateText(ScriptPath).Close();
        }

        public void AddTexture(string name, ImageType type)
        {
            name = name.ToLower().EndsWith(".png") ? name : name + ".png";
            string TexturePath = path + (type == ImageType.ITEMS_OPAQUE ? ITEMS_OPAQUE_PATH : TERRAIN_ATLAS_PATH) + name;
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

        public void build()
        {
            foreach (var line in File.ReadAllLines(projectFile))
            {
                string[] keyValue = line.Split(':');
                if (keyValue.Length != 2)
                    continue;
                switch (keyValue[0])
                {
                    case "project-version":
                        version = keyValue[1];
                        break;
                    case "settings-compress":
                        compress = Convert.ToBoolean(keyValue[1]);
                        break;
                    case "include-library":
                        libraries.Add(new Library(keyValue[1], LibrariesPath));
                        break;
                }
            }
            string outp = BuildPath + "main.js";
            File.Delete(outp);
            foreach (var file in Directory.GetFiles(ScriptsPath))
            {
                string text = File.ReadAllText(file);
                File.AppendAllText(outp, "\n" + text);
            }

            foreach (var library in libraries)
            {
                string text = library.GetCode();
                File.AppendAllText(outp, "\n" + text);
            }
            if (compress)
            {
                JavaScriptCompressor compressor = new JavaScriptCompressor();
                File.WriteAllText(outp, compressor.Compress(File.ReadAllText(outp)));
            }

            using (ZipFile zip = new ZipFile())
            {
                zip.AddFile(outp, "\\");
                zip.AddDirectoryByName("images");
                zip.AddDirectory(ResPath, "images");
                zip.Save(OutPath + projectName + ".modpkg");
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
                case ProjectType.LIBRARY:
                    return "LIBRARY";
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
                case "LIBRARY":
                    return ProjectType.LIBRARY;
                default:
                    throw new ArgumentException("Unknown project type " + type);
            }
        }
    }
}
