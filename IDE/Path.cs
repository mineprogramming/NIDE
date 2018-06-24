using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIDE
{
    public class Path
    {
        private string path;
        
        public static implicit operator Path(string value)
        {
            return new Path(value);
        }

        public static explicit operator string(Path path)
        {
            return path.path;
        }

        public static Path operator +(Path first, Path second)
        {
            return first.path.TrimEnd('\\') + "\\" + second.path.TrimStart('\\');
        }

        public static Path operator -(Path first, Path second)
        {
            return first.path.Substring(second.path.Length + 1);
        }


        public override bool Equals(object obj)
        {
            if (obj is Path)
                return path == ((Path)obj).path;
            else if (obj is string)
                return path == (string)obj;
            else return false;
        }

        public override int GetHashCode()
        {
            return path.GetHashCode();
        }


        public Path(string path)
        {
            this.path = path;
        }

        public Path(IEnumerable<string> parts)
        {
            path = String.Join("\\", parts);
        }

        public override string ToString()
        {
            return path;
        }


        public bool IsFile()
        {
            return File.Exists(path);
        }

        public bool IsDirectory()
        {
            return Directory.Exists(path);
        }

        public bool Exisis()
        {
            return Directory.Exists(path) || File.Exists(path);
        }

        public void mkdirs()
        {
            int ind = path.LastIndexOf('\\');
            if(ind != -1)
            {
                Directory.CreateDirectory(path.Substring(0, ind));
            }
        }

        public void CreateFile()
        {
            mkdirs();
            File.Create(path);
        }

        public string GetExtension()
        {
            return System.IO.Path.GetExtension(path).ToLower();
        }

        public string[] Explode()
        {
            return path.Replace('/', '\\').Trim('\\').Split('\\');
        }

        public bool IsSubPath(Path path)
        {
            return this.path.StartsWith(path.path);
        }

        internal string GetName()
        {
            return Explode().Last();
        }
    }
}
