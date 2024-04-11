using MyGarden.Core.Controllers;
using MyGarden.Core.Models;
using MyGarden.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Garden
{
    public partial class My_GardenForm : Form
    {
        public static Guid userId = MainUserForm.userId;
        GardenController controller;
        private string climate;
        private int hardiness;
        private string soil;
        private int zoneIndex;
        private List<GardeningZone> gardens;
        private GardeningZone gardeningZone;

        public My_GardenForm()
        {
            InitializeComponent();
            this.controller = new GardenController();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is your gardening zone. Here you can write down the enviroment you are working with, so we can provide the best plants for it. You can always change it, make a new one or search up for pot plants.", "Information");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MainUserForm mainuser = new MainUserForm();
            Hide();
            mainuser.ShowDialog();
            Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ClimateZonesInfo climate = new ClimateZonesInfo();
            climate.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            HardinessZonesInfo hardiness = new HardinessZonesInfo();
            hardiness.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SoilTypeInfo soilType = new SoilTypeInfo();
            soilType.Show();
        }

        private void My_Garden_Load(object sender, EventArgs e)
        {
            gardens = controller.AllZones(userId);
            if (gardens.Count != 0)
            {
                for (int i = 1; i <= gardens.Count; i++)
                {
                    string gardenName = $"Garden {i}";
                    comboBox1.Items.Add(gardenName);
                }
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
            else
            {
                label8.Visible = true;
                comboBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
            pictureBox3.Visible = true;
            if (comboBox1.Items.Count != 0)
            {
                comboBox1.SelectedIndex = -1;
                comboBox1_SelectedIndexChanged(sender, e);
            }
            else
            {
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label7.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1) MessageBox.Show("Please, choose a climate zone first.", "New gardening zone");
            else if (comboBox3.SelectedIndex == -1) MessageBox.Show("Please, choose a hardiness zone first.", "New gardening zone");
            else if (comboBox4.SelectedIndex == -1) MessageBox.Show("Please, choose a soil type first.", "New gardening zone");
            else
            {
                NewZoneViewModel newGarden = new NewZoneViewModel()
                {
                    ClimateZone = climate,
                    HardinessZone = hardiness,
                    SoilType = soil,
                    Id = userId
                };
                controller.NewZone(newGarden);

                gardens = controller.AllZones(userId);
                comboBox1.Items.Clear();
                for (int i = 1; i <= gardens.Count; i++)
                {
                    string gardenName = $"Garden {i}";
                    comboBox1.Items.Add(gardenName);
                }

                if (comboBox1.SelectedIndex == -1) comboBox1_SelectedIndexChanged(sender, e);
                else comboBox1.SelectedIndex = -1;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1) climate = comboBox2.SelectedItem.ToString();
            else comboBox2.Text = "Climate Zones";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1) hardiness = int.Parse(comboBox3.SelectedItem.ToString());
            else comboBox3.Text = "Hardiness zone";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex != -1) soil = comboBox4.SelectedItem.ToString();
            else comboBox4.Text = "Soil Type";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                comboBox1.Text = "My gardening zones";
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;

                comboBox1.Visible = true;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;

                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                pictureBox8.Visible = false;
            }
            else
            {
                gardeningZone = controller.FindGarden(comboBox1.SelectedIndex, userId);
                zoneIndex = comboBox1.SelectedIndex;

                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = false;

                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;

                label5.Text = gardeningZone.ClimateZone;
                label6.Text = gardeningZone.HardinessZone.ToString();
                label7.Text = gardeningZone.SoilType;

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;

                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;
                pictureBox6.Visible = true;

                climate = gardeningZone.ClimateZone;
                hardiness = gardeningZone.HardinessZone;
                soil = gardeningZone.SoilType;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this garden?", "Delete gardening zone", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                controller.DeleteGarden(gardeningZone.Id);
                comboBox1.SelectedIndex = -1;
                gardens = controller.AllZones(userId);
                if (gardens.Count != 0)
                {
                    comboBox1.Items.Clear();
                    for (int i = 1; i <= gardens.Count; i++)
                    {
                        string gardenName = $"Garden {i}";
                        comboBox1.Items.Add(gardenName);
                    }
                    comboBox1.Visible = true;
                    label7.Visible = false;
                }
                else
                {
                    comboBox1.Visible = false;
                    label7.Visible = true;
                }
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;

            comboBox2.SelectedIndex = comboBox2.FindStringExact(climate);
            comboBox3.SelectedIndex = comboBox3.FindStringExact(hardiness.ToString());
            comboBox4.SelectedIndex = comboBox4.FindStringExact(soil);
            comboBox1.Visible = false;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;


            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox8.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateZoneViewModel updateZoneViewModel = new UpdateZoneViewModel()
            {
                id = gardeningZone.Id,
                ClimateZone = climate,
                HardinessZone = hardiness,
                SoilType = soil
            };
            controller.UpdateZone(updateZoneViewModel);
            comboBox1_SelectedIndexChanged(sender, e);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = false;

            comboBox1.Visible = true;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = false;

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;

        }
    }
}
