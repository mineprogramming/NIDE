using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NIDE
{
    static class RegisterWorker
    {
        public static void Save(fMain sender, bool Last = true)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                key = key.CreateSubKey("NIDE");
                key = key.CreateSubKey("settings");
                key.SetValue("maximized", sender.WindowState == FormWindowState.Maximized);
                key.SetValue("Width", sender.Width.ToString());
                key.SetValue("Height", sender.Height.ToString());
                key.SetValue("dvWidth", sender.TextViewWidth.ToString());
                key.SetValue("dvHeight", sender.TextViewHeight.ToString());
                key.SetValue("ADBPath", ADBWorker.Path);
                key.SetValue("LoadLast", ProgramData.LoadLast);

                key.SetValue("NormalStyle", ProgramData.MainForm.fctbMain.ForeColor.ToArgb().ToString());
                key.SetValue("NamespaceStyle", Highlighting.NamespaceColor.ToArgb().ToString());
                key.SetValue("GlobalStyle", Highlighting.GlobalColor.ToArgb().ToString());
                key.SetValue("HookStyle", Highlighting.HookColor.ToArgb().ToString());
                key.SetValue("MemberStyle", Highlighting.MemberColor.ToArgb().ToString());
                key.SetValue("BackStyle", ProgramData.MainForm.fctbMain.BackColor.ToArgb().ToString());

                if (ProgramData.ProjectManager != null && !ProgramData.Restart)
                {
                    key.SetValue("Last", ProgramData.ProjectManager.ProjectFilePath);
                }
                else {
                    key.SetValue("Last", "");
                }
                AddRecent();
                key.SetValue("Saves", ProgramData.Recent.Count);
                for (int i = 0; i < ProgramData.Recent.Count(); i++)
                    key.SetValue("Save" + i, ProgramData.Recent[i]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cannot save window properties");
            }
        }

        public static void Load(fMain sender)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                if (!key.GetSubKeyNames().Contains("NIDE"))
                {
                    ADBWorker.Path = "/storage/emulated/0/!Nide/scripts/";
                    return;
                }
                key = key.OpenSubKey("NIDE");
                if (!File.Exists(Directory.GetCurrentDirectory() + "\\NIDE.exe"))
                    Directory.SetCurrentDirectory(key.GetValue("InstallPath").ToString());
                if (!key.GetSubKeyNames().Contains("settings"))
                {
                    ADBWorker.Path = "/storage/emulated/0/!Nide/scripts/";
                    return;
                }
                key = key.OpenSubKey("settings");
                sender.Width = Convert.ToInt32(key.GetValue("Width"));
                sender.Height = Convert.ToInt32(key.GetValue("Height"));
                sender.TextViewWidth = Convert.ToInt32(key.GetValue("dvWidth"));
                sender.TextViewHeight = Convert.ToInt32(key.GetValue("dvHeight"));
                ADBWorker.Path = key.GetValue("ADBPath").ToString();
                ProgramData.LoadLast = Convert.ToBoolean(key.GetValue("LoadLast"));
                sender.WindowState = Convert.ToBoolean(key.GetValue("maximized")) ? FormWindowState.Maximized : FormWindowState.Normal;
                int count = Convert.ToInt32(key.GetValue("Saves"));
                for (int i = 0; i < count; i++)
                    ProgramData.Recent.Add(Convert.ToString(key.GetValue("Save" + i)));
                ProgramData.Last = key.GetValue("Last").ToString();

                ProgramData.MainForm.fctbMain.ForeColor = Color.FromArgb(Convert.ToInt32(key.GetValue("NormalStyle")));
                Highlighting.NamespaceColor = Color.FromArgb(Convert.ToInt32(key.GetValue("NamespaceStyle")));
                Highlighting.GlobalColor = Color.FromArgb(Convert.ToInt32(key.GetValue("GlobalStyle")));
                Highlighting.HookColor = Color.FromArgb(Convert.ToInt32(key.GetValue("HookStyle")));
                Highlighting.MemberColor = Color.FromArgb(Convert.ToInt32(key.GetValue("MemberStyle")));
                ProgramData.MainForm.fctbMain.BackColor = Color.FromArgb(Convert.ToInt32(key.GetValue("BackStyle")));

                Highlighting.RefreshStyles();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cannot load window properties");
            }
        }

        public static void AddRecent()
        {
            if (ProgramData.ProjectManager != null)
            {
                string path = ProgramData.ProjectManager.ProjectFilePath;
                if (ProgramData.Recent.Contains(path))
                    ProgramData.Recent.Remove(path);
                ProgramData.Recent.Insert(0, path);
            }
        }
    }
}
