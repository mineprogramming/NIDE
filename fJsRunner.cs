using Noesis.Javascript;
using System.Windows.Forms;

namespace NIDE
{
    public partial class fJsRunner : Form
    {
        public fJsRunner(string code)
        {
            InitializeComponent();
            log("Running code...");
            MessageBox.Show(code);
            using (JavascriptContext context = new JavascriptContext())
            {
                context.SetParameter("Console", this);
                try
                {
                    context.Run(code);
                }
                catch(JavascriptException e)
                {
                    log(e.Message + "\n");
                }
            }

        }

        public void log(string iString)
        {
            tbLog.AppendText(iString + "\n");
        }
    }
}
