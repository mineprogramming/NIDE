using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NIDE;
using System.IO;

namespace NIDE.ProjectTypes.ZCore
{
    public partial class FModInfo : Form
    {
        private ModInfo info;
        private string filename;

        public FModInfo(string filename, string name = "", string author = "")
        {
            InitializeComponent();
            this.filename = filename;
            try
            {
                string json = File.ReadAllText(filename);
                info = json.ToObject<ModInfo>();
                if (info == null)
                    throw new Exception();
            }
            catch (Exception e)
            {
                info = new ModInfo(name, author, "1.0", "");
            }
            TbName.Text = info.name;
            TbAuthor.Text = info.author;
            TbVersion.Text = info.version;
            TbDescription.Text = info.description;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            info.name = TbName.Text;
            info.author = TbAuthor.Text;
            info.version = TbVersion.Text;
            info.description = TbDescription.Text;
            string json = info.ToJson();
            File.WriteAllText(filename, json);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private class ModInfo
        {
            public string name;
            public string author;
            public string version;
            public string description;

            public ModInfo() { }

            public ModInfo(string name, string author, string version, string description)
            {
                this.name = name;
                this.author = author;
                this.version = version;
                this.description = description;
            }            
        }
    }
}
