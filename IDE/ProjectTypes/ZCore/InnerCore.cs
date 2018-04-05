
using System.Collections.Generic;
using System.IO;

namespace NIDE.ProjectTypes.ZCore
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

        public override bool ShowMainEnabled => true;

        public override void Build() {
            string outf = Path + "\\main.js";
            string[] lines = File.ReadAllLines(MainScriptPath);
            List<string> files = new List<string>();
            foreach(string line in lines)
            {
                string l = line.Trim();
                if (l != "" && !l.StartsWith("//") && !l.StartsWith("#") && File.Exists(ScriptsPath + l))
                    files.Add(l);
            }
            File.WriteAllText(outf, @"/*
NIDE BUILD INFO:
  dir: dev
  target: main.js
  files: " + files.Count + "\n*/", ProgramData.Encoding);
            foreach(string file in files)
            {
                File.AppendAllText(outf, "\n\n\n\n// file: " + file + "\n\n");
                File.AppendAllText(outf, File.ReadAllText(ScriptsPath + file));
            }
        }

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

            FModInfo fModInfo = new FModInfo(SourceCodePath + "\\mod.info", Name);
            fModInfo.Show();
        }
    }
}
