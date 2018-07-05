using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIDE.Languages
{
    static class JavaScript
    {
        public static string[] Items =
        {
            "break", "case", "catch", "const", "continue", "debugger", "default",
            "delete", "do", "else", "finally", "for", "function", "if", "in",
            "instanceof", "let", "new", "return", "switch", "this", "throw",
            "try", "typeof", "var", "void", "while", "with", "undefined"
        };

        public static Dictionary<string, List<string>> Modules = new Dictionary<string, List<string>>() {
            { "Math", new List<string>()
                {
                    "E", "PI", "abs", "acos", "acosh", "asin", "asinh", "atan", "atanh", "atan2",
                    "cbrt", "ceil", "clz32", "cos", "cosh", "exp", "expm1", "floor", "fround",
                    "hypot", "imul", "log", "log1p", "log10", "log2", "max", "min", "pow", "random",
                    "round", "sign", "sin", "sinh", "sqrt", "tan", "tanh", "trunc"
                }
            },
            {
                "JSON", new List<string>()
                {
                    "parse", "stringify"
                }
            },
            {
                "Array", new List<string>()
                {
                    "isArray", "from", "of"
                }
            }
        };
    }
}
