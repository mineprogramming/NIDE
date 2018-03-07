using FastColoredTextBoxNS;
using NIDE.ProjectTypes;
using System.Drawing;
using System.Text.RegularExpressions;

namespace NIDE
{
    public class Highlighter
    {
        public static Color NamespaceColor = Color.Green;
        public static Color HookColor = Color.Gray;
        public static Color GlobalColor = Color.Brown;
        public static Color MemberColor = Color.LightSkyBlue;

        public static Color? NumbersColor = null;
        public static Color? StringsColor = null;
        public static Color? KeywordsColor = null;

        static TextStyle NamespaceStyle, HookStyle, GlobalStyle, MemberStyle;


        private FastColoredTextBox fctbMain;

        public Highlighter(FastColoredTextBox fctbMain)
        {
            this.fctbMain = fctbMain;
            RefreshStyles();
        }

        public void RefreshStyles()
        {
            Range range = ProgramData.MainForm.fctbMain.Range;
            range.ClearStyle(NamespaceStyle);
            range.ClearStyle(HookStyle);
            range.ClearStyle(GlobalStyle);
            range.ClearStyle(MemberStyle);

            NamespaceStyle = new TextStyle(new SolidBrush(NamespaceColor), null, FontStyle.Bold);
            HookStyle = new TextStyle(new SolidBrush(HookColor), null, FontStyle.Bold);
            GlobalStyle = new TextStyle(new SolidBrush(GlobalColor), null, FontStyle.Regular);
            MemberStyle = new TextStyle(new SolidBrush(MemberColor), null, FontStyle.Italic);

            fctbMain.AddStyle(NamespaceStyle);
            fctbMain.AddStyle(HookStyle);
            fctbMain.AddStyle(GlobalStyle);
            fctbMain.AddStyle(MemberStyle);

            if (NumbersColor != null)
                ProgramData.MainForm.fctbMain.SyntaxHighlighter.NumberStyle = new TextStyle(new SolidBrush(NumbersColor.Value), null, FontStyle.Regular);
            if(StringsColor != null)
                ProgramData.MainForm.fctbMain.SyntaxHighlighter.StringStyle = new TextStyle(new SolidBrush(StringsColor.Value), null, FontStyle.Regular);
            if(KeywordsColor != null)
                ProgramData.MainForm.fctbMain.SyntaxHighlighter.KeywordStyle = new TextStyle(new SolidBrush(KeywordsColor.Value), null, FontStyle.Regular);

            ProgramData.MainForm.fctbMain.ClearStylesBuffer();
            ResetStyles(range);
        }

        public void ResetStyles(Range range)
        {
            range.ClearStyle(NamespaceStyle);
            range.ClearStyle(MemberStyle);
            range.ClearStyle(HookStyle);
            range.ClearStyle(GlobalStyle);

            ProgramData.MainForm.fctbMain.SyntaxHighlighter.JScriptSyntaxHighlight(range);
            range.SetStyle(NamespaceStyle, @"(\W)", RegexOptions.Multiline);

            if (Autocomplete.UserItems.Keys.Count > 0)
            {
                range.SetStyle(NamespaceStyle, @"(\W|^)(" + string.Join("|", Autocomplete.UserItems.Keys) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(MemberStyle, @"(\W|^)(" + string.Join("|", Autocomplete.members) + @")(\W|$)", RegexOptions.Multiline);
            }

            if (ProgramData.Project?.Type == ProjectType.COREENGINE || ProgramData.Project?.Type == ProjectType.INNERCORE)
            {
                range.SetStyle(NamespaceStyle, @"(\W|^)(" + string.Join("|", ZCore.Items) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(MemberStyle, @"(\W|^)(" + string.Join("|", ZCore.members) + @")(\W|$)", RegexOptions.Multiline);
            }
            else
            {
                range.SetStyle(NamespaceStyle, @"(\W|^)(" + string.Join("|", ModPE.namespaces) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(HookStyle, @"(\W|^)(" + string.Join("|", ModPE.hooks) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(GlobalStyle, @"(\W|^)(" + string.Join("|", ModPE.global) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(MemberStyle, @"(\W|^)(" + string.Join("|", ModPE.members) + @")(\W|$)", RegexOptions.Multiline);
            }
         }
    }
}