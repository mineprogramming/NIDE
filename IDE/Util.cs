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
    }
}
