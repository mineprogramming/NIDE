namespace NPixelPaint
{
    partial class fPaint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPaint));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbColorPicker = new ExHtmlEditor.ColorPicker.ThemeColorPickerToolStripSplitButton();
            this.tsbPicker = new System.Windows.Forms.ToolStripButton();
            this.tsbDraw = new System.Windows.Forms.ToolStripButton();
            this.tsbFill = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbTexturize = new System.Windows.Forms.ToolStripButton();
            this.tsbRectangle = new System.Windows.Forms.ToolStripButton();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.DrawPanel = new NPixelPaint.PanelEx();
            this.themeColorPicker1 = new System.Windows.Forms.ThemeColorPicker();
            this.panel = new System.Windows.Forms.Panel();
            this.tsMain.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbUndo,
            this.tsbRedo,
            this.toolStripSeparator2,
            this.tsbColorPicker,
            this.tsbPicker,
            this.tsbDraw,
            this.tsbFill,
            this.tsbClear,
            this.tsbTexturize,
            this.tsbRectangle});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(597, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip";
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Enabled = false;
            this.tsbUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsbUndo.Image")));
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(23, 22);
            this.tsbUndo.Text = "Undo";
            this.tsbUndo.Click += new System.EventHandler(this.tsbUndo_Click);
            // 
            // tsbRedo
            // 
            this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRedo.Enabled = false;
            this.tsbRedo.Image = ((System.Drawing.Image)(resources.GetObject("tsbRedo.Image")));
            this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRedo.Name = "tsbRedo";
            this.tsbRedo.Size = new System.Drawing.Size(23, 22);
            this.tsbRedo.Text = "Redo";
            this.tsbRedo.Click += new System.EventHandler(this.tsbRedo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbColorPicker
            // 
            this.tsbColorPicker.Color = System.Drawing.Color.Black;
            this.tsbColorPicker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbColorPicker.Image = ((System.Drawing.Image)(resources.GetObject("tsbColorPicker.Image")));
            this.tsbColorPicker.ImageHeight = 16;
            this.tsbColorPicker.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbColorPicker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbColorPicker.ImageWidth = 32;
            this.tsbColorPicker.Name = "tsbColorPicker";
            this.tsbColorPicker.Size = new System.Drawing.Size(48, 22);
            this.tsbColorPicker.Text = "Color";
            // 
            // tsbPicker
            // 
            this.tsbPicker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPicker.Image = ((System.Drawing.Image)(resources.GetObject("tsbPicker.Image")));
            this.tsbPicker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPicker.Name = "tsbPicker";
            this.tsbPicker.Size = new System.Drawing.Size(23, 22);
            this.tsbPicker.Text = "Pick color";
            this.tsbPicker.Click += new System.EventHandler(this.tsbPicker_Click);
            // 
            // tsbDraw
            // 
            this.tsbDraw.Checked = true;
            this.tsbDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDraw.Image = ((System.Drawing.Image)(resources.GetObject("tsbDraw.Image")));
            this.tsbDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDraw.Name = "tsbDraw";
            this.tsbDraw.Size = new System.Drawing.Size(23, 22);
            this.tsbDraw.Text = "Draw";
            this.tsbDraw.Click += new System.EventHandler(this.tsbDraw_Click);
            // 
            // tsbFill
            // 
            this.tsbFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFill.Image = ((System.Drawing.Image)(resources.GetObject("tsbFill.Image")));
            this.tsbFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFill.Name = "tsbFill";
            this.tsbFill.Size = new System.Drawing.Size(23, 22);
            this.tsbFill.Text = "Fill";
            this.tsbFill.Click += new System.EventHandler(this.tsbFill_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(23, 22);
            this.tsbClear.Text = "Erase";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tsbTexturize
            // 
            this.tsbTexturize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTexturize.Image = ((System.Drawing.Image)(resources.GetObject("tsbTexturize.Image")));
            this.tsbTexturize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTexturize.Name = "tsbTexturize";
            this.tsbTexturize.Size = new System.Drawing.Size(23, 22);
            this.tsbTexturize.Text = "Texturize";
            this.tsbTexturize.Click += new System.EventHandler(this.tsbTexturize_Click);
            // 
            // tsbRectangle
            // 
            this.tsbRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRectangle.Image = ((System.Drawing.Image)(resources.GetObject("tsbRectangle.Image")));
            this.tsbRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRectangle.Name = "tsbRectangle";
            this.tsbRectangle.Size = new System.Drawing.Size(23, 22);
            this.tsbRectangle.Text = "Rectangle";
            this.tsbRectangle.Click += new System.EventHandler(this.tsbRectangle_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.DefaultExt = "png";
            this.dlgOpen.FileName = "/textures";
            this.dlgOpen.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgOpen_FileOk);
            // 
            // DrawPanel
            // 
            this.DrawPanel.BackgroundImage = global::NPixelPaint.Properties.Resources.background;
            this.DrawPanel.Location = new System.Drawing.Point(0, 0);
            this.DrawPanel.Name = "DrawPanel";
            this.DrawPanel.Size = new System.Drawing.Size(335, 335);
            this.DrawPanel.TabIndex = 1;
            this.DrawPanel.Click += new System.EventHandler(this.DrawPanel_Click);
            this.DrawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanel_Paint);
            this.DrawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            this.DrawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseMove);
            this.DrawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseUp);
            // 
            // themeColorPicker1
            // 
            this.themeColorPicker1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("themeColorPicker1.BackgroundImage")));
            this.themeColorPicker1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.themeColorPicker1.Color = System.Drawing.Color.Empty;
            this.themeColorPicker1.CustomColors = new int[0];
            this.themeColorPicker1.Location = new System.Drawing.Point(0, 0);
            this.themeColorPicker1.Name = "themeColorPicker1";
            this.themeColorPicker1.Size = new System.Drawing.Size(174, 166);
            this.themeColorPicker1.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.DrawPanel);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 25);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(597, 448);
            this.panel.TabIndex = 2;
            // 
            // fPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 473);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.tsMain);
            this.Name = "fPaint";
            this.Text = "N Pixel Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fPngEditor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fPngEditor_FormClosed);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbDraw;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.ToolStripButton tsbPicker;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbFill;
        private System.Windows.Forms.ToolStripButton tsbTexturize;
        private ExHtmlEditor.ColorPicker.ThemeColorPickerToolStripSplitButton tsbColorPicker;
        private System.Windows.Forms.ThemeColorPicker themeColorPicker1;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripButton tsbRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbRectangle;
        private PanelEx DrawPanel;
        private System.Windows.Forms.Panel panel;
    }
}