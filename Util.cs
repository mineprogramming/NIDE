using System.IO;
using System.Web.Script.Serialization;

namespace NIDE
{
    public static class Util
    {
        public static type ToObject<type>(this string JSON)
        {
            return new JavaScriptSerializer().Deserialize<type>(JSON);
        }

        public static void CreateFile(string PathRelative)
        {
            File.Create(ProgramData.Folder + "\\" + PathRelative).Close();
        }

        public static void CreateDirectory(string PathRelative)
        {
            Directory.CreateDirectory(ProgramData.Folder + "\\" + PathRelative);
        }
    }
}
