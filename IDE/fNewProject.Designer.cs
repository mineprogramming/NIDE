namespace NIDE
{
    partial class fNewProject
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
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbModPE = new System.Windows.Forms.RadioButton();
            this.rbCoreEngine = new System.Windows.Forms.RadioButton();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSource = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.rbTexturePack = new System.Windows.Forms.RadioButton();
            this.rbBehaviourPack = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(101, 111);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(207, 20);
            this.tbPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project directory";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(314, 109);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(24, 23);
            this.btnFolder.TabIndex = 3;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Project name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(87, 85);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(251, 20);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(270, 138);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(68, 22);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(196, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 22);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // rbModPE
            // 
            this.rbModPE.AutoSize = true;
            this.rbModPE.Checked = true;
            this.rbModPE.Location = new System.Drawing.Point(15, 12);
            this.rbModPE.Name = "rbModPE";
            this.rbModPE.Size = new System.Drawing.Size(60, 17);
            this.rbModPE.TabIndex = 8;
            this.rbModPE.TabStop = true;
            this.rbModPE.Text = "ModPE";
            this.rbModPE.UseVisualStyleBackColor = true;
            // 
            // rbCoreEngine
            // 
            this.rbCoreEngine.AutoSize = true;
            this.rbCoreEngine.Location = new System.Drawing.Point(15, 35);
            this.rbCoreEngine.Name = "rbCoreEngine";
            this.rbCoreEngine.Size = new System.Drawing.Size(80, 17);
            this.rbCoreEngine.TabIndex = 9;
            this.rbCoreEngine.Text = "CoreEngine";
            this.rbCoreEngine.UseVisualStyleBackColor = true;
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(314, 57);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(24, 23);
            this.btnSource.TabIndex = 12;
            this.btnSource.Text = "...";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Source file";
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(75, 59);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(233, 20);
            this.tbSource.TabIndex = 10;
            // 
            // rbTexturePack
            // 
            this.rbTexturePack.AutoSize = true;
            this.rbTexturePack.Location = new System.Drawing.Point(101, 12);
            this.rbTexturePack.Name = "rbTexturePack";
            this.rbTexturePack.Size = new System.Drawing.Size(89, 17);
            this.rbTexturePack.TabIndex = 13;
            this.rbTexturePack.Text = "Texture Pack";
            this.rbTexturePack.UseVisualStyleBackColor = true;
            // 
            // rbBehaviourPack
            // 
            this.rbBehaviourPack.AutoSize = true;
            this.rbBehaviourPack.Location = new System.Drawing.Point(101, 36);
            this.rbBehaviourPack.Name = "rbBehaviourPack";
            this.rbBehaviourPack.Size = new System.Drawing.Size(101, 17);
            this.rbBehaviourPack.TabIndex = 14;
            this.rbBehaviourPack.Text = "Behaviour Pack";
            this.rbBehaviourPack.UseVisualStyleBackColor = true;
            // 
            // fNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 167);
            this.Controls.Add(this.rbBehaviourPack);
            this.Controls.Add(this.rbTexturePack);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSource);
            this.Controls.Add(this.rbCoreEngine);
            this.Controls.Add(this.rbModPE);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fNewProject";
            this.Text = "New project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbModPE;
        private System.Windows.Forms.RadioButton rbCoreEngine;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.RadioButton rbTexturePack;
        private System.Windows.Forms.RadioButton rbBehaviourPack;
    }
}