using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NIDE.window
{
    public partial class InsertListBox : ListBox
    {
        private Image templateImage = new Bitmap(Properties.Resources.js);

        public InsertListBox()
        {
            InitializeComponent();
            DrawMode = DrawMode.OwnerDrawVariable;
            try
            {
                LoadInserts();
            }
            catch { }
        }

        private void LoadInserts()
        {
            string text = File.ReadAllText("inserts.txt");
            string[] patterns = text.Split('~');
            for (int i = 1; i < patterns.Length; i += 2)
                Items.Add(new InsertListItem(patterns[i].Trim(' ', '\n', '\r'), patterns[i - 1].Trim(' ', '\n', '\r')));
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index > -1 && e.Index < Items.Count)
            {
                string text = ((InsertListItem)Items[e.Index]).Text;
                string code = ((InsertListItem)Items[e.Index]).CodeText;
                
                if ((e.State & DrawItemState.Focus) == 0)
                {
                    e.Graphics.FillRectangle(
                        new SolidBrush(SystemColors.Window),
                        e.Bounds);
                    e.Graphics.DrawImage(templateImage, e.Bounds.Left, e.Bounds.Top + 1);
                    e.Graphics.DrawString(text, Font,
                        new SolidBrush(SystemColors.WindowText),
                        e.Bounds.Left + 16, e.Bounds.Top + 3);
                    e.Graphics.DrawString(code, ProgramData.MainForm.fctbMain?.Font,
                        new SolidBrush(SystemColors.WindowText),
                        e.Bounds.Left, e.Bounds.Top + 17);
                    e.Graphics.DrawLine(
                        new Pen(SystemColors.WindowText, 2), 
                        e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
                else 
                {
                    e.Graphics.FillRectangle(
                        new SolidBrush(SystemColors.Highlight),
                        e.Bounds);
                    e.Graphics.DrawImage(templateImage, e.Bounds.Left, e.Bounds.Top + 1);
                    e.Graphics.DrawString(text, Font,
                        new SolidBrush(SystemColors.HighlightText),
                        e.Bounds.Left + 16, e.Bounds.Top + 3);
                    e.Graphics.DrawString(code, ProgramData.MainForm.fctbMain?.Font,
                        new SolidBrush(SystemColors.HighlightText),
                        e.Bounds.Left, e.Bounds.Top + 17);
                    e.Graphics.DrawLine(
                        new Pen(SystemColors.WindowText, 2),
                        e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
            }
        }

        public class InsertListItem
        {
            public string Text { get; }
            public string Code { get; }
            public string CodeText { get; }

            public InsertListItem(string text, string code)
            {
                Text = text;
                Code = code;
                if(code.IndexOf('\n') != -1)
                {
                    CodeText = code.Substring(0, code.IndexOf('\n'));
                }
                else
                {
                    CodeText = code;
                }
            }
        }
    }
}
