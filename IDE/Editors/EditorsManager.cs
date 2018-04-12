using NIDE.ProjectTypes.ZCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace NIDE.Editors
{
    static class EditorsManager
    {
        private static Dictionary<Type, IReadOnlyCollection<string>> editors =
            new Dictionary<Type, IReadOnlyCollection<string>>()
            {
                { typeof(ModInfoEditor), new string[] { ".info" } },
                { typeof(JSCodeEditor), new string[] {".js"} },
                { typeof(IncludesEditor), new string[]{".includes"} }
            };

        public static void RegisterEditor(Type editor, string[] extentions)
        {
            editors.Add(editor, new ReadOnlyCollection<string>(extentions));
        }

        public static Editor GetEditor(string path)
        {
            string extension = System.IO.Path.GetExtension(path);
            foreach (var type in editors)
            {
                if (type.Value.Contains(extension))
                    return (Editor)Activator.CreateInstance(type.Key, path);
            }
            return new DefaultCodeEditor(path);
        }
    }
}
