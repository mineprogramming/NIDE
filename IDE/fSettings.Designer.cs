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
            this.btnKeywords = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnStrings = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnNumbers = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNormal = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
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
            this.cbLast = new System.Windows.Forms.CheckBox();
            this.cbRunProgram = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKeywords);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnStrings);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnNumbers);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnNormal);
            this.groupBox1.Controls.Add(this.label6);
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
            this.groupBox1.Size = new System.Drawing.Size(329, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            // 
            // btnKeywords
            // 
            this.btnKeywords.Location = new System.Drawing.Point(248, 77);
            this.btnKeywords.Name = "btnKeywords";
            this.btnKeywords.Size = new System.Drawing.Size(75, 23);
            this.btnKeywords.TabIndex = 17;
            this.btnKeywords.Text = "Change";
            this.btnKeywords.UseVisualStyleBackColor = true;
            this.btnKeywords.Click += new System.EventHandler(this.btnKeywords_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(189, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Keywords";
            // 
            // btnStrings
            // 
            this.btnStrings.Location = new System.Drawing.Point(248, 48);
            this.btnStrings.Name = "btnStrings";
            this.btnStrings.Size = new System.Drawing.Size(75, 23);
            this.btnStrings.TabIndex = 15;
            this.btnStrings.Text = "Change";
            this.btnStrings.UseVisualStyleBackColor = true;
            this.btnStrings.Click += new System.EventHandler(this.btnStrings_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(203, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Strings";
            // 
            // btnNumbers
            // 
            this.btnNumbers.Location = new System.Drawing.Point(248, 19);
            this.btnNumbers.Name = "btnNumbers";
            this.btnNumbers.Size = new System.Drawing.Size(75, 23);
            this.btnNumbers.TabIndex = 13;
            this.btnNumbers.Text = "Change";
            this.btnNumbers.UseVisualStyleBackColor = true;
            this.btnNumbers.Click += new System.EventHandler(this.btnNumbers_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Numbers";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(81, 164);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Change";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Background";
            // 
            // btnNormal
            // 
            this.btnNormal.Location = new System.Drawing.Point(81, 19);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(75, 23);
            this.btnNormal.TabIndex = 9;
            this.btnNormal.Text = "Change";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Normal text";
            // 
            // btnMembers
            // 
            this.btnMembers.Location = new System.Drawing.Point(81, 135);
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
            this.label4.Location = new System.Drawing.Point(25, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Members";
            // 
            // btnGlobal
            // 
            this.btnGlobal.Location = new System.Drawing.Point(81, 106);
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
            this.label3.Location = new System.Drawing.Point(38, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Global";
            // 
            // btnHooks
            // 
            this.btnHooks.Location = new System.Drawing.Point(81, 77);
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
            this.label2.Location = new System.Drawing.Point(37, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hooks";
            // 
            // btnNamespaces
            // 
            this.btnNamespaces.Location = new System.Drawing.Point(81, 48);
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
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namespaces \r\nand brackets";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(383, 87);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(246, 20);
            this.tbPath.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(380, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Android scripts path:";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(554, 184);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbLast
            // 
            this.cbLast.AutoSize = true;
            this.cbLast.Location = new System.Drawing.Point(383, 35);
            this.cbLast.Name = "cbLast";
            this.cbLast.Size = new System.Drawing.Size(104, 17);
            this.cbLast.TabIndex = 4;
            this.cbLast.Text = "Load last project";
            this.cbLast.UseVisualStyleBackColor = true;
            // 
            // cbRunProgram
            // 
            this.cbRunProgram.AutoSize = true;
            this.cbRunProgram.Location = new System.Drawing.Point(383, 119);
            this.cbRunProgram.Name = "cbRunProgram";
            this.cbRunProgram.Size = new System.Drawing.Size(182, 17);
            this.cbRunProgram.TabIndex = 5;
            this.cbRunProgram.Text = "Run InnerCore or BlockLauncher";
            this.cbRunProgram.UseVisualStyleBackColor = true;
            // 
            // fSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 219);
            this.Controls.Add(this.cbRunProgram);
            this.Controls.Add(this.cbLast);
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
        private System.Windows.Forms.CheckBox cbLast;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNumbers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnStrings;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnKeywords;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbRunProgram;
    }
}