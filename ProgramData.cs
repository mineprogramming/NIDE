namespace NIDE
{
    static class ProgramData
    {
        public static string[] Recent = new string[10];

        private static ProjectManager projectManager = null;

        public static ProjectManager ProjectManager { get { return projectManager; } set { projectManager = value; } }

        public static string file;

        public static bool FileOnly = false;

        public static fMain MainForm { get; set; }

        public static bool LoadLast = true;

        public static string Last = "";

        public static bool DarkTheme = true;

        public static bool Restart = false;
    }
}