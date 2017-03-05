
using System.Drawing;
using System.Windows.Forms;

namespace NIDE
{
    static class Styler
    {
        public static void Style(StyleableForm form, bool dark = false)
        {
            foreach (var control in form.FormControls)
            {
                if (dark)
                {
                    if(control is MenuStrip)
                    {
                        MenuStrip ctrl = control as MenuStrip;
                        ctrl.BackColor = Color.Black;
                        ctrl.ForeColor = Color.Wheat;
                    }
                    else if(control is ToolStripContainer)
                    {
                        ToolStripContainer ctrl = control as ToolStripContainer;
                        ctrl.TopToolStripPanel.BackColor = Color.DarkGray;
                    }
                    else if(control is ToolStrip)
                    {
                        ToolStrip ctrl = control as ToolStrip;
                    }
                }
                else
                {

                }
            }
        }
    }
}
