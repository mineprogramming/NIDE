using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ModPE_editor
{
    public partial class fCraft : Form
    {
        private CheckBox checkedNow;
        public static string recipie;

        public fCraft()
        {
            InitializeComponent();
            checkedNow = checkBox10;
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkedNow = sender as CheckBox;
            checkedNow.Checked = true;
            if (checkedNow.Tag != null)
            {
                string[] splitted_tag = checkedNow.Tag.ToString().Split('_');
                nudId.Value = Convert.ToInt32(splitted_tag[0]);
                nudMeta.Value = Convert.ToInt32(splitted_tag[1]);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            find_texture();
            checkedNow.Tag = (int)nudId.Value + "_" + (int)nudMeta.Value;
        }

        private void find_texture()
        {
            if (Directory.Exists(ProgramData.Folder + "\\images\\items"))
            {
                foreach (var file in Directory.GetFiles(ProgramData.Folder + "\\images\\items"))
                {
                    Creatable item = File.ReadAllText(file).ToObject<Creatable>();
                    if (item.id == (int)nudId.Value)
                    {
                        string path = ProgramData.Folder + "\\images\\items-opaque\\" + item.texture.name + "_" + item.texture.meta + ".png";
                        if (!File.Exists(path))
                            path = ProgramData.Folder + "\\images\\terrain-atlas\\" + item.texture.name + "_" + item.texture.meta + ".png";
                        if (!File.Exists(path))
                        {
                            MessageBox.Show("Cannot find texture for id: " + nudId.Value);
                            return;
                        }
                        checkedNow.BackgroundImage = new Bitmap(path);
                        return;
                    }
                }
            }
            try
            {
                checkedNow.BackgroundImage = new Bitmap("textures\\minecraft-textures\\" + (int)nudId.Value + "_" + (int)nudMeta.Value + ".png");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot find texture for id: " + nudId.Value);
            }
        }

        class Item { public string id, data; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbTable.Checked)
            {
                if (checkBox10.Tag == null)
                {
                    MessageBox.Show("Result item isn't mentioned!");
                    return;
                }
                else if (checkBox1.Tag == null || checkBox2.Tag == null || checkBox3.Tag == null || checkBox4.Tag == null || checkBox5.Tag == null || checkBox6.Tag == null || checkBox7.Tag == null || checkBox8.Tag == null || checkBox9.Tag == null)
                {
                    MessageBox.Show("Recipie is empty!");
                    return;
                }
                string[] splitted = checkBox10.Tag.ToString().Split('_');
                recipie = "Item.addShapedRecipe({0}, {1}, {2}, {3}, {4});";
                string object1 = "";
                string object2 = "";
                Item[] items;
                bool _3x3 = getItems(out items);
                if (!_3x3)
                    object1 = "[\"ab\", \"cd\"]";
                else
                    object1 = "[\"abc\", \"def\", \"ghi\"]";
                object2 = "[";
                for (int i = 0; i < items.Length; i++)
                    if (items[i] != null)
                        object2 += "\"" + Convert.ToChar(97 + i) + "\", " + items[i].id + ", " + items[i].data + ',';
                object2 = object2.Substring(0, object2.Length - 1) + ']';
                recipie = string.Format(recipie, splitted[0], (int)nudCount.Value, splitted[1], object1, object2);
            }
            else
            {
                if(checkBox12.Tag == null || checkBox11.Tag == null)
                {
                    MessageBox.Show("Result or ingredient item isn't mentioned!");
                    return;
                }
                recipie = "Item.addFurnaceRecipe({0}, {1}, {2});";
                string[] splitted = checkBox11.Tag.ToString().Split('_');
                string inputId = splitted[0];
                splitted = checkBox12.Tag.ToString().Split('_');
                recipie = String.Format(recipie, inputId, splitted[0], splitted[1]);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool getItems(out Item[] items)
        {
            string[] splitted;
            if (checkBox3.Tag == null && checkBox6.Tag == null && checkBox7.Tag == null && checkBox8.Tag == null && checkBox9.Tag == null)
            {
                items = new Item[4];
                if (checkBox1.Tag != null)
                {
                    splitted = checkBox1.Tag.ToString().Split('_');
                    items[0] = new Item { id = splitted[0], data = splitted[1] };
                }
                if (checkBox2.Tag != null)
                {
                    splitted = checkBox2.Tag.ToString().Split('_');
                    items[1] = new Item { id = splitted[0], data = splitted[1] };
                }
                if (checkBox4.Tag != null)
                {
                    splitted = checkBox4.Tag.ToString().Split('_');
                    items[2] = new Item { id = splitted[0], data = splitted[1] };
                }
                if (checkBox5.Tag != null)
                {
                    splitted = checkBox5.Tag.ToString().Split('_');
                    items[3] = new Item { id = splitted[0], data = splitted[1] };
                }
                return false;
            }
            items = new Item[9];
            if (checkBox1.Tag != null)
            {
                splitted = checkBox1.Tag.ToString().Split('_');
                items[0] = new Item { id = splitted[0], data = splitted[1] };
            }
            if (checkBox2.Tag != null)
            {
                splitted = checkBox2.Tag.ToString().Split('_');
                items[1] = new Item { id = splitted[0], data = splitted[1] };
            }
            if (checkBox3.Tag != null)
            {
                splitted = checkBox3.Tag.ToString().Split('_');
                items[2] = new Item { id = splitted[0], data = splitted[1] };
            }
            if (checkBox4.Tag != null)
            {
                splitted = checkBox4.Tag.ToString().Split('_');
                items[3] = new Item { id = splitted[0], data = splitted[1] };
            }
            if (checkBox5.Tag != null)
            {
                splitted = checkBox5.Tag.ToString().Split('_');
                items[4] = new Item { id = splitted[0], data = splitted[1] };
            }
            if (checkBox6.Tag != null)
            {
                splitted = checkBox6.Tag.ToString().Split('_');
                items[5] = new Item { id = splitted[0], data = splitted[1] };
            }
            if (checkBox7.Tag != null)
            {
                splitted = checkBox7.Tag.ToString().Split('_');
                items[6] = new Item { id = splitted[0], data = splitted[1] };
            }
            if (checkBox8.Tag != null)
            {
                splitted = checkBox8.Tag.ToString().Split('_');
                items[7] = new Item { id = splitted[0], data = splitted[1] };
            }
            if (checkBox9.Tag != null)
            {
                splitted = checkBox9.Tag.ToString().Split('_');
                items[8] = new Item { id = splitted[0], data = splitted[1] };
            }
            return true;
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            ContextMenuStrip menu = item.Owner as ContextMenuStrip;
            CheckBox checkBox = menu.SourceControl as CheckBox;
            checkBox.BackgroundImage = null;
            checkBox.Tag = null;
        }
    }
}
