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
    public partial class My_Garden : Form
    {
        public static Guid userId = MainUserForm.userId;

        public My_Garden()
        {
            InitializeComponent();
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
            MessageBox.Show("Earth's climate zones—the horizontal belts of different climates that encircle the planet—consist of tropical, dry, temperate, continental, and polar zones.", "Climate zone");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hardiness zone is defined by the minimal temperture in the winter (how hard are the winters where you live for the plants).", "Hardiness zone");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soil can be categorised into sand, clay, silt, peat, chalk and loam types of soil based on the dominating size of the particles within a soil.", "Soil type");
        }
    }
}
