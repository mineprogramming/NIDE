using Managed.Adb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NIDE.adb
{
    static class ADBWorker
    {
        private static AndroidDebugBridge adb = null;
        private static OutputLogReceiver creciever = null;

        public static bool RunProgram { get; set; }

        public static void Push(List<string> files, string basedir, string subdir = "")
        {
            Task task = new Task(() =>
            {
                try
                {
                    StopLog();
                    var device = GetDevice();
                    using (SyncService sync = device.SyncService)
                    {
                        ProgramData.Log("ADB", "Starting copying files.......");
                        PushFiles(files, basedir, ProgramData.Project.Name + "/" + subdir, sync);
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
                }
                catch (Exception e)
                {
                    ProgramData.Log("ADB", e.Message);
                    if (adb != null)
                        adb.Stop();
                    ProgramData.MainForm.StopProgress();
                }
            });
            task.Start();
        }

        public static void Push(DirectoryInfo directory, string subdir = "")
        {
            var files = new List<string>();
            foreach(string file in Util.GetFileList(directory))
            {
                if (!file.Contains(".git"))
                {
                    files.Add(file);
                }
            }
            Push(files, directory.FullName, subdir);
        }

        public static void Kill()
        {
            try
            {
                AdbHelper.Instance.KillAdb(AndroidDebugBridge.SocketAddress);
            } catch
            {
                adb = null;
            }
        }

        public static void StartLog()
        {
            Task task = new Task(() =>
            {
                try
                {
                    StopLog();
                    var device = GetDevice();
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
            Task task = new Task(() =>
            {
                try
                {
                    creciever = new OutputLogReceiver();
                    ProgramData.Log("ADB", "Logging initialized");
                    device.ExecuteShellCommand("logcat", creciever);
                }
                catch (Exception e)
                {
                    ProgramData.Log("ADB", "Error: " + e.Message);
                }
            });
            task.Start();
        }

        private static Device GetDevice()
        {
            if (adb == null || !adb.IsConnected)
            {
                ProgramData.Log("ADB", "Initializing ADB.......");
                adb = AndroidDebugBridge.CreateBridge(Directory.GetCurrentDirectory() + "\\ADB\\adb.exe", true);
                adb.Start();
            }
            List<Device> devices = (List<Device>)adb.Devices;
            if (devices.Count < 1)
                throw new Exception("Connect your device and retry!");
            FChooseDevice form = new FChooseDevice();
            if (form.ShowDialog(devices) == DialogResult.OK)
                return FChooseDevice.Device;
            else
                throw new Exception("Choose device and retry!");
        }

        private static void PushFiles(List<string> files, string localBasedir, string remoteBasedir, SyncService sync)
        {
            var monitor = new FileSyncProgressMonitor(files.Count);
            foreach (string file in files)
            {
                string relative = file.Substring(localBasedir.Length).TrimStart('\\').Replace('\\', '/');
                ProgramData.Log("ADB", "Pushing: " + relative);
                string remotePath = ProgramData.Project.ADBPushPath + remoteBasedir + relative;
                sync.PushFile(file, remotePath, monitor);
            }
        }
    }
}
