using FastColoredTextBoxNS;
using System;
using System.IO;
using System.Windows.Forms;

namespace NIDE.components
{
    public partial class EditorTab : TabPage
    {
        private string file;
        private bool saved;

        public FastColoredTextBox Editor { get { return fctb; } }
        public bool Saved { get
            {
                return fctb.ReadOnly || saved || fctb.Text == "";
            }
        }
        public string File { get { return file; } }

        public EditorTab(string file)
        {
            InitializeComponent();
            DoubleBuffered = true;
            Controls.Add(fctb);
            this.file = file;
            try
            {
                fctb.OpenFile(file, ProgramData.Encoding);
                saved = true;
                Text = Path.GetFileName(file);
            }
            catch (Exception e)
            {
                ProgramData.Log("FileSystem", "Unable to open script! " + e.Message);
            }
        }

        public void Save()
        {
            fctb.SaveToFile(file, ProgramData.Encoding);
            saved = true;
            Text = Text.Replace("*", "");
        }

        public bool CanClose()
        {
            if (saved)
                return true;

            var result = MessageBox.Show("Do you want to save changes in " + Path.GetFileName(file) + "?", 
                "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                fctb.SaveToFile(file, ProgramData.Encoding);
                saved = true;
                return true;
            }
            else if (result == DialogResult.No)
                return true;
            else
                return false;
        }

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            saved = false;
            if (!Text.EndsWith("*"))
                Text = Text + "*";
        }
    }
}
