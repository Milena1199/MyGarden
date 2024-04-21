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

namespace My_Garden
{
    public partial class Categories_worker : Form
    {
        PlantController controller;
        List<string> categories;
        private int index;

        public Categories_worker()
        {
            InitializeComponent();
            this.controller = new PlantController();
        }

        private void Categories_worker_Load(object sender, EventArgs e)
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
            listBox1.SelectedIndex = -1;
            categories = controller.AllCategoriesNames();
            if (categories.Count != 0)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(categories.ToArray());
            }
            else MessageBox.Show("No categories found. Click on the add button below to make a new one", "Categories");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            listBox1.SelectedIndex = -1;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") MessageBox.Show("Please fill all of your information first.", "Category");
            else
            {
                AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel()
                {
                    Name = textBox1.Text,
                    Description = textBox2.Text
                };
                controller.AddCategory(addCategoryViewModel);
                Categories_worker_Load(sender, e);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                index = listBox1.SelectedIndex;
                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox2.Text = controller.GetCategoryDescription(index);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            listBox1.Items.Remove(listBox1.Items[index]);
            listBox1.SelectedIndex = -1;
            controller.DeleteCategory(index);
            Categories_worker_Load(sender, e);
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                UpdateCatrgoryViewModel updateCatrgoryViewModel = new UpdateCatrgoryViewModel()
                {
                    Index = index,
                    Name = textBox1.Text,
                    Description = textBox2.Text
                };
                controller.UpdateCategory(updateCatrgoryViewModel);
                Categories_worker_Load(sender, e);
            }
            else MessageBox.Show("Please fill all of the information first", "Category");
        }

    }
}
