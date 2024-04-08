
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Drawing2D;

namespace My_Garden
{
    public partial class Form1 : Form
    {
        private string[] images = { "pic1", "pic2", "pic3", "pic4", "pic5", "pic6", "pic7", "pic8", "pic9", "pic10", "pic11" };
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogInForm login = new LogInForm();
            Hide();
            login.ShowDialog();
            Close();
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUpForm signup = new SignUpForm();
            Hide();
            signup.ShowDialog();
            Close();
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string randomImage = images[random.Next(0, images.Length)];
            this.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(randomImage);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
