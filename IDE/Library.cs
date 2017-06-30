using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NIDE
{
    class Library
    {
        public string path;
        public string version;
        public string name;

        public Library(string path, string LibrariesPath, List<Library> Libraries, List<string> OutFiles)
        {
            string location = path.Split('/')[0];
            name = path.Split('/')[1];
            string dirpath = (location == "nide") ? Directory.GetCurrentDirectory() + "\\libraries\\" : LibrariesPath;
            bool loaded = false;
            foreach (var folder in Directory.GetDirectories(dirpath))
            {
                if (new DirectoryInfo(folder).Name == name)
                {
                    LoadLibrary(folder, LibrariesPath, Libraries, OutFiles);
                    loaded = true;
                }
            }
            if (!loaded)
                throw new DirectoryNotFoundException("Cannot find library " + path);
        }

        private void LoadLibrary(string path, string LibrariesPath, List<Library> Libraries, List<string> OutFiles)
        {
            this.path = path;
            string pathToNlib = path + "\\info.nlib";
            foreach (var line in File.ReadAllLines(pathToNlib, Encoding.UTF8))
            {
                string[] keyValue = line.Split(':');
                if (keyValue.Length != 2)
                    continue;
                switch (keyValue[0])
                {
                    case "nide-api":
                        if (Convert.ToInt32(keyValue[1]) > ProjectManager.API_LEVEL)
                            throw new Exception("Api level is not supported");
                        break;
                    case "library-version":
                        version = keyValue[1];
                        break;
                    case "keyword":
                        if (!Autocomplete.UserItems.ContainsKey(name))
                            Autocomplete.UserItems.Add(name, new List<string>());
                        Autocomplete.UserItems[name].Add(keyValue[1]);
                        break;
                    case "requires-library":
                        var l = new Library(keyValue[1], LibrariesPath, Libraries, OutFiles);
                        var installed = false;
                        foreach (var library in Libraries)
                        {
                            if (library.name == l.name) installed = true;
                        }
                        if(!installed)
                            Libraries.Add(l);
                        break;
                    case "copy-to-out":
                        OutFiles.Add(path + "\\" + keyValue[1]);
                        break;
                    case "key-global":
                        Autocomplete.UserItems.Add(keyValue[1], new List<string>());
                        break;
                }
            }
        }

        public string GetCode()
        {
            string CodePath = path + "\\lib.js";
            return File.ReadAllText(CodePath, Encoding.UTF8);
        }
    }
}
