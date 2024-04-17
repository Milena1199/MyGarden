using MyGarden.Core.Controllers;
using MyGarden.Core.Models;
using MyGarden.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Garden
{
    public partial class PlantStyles_worker : Form
    {
        private string destinationFolder = Path.Combine(Application.StartupPath, "PlantImages");
        private PlantController controller;
        private string image;
        private int index;
        List<string> styles;
        public PlantStyles_worker()
        {
            InitializeComponent();
            this.controller = new PlantController();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MainWorkerForm mainWorkerForm = new MainWorkerForm();
            Hide();
            mainWorkerForm.ShowDialog();
            Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            openFileDialog.Title = "Select an image file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string file = Path.GetFileName(filePath);
                string destinationPath = Path.Combine(destinationFolder, file);
                if (File.Exists(destinationPath) == false)
                {
                    File.Copy(filePath, destinationPath);
                }
                pictureBox2.Image = Image.FromFile(destinationPath);
                image = destinationPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            pictureBox1.Visible = true;
            pictureBox2.Image = Image.FromFile(Path.Combine(destinationFolder, "noImageFound.png"));
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            image = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") MessageBox.Show("Please, fill in all of the information first.", "Styles");
            else
            {
                if (image == null) image = Path.Combine(destinationFolder, "noImageFound.png");
                AddStyleViewModel addStyleViewModel = new AddStyleViewModel()
                {
                    Name = textBox1.Text,
                    Description = textBox2.Text,
                    ImagePath = image
                };
                controller.AddStyle(addStyleViewModel);
                PlantStyles_worker_Load(sender, e);
            }
        }

        private void PlantStyles_worker_Load(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox1.Visible = false;
            pictureBox2.Image = Image.FromFile(Path.Combine(destinationFolder, "noImageFound.png"));
            listBox1.SelectedIndex = -1;
            styles = controller.ShowStyleNames();
            if (styles.Count != 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(styles.ToArray());
            }
            else MessageBox.Show("No garden styles were found. Click the add button to make one.", "Garden styles");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                index = listBox1.SelectedIndex;
                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox2.Text = controller.GetStyleDescription(index);
                pictureBox2.Image = Image.FromFile(controller.GetImagePathForStyle(index));
                image = controller.GetImagePathForStyle(index);
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox2.Image = Image.FromFile(Path.Combine(destinationFolder, "noImageFound.png"));
            image = null;
            listBox1.Items.Remove(listBox1.Items[index]);
            listBox1.SelectedIndex = -1;
            controller.DeleteStyle(index);
            PlantStyles_worker_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            pictureBox1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateStyleViewModel updateStyleViewModel = new UpdateStyleViewModel()
            {
                Index = index,
                Name = textBox1.Text,
                Description = textBox2.Text,
                ImagePath = image
            };
            controller.UpdateStyle(updateStyleViewModel);
            PlantStyles_worker_Load(sender,e);
        }
    }
}
