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
                ProgramData.Log("FileSystem", "Unable to open script! " + e.Message, ProgramData.LOG_STYLE_ERROR);
            }
        }

        public bool Reload()
        {
            if (CanClose())
            {
                try
                {
                    fctb.OpenFile(File, ProgramData.Encoding);
                    saved = true;
                    base.Text = System.IO.Path.GetFileName(File);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Unable to find file " + File + ". This tab will be closed.", "Warning");
                    return false;
                }
            }
            return true;
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

        private void fctb_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void fctb_ZoomChanged(object sender, EventArgs e)
        {
            RegistryWorker.FontSize = fctb.Font.Size;
        }

        private void fctb_Load(object sender, EventArgs e)
        {
            fctb.Font = new System.Drawing.Font(fctb.Font.FontFamily, RegistryWorker.FontSize);
        }
    }
}
