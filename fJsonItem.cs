using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ModPE_editor
{
    public partial class fJsonItem : Form
    {
        private string filename = null;
        private bool saved = false;

        private class Creatable
        {
            public string type;
            public string name;
            public int id;
        }

        private class Texture
        {
            public string name;
            public int meta;
            public Texture() { }
            public Texture(string name, int meta)
            {
                this.name = name; this.meta = meta;
            }
        }

        private class Item : Creatable
        {
            public Texture texture;
            public int maxStack;
        }

        private class Block : Creatable
        {
            public Texture texture;
            public int material;
            public bool opaque;
            public int renderType;
            public decimal destroyTime;
            public decimal explosionResistance;
        }

        private class Food : Creatable
        {
            public Texture texture;
            public int maxStack;
            public int restore;
        }

        private class Armor : Creatable
        {
            public Texture texture;
            public string armorType;
            public int reduceDamage;
            public int maxDamage;
            public string armorTexture;
        }

        private class Throwable : Creatable
        {
            public Texture texture;
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
            if (SaveJson()) saved = true;
        }

        private static string ObjectToJson(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        private static type JsonToObject<type>(string JSON)
        {
            return new JavaScriptSerializer().Deserialize<type>(JSON);
        }

        private bool SaveJson()
        {
            string json = "";
            string name = "";
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
                    name = item.name;
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
                    name = block.name;
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
                    name = food.name;
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
                    name = armor.name;
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
                    name = throwable.name;
                    break;
            }

            MessageBox.Show(json);
            try
            {
                string path = ProgramData.Folder + "\\images\\items\\" + name + ".json";
                if (!Directory.Exists(ProgramData.Folder + "\\images\\items\\"))
                    Directory.CreateDirectory(ProgramData.Folder + "\\images\\items\\");
                File.WriteAllText(path, json);
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
                obj = JsonToObject<Creatable>(JSON);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to  open JSON");
                return;
            }
            switch (obj.type)
            {
                case "item":
                    for (int i = 1; i < 5; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[1]);
                    Item item = JsonToObject<Item>(JSON);
                    item_name.Text = item.name;
                    item_id.Value = item.id;
                    item_icon.Text = item.texture.name;
                    item_index.Value = item.texture.meta;
                    item_stack.Value = item.maxStack;
                    item_name.Enabled = false;
                    break;
                case "block":
                    tcMain.TabPages.Remove(tcMain.TabPages[0]);
                    for (int i = 1; i < 4; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[1]);
                    Block block = JsonToObject<Block>(JSON);
                    block_name.Text = block.name;
                    block_id.Value = block.id;
                    block_texture.Text = block.texture.name;
                    block_index.Value = block.texture.meta;
                    block_material.Value = block.material;
                    block_opaque.Text = block.opaque.ToString();
                    block_render.Value = block.renderType;
                    block_destroy.Value = block.destroyTime;
                    block_explosion.Value = block.explosionResistance;
                    block_name.Enabled = false;
                    break;
                case "food":
                    for (int i = 0; i < 2; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[0]);
                    for (int i = 1; i < 3; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[1]);
                    Food food = JsonToObject<Food>(JSON);
                    food_name.Text = food.name;
                    food_id.Value = food.id;
                    food_icon.Text = food.texture.name;
                    food_index.Value = food.texture.meta;
                    food_stack.Value = food.maxStack;
                    food_restore.Value = food.restore;
                    food_name.Enabled = false;
                    break;
                case "armor":
                    for (int i = 0; i < 3; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[0]);
                    tcMain.TabPages.Remove(tcMain.TabPages[1]);
                    Armor armor = JsonToObject<Armor>(JSON);
                    armor_name.Text = armor.name;
                    armor_id.Value = armor.id;
                    armor_icon.Text = armor.texture.name;
                    armor_index.Value = armor.texture.meta;
                    armor_type.Text = armor.armorType;
                    armor_reduce.Value = armor.reduceDamage;
                    armor_max.Value = armor.maxDamage;
                    armor_texture.Text = armor.armorTexture;
                    armor_name.Enabled = false;
                    break;
                case "throwable":
                    for (int i = 0; i < 4; i++)
                        tcMain.TabPages.Remove(tcMain.TabPages[0]);
                    Throwable throwable = JsonToObject<Throwable>(JSON);
                    throwable_name.Text = throwable.name;
                    throwable_id.Value = throwable.id;
                    throwable_icon.Text = throwable.texture.name;
                    throwable_index.Value = throwable.texture.meta;
                    throwable_stack.Value = throwable.maxStack;
                    throwable_name.Enabled = false;
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
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; ;
                }
            }
        }
    }
}
