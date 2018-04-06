namespace NIDE.UI
{
    partial class NewDialog
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
            this.rbItemsOpaque = new System.Windows.Forms.RadioButton();
            this.rbTerrainAtlas = new System.Windows.Forms.RadioButton();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbItemsOpaque
            // 
            this.rbItemsOpaque.AutoSize = true;
            this.rbItemsOpaque.Checked = true;
            this.rbItemsOpaque.Location = new System.Drawing.Point(15, 47);
            this.rbItemsOpaque.Name = "rbItemsOpaque";
            this.rbItemsOpaque.Size = new System.Drawing.Size(88, 17);
            this.rbItemsOpaque.TabIndex = 1;
            this.rbItemsOpaque.TabStop = true;
            this.rbItemsOpaque.Text = "items-opaque";
            this.rbItemsOpaque.UseVisualStyleBackColor = true;
            // 
            // rbTerrainAtlas
            // 
            this.rbTerrainAtlas.AutoSize = true;
            this.rbTerrainAtlas.Location = new System.Drawing.Point(109, 47);
            this.rbTerrainAtlas.Name = "rbTerrainAtlas";
            this.rbTerrainAtlas.Size = new System.Drawing.Size(79, 17);
            this.rbTerrainAtlas.TabIndex = 2;
            this.rbTerrainAtlas.Text = "terrain-atlas";
            this.rbTerrainAtlas.UseVisualStyleBackColor = true;
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(15, 21);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(176, 20);
            this.tbFileName.TabIndex = 3;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 5);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(55, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "File name:";
            // 
            // NewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 86);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.rbItemsOpaque);
            this.Controls.Add(this.rbTerrainAtlas);
            this.Controls.Add(this.tbFileName);
            this.Name = "NewDialog";
            this.Text = "fDialog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fDialog_FormClosed);
            this.Controls.SetChildIndex(this.tbFileName, 0);
            this.Controls.SetChildIndex(this.rbTerrainAtlas, 0);
            this.Controls.SetChildIndex(this.rbItemsOpaque, 0);
            this.Controls.SetChildIndex(this.lbl1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbItemsOpaque;
        private System.Windows.Forms.RadioButton rbTerrainAtlas;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label lbl1;
    }
}