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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNewProject));
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
            this.rbInnerCore = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(135, 137);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(275, 22);
            this.tbPath.TabIndex = 1;
            this.tbPath.TextChanged += new System.EventHandler(this.tbPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 2;
            resources.ApplyResources(this.label1, "label1");
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(419, 134);
            this.btnFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(32, 28);
            this.btnFolder.TabIndex = 3;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 5;
            resources.ApplyResources(this.label2, "label2");
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(116, 105);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(333, 22);
            this.tbName.TabIndex = 4;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(360, 170);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(91, 27);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            resources.ApplyResources(this.btnCreate, "btnCreate");
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 170);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            // 
            // rbModPE
            // 
            this.rbModPE.AutoSize = true;
            this.rbModPE.Location = new System.Drawing.Point(20, 44);
            this.rbModPE.Margin = new System.Windows.Forms.Padding(4);
            this.rbModPE.Name = "rbModPE";
            this.rbModPE.Size = new System.Drawing.Size(74, 21);
            this.rbModPE.TabIndex = 8;
            this.rbModPE.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.rbModPE, "rbModPE");
            // 
            // rbCoreEngine
            // 
            this.rbCoreEngine.AutoSize = true;
            this.rbCoreEngine.Location = new System.Drawing.Point(135, 15);
            this.rbCoreEngine.Margin = new System.Windows.Forms.Padding(4);
            this.rbCoreEngine.Name = "rbCoreEngine";
            this.rbCoreEngine.Size = new System.Drawing.Size(103, 21);
            this.rbCoreEngine.TabIndex = 9;
            this.rbCoreEngine.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.rbCoreEngine, "rbCoreEngine");
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(419, 70);
            this.btnSource.Margin = new System.Windows.Forms.Padding(4);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(32, 28);
            this.btnSource.TabIndex = 12;
            this.btnSource.Text = "...";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 11;
            resources.ApplyResources(this.label3, "label3");
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(100, 73);
            this.tbSource.Margin = new System.Windows.Forms.Padding(4);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(309, 22);
            this.tbSource.TabIndex = 10;
            this.tbSource.TextChanged += new System.EventHandler(this.tbSource_TextChanged);
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "InnerCore mods (*.icmod)|*.icmod|ModPE mods (*.modpkg)|*.modpkg";
            // 
            // rbInnerCore
            // 
            this.rbInnerCore.AutoSize = true;
            this.rbInnerCore.Checked = true;
            this.rbInnerCore.Location = new System.Drawing.Point(20, 15);
            this.rbInnerCore.Margin = new System.Windows.Forms.Padding(4);
            this.rbInnerCore.Name = "rbInnerCore";
            this.rbInnerCore.Size = new System.Drawing.Size(91, 21);
            this.rbInnerCore.TabIndex = 13;
            this.rbInnerCore.TabStop = true;
            this.rbInnerCore.UseVisualStyleBackColor = true;
            resources.ApplyResources(this.rbInnerCore, "rbInnerCore");
            // 
            // fNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 206);
            this.Controls.Add(this.rbInnerCore);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fNewProject";
            this.ResumeLayout(false);
            this.PerformLayout();
            resources.ApplyResources(this, "fNewProject");

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
        private System.Windows.Forms.RadioButton rbInnerCore;
    }
}