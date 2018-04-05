using System.Collections.ObjectModel;

namespace NIDE.Editors
{
    public abstract class Editor
    {
        public abstract bool Edit();

        protected string file;

        public Editor(string file)
        {
            this.file = file;
            
        }
    }
}
