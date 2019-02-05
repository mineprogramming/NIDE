using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using NIDE.adb;
using NIDE.Highlighting;

namespace NIDE
{
    public partial class fSettings : Form
    {
        const string PATH_DEVICE = "/storage/emulated/0/games/com.mojang/mods/";
        const string PATH_EMULATOR = "/storage/emulated/legacy/games/com.mojang/mods/";

        private class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public ComboboxItem(string value, string text)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        public fSettings()
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
            btnComments.ForeColor = Highlighter.CommentsColor;

            tbPath.Text = ProgramData.Project.ADBPushPath;
            tbPath.Enabled = false;
            if (tbPath.Text == PATH_DEVICE)
                rbDevice.Select();
            else if (tbPath.Text == PATH_EMULATOR)
                rbEmulator.Select();
            else
            {
                rbCustom.Select();
                tbPath.Enabled = true;
            }
            cbLast.Checked = ProgramData.LoadLast;
            cbRunProgram.Checked = ADBWorker.RunProgram;
            cbHighlighting.Checked = (Highlighter.ErrorStrategy == ErrorHighlightStrategy.LINE_NUMBER);

            foreach(string culture in Constants.SupportedCultures)
            {
                ComboboxItem item = new ComboboxItem(culture, new CultureInfo(culture).DisplayName);
                cbLanguage.Items.Add(item);
                if(culture == Thread.CurrentThread.CurrentCulture.Name)
                {
                    cbLanguage.SelectedItem = item;
                }
            }
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.ForeColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
            }
        }

        private void btnNamespaces_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.NamespaceColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
            }
        }

        private void btnHooks_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.HookColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
            }
        }

        private void btnGlobal_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.GlobalColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
            }
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.MemberColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.BackColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
            }
        }

        private void btnNumbers_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.NumbersColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
            }
        }

        private void btnStrings_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.StringsColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
            }
        }

        private void btnKeywords_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.KeywordsColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
            }
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(sender))
            {
                Highlighter.CommentsColor = dlgColor.Color;
                ProgramData.MainForm.RequestHighlightingUpdate();
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

        private void rbDevice_CheckedChanged(object sender, EventArgs e)
        {
            tbPath.Enabled = false;
            tbPath.Text = PATH_DEVICE;
        }

        private void rbEmulator_CheckedChanged(object sender, EventArgs e)
        {
            tbPath.Enabled = false;
            tbPath.Text = PATH_EMULATOR;
        }

        private void rbCustom_CheckedChanged(object sender, EventArgs e)
        {
            tbPath.Enabled = true;
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = (ComboboxItem)cbLanguage.SelectedItem;
            CultureInfo selectedCulture = new CultureInfo(selectedItem.Value);

            Thread.CurrentThread.CurrentCulture = selectedCulture;
            Thread.CurrentThread.CurrentUICulture = selectedCulture;

            MessageBox.Show("Please, restart NIDE to apply changes");
        }
    }
}
