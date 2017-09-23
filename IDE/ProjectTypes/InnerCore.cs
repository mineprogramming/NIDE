
using System;

namespace NIDE.ProjectTypes
{
    class InnerCore : ZCore
    {
        public InnerCore(string projectFile) : base(projectFile) { }
        public InnerCore(string path, string projectName) : base(path, projectName) { }

        public override string ProgramPackage => "com.zhekasmirnov.innercore";
        public override string DefaultNproj =>
            "nide-api:{0}\nproject-name:{1}\nproject-version:1.0.0\nproject-type:INNERCORE\nsettings-compress:false";

        public override string[] Filesystem => new string[]{
                "\\mod.info",
                "\\build.config",
                "\\gui\\",
                "\\dev\\",
                "\\dev\\.includes",
                "\\assets\\",
                "\\assets\\items-opaque\\",
                "\\assets\\terrain-atlas\\"
            };

        public override ProjectType Type => ProjectType.INNERCORE;

        public override void Build(){ }
    }
}
