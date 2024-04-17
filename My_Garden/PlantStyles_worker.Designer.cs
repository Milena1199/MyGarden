namespace My_Garden
{
    partial class PlantStyles_worker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlantStyles_worker));
            label1 = new Label();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            listBox1 = new ListBox();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Lucida Fax", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(346, 9);
            label1.Name = "label1";
            label1.Size = new Size(145, 46);
            label1.TabIndex = 47;
            label1.Text = "Styles";
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Cursor = Cursors.Hand;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(12, 9);
            pictureBox8.Margin = new Padding(3, 4, 3, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(62, 65);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 46;
            pictureBox8.TabStop = false;
            pictureBox8.Click += pictureBox8_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Cursor = Cursors.Hand;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(759, 4);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(77, 70);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 45;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.FromArgb(207, 214, 191);
            listBox1.Font = new Font("Lucida Fax", 15F, FontStyle.Bold, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 30;
            listBox1.Location = new Point(25, 87);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(206, 454);
            listBox1.TabIndex = 48;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Lucida Fax", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(278, 110);
            label2.Name = "label2";
            label2.Size = new Size(115, 36);
            label2.TabIndex = 49;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Lucida Fax", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(278, 276);
            label3.Name = "label3";
            label3.Size = new Size(213, 36);
            label3.TabIndex = 50;
            label3.Text = "Description:";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(399, 110);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(280, 36);
            textBox1.TabIndex = 51;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(278, 327);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(483, 121);
            textBox2.TabIndex = 52;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(261, 486);
            button1.Name = "button1";
            button1.Size = new Size(187, 67);
            button1.TabIndex = 53;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(461, 486);
            button2.Name = "button2";
            button2.Size = new Size(176, 67);
            button2.TabIndex = 54;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(649, 486);
            button3.Name = "button3";
            button3.Size = new Size(187, 67);
            button3.TabIndex = 55;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(411, 162);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(92, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 56;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(549, 162);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(230, 151);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 57;
            pictureBox2.TabStop = false;
            // 
            // button4
            // 
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(261, 486);
            button4.Name = "button4";
            button4.Size = new Size(187, 67);
            button4.TabIndex = 58;
            button4.Text = "Add";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // PlantStyles_worker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(866, 578);
            Controls.Add(button4);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox7);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "PlantStyles_worker";
            Text = "PlantStyles_worker";
            Load += PlantStyles_worker_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private ListBox listBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button4;
    }
}