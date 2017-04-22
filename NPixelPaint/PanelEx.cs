using System.Windows.Forms;

namespace NPixelPaint
{
    public partial class PanelEx : Panel
    {
        public PanelEx()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ResizeRedraw = true;
        }
    }
}
