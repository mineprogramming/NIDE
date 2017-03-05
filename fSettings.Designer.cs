namespace NIDE
{
    partial class fSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMembers = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGlobal = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHooks = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNamespaces = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMembers);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnGlobal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnHooks);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnNamespaces);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            // 
            // btnMembers
            // 
            this.btnMembers.Location = new System.Drawing.Point(81, 98);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Size = new System.Drawing.Size(75, 23);
            this.btnMembers.TabIndex = 7;
            this.btnMembers.Text = "Change";
            this.btnMembers.UseVisualStyleBackColor = true;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Members";
            // 
            // btnGlobal
            // 
            this.btnGlobal.Location = new System.Drawing.Point(81, 69);
            this.btnGlobal.Name = "btnGlobal";
            this.btnGlobal.Size = new System.Drawing.Size(75, 23);
            this.btnGlobal.TabIndex = 5;
            this.btnGlobal.Text = "Change";
            this.btnGlobal.UseVisualStyleBackColor = true;
            this.btnGlobal.Click += new System.EventHandler(this.btnGlobal_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Global";
            // 
            // btnHooks
            // 
            this.btnHooks.Location = new System.Drawing.Point(81, 40);
            this.btnHooks.Name = "btnHooks";
            this.btnHooks.Size = new System.Drawing.Size(75, 23);
            this.btnHooks.TabIndex = 3;
            this.btnHooks.Text = "Change";
            this.btnHooks.UseVisualStyleBackColor = true;
            this.btnHooks.Click += new System.EventHandler(this.btnHooks_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hooks";
            // 
            // btnNamespaces
            // 
            this.btnNamespaces.Location = new System.Drawing.Point(81, 11);
            this.btnNamespaces.Name = "btnNamespaces";
            this.btnNamespaces.Size = new System.Drawing.Size(75, 23);
            this.btnNamespaces.TabIndex = 1;
            this.btnNamespaces.Text = "Change";
            this.btnNamespaces.UseVisualStyleBackColor = true;
            this.btnNamespaces.Click += new System.EventHandler(this.btnNamespaces_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namespaces";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(189, 52);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(243, 20);
            this.tbPath.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Android scripts path:";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(357, 123);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // fSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 158);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "fSettings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNamespaces;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGlobal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHooks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnApply;
    }
}