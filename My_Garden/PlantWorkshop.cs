using MyGarden.Core.Controllers;
using MyGarden.Core.Models;
using MyGarden.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace My_Garden
{
    public partial class PlantWorkshop : Form
    {
        List<string> plants;
        PlantController controller;
        public static List<string> images;
        public static Guid plantId;
        private int index;
        private string destinationFolder = Path.Combine(Application.StartupPath, "PlantImages");
        public static bool updatingImagesAllowed;

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
            updatingImagesAllowed = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            checkedListBox4.Items.Clear();
            images = new List<string>();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            checkedListBox1.Enabled = false;
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.AddRange(controller.AllCategoriesNames().ToArray());
            checkedListBox2.Enabled = false;
            checkedListBox2.Items.Clear();
            checkedListBox2.Items.AddRange(controller.AllDiseasesNames().ToArray());
            checkedListBox3.Enabled = false;
            checkedListBox3.Items.Clear();
            checkedListBox3.Items.AddRange(controller.AllPestsNames().ToArray());
            checkedListBox4.Enabled = false;
            checkedListBox4.Items.Clear();
            checkedListBox4.Items.AddRange(controller.ShowStyleNames().ToArray());
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            numericUpDown1.Enabled = false;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            numericUpDown1.Value = numericUpDown1.Minimum;

            pictureBox3.Enabled = false;
            pictureBox6.Visible = true;
            label19.Visible = true;
            label21.Visible = false;
            pictureBox4.Visible = false;
            label17.Visible = false;
            pictureBox7.Visible = false;
            label20.Visible = false;
            label18.Visible = false;
            listBox1.SelectedIndex = -1;
            plants = controller.ShowAllPlantsNames();
            if (plants.Count != 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(plants.ToArray());
            }
            else MessageBox.Show("No plants found, click on the add button below to make a new one", "Plant workshop");

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
            MessageBox.Show("Here you can add, edit, and delete plants", "Plant workshop");
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //add1 !!
        private void label17_Click(object sender, EventArgs e)
        {
            pictureBox3.Enabled = true;
            updatingImagesAllowed = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, false);
            }
            for (int i = 0; i < checkedListBox4.Items.Count; i++)
            {
                checkedListBox4.SetItemChecked(i, false);
            }

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            numericUpDown1.Value = numericUpDown1.Minimum;


            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            checkedListBox1.Enabled = true;
            checkedListBox2.Enabled = true;
            checkedListBox3.Enabled = true;
            checkedListBox4.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            numericUpDown1.Enabled = true;

            pictureBox7.Visible = false;
            label20.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label21.Visible = true;
            pictureBox4.Visible = false;
            label17.Visible = false;
        }
        //clear
        private void pictureBox4_Click(object sender, EventArgs e)
        {

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
                    PlantId = plantId,
                    Url = image
                };
                controller.AddImage(addImageForPlantViewModel);
            }
            updatingImagesAllowed = false;
        }
        private void picturebox6_Click(object sender, EventArgs e)
        {


        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex>=0)
            {
                index = listBox1.SelectedIndex;
                Plant plant = controller.FindPlant(index);
                plantId = plant.Id;
                textBox1.Text = listBox1.SelectedItem.ToString();
                List<string> checkedCategories = controller.CategoriesForPlantNames(index);
                images = controller.ShowImagesForPlant(plantId);
                if (images.Count == 0) images.Add("noImageFound");
                for(int i = 0; i<checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, checkedCategories.Contains(checkedListBox1.Items[i]));
                }
                textBox2.Text = plant.HowToPlant;
                textBox3.Text = plant.SeasonsOfInterest;
                textBox4.Text = plant.Characteristics;
                comboBox1.SelectedItem = plant.ClimateZone;
                numericUpDown1.Value = plant.HardinessZone;
                comboBox2.SelectedItem = plant.SoilType;
                textBox5.Text = plant.Maintenance;
                textBox6.Text = plant.LenghtOfLife;
                List<string> checkedDiseases = controller.DiseasesForPlantNames(index);
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, checkedDiseases.Contains(checkedListBox2.Items[i]));
                }
                textBox7.Text = plant.Price.ToString();
                List<string> checkedStyles = controller.StylesForPlantNames(index);
                for (int i = 0; i < checkedListBox4.Items.Count; i++)
                {
                    checkedListBox4.SetItemChecked(i, checkedStyles.Contains(checkedListBox4.Items[i]));
                }
                List<string> checkedPests = controller.PestsForPlantNames(index);
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    checkedListBox3.SetItemChecked(i, checkedPests.Contains(checkedListBox3.Items[i]));
                }
                textBox8.Text = plant.MoreInfo;

                pictureBox3.Enabled = true;
                pictureBox7.Visible = true;
                label20.Visible = true;
                label18.Visible = false;
                pictureBox6.Visible = true;
                label19.Visible = true;
                label21.Visible = false;
                pictureBox4.Visible = true;
                label17.Visible = true;
                updatingImagesAllowed = false;
            }
        }
        //image add
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (images.Count == 0) images.Add("noImageFound");

            PlantImage_worker plantImage_Worker = new PlantImage_worker();
            plantImage_Worker.ShowDialog();
        }
        //update1
        private void label20_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            checkedListBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            pictureBox3.Enabled = true;
            textBox4.Enabled = true;
            comboBox1.Enabled = true;
            numericUpDown1.Enabled = true;
            comboBox2.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            checkedListBox2.Enabled = true;
            textBox7.Enabled = true;
            checkedListBox4.Enabled = true;
            textBox8.Enabled = true;
            label20.Visible = false;
            label18.Visible = true;
            pictureBox6.Visible = false;
            label19.Visible = false;
            label21.Visible = false;
            pictureBox4.Visible = false;
            label17.Visible = false;
            updatingImagesAllowed = true;

        }
        //clear
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        //clear
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }
        //update2
        private void label18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please fill up all the required information first", "Plant workshop");
            }
            else
            {
                if (images.Count == 0) images.Add(Path.Combine(destinationFolder, "noImageFound.png"));

            }
        }
        //delete 1
        private void label17_Click_1(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this plant?","Plant workshop",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                plantId = controller.FindPlantId(textBox1.Text);
                controller.DeletePlant(plantId);
                PlantWorkshop_Load(sender, e);
            }
        }
        //delete 2
        private void label22_Click(object sender, EventArgs e)
        {

        }
        //add 2 !!
        private void label21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == ""||textBox3.Text==""||textBox4.Text==""||comboBox1.SelectedIndex==-1||comboBox2.SelectedIndex==-1||textBox5.Text==""||textBox6.Text=="")
            {
                MessageBox.Show("Please fill up all the required information first", "Plant workshop");
            }
            else
            {
                if (images.Count == 0) images.Add(Path.Combine(destinationFolder,"noImageFound.png"));
                AddPlantViewModel addPlantViewModel = new AddPlantViewModel()
                {
                    Name = textBox1.Text,
                    HowToPlant = textBox2.Text,
                    SeasonOfInteret = textBox3.Text,
                    Characteristics = textBox4.Text,
                    ClimateZone = comboBox1.SelectedItem.ToString(),
                    HardinessZone = (int)numericUpDown1.Value,
                    SoilType = comboBox2.SelectedItem.ToString(),
                    Мaintenance = textBox5.Text,
                    LenghtOfLife = textBox6.Text,
                    Price = decimal.Parse(textBox7.Text),
                    MoreInfo = textBox8.Text
                };
                controller.AddPlant(addPlantViewModel);
                plantId = controller.FindPlantId(textBox1.Text);
                foreach (string image in images)
                {
                    AddImageForPlantViewModel addImageForPlantViewModel = new AddImageForPlantViewModel()
                    {
                        PlantId = plantId,
                        Url = image
                    };
                    controller.AddImage(addImageForPlantViewModel);
                }
                for(int i =0; i<checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i)==true)
                    {
                        AddInPlantsAndCategoriesViewModel addInPlantsAndCategoriesViewModel = new AddInPlantsAndCategoriesViewModel()
                        {
                            PlantId = plantId,
                            CategoryId = controller.FindCategoryId(checkedListBox1.Items[i].ToString())
                        };
                        controller.AddInPlantsAndCategories(addInPlantsAndCategoriesViewModel);
                    }
                }
                for (int i = 0; i<checkedListBox2.Items.Count; i++)
                {
                    if (checkedListBox2.GetItemChecked(i)==true)
                    {
                        AddInPlantsAndDiseasesViewModel addInPlantsAndDiseasese = new AddInPlantsAndDiseasesViewModel()
                        {
                            PlantId = plantId,
                            DiseaseId = controller.FindDiseaseId(checkedListBox2.Items[i].ToString())
                        };
                        controller.AddInPlantsAndDiseases(addInPlantsAndDiseasese);
                    }
                }
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    if (checkedListBox3.GetItemChecked(i) == true)
                    {
                        AddInPestsAndPlantsViewModel addInPestsAndPlantsViewModel = new AddInPestsAndPlantsViewModel()
                        {
                            PlantId = plantId,
                            PestId = controller.FindPestId(checkedListBox3.Items[i].ToString())
                        };
                        controller.AddInPestsAndPlants(addInPestsAndPlantsViewModel);
                    }
                }
                for (int i = 0; i<checkedListBox4.Items.Count;i++)
                {
                    if (checkedListBox4.GetItemChecked(i) == true)
                    {
                        AddInPlantsAndStylesViewModel addInPlantsAndStylesViewModel = new AddInPlantsAndStylesViewModel()
                        {
                            PlantId = plantId,
                            StyleId = controller.FindStyleId(checkedListBox4.Items[i].ToString())
                        };
                        controller.AddInPlantsAndStyles(addInPlantsAndStylesViewModel);
                    }
                }
                PlantWorkshop_Load(sender, e);
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
