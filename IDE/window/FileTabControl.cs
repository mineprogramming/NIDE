using NIDE.Editors;
using NIDE.Highlighting;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NIDE.window
{
    public partial class FileTabControl : TabControl
    {
        ContextMenuStrip contextMenuStrip;

        public FileTabControl()
        {
            InitializeComponent();
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(120, 16);
            DrawMode = TabDrawMode.OwnerDrawFixed;
            DrawItem += FileTabControl_DrawItem;
            MouseDown += FileTabControl_MouseDown;

            contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem item = new ToolStripMenuItem("Close all tabs but this");
            item.Click += CloseAll_Click;
            contextMenuStrip.Items.Add(item);
            item = new ToolStripMenuItem("Close");
            item.Click += Close_Click;
            contextMenuStrip.Items.Add(item);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (TabPages.Count <= 1) return;
            EditorTab tab = (EditorTab)contextMenuStrip.Tag;
            if (tab.CanClose())
            {
                TabPages.Remove(tab);
            }
        }

        private void CloseAll_Click(object sender, EventArgs e)
        {
            TabPage current = (TabPage)contextMenuStrip.Tag;
            for (int i = TabPages.Count - 1; i >= 0; i--)
            {
                if(TabPages[i] != current && (((EditorTab)TabPages[i]).CanClose()))
                {
                    TabPages.RemoveAt(i);
                }
            }
        }

        private void FileTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (TabCount > 1)
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 2);
            int left = e.Bounds.Left;
            left += e.Index == 0 ? 16 : 6;
            e.Graphics.DrawString(TabPages[e.Index].Text, e.Font, Brushes.Black, left, e.Bounds.Top + 3);
            e.DrawFocusRectangle();
        }

        private void FileTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < TabPages.Count; i++)
            {
                Rectangle r = GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 15, 9);
                if (closeButton.Contains(e.Location))
                {
                    if (TabCount <= 1) return;
                    if (((EditorTab)TabPages[i]).CanClose())
                    {
                        TabPages.RemoveAt(i);
                    }
                } else if (r.Contains(e.Location) && e.Button == MouseButtons.Right){
                    contextMenuStrip.Tag = TabPages[i];
                    contextMenuStrip.Items[1].Enabled = TabPages.Count > 1;  
                    contextMenuStrip.Show(this, e.Location);
                }
            }
        }

        public EditorTab Load(string file, CodeEditor editor)
        {
            foreach (EditorTab tab in TabPages)
            {
                if (tab.File == file)
                {
                    SelectedTab = tab;
                    tab.Reload();
                    Refresh();
                    return tab;
                }
            }
            EditorTab newTab = new EditorTab(file, editor);
            TabPages.Add(newTab);
            SelectedTab = newTab;
            return newTab;
        }

        public EditorTab LoadBlank(string file, CodeEditor editor)
        {
            EditorTab newTab = new EditorTab(file, editor);
            TabPages.Add(newTab);
            foreach(TabPage page in TabPages)
            {
                if (page != newTab)
                    TabPages.Remove(page);
            }
            return newTab;
        }

        public void ReloadTabs()
        {
            foreach (EditorTab tab in TabPages)
            {
                if (!tab.Reload())
                {
                    TabPages.Remove(tab);
                }
            }
            Refresh();
        }
    }
}
