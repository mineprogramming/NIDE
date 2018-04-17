using FastColoredTextBoxNS;
using NIDE.components;
using System.Collections.Generic;

namespace NIDE.Editors
{
    public abstract class CodeEditor : Editor
    {
        public abstract void Update(Range range);
        public abstract void Focus();
        public List<int> Errors { get; } = new List<int>();

        public EditorTab EditorTab { get; private set; }
        public FastColoredTextBox TextBox { get { return EditorTab.TextBox; } }
        public bool EditBlank { get; set; } = false;

        public CodeEditor(string file) : base(file)
        {

        }

        public override bool Edit()
        {
            EditorTab = ProgramData.MainForm.OpenScript(file, this, EditBlank);
            TextBox.ReadOnly = false;
            if(EditorTab == null)
                return false;
            else return true;
        }
    }
}
