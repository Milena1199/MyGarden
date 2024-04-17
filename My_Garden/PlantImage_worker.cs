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
        private string destinationFolder = Path.Combine(Application.StartupPath, "PlantImages");
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
            num = 0;
            string imageName = images[num];
            string imagePath = FindImageInFolder(imageName);

            if (!string.IsNullOrEmpty(imagePath))
            {
                pictureBox6.Image = Image.FromFile(imagePath);
            }

        }
        private string FindImageInFolder(string imageName)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".gif", ".bmp", ".png" };

            foreach (string extension in imageExtensions)
            {
                string imagePath = Path.Combine(destinationFolder, imageName + extension);
                if (File.Exists(imagePath))
                {
                    return imagePath;
                }
            }

            return null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (num < images.Count-1)
            {
                num++;
                string imageName = images[num];
                string imagePath = FindImageInFolder(imageName);

                if (!string.IsNullOrEmpty(imagePath))
                {
                    pictureBox6.Image = Image.FromFile(imagePath);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (num > 0)
            {
                num--;
                string imageName = images[num];
                string imagePath = FindImageInFolder(imageName);

                if (!string.IsNullOrEmpty(imagePath))
                {
                    pictureBox6.Image = Image.FromFile(imagePath);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (images.Contains("noImageFound") == false)
            {
                if (plantid == Guid.Empty)
                {
                    pictureBox6.Image.Dispose();
                    images.Remove(images[num]);
                    if (images.Count == 0) images.Add("noImageFound");
                    PlantImage_worker_Load(sender, e);
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
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            openFileDialog.Title = "Select an image file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string file = Path.GetFileName(filePath);
                if (File.Exists(FindImageInFolder(fileName)) == false)
                {
                    string destinationPath = Path.Combine(destinationFolder, file);
                    File.Copy(filePath, destinationPath);
                    images.Add(fileName);
                    if (images.Contains("noImageFound")) images.Remove("noImageFound");
                    count++;
                    PlantImage_worker_Load(sender, e);
                }
                else
                {
                    if(images.Contains(fileName) == false)
                    {
                        images.Add(fileName);
                        if (images.Contains("noImageFound")) images.Remove("noImageFound");
                        count++;
                        PlantImage_worker_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("The image is already in use.","Images");
                    }
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PlantWorkshop.images = PlantImage_worker.images;
            this.Close();
        }
    }
}
