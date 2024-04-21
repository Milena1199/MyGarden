using MyGarden.Core.Controllers;
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
    public partial class MainUserForm : Form
    {
        private AccountController accountController;
        public static Guid userId = LogInForm.Id;
        public MainUserForm()
        {
            InitializeComponent();
            this.accountController = new AccountController();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo();
            Hide();
            userInfo.ShowDialog();
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainUserForm_Load(object sender, EventArgs e)
        {
            string name = accountController.GetUserName(userId);
            label1.Text = $"Hello {name}!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            My_GardenForm my_garden = new My_GardenForm();
            Hide();
            my_garden.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
