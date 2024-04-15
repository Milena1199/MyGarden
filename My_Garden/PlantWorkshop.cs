using MyGarden.Core.Controllers;
using MyGarden.Core.Models;
using MyGarden.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Garden
{
    public partial class PlantWorkshop : Form
    {
        List<Plant> plants;
        PlantController controller;
        public static Guid plantid;
        public static List<string> images;
        public PlantWorkshop()
        {
            InitializeComponent();
            this.controller = new PlantController();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PlantWorkshop_Load(object sender, EventArgs e)
        {
            plants = controller.FindAllPlants();
            images = new List<string>();
            if (plants.Count == 0)
            {
                if (MessageBox.Show("There are no plants found, do you wish to add a new one", "Plant workshop", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //add1
                    foreach (Control control in Controls)
                    {
                        if (control.Tag == "info") control.Enabled = true;
                    }
                    foreach (Control control in panel1.Controls)
                    {
                        if (control.Tag == "info") control.Enabled = true;
                    }
                    label17.Visible = false;
                    pictureBox4.Visible = false;
                    label18.Visible = false;
                    pictureBox5.Visible = false;
                    label19.Visible = true;
                    pictureBox6.Visible = true;
                }
                else
                {
                    MainWorkerForm mainWorkerForm = new MainWorkerForm();
                    Hide();
                    mainWorkerForm.ShowDialog();
                    Close();
                }
            }
            else
            {
                foreach (Plant plant in plants)
                {
                    listBox1.Items.Add(plant.Name);
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MainWorkerForm mainWorkerForm = new MainWorkerForm();
            Hide();
            mainWorkerForm.ShowDialog();
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here you can add, edit, and delete flowers", "Plant workshop");
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddOrUpdateTypeForm addOrUpdate = new AddOrUpdateTypeForm();
            Hide();
            addOrUpdate.ShowDialog();
            Close();
        }
        //add1
        private void label17_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control.Tag == "info") control.Enabled = true;
            }
            foreach (Control control in panel1.Controls)
            {
                if (control.Tag == "info") control.Enabled = true;
            }
            label17.Visible = false;
            pictureBox4.Visible = false;
            label18.Visible = false;
            pictureBox5.Visible = false;
            label19.Visible = true;
            pictureBox6.Visible = true;
        }
        //add1
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control.Tag == "info") control.Enabled = true;
            }
            foreach (Control control in panel1.Controls)
            {
                if (control.Tag == "info") control.Enabled = true;
            }
            label17.Visible = false;
            pictureBox4.Visible = false;
            label18.Visible = false;
            pictureBox5.Visible = false;
            label19.Visible = true;
            pictureBox6.Visible = true;
        }
        //add2
        private void label19_Click(object sender, EventArgs e)
        {
            //add validation not null 
            AddPlantViewModel addPlantViewModel = new AddPlantViewModel()
            {
                Name = textBox1.Text,
                HowToPlant = textBox2.Text,
                SeasonOfInteret = textBox3.Text,
                Characteristics = textBox4.Text,
                ClimateZone = comboBox1.SelectedItem.ToString(),
                HardinessZone = Convert.ToInt32(numericUpDown1.Value),
                SoilType = comboBox2.SelectedItem.ToString(),
                Мaintenance = textBox5.Text,
                LenghtOfLife = textBox6.Text,
                MoreInfo = textBox8.Text,
                Price = decimal.Parse(textBox7.Text)
            };
            foreach (string image in images)
            {
                AddImageForPlantViewModel addImageForPlantViewModel = new AddImageForPlantViewModel()
                {
                    PlantId = plantid,
                    Url = image
                };
                controller.AddImage(addImageForPlantViewModel);
            }
        }
        //add2
        private void picturebox6_Click(object sender, EventArgs e)
        {
            //add validation
            AddPlantViewModel addPlantViewModel = new AddPlantViewModel()
            {
                Name = textBox1.Text,
                HowToPlant = textBox2.Text,
                SeasonOfInteret = textBox3.Text,
                Characteristics = textBox4.Text,
                ClimateZone = comboBox1.SelectedItem.ToString(),
                HardinessZone = Convert.ToInt32(numericUpDown1.Value),
                SoilType = comboBox2.SelectedItem.ToString(),
                Мaintenance = textBox5.Text,
                LenghtOfLife = textBox6.Text,
                MoreInfo = textBox8.Text,
                Price = decimal.Parse(textBox7.Text)
            };
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            plantid = controller.FindPlant(listBox1.SelectedIndex);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (plantid == Guid.Empty) images.Add("noImageFound");
            else images = controller.ShowImagesForPlant(plantid);
            if (images.Count == 0) images.Add("noImageFound");

            PlantImage_worker plantImage_Worker = new PlantImage_worker();
            plantImage_Worker.ShowDialog();
        }
    }
}
