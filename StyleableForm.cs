using FastColoredTextBoxNS;
using System.Drawing;
using System.Windows.Forms;

namespace NIDE
{
    public class StyleableForm : Form
    {
        public Control.ControlCollection FormControls => Controls;

        protected void Style()
        {
            foreach(Control ctrl in Controls)
            {
                SetStyle(ctrl);
            }
        }

        private void SetStyle(Control ctrl)
        {
            ctrl.BackColor = SystemColors.WindowText;
            ctrl.ForeColor = Color.Wheat;
            if(ctrl is FastColoredTextBox)
            {
                (ctrl as FastColoredTextBox).PaddingBackColor = SystemColors.ControlDark;
            }
            if(ctrl.Controls.Count > 0)
            {
                foreach(Control control in ctrl.Controls)
                {
                    SetStyle(control);
                }
            }
        }
    }
}
