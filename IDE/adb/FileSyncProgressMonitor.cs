using Managed.Adb;

namespace NIDE.adb
{
    internal class FileSyncProgressMonitor : ISyncProgressMonitor
    {
        private const int FILE_WORK = 100;
        private int count;

        private int currentTotal;
        private int currentCount = -1;

        public FileSyncProgressMonitor(int count)
        {
            this.count = count;
            ProgramData.MainForm.StartProgress(count * FILE_WORK);
        }
        

        public bool IsCanceled => false;

        public void Advance(long work)
        {
            ProgramData.MainForm.Progress(FILE_WORK * ((int) work / currentTotal + currentCount));
        }

        public void Start(long totalWork)
        {
            currentTotal = (int)totalWork;
            currentCount++;
        }

        public void StartSubTask(string source, string destination)
        {
            
        }

        public void Stop()
        {
            
        }
    }
}
