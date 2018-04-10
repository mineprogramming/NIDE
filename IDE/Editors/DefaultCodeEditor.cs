using FastColoredTextBoxNS;

namespace NIDE.Editors
{
    class DefaultCodeEditor : CodeEditor
    {
        public DefaultCodeEditor(string file) : base(file)
        {

        }

        public override bool Edit()
        {
            if (!base.Edit())
                return false;

            TextBox.Language = Language.Custom;
            Autocomplete.SetAutoompleteMenu(TextBox);
            Autocomplete.Enabled = false;
            CodeAnalysisEngine.Stop();
            ProgramData.MainForm.ClearErrors();

            return true;
        }

        public override void Focus()
        {
            Autocomplete.Enabled = false;
        }

        public override void Update(Range range) { }
    }
}
