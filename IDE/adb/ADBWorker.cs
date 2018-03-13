using Managed.Adb;
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
        private static OutputLogReceiver creciever = null;

        public static bool RunProgram { get; set; }
        
        public static void Push(DirectoryInfo directory)
        {
            try
            {
                Task task = new Task(() => {
                    StopLog();
                    var device = GetFirstDevice();
                    using (SyncService sync = device.SyncService)
                    {
                        ProgramData.Log("ADB", "Starting copying files.......");
                        PushRecursive(sync, device, directory, ProgramData.Project.Name + "/");
                        sync.Close();
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
                    ProgramData.MainForm.StopProgress();
                });
                task.Start();
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
            AdbHelper.Instance.KillAdb(AndroidDebugBridge.SocketAddress);
        }

        public static void StartLog()
        {
            Task task = new Task(() =>
            {
                try
                {
                    var device = GetFirstDevice();
                    InitLogging(device);
                }
                catch (Exception e)
                {
                    ProgramData.Log("ADB", e.Message);
                }
            });
            task.Start();
        }

        public static void StopLog()
        {
            if (creciever != null)
                creciever.IsCancelled = true;
        }

        private static void InitLogging(Device device)
        {
            Task task = new Task(() => {
                try
                {
                    creciever = new OutputLogReceiver();
                    ProgramData.Log("ADB", "Logging initialized");
                    device.ExecuteShellCommand("logcat", creciever);
                }
                catch (Exception e) {
                    ProgramData.Log("ADB", "Error: " + e.Message);
                }
            });
            task.Start();
        }

        private static Device GetFirstDevice()
        {
            if (adb == null || !adb.IsConnected)
            {
                ProgramData.Log("ADB", "Initializing ADB.......");
                adb = AndroidDebugBridge.CreateBridge(Directory.GetCurrentDirectory() + "\\ADB\\adb.exe", true);
                adb.Start();
            }
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
