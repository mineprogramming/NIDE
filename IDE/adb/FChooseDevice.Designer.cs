namespace NIDE.adb
{
    partial class FChooseDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FChooseDevice));
            this.BtnCancel = new System.Windows.Forms.Button();
            this.CBDontAsk = new System.Windows.Forms.CheckBox();
            this.BtnPush = new System.Windows.Forms.Button();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(397, 288);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // CBDontAsk
            // 
            this.CBDontAsk.AutoSize = true;
            this.CBDontAsk.Location = new System.Drawing.Point(210, 292);
            this.CBDontAsk.Name = "CBDontAsk";
            this.CBDontAsk.Size = new System.Drawing.Size(100, 17);
            this.CBDontAsk.TabIndex = 5;
            this.CBDontAsk.Text = "Don\'t ask again";
            this.CBDontAsk.UseVisualStyleBackColor = true;
            // 
            // BtnPush
            // 
            this.BtnPush.Location = new System.Drawing.Point(316, 288);
            this.BtnPush.Name = "BtnPush";
            this.BtnPush.Size = new System.Drawing.Size(75, 23);
            this.BtnPush.TabIndex = 4;
            this.BtnPush.Text = "Continue";
            this.BtnPush.UseVisualStyleBackColor = true;
            this.BtnPush.Click += new System.EventHandler(this.BtnPush_Click);
            // 
            // lbDevices
            // 
            this.lbDevices.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.Location = new System.Drawing.Point(0, 0);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(484, 277);
            this.lbDevices.TabIndex = 7;
            this.lbDevices.DoubleClick += new System.EventHandler(this.BtnPush_Click);
            // 
            // FChooseDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 326);
            this.Controls.Add(this.lbDevices);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CBDontAsk);
            this.Controls.Add(this.BtnPush);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FChooseDevice";
            this.Text = "Choose device to push";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.CheckBox CBDontAsk;
        private System.Windows.Forms.Button BtnPush;
        private System.Windows.Forms.ListBox lbDevices;
    }
}