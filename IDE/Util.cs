using System;
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
