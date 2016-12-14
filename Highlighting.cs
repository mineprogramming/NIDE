using FastColoredTextBoxNS;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ModPE_editor
{
    static class Highlighting
    {
        static Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Bold);
        static Style GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Bold);
        static Style BrownStyle = new TextStyle(Brushes.Brown, null, FontStyle.Regular);
        static Style BlueStyle = new TextStyle(Brushes.LightSkyBlue, null, FontStyle.Italic);

        public static void ResetStyles(Range range)
        {
            if (ProgramData.Mode == WorkMode.CORE_ENGINE)
            {
                range.ClearStyle(GreenStyle);
                range.ClearStyle(BlueStyle);

                range.SetStyle(GreenStyle, @"(\W|^)(" + string.Join("|", CoreEngine.Items) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(BlueStyle, @"(\W|^)(" + string.Join("|", CoreEngine.members) + @")(\W|$)", RegexOptions.Multiline);
            }
            else
            {
                range.ClearStyle(GreenStyle);
                range.ClearStyle(GrayStyle);
                range.ClearStyle(BrownStyle);
                range.ClearStyle(BlueStyle);

                range.SetStyle(GreenStyle, @"(\W|^)(" + string.Join("|", ModPe.namespaces) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(GrayStyle, @"(\W|^)(" + string.Join("|", ModPe.hooks) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(BrownStyle, @"(\W|^)(" + string.Join("|", ModPe.global) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(BlueStyle, @"(\W|^)(" + string.Join("|", ModPe.members) + @")(\W|$)", RegexOptions.Multiline);
            }
        }
    }
}