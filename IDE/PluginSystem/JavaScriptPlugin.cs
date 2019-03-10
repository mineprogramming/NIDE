using System;
using System.IO;
using System.Linq;
using Noesis.Javascript;

namespace NIDE.PluginSystem
{
    class JavaScriptPlugin : Plugin
    {
        private readonly string name;
        private readonly string source;
        private JavascriptContext context;

        private class Nide
        {
            public void log(string message)
            {
                ProgramData.Log("Plugin", message, ProgramData.LOG_STYLE_NORMAL);
            }

            public void warn(string message)
            {
                ProgramData.Log("Plugin", message, ProgramData.LOG_STYLE_WARN);
            }
        }

        private class File
        {
            public static void createDirectory(string name)
            {
                Directory.CreateDirectory(name);
            }

            public string read(string path)
            {
                return System.IO.File.ReadAllText(path, ProgramData.Encoding);
            }

            public void write(string file, string text)
            {
                System.IO.File.WriteAllText(file, text, ProgramData.Encoding);
            }

            public void append(string file, string text)
            {
                System.IO.File.AppendAllText(file, text, ProgramData.Encoding);
            }

            public string[] search(string path, string pattern)
            {
                return Directory.EnumerateFiles(path, pattern, SearchOption.AllDirectories).ToArray();
            }

            public void copy(string from, string to)
            {
                System.IO.File.Copy(from, to, true);
            }
        }

        private class Project
        {
            public string getName()
            {
                return ProgramData.Project.Name;
            }

            public string getDirectory()
            {
                return ProgramData.Project.Path;
            }

            public string getScriptsDirectory()
            {
                return ProgramData.Project.ScriptsPath;
            }

            public string getBlocksDirectory()
            {
                return ProgramData.Project.TerrainAtlasPath;
            }

            public string getItemsDirectory()
            {
                return ProgramData.Project.ItemsOpaquePath;
            }
        }

        public JavaScriptPlugin(string name)
        {
            this.name = name;
            string file = "plugins\\" + name + ".js";
            source = System.IO.File.ReadAllText(file, ProgramData.Encoding);
            context = new JavascriptContext();
        }

        public override void Run()
        {
            context.SetParameter("Nide", new Nide());
            context.SetParameter("File", new File());
            context.SetParameter("Project", new Project());

            try
            {
                context.Run(source);
            } catch(Exception e)
            {
                ProgramData.Log("Plugin: " + name, e.Message, ProgramData.LOG_STYLE_ERROR);
            }
            
        }
    }
}
