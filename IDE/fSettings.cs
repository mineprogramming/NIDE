using System;
using System.Windows.Forms;
using NIDE.adb;

namespace NIDE
{
    public partial class fSettings : Form
    {
        private Highlighter highlighter;

        public fSettings(Highlighter highlighting)
        {
            InitializeComponent();
            btnNormal.ForeColor = ProgramData.MainForm.fctbMain.ForeColor;
            btnNamespaces.ForeColor = Highlighter.NamespaceColor;
            btnHooks.ForeColor = Highlighter.HookColor;
            btnGlobal.ForeColor = Highlighter.GlobalColor;
            btnMembers.ForeColor = Highlighter.MemberColor;
            btnBack.ForeColor = ProgramData.MainForm.fctbMain.BackColor;

            try
            {
                btnNumbers.ForeColor = ProgramData.MainForm.fctbMain.SyntaxHighlighter.NumberStyle.GetRTF().ForeColor;
                btnStrings.ForeColor = ProgramData.MainForm.fctbMain.SyntaxHighlighter.StringStyle.GetRTF().ForeColor;
                btnKeywords.ForeColor = ProgramData.MainForm.fctbMain.SyntaxHighlighter.KeywordStyle.GetRTF().ForeColor;
            } catch { }

            tbPath.Text = ProgramData.Project.ADBPushPath;
            cbLast.Checked = ProgramData.LoadLast;
            cbRunProgram.Checked = ADBWorker.RunProgram;
            this.highlighter = highlighting;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                ProgramData.MainForm.fctbMain.ForeColor = dlgColor.Color;
            }
        }

        private void btnNamespaces_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.NamespaceColor = dlgColor.Color;
                highlighter.RefreshStyles();
            }
        }

        private void btnHooks_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.HookColor = dlgColor.Color;
                highlighter.RefreshStyles();
            }
        }

        private void btnGlobal_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.GlobalColor = dlgColor.Color;
                highlighter.RefreshStyles();
            }
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.MemberColor = dlgColor.Color;
                highlighter.RefreshStyles();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                ProgramData.MainForm.fctbMain.BackColor = dlgColor.Color;
            }
        }

        private void btnNumbers_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.NumbersColor = dlgColor.Color;
                highlighter.RefreshStyles();
            }
        }

        private void btnStrings_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.StringsColor = dlgColor.Color;
                highlighter.RefreshStyles();
            }
        }

        private void btnKeywords_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.KeywordsColor = dlgColor.Color;
                highlighter.RefreshStyles();
            }
        }

        private bool ShowColorDialog(object sender)
        {
            dlgColor.Color = ((Button)sender).ForeColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                ((Button)sender).ForeColor = dlgColor.Color;
                return true;
            }
            return false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!tbPath.Text.EndsWith("/"))
                tbPath.Text += "/";
            ProgramData.Project.ADBPushPath = tbPath.Text;
            ProgramData.LoadLast = cbLast.Checked;
            ADBWorker.RunProgram = cbRunProgram.Checked;
            Close();
        }

    }
}
