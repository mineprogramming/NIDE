using Managed.Adb;
using Managed.Adb.Logs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NIDE.adb
{
    static class ADBWorker
    {
        private static AndroidDebugBridge adb = null;

        public static bool RunProgram { get; set; }
        
        public static void Push(DirectoryInfo directory)
        {
           
            try
            {
                var device = InitializeADB();
                using (SyncService sync = device.SyncService)
                {
                    ProgramData.Log("ADB", "Starting copying files.......");
                    PushRecursive(sync, device, directory, ProgramData.Project.Name + "/");
                    sync.Close();
                    ProgramData.MainForm.ProgressBarStatus.Visible = false;
                    ProgramData.Log("ADB", "Successfully pushed file(s) to remote device");
                }
                if (RunProgram)
                {
                    ConsoleOutputReceiver receiver = new ConsoleOutputReceiver();
                    device.ExecuteShellCommand("am force-stop " + ProgramData.Project.ProgramPackage, receiver);
                    device.ExecuteShellCommand("monkey -p " + ProgramData.Project.ProgramPackage + " 1", receiver);
                    ProgramData.Log("ADB", "Restarted package " + ProgramData.Project.ProgramPackage);
                    InitLogging(device);
                }
            }
            catch(Exception e){
                ProgramData.Log("ADB", e.Message);
                if (adb != null)
                    adb.Stop();
                ProgramData.MainForm.ProgressBarStatus.Visible = false;
            }
        }

        public static void Kill()
        {
            if (adb != null)
                adb.Stop();
        }

        public static void StartLog()
        {
            var device = InitializeADB();
            InitLogging(device);
        }

        private static void InitLogging(Device device)
        {
            Task task = new Task(() => {
                try
                {
                    OutputLogReceiver creciever = new OutputLogReceiver();
                    device.ExecuteRootShellCommand("logcat", creciever);
                }
                catch (Exception e) {
                    ProgramData.Log("ADB", "Error: " + e.Message);
                }
            });
            task.Start();
        }

        private static Device InitializeADB()
        {
            Kill();
            ProgramData.Log("ADB", "Initializing ADB.......");
            adb = AndroidDebugBridge.CreateBridge(Directory.GetCurrentDirectory() + "\\ADB\\adb.exe", true);
            List<Device> devices = (List<Device>)adb.Devices;
            if (devices.Count < 1)
            {
                throw new Exception("Connect your device and retry!");
            }
            return devices[0];
        }

        private static void PushRecursive(SyncService sync, Device device, DirectoryInfo directory, string subdir)
        {
            List<string> files = directory.GetFiles().Select(x => x.FullName).ToList();
            sync.Push(files, FileEntry.FindOrCreate(device, ProgramData.Project.ADBPushPath + subdir), new FileSyncProgressMonitor());
            foreach (var dir in directory.GetDirectories())
                PushRecursive(sync, device, dir, subdir + dir.Name + "/");
            
        }
    }
}
