using Microsoft.Win32;
using NIDE.ProjectTypes;
using NIDE.adb;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NIDE
{
    static class RegisterWorker
    {

        static Dictionary<string, string> defaults = new Dictionary<string, string>()
        {
            {"maximized", "False" },
            {"width", "1000" },
            {"height", "600" },
            {"dvWidth", "220" },
            {"dvHeight", "295" },
            {"LoadLast", "True" },
            {"RunProgram", "True" },
            {"ADBPath.ModPE", "/storage/emulated/0/!Nide/" },
            {"ADBPath.CoreEngine", "/storage/emulated/0/games/com.mojang/mods/" },
            {"saves", "0" },
            {"Last", "" }
        };

        public static void Save(fMain sender, bool Last = true)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                key = key.CreateSubKey("NIDE");
                key = key.CreateSubKey("settings");
                key.SetValue("maximized", sender.WindowState == FormWindowState.Maximized);
                key.SetValue("width", sender.Width.ToString());
                key.SetValue("height", sender.Height.ToString());
                key.SetValue("dvWidth", sender.TextViewWidth.ToString());
                key.SetValue("dvHeight", sender.TextViewHeight.ToString());
                key.SetValue("ADBPath.ModPE", ModPE.ADBPath);
                key.SetValue("ADBPath.CoreEngine", CoreEngine.ADBPath);
                key.SetValue("LoadLast", ProgramData.LoadLast);
                key.SetValue("RunProgram", ADBWorker.RunProgram);

                if (ProgramData.Project != null && !ProgramData.Restart)
                {
                    key.SetValue("Last", ProgramData.Project.Nproj);
                }
                else
                {
                    key.SetValue("Last", "");
                }
                AddRecent();
                key.SetValue("saves", ProgramData.Recent.Count);
                for (int i = 0; i < ProgramData.Recent.Count(); i++)
                    key.SetValue("Save" + i, ProgramData.Recent[i]);

                key = key.CreateSubKey("colors");
                key.SetValue("NormalStyle", ProgramData.MainForm.fctbMain.ForeColor.ToArgb().ToString());
                key.SetValue("NamespaceStyle", Highlighting.NamespaceColor.ToArgb().ToString());
                key.SetValue("GlobalStyle", Highlighting.GlobalColor.ToArgb().ToString());
                key.SetValue("HookStyle", Highlighting.HookColor.ToArgb().ToString());
                key.SetValue("MemberStyle", Highlighting.MemberColor.ToArgb().ToString());
                key.SetValue("BackStyle", ProgramData.MainForm.fctbMain.BackColor.ToArgb().ToString());
                if (Highlighting.NumbersColor != null)
                    key.SetValue("NumberStyle", Highlighting.NumbersColor.Value.ToArgb().ToString());
                if (Highlighting.StringsColor != null)
                    key.SetValue("StringStyle", Highlighting.StringsColor.Value.ToArgb().ToString());
                if (Highlighting.KeywordsColor != null)
                    key.SetValue("KeywordStyle", Highlighting.KeywordsColor.Value.ToArgb().ToString());

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
                    throw new Exception("You have to install NIDE to use it correctly!");
                }
                key = key.OpenSubKey("NIDE", true);
                if (!File.Exists(Directory.GetCurrentDirectory() + "\\NIDE.exe"))
                    Directory.SetCurrentDirectory(key.GetValue("InstallPath").ToString());

                if (!key.GetValueNames().Contains("version"))
                {
                    string path = key.GetValue("InstallPath").ToString();
                    key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);

                    key.DeleteSubKeyTree("NIDE");
                    key = key.CreateSubKey("NIDE");

                    key.SetValue("InstallPath", path);
                    key.SetValue("version", ProgramData.PROGRAM_VERSION.ToString());
                    UpdateSettings(key);
                    
                }
                else if(Convert.ToInt32(key.GetValue("version")) < ProgramData.PROGRAM_VERSION)
                {
                    UpdateSettings(key);
                    key.SetValue("version", ProgramData.PROGRAM_VERSION);
                }

                key = key.OpenSubKey("settings");
                sender.Width = Convert.ToInt32(key.GetValue("width"));
                sender.Height = Convert.ToInt32(key.GetValue("height"));
                sender.TextViewWidth = Convert.ToInt32(key.GetValue("dvWidth"));
                sender.TextViewHeight = Convert.ToInt32(key.GetValue("dvHeight"));
                CoreEngine.ADBPath = key.GetValue("ADBPath.CoreEngine").ToString();
                ModPE.ADBPath = key.GetValue("ADBPath.ModPE").ToString();
                ADBWorker.RunProgram = Convert.ToBoolean(key.GetValue("RunProgram"));
                ProgramData.LoadLast = Convert.ToBoolean(key.GetValue("LoadLast"));
                sender.WindowState = Convert.ToBoolean(key.GetValue("maximized")) ? FormWindowState.Maximized : FormWindowState.Normal;
                int count = Convert.ToInt32(key.GetValue("saves"));
                for (int i = 0; i < count; i++)
                    ProgramData.Recent.Add(Convert.ToString(key.GetValue("Save" + i)));
                ProgramData.Last = key.GetValue("Last").ToString();

                if (!key.GetSubKeyNames().Contains("colors"))
                    return;

                key = key.OpenSubKey("colors");
                ProgramData.MainForm.fctbMain.ForeColor = Color.FromArgb(Convert.ToInt32(key.GetValue("NormalStyle")));
                Highlighting.NamespaceColor = Color.FromArgb(Convert.ToInt32(key.GetValue("NamespaceStyle")));
                Highlighting.GlobalColor = Color.FromArgb(Convert.ToInt32(key.GetValue("GlobalStyle")));
                Highlighting.HookColor = Color.FromArgb(Convert.ToInt32(key.GetValue("HookStyle")));
                Highlighting.MemberColor = Color.FromArgb(Convert.ToInt32(key.GetValue("MemberStyle")));
                ProgramData.MainForm.fctbMain.BackColor = Color.FromArgb(Convert.ToInt32(key.GetValue("BackStyle")));
                if (key.GetValueNames().Contains("NumberStyle"))
                    Highlighting.NumbersColor = Color.FromArgb(Convert.ToInt32(key.GetValue("NumberStyle")));
                if (key.GetValueNames().Contains("StringStyle"))
                    Highlighting.StringsColor = Color.FromArgb(Convert.ToInt32(key.GetValue("StringStyle")));
                if (key.GetValueNames().Contains("KeywordStyle"))
                    Highlighting.KeywordsColor = Color.FromArgb(Convert.ToInt32(key.GetValue("KeywordStyle")));
                Highlighting.RefreshStyles();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cannot load window properties");
            }
        }

        private static void UpdateSettings(RegistryKey key)
        {
            key = key.CreateSubKey("settings");
            foreach(var def in defaults)
            {
                if (!key.GetValueNames().Contains(def.Key))
                    key.SetValue(def.Key, def.Value);
            }

        }

        public static void AddRecent()
        {
            if (ProgramData.Project != null)
            {
                string path = ProgramData.Project.Nproj;
                if (ProgramData.Recent.Contains(path))
                    ProgramData.Recent.Remove(path);
                ProgramData.Recent.Insert(0, path);
            }
        }
    }
}
