using System;
using System.Drawing;
using System.Windows.Forms;

namespace NIDE.window
{
    public partial class SearchListBox : ListBox
    {
        private Image jsImage = new Bitmap(Properties.Resources.js);

        public SearchListBox()
        {
            InitializeComponent();
            DrawMode = DrawMode.OwnerDrawVariable;
            ItemHeight = 36;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                string pos = Items[e.Index].ToString();
                string text = ((SearchListItem)Items[e.Index]).Text;
                
                if ((e.State & DrawItemState.Focus) == 0)
                {
                    e.Graphics.FillRectangle(
                        new SolidBrush(SystemColors.Window),
                        e.Bounds);
                    e.Graphics.DrawImage(jsImage, e.Bounds.Left, e.Bounds.Top + 1);
                    e.Graphics.DrawString(pos, Font,
                        new SolidBrush(SystemColors.WindowText),
                        e.Bounds.Left + 16, e.Bounds.Top + 3);
                    e.Graphics.DrawString(text, ProgramData.MainForm.fctbMain?.Font,
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
                    e.Graphics.DrawImage(jsImage, e.Bounds.Left, e.Bounds.Top + 1);
                    e.Graphics.DrawString(pos, Font,
                        new SolidBrush(SystemColors.HighlightText),
                        e.Bounds.Left + 16, e.Bounds.Top + 3);
                    e.Graphics.DrawString(text, ProgramData.MainForm.fctbMain?.Font,
                        new SolidBrush(SystemColors.HighlightText),
                        e.Bounds.Left, e.Bounds.Top + 17);
                    e.Graphics.DrawLine(
                        new Pen(SystemColors.WindowText, 2),
                        e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
            }
        }

        public class SearchListItem
        {
            public Path File { get; }
            public int Line { get; }
            public string Text { get; }

            public SearchListItem(Path file, int pos, string line)
            {
                File = file;
                Line = pos;
                line = line.Trim();
                Text = line.Substring(0, Math.Min(line.Length, 20)) + "...";
            }

            public override string ToString()
            {
                return string.Format("{0}, line {1}:", File.GetName(), Line + 1);
            }
        }
    }
}
