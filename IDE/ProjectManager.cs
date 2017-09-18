//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using Yahoo.Yui.Compressor;
//using System.IO.Compression;
//using NIDE.ProjectTypes;

//namespace NIDE
//{
//    class ProjectManager
//    {

//        public ProjectManager(string source, string path, string projectName) : this(path, ProjectType.MODPE, projectName)
//        {
//            using (ZipArchive archive = ZipFile.OpenRead(source))
//            {
//                foreach (ZipArchiveEntry entry in archive.Entries)
//                {
//                    if (entry.FullName.EndsWith(".js", StringComparison.OrdinalIgnoreCase))
//                    {
//                        entry.ExtractToFile(Path.Combine("scriptsPath", entry.Name), true);
//                    }
//                    else if (entry.FullName.StartsWith("images"))
//                    {
//                        if (entry.Name == "")
//                        {
//                            Directory.CreateDirectory(Path.Combine("ResPath", entry.FullName.Substring(7)));
//                        }
//                        else
//                            entry.ExtractToFile(Path.Combine("ResPath", entry.FullName.Substring(7)), true);
//                    }
//                }
//            }
//        }
        
        
//    }
//}
