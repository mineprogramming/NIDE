using NIDE.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NIDE
{
    public partial class fPngEditor : Form
    {
        string path;
        Color[,] pixels = new Color[16, 16];
        Bitmap png;
        bool saved = true;
        bool _16_16 = true;
        bool mouseDown = false;
        Random rnd;

        private PanelEx DrawPanel;

        public fPngEditor(string path)
        {
            DrawPanel = new PanelEx();
            DrawPanel.Dock = DockStyle.Fill;
            DrawPanel.BackgroundImage = Resources.background;
            DrawPanel.Paint += DrawPanel_Paint;
            DrawPanel.Click += DrawPanel_Click;
            DrawPanel.MouseMove += DrawPanel_MouseMove;
            DrawPanel.MouseDown += DrawPanel_MouseDown;
            DrawPanel.MouseUp += DrawPanel_MouseUp;
            Controls.Add(DrawPanel);
            InitializeComponent();
            rnd = new Random();
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

        private void tsbColor_Click(object sender, EventArgs e)
        {
            dlgColor.ShowDialog();
        }
        
        private void tsbDraw_Click(object sender, EventArgs e)
        {
            tsbDraw.Checked = true;
            tsbPicker.Checked = false;
            tsbClear.Checked = false;
            tsbFill.Checked = false;
            tsbTexturize.Checked = false;
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            tsbDraw.Checked = false;
            tsbPicker.Checked = false;
            tsbClear.Checked = true;
            tsbFill.Checked = false;
            tsbTexturize.Checked = false;
        }

        private void tsbPicker_Click(object sender, EventArgs e)
        {
            tsbDraw.Checked = false;
            tsbPicker.Checked = true;
            tsbClear.Checked = false;
            tsbFill.Checked = false;
            tsbTexturize.Checked = false;
        }

        private void tsbFill_Click(object sender, EventArgs e)
        {
            tsbDraw.Checked = false;
            tsbPicker.Checked = false;
            tsbClear.Checked = false;
            tsbFill.Checked = true;
            tsbTexturize.Checked = false;
        }

        private void tsbTexturize_Click(object sender, EventArgs e)
        {
            tsbDraw.Checked = false;
            tsbPicker.Checked = false;
            tsbClear.Checked = false;
            tsbFill.Checked = false;
            tsbTexturize.Checked = true;
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
                png.Dispose();
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
        }

        private void DrawPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen coordsPen = new Pen(Color.LightGray);
            for (var i = 1; i < 16; i++)
            {
                int pos = i * 21;
                g.DrawLine(coordsPen, 0, pos, 335, pos);
                e.Graphics.DrawLine(coordsPen, pos, 0, pos, 335);
            }
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    g.FillRectangle(new SolidBrush(pixels[i, j]), i * 21 + 1, j * 21 + 1, 20, 20);
                }
            }
        }


        private void DrawPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void DrawPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void DrawPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                saved = false;
                int cursorX = Cursor.Position.X - DrawPanel.PointToScreen(Point.Empty).X;
                int cursorY = Cursor.Position.Y - DrawPanel.PointToScreen(Point.Empty).Y;
                int x = cursorX / 21;
                if (x < 0) x = 0;
                if (x > 15) x = 15;
                int y = cursorY / 21;
                if (y < 0) y = 0;
                if (y > 15) y = 15;
                if (tsbDraw.Checked)
                    pixels[x, y] = dlgColor.Color;
                else if(tsbClear.Checked)
                    pixels[x, y] = Color.Transparent;
                DrawPanel.Refresh();
            }
        }

        private void DrawPanel_Click(object sender, EventArgs e)
        {
            saved = false;
            int cursorX = Cursor.Position.X - DrawPanel.PointToScreen(Point.Empty).X;
            int cursorY = Cursor.Position.Y - DrawPanel.PointToScreen(Point.Empty).Y;
            int x = cursorX / 21;
            int y = cursorY / 21;
            if (tsbPicker.Checked)
            {
                dlgColor.Color = pixels[x, y];
                tsbPicker.Checked = false;
                tsbDraw.Checked = true;
            }
            else if (tsbFill.Checked)
                FillRecursive(x, y);
            else if (tsbTexturize.Checked)
                TexturizeRecursive(x, y);
            DrawPanel.Refresh();
        }

        private void TexturizeRecursive(int x, int y)
        {
            Color prevColor = pixels[x, y];
            int darkness = rnd.Next(-30, 30);
            int A = prevColor.A + darkness;
            if (A > 255) A = 255;
            if (A < 0) A = 0;
            int R = prevColor.R + darkness;
            if (R > 255) R = 255;
            if (R < 0) R = 0;
            int G = prevColor.G + darkness;
            if (G > 255) G = 255;
            if (G < 0) G = 0;
            int B = prevColor.B + darkness;
            if (B > 255) B = 255;
            if (B < 0) B = 0;

            pixels[x, y] = Color.FromArgb(A, R, G, B);
            if (x > 0 && pixels[x - 1, y] == prevColor)
               TexturizeRecursive(x - 1, y);
            if (x < 15 && pixels[x + 1, y] == prevColor)
                TexturizeRecursive(x + 1, y);
            if (y > 0 && pixels[x, y - 1] == prevColor)
                TexturizeRecursive(x, y - 1);
            if (y < 15 && pixels[x, y + 1] == prevColor)
                TexturizeRecursive(x, y + 1);
        }

        private void FillRecursive(int x, int y)
        {
            Color prevColor = pixels[x, y];
            if (dlgColor.Color == prevColor)
                return;
            pixels[x, y] = dlgColor.Color;
            if (x > 0 && pixels[x - 1, y] == prevColor)
                FillRecursive(x - 1, y);
            if (x < 15 && pixels[x + 1, y] == prevColor)
                FillRecursive(x + 1, y);
            if (y > 0 && pixels[x, y - 1] == prevColor)
                FillRecursive(x, y - 1);
            if (y < 15 && pixels[x, y + 1] == prevColor)
                FillRecursive(x, y + 1);
        }
        
    }

    class PanelEx : Panel
    {
        public PanelEx()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}