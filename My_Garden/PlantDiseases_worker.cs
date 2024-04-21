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
    public partial class PlantDiseases_worker : Form
    {
        PlantController controller;
        List<string> diseases = new List<string>();
        private int index;
        private string destinationFolder = Path.Combine(Application.StartupPath, "PlantImages");
        private string diseaseImage;
        private string cureImage;

        public PlantDiseases_worker()
        {
            InitializeComponent();
            controller = new PlantController();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MainWorkerForm mainWorkerForm = new MainWorkerForm();
            Hide();
            mainWorkerForm.ShowDialog();
            Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex>=0)
            {
                index = listBox1.SelectedIndex;
                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox2.Text = controller.GetDisease(index).Description;
                textBox3.Text = controller.GetDisease(index).Cure;
                diseaseImage = controller.GetDisease(index).Image;
                cureImage = controller.GetDisease(index).CureImage;
                pictureBox2.Image = Image.FromFile(diseaseImage);
                pictureBox3.Image = Image.FromFile(cureImage);
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = false;
                button5.Visible = false;
            }
        }

        private void PlantDiseases_worker_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            pictureBox1.Visible = false;
            pictureBox4.Visible = false;
            pictureBox2.Image = Image.FromFile(Path.Combine(destinationFolder, "noImageFound.png"));
            pictureBox3.Image = Image.FromFile(Path.Combine(destinationFolder, "noImageFound.png"));
            listBox1.SelectedIndex = -1;
            diseases = controller.AllDiseasesNames();
            if (diseases.Count != 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(diseases.ToArray());
            }
            else MessageBox.Show("No diseases found, click the add button below to make a new one", "Diseases");
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
                diseaseImage = destinationPath;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
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
                pictureBox3.Image = Image.FromFile(destinationPath);
                cureImage = destinationPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox4.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please, add disease name and description information first.","Diseases");
            }
            else
            {
                if (diseaseImage == null) diseaseImage = Path.Combine(destinationFolder, "noImageFound.png");
                if (cureImage == null) cureImage = Path.Combine(destinationFolder, "noImageFound.png");
                AddDiseaseViewModel addDiseaseViewModel = new AddDiseaseViewModel()
                {
                    Name = textBox1.Text,
                    Description = textBox2.Text,
                    Image = diseaseImage, 
                    Cure = textBox3.Text,
                    CureImage = cureImage
                };
                controller.AddDisease(addDiseaseViewModel);
                PlantDiseases_worker_Load(sender, e);
            }
        }
    }
}
