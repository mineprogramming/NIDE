using FastColoredTextBoxNS;
using NIDE.ProjectTypes.MCPEModding;
using NIDE.ProjectTypes.MCPEModding.ZCore;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace NIDE.Highlighting
{
    public class Highlighter
    {
        public static Color NamespaceColor { get; set; } = Color.Green;
        public static Color HookColor { get; set; } = Color.Gray;
        public static Color GlobalColor { get; set; } = Color.Brown;
        public static Color MemberColor { get; set; } = Color.LightSkyBlue;
        public static Color NumbersColor { get; set; } = Color.RosyBrown;
        public static Color StringsColor { get; set; } = Color.Blue;
        public static Color KeywordsColor { get; set; } = Color.RoyalBlue;
        public static Color CommentsColor { get; set; } = Color.Green;

        public static Color ForeColor { get; set; } = Color.Black;
        public static Color BackColor { get; set; } = Color.White;

        public static ErrorHighlightStrategy ErrorStrategy { get; set; } = ErrorHighlightStrategy.UNDERLINE;

        public static Highlighter Instance { get; private set; }

        public static Dictionary<string, string> DefaultColors { get; } = new Dictionary<string, string>()
        {
            {"NormalStyle", Color.Black.ToArgb().ToString() },
            {"BackStyle", Color.White.ToArgb().ToString() },
            {"NamespaceStyle", Color.Green.ToArgb().ToString() },
            {"GlobalStyle", Color.DarkSlateGray.ToArgb().ToString() },
            {"HookStyle", Color.Gray.ToArgb().ToString() },
            {"MemberStyle", Color.DarkViolet.ToArgb().ToString() },
            {"NumberStyle", Color.Coral.ToArgb().ToString() },
            {"StringStyle", Color.DarkRed.ToArgb().ToString() },
            {"KeywordStyle", Color.Blue.ToArgb().ToString() },
            {"CommentsStyle", Color.Blue.ToArgb().ToString() }
        };

        public Highlighter()
        {
            Instance = this;
        }


        private TextStyle NamespaceStyle, HookStyle, GlobalStyle, MemberStyle;

        public void RefreshStyles(FastColoredTextBox fctb)
        {
            Range range = fctb.Range;

            range.ClearStyle(NamespaceStyle);
            range.ClearStyle(HookStyle);
            range.ClearStyle(GlobalStyle);
            range.ClearStyle(MemberStyle);

            NamespaceStyle = new TextStyle(new SolidBrush(NamespaceColor), null, FontStyle.Bold);
            HookStyle = new TextStyle(new SolidBrush(HookColor), null, FontStyle.Bold);
            GlobalStyle = new TextStyle(new SolidBrush(GlobalColor), null, FontStyle.Regular);
            MemberStyle = new TextStyle(new SolidBrush(MemberColor), null, FontStyle.Italic);

            fctb.AddStyle(NamespaceStyle);
            fctb.AddStyle(HookStyle);
            fctb.AddStyle(GlobalStyle);
            fctb.AddStyle(MemberStyle);

            fctb.ForeColor = ForeColor;
            fctb.BackColor = BackColor;

            fctb.SyntaxHighlighter.NumberStyle = new TextStyle(new SolidBrush(NumbersColor), null, FontStyle.Regular);
            fctb.SyntaxHighlighter.StringStyle = new TextStyle(new SolidBrush(StringsColor), null, FontStyle.Regular);
            fctb.SyntaxHighlighter.KeywordStyle = new TextStyle(new SolidBrush(KeywordsColor), null, FontStyle.Regular);
            fctb.SyntaxHighlighter.CommentStyle = new TextStyle(new SolidBrush(CommentsColor), null, FontStyle.Italic);

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
            catch { }
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