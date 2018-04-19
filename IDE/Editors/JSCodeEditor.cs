using FastColoredTextBoxNS;
using NIDE.Highlighting;
using NIDE.ProjectTypes.MCPEModding;

namespace NIDE.Editors
{
    class JSCodeEditor : CodeEditor
    {
        public JSCodeEditor(string file) : base(file)
        {

        }

        public override bool Edit()
        {
            if (!base.Edit())
                return false;

            TextBox.Language = Language.JS;
            Focus();
            return true;
        }

        public override void Focus()
        {
            Highlighter.Instance.RefreshStyles(TextBox);
            Autocomplete.SetAutoompleteMenu(TextBox);
            Autocomplete.Enabled = true;
            Update(TextBox.Range);
        }

        public override void RefreshStyles(Highlighter highlighter)
        {
            highlighter.RefreshStyles(TextBox);
        }

        public override void Update(Range range)
        {
            CodeAnalysisEngine.Update(this);
            ProgramData.MainForm.UpdateHighlighting(range);
        }
    }
}
