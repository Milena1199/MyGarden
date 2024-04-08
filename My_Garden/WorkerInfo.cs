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
    public partial class WorkerInfo : Form
    {
        AccountController accountController;
        public static Guid workerId = MainWorkerForm.workerId;
        private int saveChangesCount;
        private int editCount;

        public WorkerInfo()
        {
            InitializeComponent();
            this.accountController = new AccountController();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (editCount != 0 && saveChangesCount <= 0 && MessageBox.Show("Are you sure that you want to leave? No changes will be saved.", "Worker info", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MainWorkerForm mainWorkerForm = new MainWorkerForm();
                Hide();
                mainWorkerForm.ShowDialog();
                Close();
            }
            else
            {
                MainWorkerForm mainWorkerForm = new MainWorkerForm();
                Hide();
                mainWorkerForm.ShowDialog();
                Close();
            }
        }

        private void WorkerInfo_Load(object sender, EventArgs e)
        {
            label4.Text = accountController.GetWorkerName(workerId);
            label5.Text = accountController.GetWorkerUsername(workerId);
            saveChangesCount = 0;
            editCount = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox3.PasswordChar = '*';
            textBox4.Text = "";
            textBox4.PasswordChar = '*';
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            string username = textBox2.Text;
            string name = textBox1.Text;
            string password = "";
            if (accountController.IsUser(textBox1.Text) != Guid.Empty && accountController.IsWorker(textBox1.Text) != Guid.Empty)
            {
                MessageBox.Show("This username is already in use.", "Update worker's profile");
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
                    MessageBox.Show("The confirm password is either incorrect or unfulfilled.", "Update worker's profile");
                    textBox4.Text = "";
                }
            }
            WorkerUpdateViewModel workerUpdateViewModel = new WorkerUpdateViewModel()
            {
                Id =workerId,
                Username = username,
                Name = name,
                Password = password
            };
            accountController.UpdateWorker(workerUpdateViewModel);
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
            label4.Text = accountController.GetWorkerName(workerId);
            label5.Text = accountController.GetWorkerUsername(workerId);
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
