using FastColoredTextBoxNS;
using NIDE.ProjectTypes;
using NIDE.ProjectTypes.ZCore;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace NIDE
{
    public class Highlighter
    {
        public static Color NamespaceColor { get; set; } = Color.Green;
        public static Color HookColor { get; set; } = Color.Gray;
        public static Color GlobalColor { get; set; } = Color.Brown;
        public static Color MemberColor { get; set; } = Color.LightSkyBlue;

        public static Color? NumbersColor { get; set; } = null;
        public static Color? StringsColor { get; set; } = null;
        public static Color? KeywordsColor { get; set; } = null;

        public static ErrorHighlightStrategy ErrorStrategy { get; set; } = ErrorHighlightStrategy.UNDERLINE;


        private TextStyle NamespaceStyle, HookStyle, GlobalStyle, MemberStyle;
        

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

            ProgramData.MainForm.fctbMain.AddStyle(NamespaceStyle);
            ProgramData.MainForm.fctbMain.AddStyle(HookStyle);
            ProgramData.MainForm.fctbMain.AddStyle(GlobalStyle);
            ProgramData.MainForm.fctbMain.AddStyle(MemberStyle);

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
            try
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
            catch (Exception e) { }
         }

        public void HighlightError(PaintLineEventArgs e)
        {
            Brush brush;
            switch (ErrorStrategy)
            {
                case ErrorHighlightStrategy.UNDERLINE:
                    brush = new HatchBrush(HatchStyle.Wave, Color.Red, Color.Transparent);
                    e.Graphics.FillRectangle(brush, ProgramData.MainForm.fctbMain.LeftIndent, e.LineRect.Top + e.LineRect.Height, e.LineRect.Width, e.LineRect.Height / 5);
                    break;
                case ErrorHighlightStrategy.LINE_NUMBER:
                    e.Graphics.FillRectangle(Brushes.MistyRose, 0, e.LineRect.Top, ProgramData.MainForm.fctbMain.LeftIndent - 10, e.LineRect.Height);
                    break;
            }
            
            
        }
    }
}