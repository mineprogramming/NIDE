using Ionic.Zip;
using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace Updater
{
    public partial class FUpdate : Form
    {
        private const string UPDATE_FILE = "..\\update.zip";

        public FUpdate()
        {
            InitializeComponent();
        }

        private bool success = false;

        private void FUpdate_Load(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("NIDE");
            foreach (Process process in processes)
            {
                process.Kill();
            }

            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged;
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                Log("Downloading update archieve");
                client.DownloadFileAsync(new Uri("http://api.mineprogramming.org/nide/update.zip"), UPDATE_FILE);
            }
        }
        
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pbDownload.Value = e.ProgressPercentage;
            pbGeneral.Value = e.ProgressPercentage;
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Log("Success");
            pbDownload.Value = 0;
            pbGeneral.Value = 100;
            using (ZipFile zip = ZipFile.Read(UPDATE_FILE))
            {
                zip.ExtractProgress += Zip_ExtractProgress;
                Log("Unzipping update archieve");
                zip.ExtractAll("..\\", ExtractExistingFileAction.OverwriteSilently);
            }
        }

        private void Zip_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if(e.TotalBytesToTransfer != 0)
            {
                pbDownload.Value = (int)(1.0 * e.BytesTransferred / e.TotalBytesToTransfer * 100);
                pbGeneral.Value = 100 + pbDownload.Value;
                if(pbDownload.Value == 100 && !success)
                {
                    Log("Success");
                    success = true;
                    btnOk.Enabled = true;
                }
            }
        }

        private void Log(string message)
        {
            lblAction.Text = message;
            log.AppendText(string.Format("[{0:H:mm:ss}] {1}\r\n", DateTime.Now, message));
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Process.Start("..\\NIDE.exe", "update");
            Close();
        }
    }
}
