using MyGarden.Core.Controllers;
using MyGarden.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Garden
{
    public partial class UserInfo : Form
    {
        AccountController accountController;
        public static Guid userId = MainUserForm.userId;
        private int saveChangesCount;
        private int editCount;
        public UserInfo()
        {
            InitializeComponent();
            this.accountController = new AccountController();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (editCount!=0&&saveChangesCount <= 0 && MessageBox.Show("Are you sure that you want to leave? No changes will be saved.", "User info", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MainUserForm mainUserForm = new MainUserForm();
                Hide();
                mainUserForm.ShowDialog();
                Close();
            }
            else
            {
                MainUserForm mainUserForm = new MainUserForm();
                Hide();
                mainUserForm.ShowDialog();
                Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control.Tag == "edit")
                {
                    control.Visible = true;
                }
                else if (control.Tag == "hide")
                {
                    control.Visible = false;
                }
            }
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            label4.Text = accountController.GetUserName(userId);
            label5.Text = accountController.GetUsername(userId);
            saveChangesCount = 0;
            editCount = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            string name = textBox1.Text;
            string password = "";
            if (accountController.IsUser(textBox1.Text) != Guid.Empty && accountController.IsWorker(textBox1.Text) != Guid.Empty)
            {
                MessageBox.Show("This username is already in use.", "Update user's profile");
                textBox2.Text = "";
            }
            if (textBox3.Text != "")
            {
                if (textBox4.Text == textBox3.Text)
                {
                    password = textBox3.Text;
                }
                else
                {
                    MessageBox.Show("The confirm password is either incorrect or unfulfilled.", "Update user's profile");
                    textBox4.Text = "";
                }
            }
            UserUpdateViewModel userUpdateViewModel = new UserUpdateViewModel()
            {
                Id = userId,
                Username = username,
                Name = name,
                Password = password
            };
            accountController.UpdateUser(userUpdateViewModel);
            saveChangesCount++;
            foreach (Control control in this.Controls)
            {
                if (control.Tag == "edit")
                {
                    control.Visible = false;
                }
                else if (control.Tag == "hide")
                {
                    control.Visible = true;
                }
            }
            label4.Text = accountController.GetUserName(userId);
            label5.Text = accountController.GetUsername(userId);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            Hide();
            form1.ShowDialog();
            Close();
        }
    }
}
