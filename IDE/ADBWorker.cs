﻿using Managed.Adb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NIDE
{
    static class ADBWorker
    {
        public static bool RunProgram { get; set; }

        public static void Push(DirectoryInfo directory)
        {
            ProgramData.Log("ADB", "Initializing ADB.......");
            AndroidDebugBridge adb = null;
            try
            {
                adb = AndroidDebugBridge.CreateBridge(Directory.GetCurrentDirectory() + "\\ADB\\adb.exe", true);
                List<Device> devices = (List<Device>)adb.Devices;
                if (devices.Count < 1)
                {
                    throw new Exception("Connect your device and retry!");
                }
                var device = devices[0];
                using (SyncService sync = device.SyncService)
                {
                    ProgramData.Log("ADB", "Starting copying files.......");
                    PushRecursive(sync, device, directory);
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
                }
                adb.Stop();
            }
            catch(Exception e){
                ProgramData.Log("ADB", e.Message);
                if (adb != null)
                    adb.Stop();
                ProgramData.MainForm.ProgressBarStatus.Visible = false;
            }
        }

        private static void PushRecursive(SyncService sync, Device device, DirectoryInfo directory, string subdir = "")
        {
            List<string> files = directory.GetFiles().Select(x => x.FullName).ToList();
            sync.Push(files, FileEntry.FindOrCreate(device, ProgramData.Project.ADBPushPath + subdir), new FileSyncProgressMonitor());
            foreach (var dir in directory.GetDirectories())
                PushRecursive(sync, device, dir, subdir + dir.Name + "/");
            
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
            
        }
    }
}
