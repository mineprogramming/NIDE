﻿using FastColoredTextBoxNS;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ModPE_editor
{
    static class Highlighting
    {
        public static Color NamespaceColor = Color.Green;
        public static Color HookColor = Color.Gray;
        public static Color GlobalColor = Color.Brown;
        public static Color MemberColor = Color.LightSkyBlue;

        static Style NamespaceStyle = new TextStyle(new SolidBrush(NamespaceColor), null, FontStyle.Bold);
        static Style HookStyle = new TextStyle(new SolidBrush(HookColor), null, FontStyle.Bold);
        static Style GlobalStyle = new TextStyle(new SolidBrush(GlobalColor), null, FontStyle.Regular);
        static Style MemberStyle = new TextStyle(new SolidBrush(MemberColor), null, FontStyle.Italic);

        static Style OldNamespace;
        static Style OldHook;
        static Style OldGlobal;
        static Style OldMember;

        public static void RefreshStyles()
        {
            OldNamespace = NamespaceStyle;
            OldHook = HookStyle;
            OldGlobal = GlobalStyle;
            OldMember = MemberStyle;
            NamespaceStyle = new TextStyle(new SolidBrush(NamespaceColor), null, FontStyle.Bold);
            HookStyle = new TextStyle(new SolidBrush(HookColor), null, FontStyle.Bold);
            GlobalStyle = new TextStyle(new SolidBrush(GlobalColor), null, FontStyle.Regular);
            MemberStyle = new TextStyle(new SolidBrush(MemberColor), null, FontStyle.Italic);
        }

        public static void ResetStyles(Range range)
        {
            if (OldNamespace != null)
                range.ClearStyle(OldNamespace); 
            if(OldHook != null)
                range.ClearStyle(OldHook);
            if (OldGlobal != null)
                range.ClearStyle(OldGlobal);
            if (OldMember != null)
                range.ClearStyle(OldMember);
            if (ProgramData.Mode == WorkMode.CORE_ENGINE)
            {
                range.ClearStyle(NamespaceStyle);
                range.ClearStyle(MemberStyle);

                range.SetStyle(NamespaceStyle, @"(\W|^)(" + string.Join("|", CoreEngine.Items) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(MemberStyle, @"(\W|^)(" + string.Join("|", CoreEngine.members) + @")(\W|$)", RegexOptions.Multiline);
            }
            else
            {
                range.ClearStyle(NamespaceStyle);
                range.ClearStyle(HookStyle);
                range.ClearStyle(GlobalStyle);
                range.ClearStyle(MemberStyle);

                range.SetStyle(NamespaceStyle, @"(\W|^)(" + string.Join("|", ModPe.namespaces) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(HookStyle, @"(\W|^)(" + string.Join("|", ModPe.hooks) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(GlobalStyle, @"(\W|^)(" + string.Join("|", ModPe.global) + @")(\W|$)", RegexOptions.Multiline);
                range.SetStyle(MemberStyle, @"(\W|^)(" + string.Join("|", ModPe.members) + @")(\W|$)", RegexOptions.Multiline);
            }
        }
    }
}