using Managed.Adb;

namespace NIDE.adb
{
    internal class FileSyncProgressMonitor : ISyncProgressMonitor
    {
        public bool IsCanceled => false;

        public void Advance(long work)
        {
            ProgramData.MainForm.Progress((int)work);
        }

        public void Start(long totalWork)
        {
            ProgramData.MainForm.StartProgress((int)totalWork);
        }

        public void StartSubTask(string source, string destination)
        {
            
        }

        public void Stop()
        {
            
        }
    }
}
