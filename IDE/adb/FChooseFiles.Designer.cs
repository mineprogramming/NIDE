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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FChooseFiles));
            this.BtnPush = new System.Windows.Forms.Button();
            this.CBDontAsk = new System.Windows.Forms.CheckBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.tvFiles = new RikTheVeggie.TriStateTreeView();
            this.SuspendLayout();
            // 
            // BtnPush
            // 
            this.BtnPush.Location = new System.Drawing.Point(421, 358);
            this.BtnPush.Margin = new System.Windows.Forms.Padding(4);
            this.BtnPush.Name = "BtnPush";
            this.BtnPush.Size = new System.Drawing.Size(100, 28);
            this.BtnPush.TabIndex = 1;
            this.BtnPush.Text = "Push";
            this.BtnPush.UseVisualStyleBackColor = true;
            this.BtnPush.Click += new System.EventHandler(this.BtnPush_Click);
            // 
            // CBDontAsk
            // 
            this.CBDontAsk.AutoSize = true;
            this.CBDontAsk.Location = new System.Drawing.Point(280, 363);
            this.CBDontAsk.Margin = new System.Windows.Forms.Padding(4);
            this.CBDontAsk.Name = "CBDontAsk";
            this.CBDontAsk.Size = new System.Drawing.Size(128, 21);
            this.CBDontAsk.TabIndex = 2;
            this.CBDontAsk.Text = "Don\'t ask again";
            this.CBDontAsk.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(529, 358);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 28);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // tvFiles
            // 
            this.tvFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvFiles.Location = new System.Drawing.Point(0, 0);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.Size = new System.Drawing.Size(645, 351);
            this.tvFiles.TabIndex = 4;
            this.tvFiles.TriStateStyleProperty = RikTheVeggie.TriStateTreeView.TriStateStyles.Installer;
            this.tvFiles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvFiles_AfterCheck);
            // 
            // FChooseFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 401);
            this.Controls.Add(this.tvFiles);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CBDontAsk);
            this.Controls.Add(this.BtnPush);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FChooseFiles";
            this.Text = "Choose files to push";
            this.Load += new System.EventHandler(this.FChooseFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnPush;
        private System.Windows.Forms.CheckBox CBDontAsk;
        private System.Windows.Forms.Button BtnCancel;
        private RikTheVeggie.TriStateTreeView tvFiles;
    }
}