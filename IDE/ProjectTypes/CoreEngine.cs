

using System;

namespace NIDE.ProjectTypes
{
    class CoreEngine : ZCore
    {
        public CoreEngine(string projectFile) : base(projectFile) { }
        public CoreEngine(string path, string projectName) : base(path, projectName) { }

        public override string ProgramPackage => "net.zhuoweizhang.mcpelauncher.pro";
        public override string DefaultNproj =>
            "nide-api:{0}\nproject-name:{1}\nproject-version:1.0.0\nproject-type:COREENGINE\nsettings-compress:false";

        public override string[] Filesystem => new string[]{
                "\\gui\\",
                "\\dev\\",
                "\\dev\\.includes",
                "\\assets\\",
                "\\assets\\items-opaque\\",
                "\\assets\\terrain-atlas\\"
            };

        public override ProjectType Type => ProjectType.COREENGINE;

        public override void Build()
        {
            using (var zip = new Ionic.Zip.ZipFile())
            {
                zip.AddDirectoryByName("assets");
                zip.AddDirectory(ResPath, "assets");
                zip.Save(Path + "\\resources.zip");
            }
        }

        public override void Post_init()
        {
            throw new NotImplementedException();
        }
    }
}