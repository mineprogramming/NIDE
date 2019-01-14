using FastColoredTextBoxNS;
using NIDE.ProjectTypes;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NIDE
{
    static class ProgramData
    {
        public static Style LOG_STYLE_NORMAL = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        public static Style LOG_STYLE_ERROR = new TextStyle(Brushes.DarkRed, null, FontStyle.Bold);
        public static Style LOG_STYLE_WARN = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        public static Style LOG_STYLE_SUCCESS = new TextStyle(Brushes.DarkGreen, null, FontStyle.Regular);

        public const int PROGRAM_VERSION = 
            /*THIS IS VERY IMPORTANT*/
            /*Ta-boom-tss...*/     42;
            /*EXTREMELY*/
        public const int API_LEVEL = 3;

        public static Encoding Encoding { get { return new UTF8Encoding(false); } }

        public static void Log(string source, string message, Style style)
        {
            if(MainForm != null)
            {
                MainForm.Log(source, message, style);
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

        public static fMain MainForm { get; set; }

        public static bool LoadLast = true;

        public static string Last = "";

        public static bool Restart = false;
    }
}