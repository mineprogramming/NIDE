using Managed.Adb;
using System.Collections.Generic;
using System.IO;

namespace NIDE.adb
{
    static class Util
    {
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
    }
}
