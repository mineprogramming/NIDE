namespace NIDE
{
    partial class fStartWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fStartWindow));
            this.lvRecent = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRecent = new System.Windows.Forms.Button();
            this.btnImportModpkg = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnImportIcmod = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvRecent
            // 
            this.lvRecent.ContextMenuStrip = this.contextMenuStrip;
            this.lvRecent.Location = new System.Drawing.Point(17, 202);
            this.lvRecent.Margin = new System.Windows.Forms.Padding(4);
            this.lvRecent.MultiSelect = false;
            this.lvRecent.Name = "lvRecent";
            this.lvRecent.Size = new System.Drawing.Size(320, 168);
            this.lvRecent.TabIndex = 0;
            this.lvRecent.UseCompatibleStateImageBehavior = false;
            this.lvRecent.View = System.Windows.Forms.View.List;
            this.lvRecent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvRecent_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRemove});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(133, 28);
            // 
            // tsmiRemove
            // 
            this.tsmiRemove.Name = "tsmiRemove";
            this.tsmiRemove.Size = new System.Drawing.Size(132, 24);
            this.tsmiRemove.Text = "Remove";
            this.tsmiRemove.Click += new System.EventHandler(this.tsmiRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 181);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Open recent";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(16, 15);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(321, 28);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New project";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(16, 50);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(321, 28);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open project";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRecent
            // 
            this.btnRecent.Location = new System.Drawing.Point(16, 378);
            this.btnRecent.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecent.Name = "btnRecent";
            this.btnRecent.Size = new System.Drawing.Size(321, 28);
            this.btnRecent.TabIndex = 4;
            this.btnRecent.Text = "Open recent";
            this.btnRecent.UseVisualStyleBackColor = true;
            this.btnRecent.Click += new System.EventHandler(this.btnRecent_Click);
            // 
            // btnImportModpkg
            // 
            this.btnImportModpkg.Enabled = false;
            this.btnImportModpkg.Location = new System.Drawing.Point(16, 122);
            this.btnImportModpkg.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportModpkg.Name = "btnImportModpkg";
            this.btnImportModpkg.Size = new System.Drawing.Size(321, 28);
            this.btnImportModpkg.TabIndex = 5;
            this.btnImportModpkg.Text = "Import .modpkg";
            this.btnImportModpkg.UseVisualStyleBackColor = true;
            this.btnImportModpkg.Click += new System.EventHandler(this.btnImportModpkg_Click);
            // 
            // btnImportIcmod
            // 
            this.btnImportIcmod.Enabled = false;
            this.btnImportIcmod.Location = new System.Drawing.Point(16, 86);
            this.btnImportIcmod.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportIcmod.Name = "btnImportIcmod";
            this.btnImportIcmod.Size = new System.Drawing.Size(321, 28);
            this.btnImportIcmod.TabIndex = 6;
            this.btnImportIcmod.Text = "Import .icmod";
            this.btnImportIcmod.UseVisualStyleBackColor = true;
            // 
            // fStartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 426);
            this.Controls.Add(this.btnImportIcmod);
            this.Controls.Add(this.btnImportModpkg);
            this.Controls.Add(this.btnRecent);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvRecent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fStartWindow";
            this.Text = "NIDE - welcome";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvRecent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRecent;
        private System.Windows.Forms.Button btnImportModpkg;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemove;
        private System.Windows.Forms.Button btnImportIcmod;
    }
}