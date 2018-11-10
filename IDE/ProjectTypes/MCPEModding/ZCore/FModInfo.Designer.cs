namespace NIDE.ProjectTypes.MCPEModding.ZCore
{
    partial class FModInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FModInfo));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.TbAuthor = new System.Windows.Forms.TextBox();
            this.TbVersion = new System.Windows.Forms.TextBox();
            this.TbDescription = new System.Windows.Forms.TextBox();
            this.cbIndent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mod title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author\'s name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 107);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mod description";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(163, 7);
            this.TbName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(303, 22);
            this.TbName.TabIndex = 4;
            // 
            // TbAuthor
            // 
            this.TbAuthor.Location = new System.Drawing.Point(163, 39);
            this.TbAuthor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbAuthor.Name = "TbAuthor";
            this.TbAuthor.Size = new System.Drawing.Size(303, 22);
            this.TbAuthor.TabIndex = 5;
            // 
            // TbVersion
            // 
            this.TbVersion.Location = new System.Drawing.Point(163, 71);
            this.TbVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbVersion.Name = "TbVersion";
            this.TbVersion.Size = new System.Drawing.Size(303, 22);
            this.TbVersion.TabIndex = 6;
            // 
            // TbDescription
            // 
            this.TbDescription.Location = new System.Drawing.Point(163, 103);
            this.TbDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TbDescription.Multiline = true;
            this.TbDescription.Name = "TbDescription";
            this.TbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbDescription.Size = new System.Drawing.Size(303, 110);
            this.TbDescription.TabIndex = 7;
            // 
            // cbIndent
            // 
            this.cbIndent.AutoSize = true;
            this.cbIndent.Checked = true;
            this.cbIndent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIndent.Location = new System.Drawing.Point(312, 220);
            this.cbIndent.Name = "cbIndent";
            this.cbIndent.Size = new System.Drawing.Size(154, 21);
            this.cbIndent.TabIndex = 8;
            this.cbIndent.Text = "Indent output JSON";
            this.cbIndent.UseVisualStyleBackColor = true;
            // 
            // FModInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 306);
            this.Controls.Add(this.cbIndent);
            this.Controls.Add(this.TbDescription);
            this.Controls.Add(this.TbVersion);
            this.Controls.Add(this.TbAuthor);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "FModInfo";
            this.Text = "mod.info";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.TbName, 0);
            this.Controls.SetChildIndex(this.TbAuthor, 0);
            this.Controls.SetChildIndex(this.TbVersion, 0);
            this.Controls.SetChildIndex(this.TbDescription, 0);
            this.Controls.SetChildIndex(this.cbIndent, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.TextBox TbAuthor;
        private System.Windows.Forms.TextBox TbVersion;
        private System.Windows.Forms.TextBox TbDescription;
        private System.Windows.Forms.CheckBox cbIndent;
    }
}