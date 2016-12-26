using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ModPE_editor
{
    static class CodeAnalysisEngine
    {
        static FastColoredTextBox fctb;
        public static List<string> Variables = new List<string>();

        public static void Initialize(FastColoredTextBox fctb)
        {
            CodeAnalysisEngine.fctb = fctb;
        }

        public static void Update()
        {
            Variables.Clear();
            Regex regex = new Regex(@"\b(var)\s+(?<range>[\w_]+?)\b");
            foreach (Match match in regex.Matches(fctb.Text))
            {
                string variable = match.Value.Split(' ')[1];
                if (!Variables.Contains(variable))
                    Variables.Add(match.Value.Split(' ')[1]);
            }
            regex = new Regex(@"\bfunction\b");
            foreach (var line in fctb.Lines)
            {
                if (regex.IsMatch(line) && line.IndexOf('(') != -1 && line.IndexOf(')') != -1)
                {
                    string params_line = line.Split('(')[1].Split(')')[0];
                    foreach (var param in params_line.Split(','))
                        Variables.Add(param.Trim());
                }
            }
        }
    }
}
