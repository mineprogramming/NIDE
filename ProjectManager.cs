using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIDE
{
    class ProjectManager
    {
        private string[] filesystem =
        {
            "\\source\\",
            "\\source\\res\\",
            "\\source\\res/images\\",
            "\\source\\res\\images\\items-opaque\\",
            "\\source\\res\\images\\terrain-atlas\\",
            "\\source\\scripts\\",
            "\\source\\scripts\\main.js",
            "\\source\\libs\\",
            "\\build\\",
            "\\out\\"
        };

        public ProjectManager(string path)
        {

        }

        public ProjectManager(string path, ProjectType type)
        {
            foreach (string item in filesystem)
            {
                if (item.EndsWith("\\"))
                    Directory.CreateDirectory(path + item);
                else File.Create(path + item).Close();
            }
        }
    }
}
