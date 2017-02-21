namespace NIDE
{
    static class ProgramData
    {
        public static string[] Recent = new string[10];

        private static ProjectManager projectManager = null;

        public static ProjectManager ProjectManager { get { return projectManager; } set { projectManager = value; } }

        public static string file;
    }
}