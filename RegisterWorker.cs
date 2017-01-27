using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Forms;

namespace NIDE
{
    static class RegisterWorker
    {
        public static void Save(fMain sender)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                key = key.CreateSubKey("ModPE");
                key.SetValue("maximized", sender.WindowState == FormWindowState.Maximized);
                key.SetValue("Width", sender.Width.ToString());
                key.SetValue("Height", sender.Height.ToString());
                key.SetValue("dvWidth", sender.TextViewWidth.ToString());
                key.SetValue("NamespaceStyle", Highlighting.NamespaceColor.ToArgb().ToString());
                key.SetValue("GlobalStyle", Highlighting.GlobalColor.ToArgb().ToString());
                key.SetValue("HookStyle", Highlighting.HookColor.ToArgb().ToString());
                key.SetValue("MemberStyle", Highlighting.MemberColor.ToArgb().ToString());
                AddRecent();
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
                if (!key.GetSubKeyNames().Contains("ModPE"))
                    return;
                key = key.OpenSubKey("ModPE");
                sender.Width = Convert.ToInt32(key.GetValue("Width"));
                sender.Height = Convert.ToInt32(key.GetValue("Height"));
                sender.TextViewWidth = Convert.ToInt32(key.GetValue("dvWidth"));
                if (key.GetValueNames().Contains("maximized"))
                    sender.WindowState = Convert.ToBoolean(key.GetValue("maximized")) ? FormWindowState.Maximized : FormWindowState.Normal;
                for (int i = 0; i < ProgramData.Recent.Count(); i++)
                    ProgramData.Recent[i] = Convert.ToString(key.GetValue("Save" + i));
                if (key.GetValueNames().Contains("NamespaceStyle"))
                {
                    Highlighting.NamespaceColor = System.Drawing.Color.FromArgb(Convert.ToInt32(key.GetValue("NamespaceStyle")));
                    Highlighting.GlobalColor = System.Drawing.Color.FromArgb(Convert.ToInt32(key.GetValue("GlobalStyle")));
                    Highlighting.HookColor = System.Drawing.Color.FromArgb(Convert.ToInt32(key.GetValue("HookStyle")));
                    Highlighting.MemberColor = System.Drawing.Color.FromArgb(Convert.ToInt32(key.GetValue("MemberStyle")));
                    Highlighting.RefreshStyles();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cannot load window properties");
            }
        }

        public static void AddRecent()
        {
            string path = ProgramData.Mode == WorkMode.JAVASCRIPT ? ProgramData.File : ProgramData.Folder;
            if (ProgramData.File != "" && !ProgramData.Recent.Contains(path))
            {
                for (int i = ProgramData.Recent.Count() - 1; i > 0; i--)
                    ProgramData.Recent[i] = ProgramData.Recent[i - 1];
                ProgramData.Recent[0] = path;
            }
            else if (ProgramData.File != "")
            {
                for (int i = 0; i < Array.IndexOf(ProgramData.Recent, path); i++)
                    ProgramData.Recent[i + 1] = ProgramData.Recent[i];
                ProgramData.Recent[0] = path;
            }
        }
    }
}
