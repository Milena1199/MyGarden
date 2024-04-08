using Microsoft.VisualBasic.ApplicationServices;
using MyGarden.Core.Controllers;
using MyGarden.Data.Data.Models;
using System;
using System.CodeDom;
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
    public partial class MainWorkerForm : Form
    {
        public static Guid workerId = LogInForm.Id;
        AccountController accountController;

        public MainWorkerForm()
        {
            InitializeComponent();
            this.accountController = new AccountController();
        }

        private void MainWorkerForm_Load(object sender, EventArgs e)
        {
            string name = accountController.GetWorkerName(workerId);
            label1.Text = $"Hello {name}!";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WorkerInfo workerInfo = new WorkerInfo();
            Hide();
            workerInfo.ShowDialog();
            Close();
        }
    }
}
