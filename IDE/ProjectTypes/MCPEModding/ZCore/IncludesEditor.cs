using NIDE.Editors;
using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using NIDE.Highlighting;
using System.Text.RegularExpressions;
using System;
using System.Drawing;

namespace NIDE.ProjectTypes.MCPEModding.ZCore
{
    class IncludesEditor : CodeEditor, IEnumerable<AutocompleteItem>
    {
        private AutocompleteMenu autocomplete;

        TextStyle commentStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        TextStyle delimitersStyle = new TextStyle(Brushes.Green, null, FontStyle.Bold);

        public IncludesEditor(string file) : base(file) { }

        public override bool Edit()
        {
            if (!base.Edit())
                return false;
            autocomplete = new AutocompleteMenu(TextBox);
            autocomplete.Items.SetAutocompleteItems(this);
            autocomplete.MinFragmentLength = 1;
            TextBox.Language = Language.Custom;
            Autocomplete.SetAutoompleteMenu(TextBox);
            CodeAnalysisEngine.Stop();
            Focus();
            Update(TextBox.Range);
            return true;
        }

        public override void Focus()
        {
            Autocomplete.Enabled = false;
            RefreshStyles(Highlighter.Instance);
        }

        public IEnumerator<AutocompleteItem> GetEnumerator()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            string path = ProgramData.Project.ScriptsPath;
            List<string> files = Util.GetFileList(new DirectoryInfo(path)).Relative(path);
            foreach (string file in files)
            {
                if(file != ".includes")
                    yield return new AutocompleteItem(file.Replace('\\', '/'));
            }
        }

        public override void RefreshStyles(Highlighter highlighter)
        {
            commentStyle = new TextStyle(new SolidBrush(Highlighter.CommentsColor), null, FontStyle.Italic);
            delimitersStyle = new TextStyle(new SolidBrush(Highlighter.StringsColor), null, FontStyle.Bold);
        }

        public override void Update(Range range)
        {
            range.ClearStyle(commentStyle);
            range.ClearStyle(delimitersStyle);
            range.SetStyle(delimitersStyle, "/", RegexOptions.Multiline);
            range.SetStyle(commentStyle, "#.*", RegexOptions.Multiline);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
