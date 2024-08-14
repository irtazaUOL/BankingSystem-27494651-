namespace BankSystemc_
{
    partial class Delete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Delete));
            label1 = new Label();
            account = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            panel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            panel12 = new Panel();
            pictureBox2 = new PictureBox();
            button5 = new Button();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Fax", 10F, FontStyle.Bold);
            label1.Location = new Point(311, 202);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 0;
            label1.Text = "Account  Number :  ";
            // 
            // account
            // 
            account.BorderStyle = BorderStyle.None;
            account.Location = new Point(493, 180);
            account.Multiline = true;
            account.Name = "account";
            account.Size = new Size(392, 44);
            account.TabIndex = 1;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Lucida Fax", 16F, FontStyle.Bold);
            button1.Location = new Point(539, 322);
            button1.Name = "button1";
            button1.Size = new Size(189, 50);
            button1.TabIndex = 2;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Lucida Fax", 14F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(12, 577);
            button2.Name = "button2";
            button2.Size = new Size(94, 43);
            button2.TabIndex = 3;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Fax", 26F, FontStyle.Bold);
            label4.Location = new Point(539, 58);
            label4.Name = "label4";
            label4.Size = new Size(198, 51);
            label4.TabIndex = 9;
            label4.Text = "DELETE";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(panel12);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(account);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.FillColor = Color.White;
            panel1.Location = new Point(-6, 107);
            panel1.Name = "panel1";
            panel1.ShadowColor = Color.Black;
            panel1.Size = new Size(1326, 444);
            panel1.TabIndex = 5;
            // 
            // panel12
            // 
            panel12.BackColor = Color.MediumSlateBlue;
            panel12.Location = new Point(493, 225);
            panel12.Name = "panel12";
            panel12.Size = new Size(392, 2);
            panel12.TabIndex = 112;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1, 29);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(60, 54);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // button5
            // 
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Lucida Fax", 10F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(1164, 43);
            button5.Name = "button5";
            button5.Size = new Size(86, 29);
            button5.TabIndex = 11;
            button5.Text = "Logout";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(1129, 40);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(27, 40);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 18F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(67, 43);
            label2.Name = "label2";
            label2.Size = new Size(107, 36);
            label2.TabIndex = 10;
            label2.Text = "Home";
            label2.Click += label2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1077, 573);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(1108, 577);
            label3.Name = "label3";
            label3.Size = new Size(184, 20);
            label3.TabIndex = 14;
            label3.Text = "Bank Management System";
            // 
            // Delete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(1314, 632);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(pictureBox2);
            Controls.Add(button5);
            Controls.Add(pictureBox3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(button2);
            Name = "Delete";
            Text = "Delete";
            Load += Delete_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label4;
        public Button button2;
        public TextBox account;
        public Button button1;
        private Guna.UI2.WinForms.Guna2ShadowPanel panel1;
        private Panel panel12;
        private PictureBox pictureBox2;
        private Button button5;
        private PictureBox pictureBox3;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label3;
    }
}