using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NIDE
{
    public static class Util
    {
        public static type ToObject<type>(this string JSON)
        {
            return new JavaScriptSerializer().Deserialize<type>(JSON);
        }

        public static void FillDirectoryNodes(TreeNode node, DirectoryInfo dir)
        {
            try
            {
                foreach (var subdir in dir.GetDirectories())
                    FillDirectoryNodes(node.Nodes.Add(subdir.Name), subdir);
                foreach (var file in dir.GetFiles())
                    node.Nodes.Add(file.Name);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to load filesystem");
            }
        }

        public static void CopyDirectory(string FromDir, string ToDir)
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

        public static string ProjectTypeToString(ProjectType type)
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

        public static ProjectType StringToProjectType(string type)
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
