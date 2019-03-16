using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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
            private string name;
            public Nide(string name)
            {
                this.name = name;
            }

            public void log(string message)
            {
                ProgramData.Log("Plugin: " + name, message, ProgramData.LOG_STYLE_NORMAL);
            }

            public void success(string message)
            {
                ProgramData.Log("Plugin: " + name, message, ProgramData.LOG_STYLE_SUCCESS);
            }

            public void warn(string message)
            {
                ProgramData.Log("Plugin: " + name, message, ProgramData.LOG_STYLE_WARN);
            }

            public void error(string message)
            {
                ProgramData.Log("Plugin: " + name, message, ProgramData.LOG_STYLE_ERROR);
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

            public bool exists(string path)
            {
                return System.IO.File.Exists(path) || Directory.Exists(path);
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
                if (Directory.Exists(ProgramData.Project.TerrainAtlasPath))
                {
                    return ProgramData.Project.TerrainAtlasPath;
                } else 
                {
                    return ProgramData.Project.Path;
                }                 
            }

            public string getItemsDirectory()
            {
                if (Directory.Exists(ProgramData.Project.TerrainAtlasPath))
                {
                    return ProgramData.Project.ItemsOpaquePath;
                }
                else
                {
                    return ProgramData.Project.Path;
                }
            }
        }

        private class Plugin
        {
            private Dictionary<string, JavascriptFunction> menuButtons = new Dictionary<string, JavascriptFunction>();
            private string name;

            public Plugin(string name)
            {
                this.name = name;
            }

            private void menuButtonClick(object sender, EventArgs e)
            {
                string command = ((ToolStripItem)sender).Text;
                try
                {
                    menuButtons[command].Call();
                }
                catch (Exception ex)
                {
                    ProgramData.Log("Plugin: " + name, ex.Message, ProgramData.LOG_STYLE_ERROR);
                }
                
            }

            public void registerMenuButton(string text, JavascriptFunction function)
            {
                if (menuButtons.Keys.Contains(text)){
                    throw new Exception("Button already exists: " + text);
                }
                menuButtons.Add(text, function);
                ProgramData.MainForm.addPluginMenuItem(text, menuButtonClick);
            }
        }

        public JavaScriptPlugin(string name)
        {
            this.name = name;
            string file = "plugins\\" + name + ".js";
            try
            {
                source = System.IO.File.ReadAllText(file, ProgramData.Encoding);
                context = new JavascriptContext();
                context.SetParameter("Nide", new Nide(name));
                context.SetParameter("File", new File());
                context.SetParameter("Project", new Project());
                context.SetParameter("Plugin", new Plugin(name));
            }
            catch (Exception e)
            {
                ProgramData.Log("Plugin: " + name, e.Message, ProgramData.LOG_STYLE_ERROR);
            }
        }

        public override void Run()
        {
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
