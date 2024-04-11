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
    public partial class SoilTypeInfo : Form
    {
        private int num = -1;
        private List<string> soil_types = new List<string>()
        {
            "clay", "sandy", "slit", "loam", "peat", "chalky"
        };

        public SoilTypeInfo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SoilTypeInfo_Load(object sender, EventArgs e)
        {
            num = 0;
            pictureBox4.Image = (Image)Properties.Resources.ResourceManager.GetObject(soil_types[num]);
            label2.Text = soil_types[num].ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (num < soil_types.Count-1)
            {
                num++;
                pictureBox4.Image = (Image)Properties.Resources.ResourceManager.GetObject(soil_types[num]);
                label2.Text = soil_types[num].ToString();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (num >0)
            {
                num--;
                pictureBox4.Image = (Image)Properties.Resources.ResourceManager.GetObject(soil_types[num]);
                label2.Text = soil_types[num].ToString();
            }
        }
    }
}
