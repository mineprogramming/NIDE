using System.Windows.Forms;

namespace NIDE
{
    public class StyleableForm : Form
    {
        public Control.ControlCollection FormControls => Controls;
    }
}
