using System;
using System.Windows.Forms;

namespace NPixelPaint
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpenFileDialog dlgFile = new OpenFileDialog();
            if(args.Length > 0)
            {
                Application.Run(new fPaint(args[0]));
            }
            else if(dlgFile.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new fPaint(dlgFile.FileName));
            }
            
        }
    }
}
