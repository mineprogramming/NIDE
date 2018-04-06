using NIDE.Editors;
using FastColoredTextBoxNS;

namespace NIDE.ProjectTypes.ZCore
{
    class IncludesEditor : CodeEditor
    {
        public IncludesEditor(string file) : base(file)
        {

        }

        public override bool Edit()
        {
            if (!base.Edit())
                return false;

            TextBox.Language = Language.Custom;
            return true;
        }

        public override void Update(Range range)
        {
            
        }
    }
}
