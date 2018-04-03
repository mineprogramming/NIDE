namespace NIDE.adb
{
    partial class FChooseFiles
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
            this.CLBFiles = new System.Windows.Forms.CheckedListBox();
            this.BtnPush = new System.Windows.Forms.Button();
            this.CBDontAsk = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CLBFiles
            // 
            this.CLBFiles.CheckOnClick = true;
            this.CLBFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.CLBFiles.FormattingEnabled = true;
            this.CLBFiles.Location = new System.Drawing.Point(0, 0);
            this.CLBFiles.Name = "CLBFiles";
            this.CLBFiles.Size = new System.Drawing.Size(488, 289);
            this.CLBFiles.TabIndex = 0;
            // 
            // BtnPush
            // 
            this.BtnPush.Location = new System.Drawing.Point(320, 291);
            this.BtnPush.Name = "BtnPush";
            this.BtnPush.Size = new System.Drawing.Size(75, 23);
            this.BtnPush.TabIndex = 1;
            this.BtnPush.Text = "Push";
            this.BtnPush.UseVisualStyleBackColor = true;
            this.BtnPush.Click += new System.EventHandler(this.BtnPush_Click);
            // 
            // CBDontAsk
            // 
            this.CBDontAsk.AutoSize = true;
            this.CBDontAsk.Location = new System.Drawing.Point(214, 295);
            this.CBDontAsk.Name = "CBDontAsk";
            this.CBDontAsk.Size = new System.Drawing.Size(100, 17);
            this.CBDontAsk.TabIndex = 2;
            this.CBDontAsk.Text = "Don\'t ask again";
            this.CBDontAsk.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(401, 291);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FChooseFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 326);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CBDontAsk);
            this.Controls.Add(this.BtnPush);
            this.Controls.Add(this.CLBFiles);
            this.Name = "FChooseFiles";
            this.Text = "Choose files to push";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CLBFiles;
        private System.Windows.Forms.Button BtnPush;
        private System.Windows.Forms.CheckBox CBDontAsk;
        private System.Windows.Forms.Button BtnCancel;
    }
}