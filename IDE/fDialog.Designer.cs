namespace NIDE
{
    partial class fDialog
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.rbItemsOpaque = new System.Windows.Forms.RadioButton();
            this.rbTerrainAtlas = new System.Windows.Forms.RadioButton();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(55, 13);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "File name:";
            // 
            // rbItemsOpaque
            // 
            this.rbItemsOpaque.AutoSize = true;
            this.rbItemsOpaque.Checked = true;
            this.rbItemsOpaque.Location = new System.Drawing.Point(15, 51);
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
            this.rbTerrainAtlas.Location = new System.Drawing.Point(106, 51);
            this.rbTerrainAtlas.Name = "rbTerrainAtlas";
            this.rbTerrainAtlas.Size = new System.Drawing.Size(79, 17);
            this.rbTerrainAtlas.TabIndex = 2;
            this.rbTerrainAtlas.Text = "terrain-atlas";
            this.rbTerrainAtlas.UseVisualStyleBackColor = true;
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(15, 25);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(170, 20);
            this.tbFileName.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(40, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(121, 74);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // fDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 105);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.rbTerrainAtlas);
            this.Controls.Add(this.rbItemsOpaque);
            this.Controls.Add(this.lbl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fDialog";
            this.Text = "fDialog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fDialog_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.RadioButton rbItemsOpaque;
        private System.Windows.Forms.RadioButton rbTerrainAtlas;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}