using System;
using System.Windows.Forms;

namespace NIDE
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
            btnNamespaces.BackColor = Highlighting.NamespaceColor;
            btnHooks.BackColor = Highlighting.HookColor;
            btnGlobal.BackColor = Highlighting.GlobalColor;
            btnMembers.BackColor = Highlighting.MemberColor;
            tbPath.Text = ADBWorker.Path;
        }

        private void btnNamespaces_Click(object sender, EventArgs e)
        {
            dlgColor.Color = Highlighting.NamespaceColor;
            if(dlgColor.ShowDialog() == DialogResult.OK)
            {
                btnNamespaces.BackColor = dlgColor.Color;
                Highlighting.NamespaceColor = dlgColor.Color;
                Highlighting.RefreshStyles();
            }
        }

        private void btnHooks_Click(object sender, EventArgs e)
        {
            dlgColor.Color = Highlighting.HookColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                btnHooks.BackColor = dlgColor.Color;
                Highlighting.HookColor = dlgColor.Color;
                Highlighting.RefreshStyles();
            }
        }

        private void btnGlobal_Click(object sender, EventArgs e)
        {
            dlgColor.Color = Highlighting.GlobalColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                btnGlobal.BackColor = dlgColor.Color;
                Highlighting.GlobalColor = dlgColor.Color;
                Highlighting.RefreshStyles();
            }
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            dlgColor.Color = Highlighting.MemberColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                btnMembers.BackColor = dlgColor.Color;
                Highlighting.MemberColor = dlgColor.Color;
                Highlighting.RefreshStyles();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ADBWorker.Path = tbPath.Text;
            Close();
        }
    }
}
