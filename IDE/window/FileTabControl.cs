using NIDE.Editors;
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
            MouseClick += FileTabControl_MouseClick;

            MouseDown += FileTabControl_MouseDown;
            MouseUp += FileTabControl_MouseUp;
            MouseMove += FileTabControl_MouseMove;
            DragOver += FileTabControl_DragOver;


            contextMenuStrip = new ContextMenuStrip();

            ToolStripMenuItem item = new ToolStripMenuItem("Show in project tree");
            item.Click += ShowInProjectTree_Click;
            contextMenuStrip.Items.Add(item);

            item = new ToolStripMenuItem("Close all tabs but this");
            item.Click += CloseAll_Click;
            contextMenuStrip.Items.Add(item);

            item = new ToolStripMenuItem("Close");
            item.Click += Close_Click;
            contextMenuStrip.Items.Add(item);
        }

        

        private void FileTabControl_DragOver(object sender, DragEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            // a tab is draged?
            if (e.Data.GetData(typeof(EditorTab)) == null) return;
            EditorTab dragTab = (EditorTab)e.Data.GetData(typeof(EditorTab));
            int dragTab_index = tc.TabPages.IndexOf(dragTab);

            // hover over a tab?
            int hoverTab_index = this.getHoverTabIndex(tc);
            if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
            TabPage hoverTab = tc.TabPages[hoverTab_index];
            e.Effect = DragDropEffects.Move;

            // start of drag?
            if (dragTab == hoverTab) return;

            // swap dragTab & hoverTab - avoids toggeling
            Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
            Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);

            if (dragTabRect.Width < hoverTabRect.Width)
            {
                Point tcLocation = tc.PointToScreen(tc.Location);

                if (dragTab_index < hoverTab_index)
                {
                    if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
                else if (dragTab_index > hoverTab_index)
                {
                    if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
            }
            else this.swapTabPages(tc, dragTab, hoverTab);

            // select new pos of dragTab
            tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);
        }


        private void FileTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            // store clicked tab
            TabControl tc = (TabControl)sender;
            int hover_index = getHoverTabIndex(tc);
            if (hover_index >= 0) { tc.Tag = tc.TabPages[hover_index]; }
        }

        private void FileTabControl_MouseUp(object sender, MouseEventArgs e)
        {
            // clear stored tab
            TabControl tc = (TabControl)sender;
            tc.Tag = null;
        }

        private void FileTabControl_MouseMove(object sender, MouseEventArgs e)
        {
            // mouse button down? tab was clicked?
            TabControl tc = (TabControl)sender;
            if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
            EditorTab clickedTab = (EditorTab)tc.Tag;
            int clicked_index = tc.TabPages.IndexOf(clickedTab);

            // start drag n drop
            tc.DoDragDrop(clickedTab, DragDropEffects.All);
        }

        private int getHoverTabIndex(TabControl tc)
        {
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                    return i;
            }

            return -1;
        }

        private void swapTabPages(TabControl tc, TabPage src, TabPage dst)
        {
            int index_src = tc.TabPages.IndexOf(src);
            int index_dst = tc.TabPages.IndexOf(dst);
            tc.TabPages[index_dst] = src;
            tc.TabPages[index_src] = dst;
            tc.Refresh();
        }


        private void ShowInProjectTree_Click(object sender, EventArgs e)
        {
            EditorTab tab = (EditorTab)contextMenuStrip.Tag;
            var file = tab.File;
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
                if (TabPages[i] != current && (((EditorTab)TabPages[i]).CanClose()))
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

        private void FileTabControl_MouseClick(object sender, MouseEventArgs e)
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
                } else if (r.Contains(e.Location) && e.Button == MouseButtons.Right) {
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
            foreach (TabPage page in TabPages)
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

        public void SaveTabs()
        {
            foreach (EditorTab tab in TabPages)
            {
                if (!tab.Saved)
                {
                    tab.Save();
                }
            }
            Refresh();
        }

        private void FileTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditorTab editorTab = (EditorTab)TabPages[SelectedIndex];
            if((editorTab?.Editor?.TextBox?? null) != null)
            {
                Font font = editorTab.Editor.TextBox.Font;
                editorTab.Editor.TextBox.Font = new Font(font.FontFamily, RegistryWorker.FontSize);
            }
        }
    }
}
