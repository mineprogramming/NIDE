using FastColoredTextBoxNS;
using NIDE.components;

namespace NIDE.Editors
{
    public abstract class CodeEditor : Editor
    {
        public abstract void Update(Range range);
        
        public EditorTab EditorTab { get; private set; }
        public FastColoredTextBox TextBox { get { return EditorTab.TextBox; } }

        public CodeEditor(string file) : base(file)
        {

        }

        public override bool Edit()
        {
            EditorTab = ProgramData.MainForm.OpenScript(file, this);
            TextBox.ReadOnly = false;
            if(EditorTab == null)
                return false;
            else return true;
        }
    }
}
