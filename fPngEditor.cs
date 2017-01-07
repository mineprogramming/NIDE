using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ModPE_editor
{
    public partial class fPngEditor : Form
    {
        string path;
        Color[,] pixels = new Color[16, 16];
        Bitmap png;
        bool saved = true;
        bool _16_16 = true;

        public fPngEditor(string path)
        {
            InitializeComponent();
            this.path = path;
            try
            {
                png = new Bitmap(path);
                if (png.Height == 16 && png.Width == 16)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            pixels[i, j] = png.GetPixel(i, j);
                        }
                    }
                }
                else
                {
                    _16_16 = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to load image: " + e.Message);
            }
        }

        public new void ShowDialog()
        {
            if (_16_16)
                base.ShowDialog();
            else
                Process.Start(path);
        }

        private void DrawPanel_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(pixels[e.Column, e.Row]);
            e.Graphics.FillRectangle(brush, e.CellBounds);
        }

        Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;

            return new Point(col, row);
        }

        private void DrawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            saved = false;
            var cellPos = GetRowColIndex(DrawPanel, DrawPanel.PointToClient(Cursor.Position));
            if (cellPos != null)
            {
                int x = cellPos.Value.X;
                int y = cellPos.Value.Y;
                if (tsbDraw.Checked)
                    pixels[x, y] = dlgColor.Color;
                else
                    pixels[x, y] = Color.Transparent;
                DrawPanel.Refresh();
            }
        }

        private void tsbColor_Click(object sender, EventArgs e)
        {
            dlgColor.ShowDialog();
        }

        private void tsbDraw_Click(object sender, EventArgs e)
        {
            tsbDraw.Checked = true;
            tsbClear.Checked = false;
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            tsbDraw.Checked = false;
            tsbClear.Checked = true;
        }

        private void fPngEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                var result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    save();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; ;
                }
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            png.Dispose();
            png = new Bitmap(16, 16);
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    png.SetPixel(i, j, pixels[i, j]);
                }
            }
            try
            {
                png.Save(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            saved = true;
        }

        private void tsbOpen_Click(object sender, EventArgs e)
        {
            dlgOpen.ShowDialog();
        }

        private void dlgOpen_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Bitmap bmp = new Bitmap(dlgOpen.FileName);
            if (bmp.Height == 16 && bmp.Width == 16)
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        pixels[i, j] = bmp.GetPixel(i, j);
                    }
                }
            }
            DrawPanel.Refresh();
        }
    }
}