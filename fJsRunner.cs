using Noesis.Javascript;
using System.Windows.Forms;

namespace NIDE
{
    public partial class fJsRunner : Form
    {
        public delegate void Log(object iString);

        public fJsRunner(string code)
        {
            InitializeComponent();
            log("Running code...");
            using (JavascriptContext context = new JavascriptContext())
            {
                Log print = log;
                context.SetParameter("print", print);
                context.SetParameter("clientMessage", print);
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

        private void log(object iString)
        {
            tbLog.AppendText(iString.ToString() + "\n");
        }
    }
}
