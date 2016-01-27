using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MinePatch
{
    public partial class Minepatch : Form
    {
        public Minepatch()
        {
            InitializeComponent();
        }
        string fl = "";
        private void Minepatch_Load(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("WARNING: MinePatch is in BETA! It means that it has some bugs and that MinePatch is not completely finished.\nMinePatch is not finished thus the limited functionality!");
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Select your Minecraft directory, ex: .minecraft";
                fbd.ShowDialog();
                if(!System.IO.Directory.Exists(fbd.SelectedPath))
                {
                    Application.Exit();
                }
                fl = fbd.SelectedPath;
                this.TopMost = true;
                if (!System.IO.Directory.Exists(fl + "\\resourcepacks\\MinePatchEditPack"))
                {
                    
                }
                else
                {
                    button1.Enabled = false;
                    button1.Text = "[CONTENT PACK IS INSTALLED]";
                }
                if (!System.IO.Directory.Exists("mp_resources"))
                {
                    MessageBox.Show("The folder mp_resources doesn't exist! It's a required component or MinePatch will NOT work!");
                    throw new Exception("");
                }
                try
                {
                    textBox6.Text = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\texts\\splashes.txt");
                }
                catch (Exception)
                {
                    
                }
                try
                {
                    textBox7.Text = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\texts\\credits.txt");
                }
                catch (Exception)
                {

                }
                try
                {
                    textBox8.Text = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\texts\\end.txt");
                }
                catch (Exception)
                {

                }
                try
                {
                    File.Copy(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\mojang.png", fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\mojanglck.png", true);
                    pictureBox5.Image = Image.FromFile(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\mojanglck.png");
                }
                catch (Exception)
                {
                    
                }
            }
            catch (Exception)
            {
                Application.Exit();
            }
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                return;
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryCopy("mp_resources\\cpack", fl + "\\resourcepacks\\MinePatchEditPack", true);
                Application.Restart();
            }
            catch (Exception)
            {
                
            }
        }
        string ln(int i)
        {
            return System.IO.File.ReadAllLines(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\lang\\en_US.lang")[i];
        }
        void set(int i,string t)
        {
            try
            {
                System.IO.File.ReadAllLines(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\lang\\en_US.lang")[i] = t;
            }
            catch (Exception)
            {
                
            }
        }
        string h = "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\lang\\en_US.lang";
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int c = 0;
                foreach(var i in System.IO.File.ReadAllLines(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\lang\\en_US.lang"))
                {
                    c = c + 1;
                    if (i.StartsWith("menu.singleplayer"))
                    {
                        if (textBox1.Text.Trim() == "") goto o;
                        string s = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\lang\\en_US.lang").Replace(i, "menu.singleplayer=" + textBox1.Text);
                        System.IO.File.WriteAllText(fl + h, s);
                    o:
                        int exc = 0;
                    }
                    if (i.StartsWith("menu.multiplayer"))
                    {
                        if (textBox2.Text.Trim() == "") goto o;
                        string s = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\lang\\en_US.lang").Replace(i, "menu.multiplayer=" + textBox2.Text);
                        System.IO.File.WriteAllText(fl + h, s);
                    o:
                        int exc = 0;
                    }
                    if (i.StartsWith("menu.online"))
                    {
                        if (textBox3.Text.Trim() == "") goto o;
                        string s = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\lang\\en_US.lang").Replace(i, "menu.online=" + textBox3.Text);
                        System.IO.File.WriteAllText(fl + h, s);
                    o:
                        int exc = 0;
                    }
                    if (i.StartsWith("menu.options"))
                    {
                        if (textBox4.Text.Trim() == "") goto o;
                        string s = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\lang\\en_US.lang").Replace(i, "menu.options=" + textBox4.Text);
                        System.IO.File.WriteAllText(fl + h, s);
                    o:
                        int exc = 0;
                    }
                    if (i.StartsWith("menu.quit"))
                    {
                        if (textBox5.Text.Trim() == "") goto o;
                        string s = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\lang\\en_US.lang").Replace(i, "menu.quit=" + textBox5.Text);
                        System.IO.File.WriteAllText(fl + h, s);
                    o:
                        int exc = 0;
                    }
                }
                MessageBox.Show("Magic Applied!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Couldn't apply the patch!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string s = fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\texts\\splashes.txt";
                System.IO.File.WriteAllText(s, textBox6.Text);
                MessageBox.Show("Magic Applied!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Couldn't apply the patch!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\texts\\splashes.txt");
            }
            catch (Exception)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox7.Text = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\texts\\credits.txt");
            }
            catch (Exception)
            {
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string s = fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\texts\\credits.txt";
                System.IO.File.WriteAllText(s, textBox7.Text);
                MessageBox.Show("Magic Applied!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Couldn't apply the patch!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text = System.IO.File.ReadAllText(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\texts\\end.txt");
            }
            catch (Exception)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string s = fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\texts\\end.txt";
                System.IO.File.WriteAllText(s, textBox8.Text);
                MessageBox.Show("Magic Applied!");
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Couldn't apply the patch!");
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                pictureBox3.Image = Image.FromFile(fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\items\\" + textBox9.Text + ".png");
            }
            catch (Exception)
            {
                
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                this.pictureBox4.Image = Properties.Resources.title;
                this.pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception)
            {
                
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.ShowDialog();
                sf.Filter = "PNG Image (*.png)|*.png";
                pictureBox4.Image.Save(sf.FileName);
            }
            catch (Exception)
            {
                
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.ShowDialog();
                textBox10.Text = opf.FileName;
                pictureBox4.Image = Image.FromFile(textBox4.Text);

            }
            catch (Exception)
            {

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(textBox10.Text))
                {
                    File.Copy(textBox10.Text, fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\minecraft.png", true);
                }
                MessageBox.Show("Magic Applied!");
            }
            catch (Exception)
            {
                MessageBox.Show("Oops!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.ShowDialog();
                pictureBox5.Image.Save(sf.FileName + ".png");

            }
            catch (Exception)
            {

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.ShowDialog();
                textBox11.Text = opf.FileName;
                

            }
            catch (Exception)
            {
                
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(textBox11.Text))
                {
                    File.Copy(textBox11.Text, fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\mojang.png", true);
                }
                MessageBox.Show("Magic Applied!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops! \n[This is a common issue and will be investigated at a later stage!]\nMore Info:\n" + ex.Message);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.ShowDialog();
                File.Copy(opf.FileName, fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\background\\panorama_0.png", true);
                MessageBox.Show("Panorama Replaced!");
                pictureBox6.Image = Image.FromFile(opf.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops!");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.ShowDialog();
                File.Copy(opf.FileName, fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\background\\panorama_1.png", true);
                MessageBox.Show("Panorama Replaced!");
                pictureBox7.Image = Image.FromFile(opf.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops!");
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.ShowDialog();
                File.Copy(opf.FileName, fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\background\\panorama_4.png", true);
                MessageBox.Show("Panorama Replaced!");
                pictureBox10.Image = Image.FromFile(opf.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops!");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.ShowDialog();
                File.Copy(opf.FileName, fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\background\\panorama_2.png", true);
                MessageBox.Show("Panorama Replaced!");
                pictureBox8.Image = Image.FromFile(opf.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops!");
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.ShowDialog();
                File.Copy(opf.FileName, fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\background\\panorama_3.png", true);
                MessageBox.Show("Panorama Replaced!");
                pictureBox9.Image = Image.FromFile(opf.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops!");
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.ShowDialog();
                File.Copy(opf.FileName, fl + "\\resourcepacks\\MinePatchEditPack\\assets\\minecraft\\textures\\gui\\title\\background\\panorama_5.png", true);
                MessageBox.Show("Panorama Replaced!");
                pictureBox11.Image = Image.FromFile(opf.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Oops!");
            }
        }
    }
}
