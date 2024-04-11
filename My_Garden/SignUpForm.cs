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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace My_Garden
{
    public partial class SignUpForm : Form
    {
        AccountController controller;
        public SignUpForm()
        {
            InitializeComponent();
            this.controller = new AccountController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null) MessageBox.Show("Please, choose your username.", "Register");
            else if (textBox2.Text == null) MessageBox.Show("Please, make a password.", "Register");
            else if (textBox3.Text == null) MessageBox.Show("Please, confirm your password.", "Register");
            else if (textBox4.Text == null) MessageBox.Show("Please, put in your name.", "Register");
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Your password doesn't match the confrim password one", "Register");
                textBox3.Text = "";
            }
            else if (radioButton1.Checked == false && radioButton2.Checked == false) MessageBox.Show("Please choose your role", "Register");
            else if (controller.IsWorker(textBox1.Text) != Guid.Empty || controller.IsUser(textBox1.Text) != Guid.Empty)
            {
                MessageBox.Show("Username already exists.", "Register");
                textBox1.Text = "";
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    UserViewModel userViewModel = new UserViewModel()
                    {
                        Username = textBox1.Text,
                        Password = textBox2.Text,
                        Name = textBox4.Text
                    };
                    controller.UserRegister(userViewModel);
                    if (controller.IsUser(userViewModel.Username) != Guid.Empty)
                    {
                        MessageBox.Show("Registration successful.", "Register");
                        Form1 form = new Form1();
                        SignUpForm signup = new SignUpForm();
                        form.Show();
                        signup.Hide();
                    }
                    else MessageBox.Show("Something went wrong with the registration", "Register");
                }
                else
                {
                    WorkerViewModel workerViewModel = new WorkerViewModel()
                    {
                        Username = textBox1.Text,
                        Password = textBox2.Text,
                        Name = textBox4.Text
                    };
                    controller.WorkerRegister(workerViewModel);
                    if (controller.IsWorker(workerViewModel.Username) != Guid.Empty) MessageBox.Show("Registration successful.", "Register");
                    else
                    {
                        MessageBox.Show("Something went wrong with the registration", "Registration");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                    }
                }
            }
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
            textBox3.Text = "";
            textBox3.PasswordChar = '*';
            textBox4.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Hide();
            form.ShowDialog();
            Close();
        }
    }
}
