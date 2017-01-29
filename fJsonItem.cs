using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace NIDE
{
    public partial class fJsonItem : Form
    {
        public static string name;
        private string filename = null;
        private bool saved = false;

        private class Item : Creatable
        {
            public int maxStack;
        }

        private class Block : Creatable
        {
            public int material;
            public bool opaque;
            public int renderType;
            public decimal destroyTime;
            public decimal explosionResistance;
        }

        private class Food : Creatable
        {
            public int maxStack;
            public int restore;
        }

        private class Armor : Creatable
        {
            public string armorType;
            public int reduceDamage;
            public int maxDamage;
            public string armorTexture;
        }

        private class Throwable : Creatable
        {
            public int maxStack;
        }

        public fJsonItem()
        {
            InitializeComponent();
        }

        public fJsonItem(string filename)
        {
            this.filename = filename;
            InitializeComponent();
            if (filename != null)
            {
                LoadFromJson();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (SaveJson())
            {
                saved = true;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private static string ObjectToJson(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        private bool SaveJson()
        {
            string json = "";
            if (tbFilename.Text == "")
            {
                MessageBox.Show("All fileds have to be comleted");
                return false;
            }
            switch (tcMain.SelectedTab.Text)
            {
                case "Item":
                    if (item_name.Text == "" || item_icon.Text == "")
                    {
                        MessageBox.Show("All fileds have to be comleted");
                        return false;
                    }
                    Item item = new Item
                    {
                        type = "item",
                        name = item_name.Text,
                        id = (int)item_id.Value,
                        texture = new Texture(item_icon.Text, (int)item_index.Value),
                        maxStack = (int)item_stack.Value
                    };
                    json = ObjectToJson(item);
                    break;
                case "Block":
                    if (block_name.Text == "" || block_texture.Text == "")
                    {
                        MessageBox.Show("All fileds have to be comleted");
                        return false;
                    }
                    Block block = new Block
                    {
                        type = "block",
                        name = block_name.Text,
                        id = (int)block_id.Value,
                        texture = new Texture(block_texture.Text, (int)block_index.Value),
                        material = (int)block_material.Value,
                        opaque = block_opaque.Text == "true",
                        renderType = (int)block_render.Value,
                        destroyTime = block_destroy.Value,
                        explosionResistance = block_explosion.Value
                    };
                    json = ObjectToJson(block);
                    break;
                case "Food":
                    if (food_name.Text == "" || food_icon.Text == "")
                    {
                        MessageBox.Show("All fileds have to be comleted");
                        return false;
                    }
                    Food food = new Food
                    {
                        type = "food",
                        name = food_name.Text,
                        id = (int)food_id.Value,
                        texture = new Texture(food_icon.Text, (int)food_index.Value),
                        maxStack = (int)food_stack.Value,
                        restore = (int)food_restore.Value
                    };
                    json = ObjectToJson(food);
                    break;
                case "Armor":
                    if (armor_name.Text == "" || armor_icon.Text == "" || armor_texture.Text == "")
                    {
                        MessageBox.Show("All fileds have to be comleted");
                        return false;
                    }
                    Armor armor = new Armor
                    {
                        type = "armor",
                        name = armor_name.Text,
                        id = (int)armor_id.Value,
                        texture = new Texture(armor_icon.Text, (int)armor_index.Value),
                        armorType = armor_type.Text,
                        reduceDamage = (int)armor_reduce.Value,
                        maxDamage = (int)armor_max.Value,
                        armorTexture = armor_texture.Text
                    };
                    json = ObjectToJson(armor);
                    break;
                case "Throwable":
                    if (throwable_name.Text == "" || throwable_icon.Text == "")
                    {
                        MessageBox.Show("All fileds have to be comleted");
                        return false;
                    }
                    Throwable throwable = new Throwable
                    {
                        type = "throwable",
                        name = throwable_name.Text,
                        id = (int)throwable_id.Value,
                        texture = new Texture(throwable_icon.Text, (int)throwable_index.Value),
                        maxStack = (int)throwable_stack.Value
                    };
                    json = ObjectToJson(throwable);
                    break;
            }
            name = tbFilename.Text;
            try
            {
                filename = ProgramData.ProjectManager.OtherResourcesPath + name + ".json";
                File.WriteAllText(filename, json);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to save item description");
                return false;
            }
            return true;
        }

        private void LoadFromJson()
        {
            string JSON;
            Creatable obj;
            try
            {
                JSON = File.ReadAllText(filename);
                obj = JSON.ToObject<Creatable>();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to  open JSON");
                return;
            }
            tbFilename.Enabled = false;
            string[] splitted = filename.Split('\\');
            splitted = splitted[splitted.Length - 1].Split('.');
            tbFilename.Text = splitted[0];
            switch (obj.type)
            {
                case "item":
                    for (int i = 1; i < 5; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[1]);
                    Item item = JSON.ToObject<Item>();
                    item_name.Text = item.name;
                    item_id.Value = item.id;
                    item_icon.Text = item.texture.name;
                    item_index.Value = item.texture.meta;
                    item_stack.Value = item.maxStack;
                    break;
                case "block":
                    tcMain.TabPages.Remove(tcMain.TabPages[0]);
                    for (int i = 1; i < 4; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[1]);
                    Block block = JSON.ToObject<Block>();
                    block_name.Text = block.name;
                    block_id.Value = block.id;
                    block_texture.Text = block.texture.name;
                    block_index.Value = block.texture.meta;
                    block_material.Value = block.material;
                    block_opaque.Text = block.opaque.ToString();
                    block_render.Value = block.renderType;
                    block_destroy.Value = block.destroyTime;
                    block_explosion.Value = block.explosionResistance;
                    break;
                case "food":
                    for (int i = 0; i < 2; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[0]);
                    for (int i = 1; i < 3; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[1]);
                    Food food = JSON.ToObject<Food>();
                    food_name.Text = food.name;
                    food_id.Value = food.id;
                    food_icon.Text = food.texture.name;
                    food_index.Value = food.texture.meta;
                    food_stack.Value = food.maxStack;
                    food_restore.Value = food.restore;
                    break;
                case "armor":
                    for (int i = 0; i < 3; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[0]);
                    tcMain.TabPages.Remove(tcMain.TabPages[1]);
                    Armor armor = JSON.ToObject<Armor>();
                    armor_name.Text = armor.name;
                    armor_id.Value = armor.id;
                    armor_icon.Text = armor.texture.name;
                    armor_index.Value = armor.texture.meta;
                    armor_type.Text = armor.armorType;
                    armor_reduce.Value = armor.reduceDamage;
                    armor_max.Value = armor.maxDamage;
                    armor_texture.Text = armor.armorTexture;
                    break;
                case "throwable":
                    for (int i = 0; i < 4; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[0]);
                    Throwable throwable = JSON.ToObject<Throwable>();
                    throwable_name.Text = throwable.name;
                    throwable_id.Value = throwable.id;
                    throwable_icon.Text = throwable.texture.name;
                    throwable_index.Value = throwable.texture.meta;
                    throwable_stack.Value = throwable.maxStack;
                    break;
            }
        }

        private void SomethingChanged(object sender, EventArgs e)
        {
            saved = false;
        }

        private void fJsonItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                var result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = !SaveJson();
                    if (e.Cancel)
                        DialogResult = DialogResult.Cancel;
                    else
                        DialogResult = DialogResult.OK;
                }
                else if (result == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.Cancel;
                    e.Cancel = true; ;
                }
            }
        }
    }
}

class Creatable
{
    public string type;
    public string name;
    public int id;
    public Texture texture;
}

class Texture
{
    public string name;
    public int meta;
    public Texture() { }
    public Texture(string name, int meta)
    {
        this.name = name; this.meta = meta;
    }
}
