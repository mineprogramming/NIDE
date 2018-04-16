using System;
using System.Windows.Forms;
using NIDE.adb;
using NIDE.highlighting;

namespace NIDE
{
    public partial class fSettings : Form
    {
        private Highlighter highlighter;

        public fSettings(Highlighter highlighter)
        {
            InitializeComponent();
            btnNormal.ForeColor = Highlighter.ForeColor;
            btnNamespaces.ForeColor = Highlighter.NamespaceColor;
            btnHooks.ForeColor = Highlighter.HookColor;
            btnGlobal.ForeColor = Highlighter.GlobalColor;
            btnMembers.ForeColor = Highlighter.MemberColor;
            btnBack.ForeColor = Highlighter.BackColor;
            btnNumbers.ForeColor = Highlighter.NumbersColor;
            btnStrings.ForeColor = Highlighter.StringsColor;
            btnKeywords.ForeColor = Highlighter.KeywordsColor;

            tbPath.Text = ProgramData.Project.ADBPushPath;
            cbLast.Checked = ProgramData.LoadLast;
            cbRunProgram.Checked = ADBWorker.RunProgram;
            cbHighlighting.Checked = (Highlighter.ErrorStrategy == ErrorHighlightStrategy.LINE_NUMBER);
            this.highlighter = highlighter;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.ForeColor = dlgColor.Color;
                highlighter.RefreshStyles();
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
                Highlighter.BackColor = dlgColor.Color;
                highlighter.RefreshStyles();
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

        private void cbHighlighting_CheckedChanged(object sender, EventArgs e)
        {
            Highlighter.ErrorStrategy = cbHighlighting.Checked ?
             ErrorHighlightStrategy.LINE_NUMBER : ErrorHighlightStrategy.UNDERLINE;
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
