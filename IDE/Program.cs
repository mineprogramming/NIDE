using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace NIDE
{
    static class Program
    {
        public static fSplashScreen splashForm = null;

        [DllImport("coredll.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread splashThread = new Thread(new ThreadStart(
            delegate
            {
                splashForm = new fSplashScreen();
                Application.Run(splashForm);
            }
            ));
            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();
            fMain mainForm = new fMain(args);
            mainForm.Load += new EventHandler(fMain_Load);
            Application.Run(mainForm);
            SetForegroundWindow(mainForm.Handle);
        }

        private static void fMain_Load(object sender, EventArgs e)
        {
            if (splashForm == null)
            {
                return;
            }

            splashForm.Invoke(new Action(splashForm.Close));
            splashForm.Dispose();
            splashForm = null;
        }
    }
}
