using Managed.Adb;
using System.Text;

namespace NIDE.adb
{
    internal class OutputLogReceiver : IShellOutputReceiver
    {
        public bool IsCancelled { get; set; } = false;

        public void AddOutput(byte[] data, int offset, int length)
        {
            string item = Encoding.UTF8.GetString(data);
            string[] items = item.Split('\n');
            foreach (var it in items)
                if (it.Contains("INNERCORE"))
                {
                    string msg = it.Substring(it.IndexOf(':') + 2);
                    ProgramData.Log("InnerCore", msg);
                } else if (it.Contains("MOD-PRINT"))
                {
                    string msg = it.Substring(it.IndexOf(':') + 2);
                    ProgramData.Log("Mod-Print", msg);
                }
        }

        public void Flush()
        {
            
        }
    }
}
