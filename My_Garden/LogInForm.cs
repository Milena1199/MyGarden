using MyGarden.Core.Controllers;
using MyGarden.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Garden
{
    public partial class LogInForm : Form
    {
        AccountController accountController;
        public static Guid Id;

        public LogInForm()
        {
            InitializeComponent();
            this.accountController = new AccountController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""||textBox2.Text=="")
            {
                MessageBox.Show("Please, fill up all of your information","Log in");
            }
            else
            {
                Guid ifUserId = accountController.IsUser(textBox1.Text);
                Guid ifWorkerId = accountController.IsWorker(textBox1.Text);
                if (ifUserId != Guid.Empty)
                {
                    LogInViewModel loginViewModel = new LogInViewModel()
                    {
                        Id = ifUserId,
                        Password = textBox2.Text
                    };

                    if (accountController.LogInUser(loginViewModel)!= Guid.Empty)
                    {
                        Id = ifUserId;
                        MainUserForm mainuser = new MainUserForm();
                        Hide();
                        mainuser.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password","Log in");
                        textBox2.Text = "";
                    }
                }
                else if (ifWorkerId != Guid.Empty)
                {
                    LogInViewModel logInViewModel = new LogInViewModel()
                    {
                        Id = ifWorkerId,
                        Password = textBox2.Text
                    };
                    if(accountController.LogInWorker(logInViewModel)!= Guid.Empty)
                    {
                        Id = ifWorkerId;
                        MainWorkerForm mainworker = new MainWorkerForm();
                        Hide();
                        mainworker.ShowDialog();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong password", "Log in");
                        textBox2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("This username does not exists.", "Log in");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
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
