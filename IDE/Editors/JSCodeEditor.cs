using FastColoredTextBoxNS;

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
            Autocomplete.SetAutoompleteMenu(TextBox);
            Autocomplete.Enabled = true;

            Update(TextBox.Range);
            return true;
        }

        public override void Update(Range range)
        {
            CodeAnalysisEngine.Update();
            ProgramData.MainForm.UpdateHighlighting(range);
        }
    }
}
