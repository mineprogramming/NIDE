using Managed.Adb;
using NIDE.components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NIDE
{
    public static class Util
    {
        private static Random rnd = new Random();

        public static type ToObject<type>(this string JSON)
        {
            return new JavaScriptSerializer().Deserialize<type>(JSON);
        }

        public static string ToJson(this object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        public static void FillDirectoryNodes(TreeNode node, DirectoryInfo dir)
        {
            try
            {
                foreach (var subdir in dir.GetDirectories())
                {
                    TreeNode n = node.Nodes.Add(subdir.Name);
                    ((ProjectTree)n.TreeView).UpdateIcon(n);
                    FillDirectoryNodes(n, subdir);
                }
                foreach (var file in dir.GetFiles())
                {
                    TreeNode n = node.Nodes.Add(file.Name);
                    ((ProjectTree)n.TreeView).UpdateIcon(n);
                }
                    
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to load filesystem");
            }
        }

        public static string GenerateUUID()
        {
            
            string uuid = "";
            for(int i = 0; i < 32; i++)
            {
                uuid += rnd.Next(16).ToString("x");
                if (i == 7 || i == 11 || i == 15 || i == 19)
                    uuid += "-";
            }
            return uuid;
        }

        public static string ProjectTypeToString(ProjectType type)
        {
            switch (type)
            {
                case ProjectType.MODPE:
                    return "MODPE";
                case ProjectType.COREENGINE:
                    return "COREENGINE";
                case ProjectType.INNERCORE:
                    return "INNERCORE";
                default:
                    return null;
            }
        }

        public static ProjectType StringToProjectType(string type)
        {
            switch (type)
            {
                case "MODPE":
                    return ProjectType.MODPE;
                case "COREENGINE":
                    return ProjectType.COREENGINE;
                case "INNERCORE":
                    return ProjectType.INNERCORE;
                default:
                    throw new ArgumentException("Unknown project type " + type);
            }
        }

        public static List<string> GetFileList(DirectoryInfo directory)
        {
            List<string> files = new List<string>();
            foreach (var file in directory.GetFiles("*.*", SearchOption.AllDirectories))
                if (file.IsFile()) files.Add(file.FullName);
            return files;
        }


        public static List<string> Relative(this List<string> files, string basedir)
        {
            List<string> relative = new List<string>();
            foreach (var file in files)
                relative.Add(file.Substring(basedir.Length).TrimStart('\\'));
            return relative;
        }

        public static Path ToPath(this IEnumerable<string> parts)
        {
            return new Path(parts);
        }
    }
}
