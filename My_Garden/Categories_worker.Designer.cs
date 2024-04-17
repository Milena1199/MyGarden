namespace My_Garden
{
    partial class Categories_worker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Categories_worker));
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            label1 = new Label();
            listBox1 = new ListBox();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            SuspendLayout();
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Transparent;
            pictureBox7.Cursor = Cursors.Hand;
            pictureBox7.Image = (Image)resources.GetObject("pictureBox7.Image");
            pictureBox7.Location = new Point(833, 7);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(77, 70);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 42;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.Transparent;
            pictureBox8.Cursor = Cursors.Hand;
            pictureBox8.Image = (Image)resources.GetObject("pictureBox8.Image");
            pictureBox8.Location = new Point(22, 12);
            pictureBox8.Margin = new Padding(3, 4, 3, 4);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(62, 65);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.TabIndex = 43;
            pictureBox8.TabStop = false;
            pictureBox8.Click += pictureBox8_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Lucida Fax", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(329, 12);
            label1.Name = "label1";
            label1.Size = new Size(245, 46);
            label1.TabIndex = 44;
            label1.Text = "Categories";
            // 
            // listBox1
            // 
            listBox1.BackColor = SystemColors.InactiveCaption;
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.Font = new Font("Lucida Fax", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(22, 98);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(278, 384);
            listBox1.TabIndex = 45;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Lucida Fax", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(330, 96);
            label2.Name = "label2";
            label2.Size = new Size(115, 36);
            label2.TabIndex = 46;
            label2.Text = "Name:";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Font = new Font("Lucida Fax", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(330, 135);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(549, 47);
            textBox1.TabIndex = 47;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Font = new Font("Lucida Fax", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(330, 233);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(549, 153);
            textBox2.TabIndex = 49;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Lucida Fax", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(330, 194);
            label3.Name = "label3";
            label3.Size = new Size(213, 36);
            label3.TabIndex = 48;
            label3.Text = "Description:";
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(330, 416);
            button1.Name = "button1";
            button1.Size = new Size(174, 66);
            button1.TabIndex = 51;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(526, 416);
            button2.Name = "button2";
            button2.Size = new Size(174, 66);
            button2.TabIndex = 52;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Stretch;
            button3.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(718, 416);
            button3.Name = "button3";
            button3.Size = new Size(174, 66);
            button3.TabIndex = 53;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            button4.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(330, 416);
            button4.Name = "button4";
            button4.Size = new Size(174, 66);
            button4.TabIndex = 54;
            button4.Text = "Add";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(526, 416);
            button5.Name = "button5";
            button5.Size = new Size(174, 66);
            button5.TabIndex = 55;
            button5.Text = "Update";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += button5_Click;
            // 
            // Categories_worker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(920, 520);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(listBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox8);
            Controls.Add(pictureBox7);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Categories_worker";
            Text = "Categories_worker";
            Load += Categories_worker_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private Label label1;
        private ListBox listBox1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}