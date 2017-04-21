using Managed.Adb;
using System;
using System.Collections.Generic;
using System.IO;

namespace NIDE
{
    static class ADBWorker
    {
        public static string Path { get; set; }

        public static void Push(string script, string resource)
        {
            FileInfo local = new FileInfo(script);
            FileInfo res = new FileInfo(resource);
            AndroidDebugBridge adb = null;
            try
            {
                adb = AndroidDebugBridge.CreateBridge(Directory.GetCurrentDirectory() + "\\ADB\\adb.exe", true);
                List<Device> devices = (List<Device>)adb.Devices;
                if (devices.Count < 1)
                {
                    ProgramData.Log("ADB", "Connect your device and retry!");
                    throw new Exception();
                }
                var device = devices[0];
                using (SyncService sync = device.SyncService)
                {
                    SyncResult result = sync.Push(new List<string> { local.FullName, res.FullName }, 
                        FileEntry.FindOrCreate(device, Path),  new FileSyncProgressMonitor());
                    sync.Close();
                }
                adb.Stop();

            }
            catch(Exception e){
                ProgramData.Log("ADB", e.Message);
                if (adb != null)
                    adb.Stop();
            }
        }
    }

    internal class FileSyncProgressMonitor : ISyncProgressMonitor
    {
        public bool IsCanceled => false;

        public void Advance(long work)
        {
            ProgramData.MainForm.ProgressBarStatus.Value = (int)work;
        }

        public void Start(long totalWork)
        {
            ProgramData.MainForm.ProgressBarStatus.Visible = true;
            ProgramData.MainForm.ProgressBarStatus.Maximum = (int)totalWork;
        }

        public void StartSubTask(string source, string destination)
        {
            
        }

        public void Stop()
        {
            ProgramData.MainForm.ProgressBarStatus.Visible = false;
            ProgramData.Log("ADB", "Successfully pushed file to remote device");
        }
    }
}
