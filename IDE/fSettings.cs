using System;
using System.Windows.Forms;

namespace NIDE
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
            btnNormal.ForeColor = ProgramData.MainForm.fctbMain.ForeColor;
            btnNamespaces.ForeColor = Highlighting.NamespaceColor;
            btnHooks.ForeColor = Highlighting.HookColor;
            btnGlobal.ForeColor = Highlighting.GlobalColor;
            btnMembers.ForeColor = Highlighting.MemberColor;
            btnBack.ForeColor = ProgramData.MainForm.fctbMain.BackColor;

            btnNumbers.ForeColor = ProgramData.MainForm.fctbMain.SyntaxHighlighter.NumberStyle.GetRTF().ForeColor;
            btnStrings.ForeColor = ProgramData.MainForm.fctbMain.SyntaxHighlighter.StringStyle.GetRTF().ForeColor;

            tbPath.Text = ADBWorker.Path;
            cbLast.Checked = ProgramData.LoadLast;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            dlgColor.Color = ProgramData.MainForm.fctbMain.ForeColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                btnNormal.ForeColor = dlgColor.Color;
                ProgramData.MainForm.fctbMain.ForeColor = dlgColor.Color;
            }
        }

        private void btnNamespaces_Click(object sender, EventArgs e)
        {
            dlgColor.Color = Highlighting.NamespaceColor;
            if(dlgColor.ShowDialog() == DialogResult.OK)
            {
                btnNamespaces.ForeColor = dlgColor.Color;
                Highlighting.NamespaceColor = dlgColor.Color;
                Highlighting.RefreshStyles();
            }
        }

        private void btnHooks_Click(object sender, EventArgs e)
        {
            dlgColor.Color = Highlighting.HookColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                btnHooks.ForeColor = dlgColor.Color;
                Highlighting.HookColor = dlgColor.Color;
                Highlighting.RefreshStyles();
            }
        }

        private void btnGlobal_Click(object sender, EventArgs e)
        {
            dlgColor.Color = Highlighting.GlobalColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                btnGlobal.ForeColor = dlgColor.Color;
                Highlighting.GlobalColor = dlgColor.Color;
                Highlighting.RefreshStyles();
            }
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            dlgColor.Color = Highlighting.MemberColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                btnMembers.ForeColor = dlgColor.Color;
                Highlighting.MemberColor = dlgColor.Color;
                Highlighting.RefreshStyles();
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
                Highlighting.NumbersColor = dlgColor.Color;
                Highlighting.RefreshStyles();
            }
        }

        private void btnStrings_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighting.StringsColor = dlgColor.Color;
                Highlighting.RefreshStyles();
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
            ADBWorker.Path = tbPath.Text;
            ProgramData.LoadLast = cbLast.Checked;
            Close();
        }
    }
}
