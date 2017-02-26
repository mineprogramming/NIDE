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
        static fMain form;
        public static List<string> Variables = new List<string>();
        static Parser parser;
        static ErrorReporterEx reporter;

        public static void Initialize(fMain form, FastColoredTextBox fctb)
        {
            CodeAnalysisEngine.form = form;
            CodeAnalysisEngine.fctb = fctb;
            reporter = new ErrorReporterEx(form);
            parser = new Parser(new CompilerEnvirons(), reporter);
        }

        public static void Update()
        {
            Thread thread = new Thread(_Update);
            thread.Start();
        }

        private static void _Update()
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
                form.ClearLog();
            }
            catch(Exception e) { }
        }
    }

    class ErrorReporterEx : ErrorReporter
    {
        fMain form;
        int l = -1;

        private delegate void Logs(string source, string message);

        public ErrorReporterEx(fMain form)
        {
            this.form = form;
        }

        public void Clear()
        {
            l = -1;
        } 

        public void Error(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            if (line != l)
            {
                form.Log("CodeAnalysisEngine", message);
                form.HighlightError(line);
                l = line;
            }
        }

        public EcmaScriptRuntimeException RuntimeError(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            return new EcmaScriptRuntimeException("");
        }

        public void Warning(string message, string sourceName, int line, string lineSource, int lineOffset)
        {
            if (line != l)
            {
                form.Log("CodeAnalysisEngine", message);
                form.HighlightError(line);
                l = line;
            }
        }
    }
}
