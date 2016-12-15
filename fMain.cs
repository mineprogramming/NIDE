using FastColoredTextBoxNS;
using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using Yahoo.Yui.Compressor;
using System.Drawing;
using System.Diagnostics;
using Microsoft.Win32;
using System.Linq;

namespace ModPE_editor
{
    public partial class fMain : Form
    {
        bool saved = true;
        string file = "";
        string folder = "";
        XmlDocument xml;

        public fMain(string[] args)
        {
            InitializeComponent();
            CodeAnalysisEngine.Initialize(fctbMain);
            LoadWindow();
            fctbMain.Language = Language.JS;
            Autocomplete.SetAutoompleteMenu(fctbMain);
            fctbMain.HighlightingRangeType = HighlightingRangeType.VisibleRange;
            try
            {
                ModPe.LoadModPeData("modpescript_dump.txt");
                CoreEngine.LoadCoreEngineData("core.dump");
            }
            catch
            {
                MessageBox.Show("Unable to load ModPE data. Check if modpescript_dump.txt exists, availiable and correct");
            }
            if (args.Length > 0)
            {
                try
                {
                    file = args[1];
                    fctbMain.OpenFile(file, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to load file: " + ex.Message);
                }
            }
        }

        private void fctbMain_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (fctbMain.Language == Language.JS)
            {
                Highlighting.ResetStyles(e.ChangedRange);
                CodeAnalysisEngine.Update();
            }
            saved = false;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWindow();
            e.Cancel = !BeforeClosingFile();
        }

        private void tvFolders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string nodeName = e.Node.Text;
            if (nodeName.IndexOf('.') != -1)
            {
                string[] splitted = nodeName.Split('.');
                string ext = splitted[splitted.Length - 1].ToLower();
                string path = e.Node.FullPath;
                if (ext == "png")
                {
                    fPngEditor editor = new fPngEditor(path);
                    editor.ShowDialog();
                }
                else if (ext == "js")
                {
                    if (BeforeClosingFile())
                        LoadJS(path);
                }
                else if (ext == "xml")
                {
                    fctbMain.Language = Language.XML;
                    if (BeforeClosingFile())
                        LoadXML(path);
                }
            }
        }

        private void tsmiNewScript_Click(object sender, EventArgs e)
        {
            var dlgFileName = new fDialog();
            if (dlgFileName.ShowDialog() == DialogResult.OK)
            {
                string name = dlgFileName.FileName;
                if (!name.ToLower().Contains(".js"))
                    name = name + ".js";
                if (ProgramData.Mode == WorkMode.CORE_ENGINE)
                {
                    CreateFile("dev\\" + name);
                    File.AppendAllLines(folder + "\\dev\\.includes", new string[] { name });
                }
                else
                {
                    CreateFile("script\\" + name);
                }
                LoadDiretories();
            }
        }

        private void tsmiNewTexture_Click(object sender, EventArgs e)
        {
            var dlgFileName = new fDialog(true);
            if (dlgFileName.ShowDialog() == DialogResult.OK)
            {
                Bitmap png = new Bitmap(16, 16);
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        png.SetPixel(i, j, Color.Transparent);
                    }
                }
                string name = dlgFileName.FileName;
                if (!name.ToLower().Contains(".png"))
                    name = name + ".png";
                string path = folder + (ProgramData.Mode == WorkMode.MODPKG ? "\\images\\" : "\\assets\\") + (dlgFileName.Type == ImageType.ITEMS_OPAQUE ? "items-opaque" : "terrain-atlas");
                png.Save(path + "\\" + name);
                LoadDiretories();
            }
        }

        private void tsmiDeleteTexture_Click(object sender, EventArgs e)
        {
            string path = tvFolders.SelectedNode.FullPath;
            if (path.IndexOf('.') != -1)
            {
                File.Delete(path);
                LoadDiretories();

            }
        }

        private void tsmiCoreEngineDocs_Click(object sender, EventArgs e)
        {
            Process.Start("CoreEngine help.chm");
        }

        //util
        private void LoadDiretories()
        {
            tvFolders.Nodes.Clear();
            DirectoryRecursive(tvFolders.Nodes.Add(folder), new DirectoryInfo(folder));
            tvFolders.Nodes[0].Expand();
        }

        private void DirectoryRecursive(TreeNode node, DirectoryInfo dir)
        {
            try
            {
                var dirs = dir.GetDirectories();
                var files = dir.GetFiles();
                foreach (var subdir in dirs)
                    DirectoryRecursive(AddNode(node, subdir.Name), subdir);
                foreach (var file in files)
                    AddNode(node, file.Name);
            }
            catch
            {
            }
        }

        private TreeNode AddNode(TreeNode node, string text)
        {
            return node.Nodes.Add(text);
        }

        private void CreateFile(string PathRelative)
        {
            File.Create(folder + "\\" + PathRelative).Close();
        }

        private void CreateDirectory(string PathRelative)
        {
            Directory.CreateDirectory(folder + "\\" + PathRelative);
        }

        //textworking
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            fctbMain.Undo();
        }

        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            fctbMain.Redo();
        }

        private void tsmiFind_Click(object sender, EventArgs e)
        {
            fctbMain.ShowFindDialog();
        }

        private void tsmiReplace_Click(object sender, EventArgs e)
        {
            fctbMain.ShowReplaceDialog();
        }

        private void ctsmiAutoIndent_Click(object sender, EventArgs e)
        {
            fctbMain.DoAutoIndent();
        }

        private void tsmiComment_Click(object sender, EventArgs e)
        {
            fctbMain.CommentSelected();
        }

        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            fctbMain.SelectAll();
        }

        private void tsmiAutocompleteItems_Click(object sender, EventArgs e)
        {
            var itemsList = new fAutocompleteItems();
            itemsList.ShowDialog();
        }

        //fileworking
        private void tsmiOpenRecent_Click(object sender, EventArgs e)
        {
            fRecentItems items = new fRecentItems();
            if (items.ShowDialog() == DialogResult.OK)
                if (BeforeClosingFile() && LoadFile(fRecentItems.Path))
                {
                    saved = true;
                }
        }

        private void tsmiNewJS_Click(object sender, EventArgs e)
        {
            if (BeforeClosingFile() && CreateJS())
            {
                tvFolders.Visible = false;
                ProgramData.Mode = WorkMode.JAVASCRIPT;
            }
        }

        private void tsmiNewJSFromModel_Click(object sender, EventArgs e)
        {
            tsmiNewJS_Click(sender, e);
            LoadModel();
        }

        private void tsmiOpenJS_Click(object sender, EventArgs e)
        {
            if (BeforeClosingFile() && LoadJS())
            {
                tvFolders.Visible = false;
                ProgramData.Mode = WorkMode.JAVASCRIPT;
                saved = true;
            }
        }

        private void tsmiNewModpkg_Click(object sender, EventArgs e)
        {
            if (BeforeClosingFile() && CreateModpkg())
            {
                ProgramData.Mode = WorkMode.MODPKG;
            }
        }

        private void tsmiNewModpkgFromModel_Click(object sender, EventArgs e)
        {
            tsmiNewModpkg_Click(sender, e);
            LoadModel();
        }

        private void tsmiOpenModpkg_Click(object sender, EventArgs e)
        {
            if (BeforeClosingFile() && LoadModpkg())
            {
                ProgramData.Mode = WorkMode.MODPKG;
                saved = true;
            }
        }

        private void tsmiNewCoreEngine_Click(object sender, EventArgs e)
        {
            if (BeforeClosingFile() && CreateCoreEngine())
            {
                ProgramData.Mode = WorkMode.CORE_ENGINE;
            }
        }

        private void tsmiOpenCoreEngine_Click(object sender, EventArgs e)
        {
            if (BeforeClosingFile() && LoadCoreEngine())
            {
                ProgramData.Mode = WorkMode.CORE_ENGINE;
                saved = true;
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            saved = Save();
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            string _file = file, _folder = folder;
            file = ""; folder = "";
            saved = Save();
            if (!saved)
            {
                file = _file; folder = _folder;
            }
        }


        private bool LoadModel()
        {
            dlgOpen.InitialDirectory = Directory.GetCurrentDirectory() + "\\models";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fctbMain.OpenFile(dlgOpen.FileName);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else return false;
        }

        private bool BeforeClosingFile()
        {
            if (saved || fctbMain.Text == "")
                return true;
            var result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                return Save();
            }
            else if (result == DialogResult.No)
            {
                return true;
            }
            else return false;
        }

        private bool InitJS()
        {
            fctbMain.Language = Language.JS;
            fctbMain.Refresh();
            return true;
        }

        private bool InitXML()
        {
            fctbMain.Language = Language.XML;
            tvFolders.Visible = false;
            return true;
        }

        private bool InitModpkg()
        {
            try
            {
                file = folder + "\\script\\main.js";
                fctbMain.OpenFile(file, Encoding.UTF8);
                CodeAnalysisEngine.Update();
                tvFolders.Visible = true;
                xml = new XmlDocument();
                if (!File.Exists(folder + "\\projet_info.xml"))
                {
                    xml.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><settings></settings>");
                    XmlElement el = xml.CreateElement("pack");
                    el.InnerText = "true";
                    xml.DocumentElement.AppendChild(el);
                    xml.Save(folder + "\\projet_info.xml");
                }
                else
                {
                    xml.Load(folder + "\\projet_info.xml");
                }
                LoadDiretories();
                fctbMain.Language = Language.JS;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to load .modpkg");
                return false;
            }
        }

        private bool InitCoreEngine()
        {
            try
            {
                file = folder + "\\main.js";
                fctbMain.OpenFile(file, Encoding.UTF8);
                CodeAnalysisEngine.Update();
                tvFolders.Visible = true;
                LoadDiretories();
                fctbMain.Language = Language.JS;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to load CoreEngine project");
                return false;
            }
        }

        private bool CreateJS()
        {
            if (BeforeClosingFile())
            {
                file = "";
                fctbMain.Clear();
                return InitJS();
            }
            return false;
        }

        private bool CreateModpkg()
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    folder = dlgFolder.SelectedPath;
                    Directory.CreateDirectory(folder + "\\images\\items-opaque");
                    Directory.CreateDirectory(folder + "\\images\\terrain-atlas");
                    Directory.CreateDirectory(folder + "\\script");
                    File.Create(folder + "\\script\\main.js").Close();
                    return InitModpkg();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Cannot create .modpkg");
                    return false;
                }
            }
            else return false;
        }

        private bool CreateCoreEngine()
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    folder = dlgFolder.SelectedPath;
                    CreateFile("main.js");
                    CreateFile("launcher.js");
                    CreateFile("mod.info");
                    CreateFile("resources.zip");
                    CreateDirectory("gui");
                    CreateDirectory("dev");
                    CreateDirectory("assets\\items-opaque");
                    CreateDirectory("assets\\terrain-atlas");
                    CreateFile("dev\\.includes");
                    return InitCoreEngine();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Cannot create CoreEngine project");
                    return false;
                }
            }
            else return false;
        }

        private bool LoadJS()
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                return LoadJS(dlgOpen.FileName);
            }
            else return false;
        }

        private bool LoadJS(string path)
        {
            try
            {
                file = path;
                fctbMain.OpenFile(file, Encoding.UTF8);
                CodeAnalysisEngine.Update();
                return InitJS();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to load file");
                return false;
            }
        }

        private bool LoadXML(string path)
        {
            try
            {
                file = path;
                fctbMain.OpenFile(file, Encoding.UTF8);
                return InitJS();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to load file");
                return false;
            }
        }

        private bool LoadModpkg()
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                return LoadModpkg(dlgFolder.SelectedPath);
            }
            else return false;
        }

        private bool LoadModpkg(string path)
        {
            if (File.Exists(path + "\\script\\main.js"))
            {
                folder = path;
                return InitModpkg();
            }
            else
            {
                MessageBox.Show("This folder isn't a modpkg!");
                return false;
            }
        }

        private bool LoadCoreEngine()
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                return LoadCoreEngine(dlgFolder.SelectedPath);
            }
            else return false;
        }

        private bool LoadCoreEngine(string path)
        {
            if (File.Exists(path + "\\main.js") &&
                File.Exists(path + "\\dev\\.includes") &&
                File.Exists(path + "\\launcher.js") &&
                File.Exists(path + "\\mod.info"))
            {
                folder = path;
                return InitCoreEngine();
            }
            else
            {
                MessageBox.Show("This folder isn't a CoreEngine project!");
                return false;
            }
        }

        private bool LoadFile(string path)
        {
            if (path.Split('\\').Last().Contains("."))
            {
                ProgramData.Mode = WorkMode.JAVASCRIPT;
                tvFolders.Visible = false;
                return LoadJS(path);
            }
            else if (Directory.GetDirectories(path).Contains(path + "\\script"))
            {
                ProgramData.Mode = WorkMode.MODPKG;
                tvFolders.Visible = true;
                return LoadModpkg(path);
            }
            else
            {
                ProgramData.Mode = WorkMode.CORE_ENGINE;
                tvFolders.Visible = true;
                return LoadCoreEngine(path);
            }
        }

        private bool SaveJS()
        {
            if (file == "")
            {
                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    file = dlgSave.FileName;
                }
                else return false;
            }
            try
            {
                fctbMain.SaveToFile(file, Encoding.UTF8);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to save JS");
                return false;
            }
        }

        private bool SaveModpkg()
        {
            if (folder == "")
            {
                if (dlgFolder.ShowDialog() == DialogResult.OK)
                {
                    folder = dlgFolder.SelectedPath;
                }
                else return false;
            }
            try
            {
                fctbMain.SaveToFile(file, Encoding.UTF8);
                if (xml.GetElementsByTagName("pack")[0].InnerText == "true")
                {
                    JavaScriptCompressor compressor = new JavaScriptCompressor();
                    File.WriteAllText(file, compressor.Compress(fctbMain.Text), Encoding.UTF8);
                }
                using (ZipFile zip = new ZipFile())
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
                    zip.AddDirectoryByName("images");
                    zip.AddDirectoryByName("script");
                    zip.AddDirectory(folder + "\\images", "images");
                    zip.AddDirectory(folder + "\\script", "script");
                    zip.Save(folder + "\\" + new DirectoryInfo(folder).Name + ".modpkg");
                }
                fctbMain.SaveToFile(file, Encoding.UTF8);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to save .modpkg");
                return false;
            }
        }

        private bool SaveCoreEngine()
        {
            try
            {
                fctbMain.SaveToFile(file, Encoding.UTF8);
                using (ZipFile zip = new ZipFile())
                {
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
                    zip.AddDirectory(folder + "\\assets");
                    zip.Save(folder + "\\" + "resources.zip");
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Unable to save CoreEngine");
                return false;
            }
        }

        private bool Save()
        {
            if (ProgramData.Mode == WorkMode.MODPKG)
                return SaveModpkg();
            else if (ProgramData.Mode == WorkMode.JAVASCRIPT)
                return SaveJS();
            else if (ProgramData.Mode == WorkMode.CORE_ENGINE)
                return SaveCoreEngine();
            else return false;
        }

        //save
        private bool SaveWindow()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                key = key.CreateSubKey("ModPE");
                key.SetValue("maximized", WindowState == FormWindowState.Maximized);
                key.SetValue("Width", Width.ToString());
                key.SetValue("Height", Height.ToString());
                key.SetValue("dvWidth", tvFolders.Width.ToString());
                if (file != "" && !ProgramData.Recent.Contains(file))
                {
                    for (int i = ProgramData.Recent.Count() - 1; i > 0; i--)
                        ProgramData.Recent[i] = ProgramData.Recent[i - 1];
                    ProgramData.Recent[0] = ProgramData.Mode == WorkMode.JAVASCRIPT ? file : folder;
                }
                for (int i = 0; i < ProgramData.Recent.Count(); i++)
                    key.SetValue("Save" + i, ProgramData.Recent[i]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cannot save window properties");
                return false;
            }
            return true;
        }

        private bool LoadWindow()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                if (!key.GetSubKeyNames().Contains("ModPE"))
                    return false;
                key = key.OpenSubKey("ModPE");
                Width = Convert.ToInt32(key.GetValue("Width"));
                Height = Convert.ToInt32(key.GetValue("Height"));
                tvFolders.Width = Convert.ToInt32(key.GetValue("dvWidth"));
                if (key.GetSubKeyNames().Contains("maximized"))
                    WindowState = Convert.ToBoolean(key.GetValue("maximized")) ? FormWindowState.Maximized : FormWindowState.Normal;
                for (int i = 0; i < ProgramData.Recent.Count(); i++)
                    ProgramData.Recent[i] = Convert.ToString(key.GetValue("Save" + i));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cannot load window properties");
                return false;
            }
            return true;
        }

        //debugger
        private void tsmiRun_Click(object sender, EventArgs e)
        {

        }

    }
}