namespace My_Garden
{
    partial class UserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfo));
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox3 = new PictureBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button2 = new Button();
            label6 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Cursor = Cursors.Hand;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(349, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(105, 100);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 19;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(673, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(93, 89);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(12, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(105, 100);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 21;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.Connection = null;
            sqlCommand1.Notification = null;
            sqlCommand1.Transaction = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Lucida Fax", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(68, 273);
            label1.Name = "label1";
            label1.Size = new Size(107, 32);
            label1.TabIndex = 22;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Lucida Fax", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(68, 341);
            label2.Name = "label2";
            label2.Size = new Size(172, 32);
            label2.TabIndex = 23;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Lucida Fax", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(68, 404);
            label3.Name = "label3";
            label3.Size = new Size(165, 32);
            label3.TabIndex = 24;
            label3.Tag = "edit";
            label3.Text = "Password:";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Lucida Fax", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(284, 273);
            label4.Name = "label4";
            label4.Size = new Size(95, 32);
            label4.TabIndex = 25;
            label4.Tag = "hide";
            label4.Text = ".........";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Lucida Fax", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(284, 341);
            label5.Name = "label5";
            label5.Size = new Size(95, 32);
            label5.TabIndex = 26;
            label5.Tag = "hide";
            label5.Text = ".........";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Lucida Fax", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(68, 474);
            label7.Name = "label7";
            label7.Size = new Size(296, 32);
            label7.TabIndex = 28;
            label7.Tag = "edit";
            label7.Text = "Confirm password:";
            label7.Visible = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(230, 227, 218);
            textBox1.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(385, 263);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(263, 42);
            textBox1.TabIndex = 29;
            textBox1.Tag = "edit";
            textBox1.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(196, 189, 168);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(371, 535);
            button1.Name = "button1";
            button1.Size = new Size(153, 48);
            button1.TabIndex = 30;
            button1.Tag = "hide";
            button1.Text = "Edit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(230, 227, 218);
            textBox2.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(385, 331);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(263, 42);
            textBox2.TabIndex = 31;
            textBox2.Tag = "edit";
            textBox2.Visible = false;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(230, 227, 218);
            textBox3.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.Location = new Point(385, 394);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(263, 42);
            textBox3.TabIndex = 33;
            textBox3.Tag = "edit";
            textBox3.Visible = false;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(230, 227, 218);
            textBox4.Font = new Font("Lucida Fax", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox4.Location = new Point(385, 464);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(263, 42);
            textBox4.TabIndex = 32;
            textBox4.Tag = "edit";
            textBox4.Visible = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(196, 189, 168);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(412, 535);
            button2.Name = "button2";
            button2.Size = new Size(203, 48);
            button2.TabIndex = 34;
            button2.Tag = "edit";
            button2.Text = "Save changes";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Lucida Fax", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(284, 112);
            label6.Name = "label6";
            label6.Size = new Size(232, 43);
            label6.TabIndex = 35;
            label6.Text = "My profile:";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(196, 189, 168);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Lucida Fax", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(80, 535);
            button3.Name = "button3";
            button3.Size = new Size(153, 48);
            button3.TabIndex = 36;
            button3.Tag = "";
            button3.Text = "Log out";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // UserInfo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(797, 627);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserInfo";
            Text = " ";
            Load += UserInfo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button2;
        private Label label6;
        private Button button3;
    }
}