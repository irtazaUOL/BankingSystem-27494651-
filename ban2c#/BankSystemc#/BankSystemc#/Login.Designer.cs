namespace BankSystemc_
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pnltransaction = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2Button2 = new Button();
            panel2 = new Panel();
            panel1 = new Panel();
            Email = new TextBox();
            Name = new TextBox();
            pnltransaction.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei", 10F, FontStyle.Bold);
            label3.Location = new Point(359, 261);
            label3.Name = "label3";
            label3.Size = new Size(155, 22);
            label3.TabIndex = 3;
            label3.Text = "Enter Your Email :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Malgun Gothic", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(553, 25);
            label2.Name = "label2";
            label2.Size = new Size(142, 60);
            label2.TabIndex = 2;
            label2.Text = "Login";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Microsoft JhengHei", 10F, FontStyle.Bold);
            label1.Location = new Point(359, 170);
            label1.Name = "label1";
            label1.Size = new Size(164, 22);
            label1.TabIndex = 0;
            label1.Text = "Enter Your Name : ";
            // 
            // pnltransaction
            // 
            pnltransaction.BackColor = Color.Transparent;
            pnltransaction.Controls.Add(guna2Button2);
            pnltransaction.Controls.Add(panel2);
            pnltransaction.Controls.Add(panel1);
            pnltransaction.Controls.Add(Email);
            pnltransaction.Controls.Add(Name);
            pnltransaction.Controls.Add(label2);
            pnltransaction.Controls.Add(label3);
            pnltransaction.Controls.Add(label1);
            pnltransaction.FillColor = Color.White;
            pnltransaction.Location = new Point(-5, 63);
            pnltransaction.Name = "pnltransaction";
            pnltransaction.ShadowColor = Color.Black;
            pnltransaction.Size = new Size(1326, 444);
            pnltransaction.TabIndex = 9;
            // 
            // guna2Button2
            // 
            guna2Button2.BackColor = Color.MediumSlateBlue;
            guna2Button2.FlatAppearance.BorderSize = 0;
            guna2Button2.FlatStyle = FlatStyle.Flat;
            guna2Button2.Font = new Font("Microsoft JhengHei", 16F, FontStyle.Bold);
            guna2Button2.ForeColor = Color.White;
            guna2Button2.Location = new Point(553, 331);
            guna2Button2.Name = "guna2Button2";
            guna2Button2.Size = new Size(140, 56);
            guna2Button2.TabIndex = 20;
            guna2Button2.Text = "Login";
            guna2Button2.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MediumSlateBlue;
            panel2.Location = new Point(523, 284);
            panel2.Name = "panel2";
            panel2.Size = new Size(332, 2);
            panel2.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MediumSlateBlue;
            panel1.Location = new Point(523, 195);
            panel1.Name = "panel1";
            panel1.Size = new Size(332, 2);
            panel1.TabIndex = 18;
            // 
            // Email
            // 
            Email.BorderStyle = BorderStyle.None;
            Email.Location = new Point(523, 221);
            Email.Multiline = true;
            Email.Name = "Email";
            Email.Size = new Size(332, 60);
            Email.TabIndex = 17;
            // 
            // Name
            // 
            Name.BorderStyle = BorderStyle.None;
            Name.Location = new Point(523, 128);
            Name.Multiline = true;
            Name.Name = "Name";
            Name.Size = new Size(332, 60);
            Name.TabIndex = 10;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSlateBlue;
            ClientSize = new Size(1314, 632);
            Controls.Add(pnltransaction);

            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Form1_Load;
            pnltransaction.ResumeLayout(false);
            pnltransaction.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label3;
        private Label label2;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnltransaction;
        private TextBox Email;
        private TextBox Name;
        private Panel panel2;
        private Panel panel1;
        private Button guna2Button2;
    }
}
