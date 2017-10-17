
using System;
using System.IO;

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
                "\\assets\\terrain-atlas\\",
                "\\launcher.js"
            };

        public override ProjectType Type => ProjectType.INNERCORE;

        public override void Build() { }

        public override void Post_init()
        {
            File.WriteAllText(SourceCodePath + "\\build.config", @"{
  ""resources"":[
    {
      ""path"":""assets/"",
      ""resourceType"":""resource""
    },
    {
      ""path"":""gui/"",
      ""resourceType"":""gui""
    }
  ],
  ""defaultConfig"":{
    ""buildType"":""develop"",
    ""api"":""CoreEngine"",
    ""libraryDir"":""lib/""
  },
  ""buildDirs"":[
    {
      ""targetSource"":""main.js"",
      ""dir"":""dev/""
    }
  ],
  ""compile"":[
    {
      ""path"":""main.js"",
      ""sourceType"":""mod""
    },
    {
      ""path"":""launcher.js"",
      ""sourceType"":""launcher""
    }
  ]
}", ProgramData.Encoding);
            File.WriteAllText(SourceCodePath + "\\launcher.js", "Launch();", ProgramData.Encoding);
        }
    }
}
