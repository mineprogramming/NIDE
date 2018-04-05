using System.Windows.Forms;
using NIDE.Editors;

namespace NIDE.ProjectTypes.ZCore
{
    class ModInfoEditor : FormEditor
    {
        public override Form Form { get; }

        public ModInfoEditor(string file) : base(file)
        {
            Form = new FModInfo(file);
        }

        public override bool Edit()
        {
            if (Form.ShowDialog() == DialogResult.OK)
                return true;
            else return false;
        }
    }
}
