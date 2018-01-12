using FastColoredTextBoxNS;
using System.Collections.Generic;

namespace NIDE
{
    class DynamicCollection : IEnumerable<AutocompleteItem>
    {
        private AutocompleteMenu menu;
        private FastColoredTextBox tb;

        public DynamicCollection(AutocompleteMenu menu, FastColoredTextBox tb)
        {
            this.menu = menu;
            this.tb = tb;
        }

        public IEnumerator<AutocompleteItem> GetEnumerator()
        {
            var text = menu.Fragment.Text;
            var parts = text.Split('.');
            List<AutocompleteItem> items = new List<AutocompleteItem>();
            foreach (var item in Autocomplete.UserItems.Keys)
                items.Add(new AutocompleteItem(item));
            if (parts.Length < 2)
            {
                items.AddRange(ProgramData.Project.GetDefaultList());
                foreach (var item in CodeAnalysisEngine.Variables)
                    items.Add(new AutocompleteItem(item));
                foreach (var item in items)
                    yield return item;
            }
            else
            {
                var className = parts[parts.Length - 2];
                foreach (var methodName in ProgramData.Project.GetListByClassName(className))
                    items.Add(methodName);
                if (Autocomplete.UserItems.ContainsKey(className))
                    foreach (var methodName in Autocomplete.UserItems[className])
                        items.Add(new MethodAutocompleteItem(methodName));
                if (CodeAnalysisEngine.Objects.ContainsKey(className))
                    foreach (var methodName in CodeAnalysisEngine.Objects[className])
                    {
                        var item = new MethodAutocompleteItem(methodName);
                        if (!items.Contains(item))
                            items.Add(item);
                    }
                foreach (var item in items)
                    yield return item;
            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}