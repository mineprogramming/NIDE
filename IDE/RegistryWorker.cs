using Microsoft.Win32;
using NIDE.ProjectTypes;
using NIDE.adb;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NIDE.ProjectTypes.ZCore;

namespace NIDE
{
    static class RegistryWorker
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
            {"Last", "" },
            {"ErrorHighlighting", "False"}
        };

        public static void Save(bool Last = true)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                key = key.CreateSubKey("NIDE");
                key = key.CreateSubKey("settings");
                key.SetValue("maximized", ProgramData.MainForm.WindowState == FormWindowState.Maximized);
                key.SetValue("width", ProgramData.MainForm.Width.ToString());
                key.SetValue("height", ProgramData.MainForm.Height.ToString());
                key.SetValue("dvWidth", ProgramData.MainForm.TextViewWidth.ToString());
                key.SetValue("dvHeight", ProgramData.MainForm.TextViewHeight.ToString());
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
                key.SetValue("NamespaceStyle", Highlighter.NamespaceColor.ToArgb().ToString());
                key.SetValue("GlobalStyle", Highlighter.GlobalColor.ToArgb().ToString());
                key.SetValue("HookStyle", Highlighter.HookColor.ToArgb().ToString());
                key.SetValue("MemberStyle", Highlighter.MemberColor.ToArgb().ToString());
                key.SetValue("BackStyle", ProgramData.MainForm.fctbMain.BackColor.ToArgb().ToString());
                if (Highlighter.NumbersColor != null)
                    key.SetValue("NumberStyle", Highlighter.NumbersColor.Value.ToArgb().ToString());
                if (Highlighter.StringsColor != null)
                    key.SetValue("StringStyle", Highlighter.StringsColor.Value.ToArgb().ToString());
                if (Highlighter.KeywordsColor != null)
                    key.SetValue("KeywordStyle", Highlighter.KeywordsColor.Value.ToArgb().ToString());
                key.SetValue("ErrorHighlighting", Highlighter.ErrorStrategy == ErrorHighlightStrategy.LINE_NUMBER);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cannot save window properties");
            }
        }

        public static void Load()
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
                ProgramData.MainForm.Width = Convert.ToInt32(key.GetValue("width"));
                ProgramData.MainForm.Height = Convert.ToInt32(key.GetValue("height"));
                ProgramData.MainForm.TextViewWidth = Convert.ToInt32(key.GetValue("dvWidth"));
                ProgramData.MainForm.TextViewHeight = Convert.ToInt32(key.GetValue("dvHeight"));
                ZCore.ADBPath = key.GetValue("ADBPath.CoreEngine").ToString();
                ModPE.ADBPath = key.GetValue("ADBPath.ModPE").ToString();
                ADBWorker.RunProgram = Convert.ToBoolean(key.GetValue("RunProgram"));
                ProgramData.LoadLast = Convert.ToBoolean(key.GetValue("LoadLast"));
                ProgramData.MainForm.WindowState = Convert.ToBoolean(key.GetValue("maximized")) ? FormWindowState.Maximized : FormWindowState.Normal;
                int count = Convert.ToInt32(key.GetValue("saves"));
                for (int i = 0; i < count; i++)
                    ProgramData.Recent.Add(Convert.ToString(key.GetValue("Save" + i)));
                ProgramData.Last = key.GetValue("Last").ToString();

                if (!key.GetSubKeyNames().Contains("colors"))
                    return;

                key = key.OpenSubKey("colors");
                //ProgramData.MainForm.fctbMain.ForeColor = Color.FromArgb(Convert.ToInt32(key.GetValue("NormalStyle")));
                Highlighter.NamespaceColor = Color.FromArgb(Convert.ToInt32(key.GetValue("NamespaceStyle")));
                Highlighter.GlobalColor = Color.FromArgb(Convert.ToInt32(key.GetValue("GlobalStyle")));
                Highlighter.HookColor = Color.FromArgb(Convert.ToInt32(key.GetValue("HookStyle")));
                Highlighter.MemberColor = Color.FromArgb(Convert.ToInt32(key.GetValue("MemberStyle")));
                //ProgramData.MainForm.fctbMain.BackColor = Color.FromArgb(Convert.ToInt32(key.GetValue("BackStyle")));
                if (key.GetValueNames().Contains("NumberStyle"))
                    Highlighter.NumbersColor = Color.FromArgb(Convert.ToInt32(key.GetValue("NumberStyle")));
                if (key.GetValueNames().Contains("StringStyle"))
                    Highlighter.StringsColor = Color.FromArgb(Convert.ToInt32(key.GetValue("StringStyle")));
                if (key.GetValueNames().Contains("KeywordStyle"))
                    Highlighter.KeywordsColor = Color.FromArgb(Convert.ToInt32(key.GetValue("KeywordStyle")));
                Highlighter.ErrorStrategy = Convert.ToBoolean(key.GetValue("ErrorHighlighting")) ? 
                    ErrorHighlightStrategy.LINE_NUMBER : ErrorHighlightStrategy.UNDERLINE;
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
