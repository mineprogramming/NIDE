using System.Collections.Generic;
using System.Text;

namespace NIDE
{
    static class ProgramData
    {
        public const int PROGRAM_VERSION = 4;

        public static Encoding Encoding { get { return new UTF8Encoding(false); } }

        public static void Log(string source, string message)
        {
            if(MainForm != null)
            {
                MainForm.Log(source, message);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(message, source);
            }
        }

        public static void Error(int line, string message)
        {
            if (MainForm != null)
            {
                MainForm.Error(line, message);
            }
        }

        public static List<string> Recent = new List<string>();

        private static ProjectManager projectManager = null;

        public static ProjectManager ProjectManager { get { return projectManager; } set { projectManager = value; } }

        public static string file;

        public static bool FileOnly = false;

        public static fMain MainForm { get; set; }

        public static bool LoadLast = true;

        public static string Last = "";

        public static bool Restart = false;
    }
}