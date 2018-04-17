using System;
using System.Drawing;
using System.Windows.Forms;

namespace NIDE.window
{
    public partial class SearchListBox : ListBox
    {
        public SearchListBox()
        {
            InitializeComponent();
            DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            if ((e.Index < 0) || (e.Index >= Items.Count))
                return;
            string s = Items[e.Index].ToString();
            SizeF sf = e.Graphics.MeasureString(s, Font, Width);
            e.ItemHeight = (int)sf.Height + 10;
            e.ItemWidth = Width;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                string s = Items[e.Index].ToString();
                
                if ((e.State & DrawItemState.Focus) == 0)
                {
                    e.Graphics.FillRectangle(
                        new SolidBrush(SystemColors.Window),
                        e.Bounds);
                    e.Graphics.DrawString(s, Font,
                        new SolidBrush(SystemColors.WindowText),
                        e.Bounds.Left, e.Bounds.Top + 3);
                    e.Graphics.DrawLine(
                        new Pen(SystemColors.WindowText, 2), 
                        e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                }
                else 
                {
                    e.Graphics.FillRectangle(
                        new SolidBrush(SystemColors.Highlight),
                        e.Bounds);
                    e.Graphics.DrawString(s, Font,
                        new SolidBrush(SystemColors.HighlightText),
                        e.Bounds.Left, e.Bounds.Top + 3);
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
            private string line;

            public SearchListItem(Path file, int pos, string line)
            {
                File = file;
                Line = pos;
                line = line.Trim();
                this.line = line.Substring(0, Math.Min(line.Length, 20)) + "...";
            }

            public override string ToString()
            {
                return string.Format("{0}, line {1}:\n{2}", File.GetName(), Line + 1, line);
            }
        }
    }
}
