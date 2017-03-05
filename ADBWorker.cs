using Managed.Adb;
using System;
using System.Collections.Generic;
using System.IO;

namespace NIDE
{
    static class ADBWorker
    {
        public static string Path { get; set; }

        public static void Push(string file)
        {
            FileInfo local = new FileInfo(file);

            try
            {
                Device device = GetFirstDevice();
                using (SyncService sync = device.SyncService)
                {
                    SyncResult result = sync.PushFile(local.FullName, Path + local.Name, new FileSyncProgressMonitor());
                }
            }
            catch(Exception e){
                ProgramData.MainForm.Log("ADB", e.Message);
            }
        }

        private static Device GetFirstDevice()
        {
            var adb = AndroidDebugBridge.CreateBridge(Directory.GetCurrentDirectory() + "\\ADB\\adb.exe", true);
            List<Device> devices = (List<Device>)adb.Devices;
            if (devices.Count < 1)
            {
                ProgramData.MainForm.Log("ADB", "Connect your device and retry!");
                throw new Exception();
            }
            return devices[0];
        }
    }

    internal class FileSyncProgressMonitor : ISyncProgressMonitor
    {
        public bool IsCanceled => false;

        public void Advance(long work)
        {
            
        }

        public void Start(long totalWork)
        {
            
        }

        public void StartSubTask(string source, string destination)
        {
            
        }

        public void Stop()
        {
            ProgramData.MainForm.Log("ADB", "Successfully pushed file to remote device");
        }
    }
}
