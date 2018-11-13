using NIDE.ProjectTypes.MCPEModding.ZCore;
using Noesis.Javascript;

namespace NIDE
{
    public class JsRunner
    {
        public delegate void Log(object iString);

        public JsRunner(string code)
        {
            log("Running code...");
            using (JavascriptContext context = new JavascriptContext())
            {
                Log print = log;
                try
                {
                    context.Run(ZCore.JavaScriptAPI);

                    context.SetParameter("print", print);
                    context.SetParameter("clientMessage", print);
                    context.SetParameter("alert", print);

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
            ProgramData.Log("JsRunner", iString.ToString(), ProgramData.LOG_STYLE_NORMAL);
        }
    }
}
