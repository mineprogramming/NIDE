using System.Windows.Forms;

namespace NIDE.Editors
{
    abstract class FormEditor: Editor
    {
        public abstract Form Form { get; }

        public FormEditor(string file) : base(file)
        {

        }
    }
}
