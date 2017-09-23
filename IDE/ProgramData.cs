using NIDE.ProjectTypes;
using System.Collections.Generic;
using System.Text;

namespace NIDE
{
    static class ProgramData
    {
        public const int PROGRAM_VERSION = 7;
        public const int API_LEVEL = 3;

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

        public static Project Project { get; set; }

        public static string file;

        public static fMain MainForm { get; set; }

        public static bool LoadLast = true;

        public static string Last = "";

        public static bool Restart = false;
    }
}