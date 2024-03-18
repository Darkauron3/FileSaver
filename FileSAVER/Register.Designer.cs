using System.Runtime.CompilerServices;

namespace FileSAVER
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            label1 = new Label();
            label2 = new Label();
            btn_register = new Button();
            rdbtn1 = new RadioButton();
            rdbtn2 = new RadioButton();
            panel2 = new Panel();
            txt_username = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            txt_email = new TextBox();
            panel5 = new Panel();
            txt_age = new TextBox();
            txt_pass = new TextBox();
            panel6 = new Panel();
            txt_passconfirm = new TextBox();
            return_btn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(62, 120, 138);
            label1.Location = new Point(261, 20);
            label1.Name = "label1";
            label1.Size = new Size(139, 38);
            label1.TabIndex = 0;
            label1.Text = "Register";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(62, 120, 138);
            label2.Location = new Point(24, 91);
            label2.Name = "label2";
            label2.Size = new Size(153, 33);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // btn_register
            // 
            btn_register.BackColor = Color.DarkOrange;
            btn_register.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_register.Location = new Point(207, 568);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(219, 56);
            btn_register.TabIndex = 14;
            btn_register.Text = "Register!";
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += btn1_Click;
            // 
            // rdbtn1
            // 
            rdbtn1.AutoSize = true;
            rdbtn1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            rdbtn1.ForeColor = Color.FromArgb(62, 120, 138);
            rdbtn1.Location = new Point(134, 495);
            rdbtn1.Name = "rdbtn1";
            rdbtn1.Size = new Size(187, 34);
            rdbtn1.TabIndex = 18;
            rdbtn1.Text = "Administrator";
            rdbtn1.UseVisualStyleBackColor = true;
            // 
            // rdbtn2
            // 
            rdbtn2.AutoSize = true;
            rdbtn2.Checked = true;
            rdbtn2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            rdbtn2.ForeColor = Color.FromArgb(62, 120, 138);
            rdbtn2.Location = new Point(355, 495);
            rdbtn2.Name = "rdbtn2";
            rdbtn2.Size = new Size(173, 34);
            rdbtn2.TabIndex = 19;
            rdbtn2.TabStop = true;
            rdbtn2.Text = "Normal user";
            rdbtn2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkOrange;
            panel2.ForeColor = Color.FromArgb(62, 120, 138);
            panel2.Location = new Point(191, 127);
            panel2.Name = "panel2";
            panel2.Size = new Size(368, 5);
            panel2.TabIndex = 21;
            // 
            // txt_username
            // 
            txt_username.BackColor = Color.FromArgb(41, 44, 51);
            txt_username.BorderStyle = BorderStyle.None;
            txt_username.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            txt_username.ForeColor = Color.White;
            txt_username.Location = new Point(190, 83);
            txt_username.Margin = new Padding(4, 3, 4, 3);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(369, 43);
            txt_username.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(62, 120, 138);
            label7.Location = new Point(32, 161);
            label7.Name = "label7";
            label7.Size = new Size(145, 33);
            label7.TabIndex = 22;
            label7.Text = "Password:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.FromArgb(62, 120, 138);
            label8.Location = new Point(30, 216);
            label8.Name = "label8";
            label8.Size = new Size(147, 66);
            label8.TabIndex = 23;
            label8.Text = "Repeat\r\npassword:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.FromArgb(62, 120, 138);
            label9.Location = new Point(79, 334);
            label9.Name = "label9";
            label9.Size = new Size(92, 33);
            label9.TabIndex = 24;
            label9.Text = "Email:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.FromArgb(62, 120, 138);
            label10.Location = new Point(94, 416);
            label10.Name = "label10";
            label10.Size = new Size(77, 33);
            label10.TabIndex = 25;
            label10.Text = "Age:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkOrange;
            panel1.ForeColor = Color.FromArgb(62, 120, 138);
            panel1.Location = new Point(192, 205);
            panel1.Name = "panel1";
            panel1.Size = new Size(368, 5);
            panel1.TabIndex = 27;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DarkOrange;
            panel4.ForeColor = Color.FromArgb(62, 120, 138);
            panel4.Location = new Point(191, 362);
            panel4.Name = "panel4";
            panel4.Size = new Size(368, 5);
            panel4.TabIndex = 31;
            // 
            // txt_email
            // 
            txt_email.BackColor = Color.FromArgb(41, 44, 51);
            txt_email.BorderStyle = BorderStyle.None;
            txt_email.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            txt_email.ForeColor = Color.White;
            txt_email.Location = new Point(190, 318);
            txt_email.Margin = new Padding(4, 3, 4, 3);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(369, 43);
            txt_email.TabIndex = 30;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkOrange;
            panel5.ForeColor = Color.FromArgb(62, 120, 138);
            panel5.Location = new Point(195, 444);
            panel5.Name = "panel5";
            panel5.Size = new Size(368, 5);
            panel5.TabIndex = 33;
            // 
            // txt_age
            // 
            txt_age.BackColor = Color.FromArgb(41, 44, 51);
            txt_age.BorderStyle = BorderStyle.None;
            txt_age.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            txt_age.ForeColor = Color.White;
            txt_age.Location = new Point(194, 400);
            txt_age.Margin = new Padding(4, 3, 4, 3);
            txt_age.Name = "txt_age";
            txt_age.Size = new Size(369, 43);
            txt_age.TabIndex = 32;
            // 
            // txt_pass
            // 
            txt_pass.BackColor = Color.FromArgb(41, 44, 51);
            txt_pass.BorderStyle = BorderStyle.None;
            txt_pass.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            txt_pass.ForeColor = Color.White;
            txt_pass.Location = new Point(190, 161);
            txt_pass.Margin = new Padding(4, 3, 4, 3);
            txt_pass.Name = "txt_pass";
            txt_pass.Size = new Size(369, 43);
            txt_pass.TabIndex = 34;
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkOrange;
            panel6.ForeColor = Color.FromArgb(62, 120, 138);
            panel6.Location = new Point(192, 283);
            panel6.Name = "panel6";
            panel6.Size = new Size(368, 5);
            panel6.TabIndex = 33;
            // 
            // txt_passconfirm
            // 
            txt_passconfirm.BackColor = Color.FromArgb(41, 44, 51);
            txt_passconfirm.BorderStyle = BorderStyle.None;
            txt_passconfirm.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            txt_passconfirm.ForeColor = Color.White;
            txt_passconfirm.Location = new Point(191, 239);
            txt_passconfirm.Margin = new Padding(4, 3, 4, 3);
            txt_passconfirm.Name = "txt_passconfirm";
            txt_passconfirm.Size = new Size(369, 43);
            txt_passconfirm.TabIndex = 32;
            // 
            // return_btn
            // 
            return_btn.BackColor = Color.FromArgb(41, 44, 51);
            return_btn.BackgroundImageLayout = ImageLayout.None;
            return_btn.Image = (Image)resources.GetObject("return_btn.Image");
            return_btn.Location = new Point(-2, 3);
            return_btn.Name = "return_btn";
            return_btn.Size = new Size(78, 66);
            return_btn.TabIndex = 35;
            return_btn.UseVisualStyleBackColor = false;
            return_btn.Click += button1_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackColor = Color.FromArgb(41, 44, 51);
            ClientSize = new Size(663, 662);
            Controls.Add(return_btn);
            Controls.Add(panel6);
            Controls.Add(txt_pass);
            Controls.Add(txt_passconfirm);
            Controls.Add(panel5);
            Controls.Add(txt_age);
            Controls.Add(panel4);
            Controls.Add(txt_email);
            Controls.Add(panel1);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(panel2);
            Controls.Add(txt_username);
            Controls.Add(rdbtn2);
            Controls.Add(rdbtn1);
            Controls.Add(btn_register);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            MouseDown += Register_MouseDown;
            MouseMove += Register_MouseMove;
            MouseUp += Register_MouseUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private MaskedTextBox txt_password;
        private MaskedTextBox txt_password_confirm;
        private Button btn_register;
        private RadioButton rdbtn1;
        private RadioButton rdbtn2;
        private Panel panel2;
        private TextBox txt_username;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Panel panel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Panel panel4;
        private TextBox txt_email;
        private Panel panel5;
        private TextBox txt_age;
        private TextBox txt_pass;
        private Panel panel6;
        private TextBox txt_passconfirm;
        private Button return_btn;
    }
}