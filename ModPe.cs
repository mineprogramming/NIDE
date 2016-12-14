using System.Collections.Generic;
using System.Linq;
using System.IO;
using FastColoredTextBoxNS;

namespace ModPE_editor
{
    static class ModPe
    {
        public static string[] JSitems =
        {
            "break", "case", "catch", "const", "continue", "debugger", "default",
            "delete", "do", "else", "finally", "for", "function", "if", "in",
            "instanceof", "let", "new", "return", "switch", "this", "throw",
            "try", "typeof", "var", "void", "while", "with", "Math"
        };
        public static List<string> global = new List<string>();
        public static Dictionary<string, List<string>> Members = new Dictionary<string, List<string>>();
        public static List<string> namespaces = new List<string>();
        public static List<string> hooks = new List<string>();
        public static List<string> hooks_autocomplete = new List<string>();

        public static IEnumerable<string> members
        {
            get
            {
                var items = Members.SelectMany(x => x.Value);
                return items;
            }
        }

        public static void LoadModPeData(string path)
        {
            Members.Add("Math", new List<string>()
            {
                "E", "PI", "abs", "acos", "acosh", "asin", "asinh", "atan", "atanh", "atan2",
                "cbrt", "ceil", "clz32", "cos", "cosh", "exp", "expm1", "floor", "fround",
                "hypot", "imul", "log", "log1p", "log10", "log2", "max", "min", "pow", "random",
                "round", "sign", "sin", "sinh", "sqrt", "tan", "tanh", "trunc"
            });
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                if (line.Length == 0 || (line[0] == '/' && line[1] == '/'))
                    continue;
                string[] functions = line.Split(' ');
                if (functions[0] == "function")
                {
                    string hook = "";
                    for (int i = 1; i < functions.Length; i++)
                    {
                        hook += functions[i];
                    }
                    hook += " {\n\n}";
                    string hook_name = hook.Split('(')[0];
                    hooks.Add(hook_name);
                    hooks_autocomplete.Add(hook);
                    continue;
                }
                functions = line.Split('.');
                if (functions.Length < 2)
                {
                    string method_name = line.Split('(')[0];
                    global.Add(method_name);
                    continue;
                }
                if (line.IndexOf('(') == -1)
                {
                    functions[1] = functions[1].Substring(0, functions[1].Length - 1);
                    if (!global.Contains(functions[0]))
                        global.Add(functions[0]);
                    if (Members.ContainsKey(functions[0]))
                        Members[functions[0]].Add(functions[1]);
                    else
                        Members.Add(functions[0], new List<string>() { functions[1] });
                    continue;
                }
                if (!namespaces.Contains(functions[0]))
                    namespaces.Add(functions[0]);
                functions[1] = functions[1].Split('(')[0];
                if (Members.ContainsKey(functions[0]))
                    Members[functions[0]].Add(functions[1]);
                else
                    Members.Add(functions[0], new List<string>() { functions[1] });
            }
        }

        public static List<AutocompleteItem> GetDefaultList()
        {
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            foreach (var item in JSitems)
                items.Add(new AutocompleteItem(item, 0));
            foreach (var item in hooks_autocomplete)
                items.Add(new AutocompleteItem(item, 4, hooks[hooks_autocomplete.IndexOf(item)]));
            foreach (var item in global)
                items.Add(new AutocompleteItem(item, 1));
            foreach (var item in namespaces)
                items.Add(new AutocompleteItem(item, 3));
            return items;
        }

        public static List<AutocompleteItem> GetListByClassName(string className)
        {
            List<string> result;
            if (Members.TryGetValue(className, out result))
            {
                int icon = namespaces.Contains(className)?2:6;
                List<AutocompleteItem> acList = new List<AutocompleteItem>();
                foreach (var item in result)
                {
                    MethodAutocompleteItem it = new MethodAutocompleteItem(item);
                    it.ImageIndex = icon;
                    acList.Add(it);
                }
                return acList;
            }
            else
            {
                return GetDefaultList();
            }
        }
    }
}