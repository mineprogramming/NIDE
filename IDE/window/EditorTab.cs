using FastColoredTextBoxNS;
using NIDE.Editors;
using System;
using System.Windows.Forms;

namespace NIDE.window
{
    public partial class EditorTab : TabPage
    {
        private bool saved;

        public FastColoredTextBox TextBox { get { return fctb; } }
        public CodeEditor Editor { get; private set; }

        public bool Saved
        {
            get
            {
                return fctb.ReadOnly || saved;
            }
        }
        public string File { get; }

        public EditorTab(string file, CodeEditor editor)
        {
            InitializeComponent();
            DoubleBuffered = true;
            Controls.Add(fctb);
            File = file;
            Editor = editor;
            try
            {
                fctb.OpenFile(file, ProgramData.Encoding);
                saved = true;
                base.Text = System.IO.Path.GetFileName(file);
            }
            catch (Exception e)
            {
                ProgramData.Log("FileSystem", "Unable to open script! " + e.Message);
            }
        }

        public void Reload()
        {
            if (CanClose())
            {
                fctb.OpenFile(File, ProgramData.Encoding);
                saved = true;
                base.Text = System.IO.Path.GetFileName(File);
            }
        }

        public void Save()
        {
            fctb.SaveToFile(File, ProgramData.Encoding);
            saved = true;
            Text = Text.Replace("*", "");
        }

        public bool CanClose()
        {
            if (saved)
                return true;

            var result = MessageBox.Show("Do you want to save changes in " + System.IO.Path.GetFileName(File) + "?",
                "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                fctb.SaveToFile(File, ProgramData.Encoding);
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

        private void fctb_Load(object sender, EventArgs e)
        {
        }
    }
}
