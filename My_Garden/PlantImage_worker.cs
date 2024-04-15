using My_Garden.Properties;
using MyGarden.Core.Controllers;
using MyGarden.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace My_Garden
{
    public partial class PlantImage_worker : Form
    {
        public static Guid plantid = PlantWorkshop.plantid;
        PlantController controller;
        public static List<string> images;
        int num = -1;
        int count = 0;

        public PlantImage_worker()
        {
            InitializeComponent();
            this.controller = new PlantController();
        }

        private void PlantImage_worker_Load(object sender, EventArgs e)
        {
            if(count==0)
            {
                images = PlantWorkshop.images;
            }
            count = 0;
            pictureBox6.Image = (Image)Properties.Resources.ResourceManager.GetObject(images[0]);
            num = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (num < images.Count - 1)
            {
                num++;
                pictureBox6.Image = (Image)Properties.Resources.ResourceManager.GetObject(images[num]);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (num > images.Count - 1)
            {
                num--;
                pictureBox6.Image = (Image)Properties.Resources.ResourceManager.GetObject(images[num]);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (images.Contains("noImageFound") == false)
            {
                if (plantid == Guid.Empty)
                {
                    images.Remove(images[num]);
                }
                else controller.DeleteImage(plantid, num);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            openFileDialog.Title = "Select an image file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string resourceName = Path.GetFileNameWithoutExtension(fileName);

                // Remove the existing resource with the same name
                if (Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentUICulture, true, true).Contains(resourceName))
                {
                    Properties.Resources.Remove(resourceName);
                }

                // Save the image to the project's resources
                Properties.Resources.Add(resourceName, File.ReadAllBytes(fileName));

                images.Add(resourceName);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PlantWorkshop.images = images;
            this.Close();
        }
    }
}
