using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using EcmaScript.NET;
using System.Threading;
using System;

namespace NIDE
{
    static class CodeAnalysisEngine
    {
        static FastColoredTextBox fctb;
        public static List<string> Variables = new List<string>();
        static Parser parser;
        static ErrorReporterEx reporter;

        public static void Initialize(FastColoredTextBox fctb)
        {
            CodeAnalysisEngine.fctb = fctb;
            reporter = new ErrorReporterEx();
            parser = new Parser(new CompilerEnvirons(), reporter);
        }

        public static void Update()
        {
            Thread thread = new Thread(_Update);
            thread.Start();
        }

        private static void _Update()
        {
            try
            {
                List<string> variables = new List<string>();
                Regex regex = new Regex(@"\b(var)\s+(?<range>[\w_]+?)\b");
                foreach (Match match in regex.Matches(fctb.Text))
                {
                    if (match.Value.Split(' ').Length > 1)
                    {
                        string variable = match.Value.Split(' ')[1];
                        if (!variables.Contains(variable))
                            variables.Add(variable);
                    }
                }
                regex = new Regex(@"\bfunction\b");
                foreach (var line in fctb.Lines)
                {
                    if (regex.IsMatch(line) && line.IndexOf('(') != -1 && line.IndexOf(')') != -1)
                    {
                        try
                        {
                            string params_line = line.Split('(')[1].Split(')')[0];
                            string function_line = line.Split('(')[0].Split()[1];
                            foreach (var param in params_line.Split(','))
                                variables.Add(param.Trim());
                            if (!ModPe.hooks.Contains(function_line))
                                variables.Add(function_line);
                        }
                        catch { }
                    }
                }
                Variables = variables;
                try
                {
                    parser.Parse(fctb.Text, "", 0);
                    reporter.Clear();
                    ProgramData.MainForm?.ClearLog();
                }
                catch (Exception e) { }
            }
            catch { }
        }
    }

    class ErrorReporterEx : ErrorReporter
    {
        List<int> lines = new List<int>();

        private delegate void Logs(string source, string message);
        
        public void Clear()
        {
            lines.Clear();
        }

        public void Error(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            if (!lines.Contains(line))
            {
                ProgramData.MainForm?.Log("CodeAnalysisEngine", "Line " + line + ": " + message);
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
                ProgramData.MainForm?.Log("CodeAnalysisEngine", message);
                ProgramData.MainForm?.HighlightError(line);
                lines.Add(line);
            }
        }
    }
}
