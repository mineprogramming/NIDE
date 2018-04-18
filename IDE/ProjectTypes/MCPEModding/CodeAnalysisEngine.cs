using System.Collections.Generic;
using System.Text.RegularExpressions;
using EcmaScript.NET;
using System.Threading;
using NIDE.Editors;

namespace NIDE.ProjectTypes.MCPEModding
{
    static class CodeAnalysisEngine
    {
        public static List<string> Variables = new List<string>();
        public static Dictionary<string, List<string>> Objects = new Dictionary<string, List<string>>();
        static Thread updateThread;

        static Parser parser;
        static ErrorReporterEx reporter;

        static bool shouldUpdate = false;

        static CodeAnalysisEngine()
        {
            reporter = new ErrorReporterEx();
            parser = new Parser(new CompilerEnvirons(), reporter);
        }

        public static void Update(CodeEditor editor)
        {
            if (updateThread == null || !updateThread.IsAlive)
            {
                updateThread = new Thread(() => _Update(editor));
                updateThread.IsBackground = true;
                updateThread.Start();
            }
            else shouldUpdate = true;
        }

        public static void Stop()
        {
            if (updateThread != null)
                updateThread.Abort();
            ProgramData.MainForm?.ClearErrors();
        }

        private static void _Update(CodeEditor editor)
        {
            try
            {
                try
                {
                    reporter.SetOut(editor.Errors);
                    reporter.Clear();
                    ProgramData.MainForm?.ClearErrors();
                    string text = editor.TextBox.Text;
                    Regex reg = new Regex(@"\b(const|let)\b");
                    text = reg.Replace(text, " var ");
                    reg = new Regex(@"(class|super|extends|implements|abstract|final|static|public|private)");
                    text = reg.Replace(text, "kek");
                    parser.Parse(text, "", 0);
                }
                catch { }

                List<string> variables = new List<string>();
                Dictionary<string, List<string>> objects = new Dictionary<string, List<string>>();
                Regex regex = new Regex(@"\b(var|const|let)\s+(?<range>[\w_]+?)\b");
                foreach (Match match in regex.Matches(ProgramData.MainForm.fctbMain.Text))
                {
                    if (match.Value.Split(' ').Length > 1)
                    {
                        string variable = match.Value.Split(' ')[1];
                        if (!variables.Contains(variable))
                            variables.Add(variable);
                    }
                }
                regex = new Regex(@"\bfunction\b");
                foreach (var line in ProgramData.MainForm.fctbMain.Lines)
                {
                    if (regex.IsMatch(line) && line.IndexOf('(') != -1 && line.IndexOf(')') != -1)
                    {
                        try
                        {
                            string params_line = line.Split('(')[1].Split(')')[0];
                            string function_line = line.Split('(')[0].Split()[1];
                            foreach (var param in params_line.Split(','))
                                variables.Add(param.Trim());
                            if (!ModPE.hooks.Contains(function_line))
                                variables.Add(function_line);
                        }
                        catch { }
                    }
                }
                Variables = variables;
                regex = new Regex(@"([\w_]+)\.([\w_]+)");
                foreach (Match match in regex.Matches(ProgramData.MainForm.fctbMain.Text))
                {
                    string[] splitted = match.Value.Split('.');
                    if (!objects.ContainsKey(splitted[0]))
                        objects.Add(splitted[0], new List<string>());
                    if (!objects[splitted[0]].Contains(splitted[1]))
                        objects[splitted[0]].Add(splitted[1]);
                }
                Objects = objects;
            }
            catch { }
            if (shouldUpdate)
            {
                shouldUpdate = false;
                _Update(editor);
            }
        }
    }

    class ErrorReporterEx : ErrorReporter
    {
        List<int> lines;

        private delegate void Logs(string source, string message);

        public void SetOut(List<int> outLines)
        {
            lines = outLines;
        }

        public void Clear()
        {
            lines.Clear();
        }

        public void Error(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            if (!lines.Contains(line))
            {
                ProgramData.Error(line, message);
                ProgramData.MainForm?.HighlightError(line);
                lines.Add(line);
            }
        }

        public EcmaScriptRuntimeException RuntimeError(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            return new EcmaScriptRuntimeException("");
        }

        public void Warning(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            if (!lines.Contains(line))
            {
                ProgramData.Error(line, message);
                ProgramData.MainForm?.HighlightError(line);
                lines.Add(line);
            }
        }
    }
}
