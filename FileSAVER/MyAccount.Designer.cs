﻿namespace FileSAVER
{
    partial class MyAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyAccount));
            panel1 = new Panel();
            btn_logout = new Button();
            panel2 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btn_admintools = new Button();
            btn_acc = new Button();
            label5 = new Label();
            label7 = new Label();
            lbl_acc_type = new Label();
            label6 = new Label();
            button2 = new Button();
            txt_age = new TextBox();
            txt_username = new TextBox();
            txt_email = new TextBox();
            label2 = new Label();
            label4 = new Label();
            btn_changepass = new Button();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            txt_newpass_confirm = new MaskedTextBox();
            txt_newpass = new MaskedTextBox();
            txt_oldpass = new MaskedTextBox();
            label3 = new Label();
            label8 = new Label();
            label9 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(62, 120, 138);
            panel1.Controls.Add(btn_logout);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btn_admintools);
            panel1.Controls.Add(btn_acc);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 605);
            panel1.TabIndex = 0;
            // 
            // btn_logout
            // 
            btn_logout.FlatAppearance.BorderSize = 0;
            btn_logout.FlatStyle = FlatStyle.Flat;
            btn_logout.ForeColor = Color.White;
            btn_logout.Image = (Image)resources.GetObject("btn_logout.Image");
            btn_logout.ImageAlign = ContentAlignment.TopCenter;
            btn_logout.Location = new Point(8, 442);
            btn_logout.Name = "btn_logout";
            btn_logout.Size = new Size(225, 108);
            btn_logout.TabIndex = 6;
            btn_logout.Text = "Log out";
            btn_logout.TextAlign = ContentAlignment.BottomCenter;
            btn_logout.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(233, 88);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 63);
            label1.Name = "label1";
            label1.Size = new Size(222, 18);
            label1.TabIndex = 1;
            label1.Text = "\"Where Security Meets Simplicity\"";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(228, 57);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btn_admintools
            // 
            btn_admintools.FlatAppearance.BorderSize = 0;
            btn_admintools.FlatStyle = FlatStyle.Flat;
            btn_admintools.ForeColor = Color.White;
            btn_admintools.Image = (Image)resources.GetObject("btn_admintools.Image");
            btn_admintools.ImageAlign = ContentAlignment.TopCenter;
            btn_admintools.Location = new Point(5, 277);
            btn_admintools.Name = "btn_admintools";
            btn_admintools.Size = new Size(225, 108);
            btn_admintools.TabIndex = 5;
            btn_admintools.Text = "Admin tools";
            btn_admintools.TextAlign = ContentAlignment.BottomCenter;
            btn_admintools.UseVisualStyleBackColor = true;
            // 
            // btn_acc
            // 
            btn_acc.FlatAppearance.BorderSize = 0;
            btn_acc.FlatStyle = FlatStyle.Flat;
            btn_acc.ForeColor = Color.White;
            btn_acc.Image = (Image)resources.GetObject("btn_acc.Image");
            btn_acc.ImageAlign = ContentAlignment.TopCenter;
            btn_acc.Location = new Point(5, 120);
            btn_acc.Name = "btn_acc";
            btn_acc.Size = new Size(225, 108);
            btn_acc.TabIndex = 4;
            btn_acc.Text = "My Account";
            btn_acc.TextAlign = ContentAlignment.BottomCenter;
            btn_acc.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(62, 120, 138);
            label5.Location = new Point(256, 399);
            label5.Name = "label5";
            label5.Size = new Size(157, 24);
            label5.TabIndex = 28;
            label5.Text = "Account type:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(62, 120, 138);
            label7.Location = new Point(283, 205);
            label7.Name = "label7";
            label7.Size = new Size(118, 24);
            label7.TabIndex = 25;
            label7.Text = "Username:";
            // 
            // lbl_acc_type
            // 
            lbl_acc_type.AutoSize = true;
            lbl_acc_type.BackColor = SystemColors.ActiveCaptionText;
            lbl_acc_type.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_acc_type.ForeColor = Color.Olive;
            lbl_acc_type.Location = new Point(442, 399);
            lbl_acc_type.Name = "lbl_acc_type";
            lbl_acc_type.Size = new Size(69, 31);
            lbl_acc_type.TabIndex = 24;
            lbl_acc_type.Text = "fafaf";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(62, 120, 138);
            label6.Location = new Point(317, 53);
            label6.Name = "label6";
            label6.Size = new Size(339, 56);
            label6.TabIndex = 19;
            label6.Text = "Your account";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Left;
            button2.BackColor = Color.FromArgb(62, 120, 138);
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(377, 438);
            button2.Margin = new Padding(10);
            button2.Name = "button2";
            button2.Size = new Size(232, 46);
            button2.TabIndex = 23;
            button2.Text = "Save changes";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            // 
            // txt_age
            // 
            txt_age.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_age.Location = new Point(418, 339);
            txt_age.Name = "txt_age";
            txt_age.Size = new Size(223, 39);
            txt_age.TabIndex = 22;
            // 
            // txt_username
            // 
            txt_username.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_username.Location = new Point(418, 196);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(223, 39);
            txt_username.TabIndex = 20;
            // 
            // txt_email
            // 
            txt_email.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_email.Location = new Point(418, 268);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(223, 39);
            txt_email.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(62, 120, 138);
            label2.Location = new Point(332, 277);
            label2.Name = "label2";
            label2.Size = new Size(69, 24);
            label2.TabIndex = 29;
            label2.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(62, 120, 138);
            label4.Location = new Point(343, 348);
            label4.Name = "label4";
            label4.Size = new Size(58, 24);
            label4.TabIndex = 30;
            label4.Text = "Age:";
            // 
            // btn_changepass
            // 
            btn_changepass.BackColor = Color.FromArgb(62, 120, 138);
            btn_changepass.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_changepass.ForeColor = Color.White;
            btn_changepass.Image = (Image)resources.GetObject("btn_changepass.Image");
            btn_changepass.ImageAlign = ContentAlignment.MiddleLeft;
            btn_changepass.Location = new Point(1060, 436);
            btn_changepass.Name = "btn_changepass";
            btn_changepass.Size = new Size(271, 48);
            btn_changepass.TabIndex = 37;
            btn_changepass.Text = "Change password";
            btn_changepass.TextAlign = ContentAlignment.MiddleRight;
            btn_changepass.UseVisualStyleBackColor = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(859, 339);
            label17.Name = "label17";
            label17.Size = new Size(245, 24);
            label17.TabIndex = 36;
            label17.Text = "Confirm New Password";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(944, 268);
            label16.Name = "label16";
            label16.Size = new Size(160, 24);
            label16.TabIndex = 35;
            label16.Text = "New password";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(957, 205);
            label15.Name = "label15";
            label15.Size = new Size(147, 24);
            label15.TabIndex = 34;
            label15.Text = "Old Password";
            // 
            // txt_newpass_confirm
            // 
            txt_newpass_confirm.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_newpass_confirm.Location = new Point(1131, 339);
            txt_newpass_confirm.Name = "txt_newpass_confirm";
            txt_newpass_confirm.Size = new Size(213, 33);
            txt_newpass_confirm.TabIndex = 33;
            // 
            // txt_newpass
            // 
            txt_newpass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_newpass.Location = new Point(1131, 267);
            txt_newpass.Name = "txt_newpass";
            txt_newpass.Size = new Size(213, 33);
            txt_newpass.TabIndex = 32;
            // 
            // txt_oldpass
            // 
            txt_oldpass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_oldpass.Location = new Point(1131, 202);
            txt_oldpass.Name = "txt_oldpass";
            txt_oldpass.Size = new Size(213, 33);
            txt_oldpass.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(62, 120, 138);
            label3.Location = new Point(956, 53);
            label3.Name = "label3";
            label3.Size = new Size(449, 56);
            label3.TabIndex = 38;
            label3.Text = "Change password";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label8.ForeColor = Color.Olive;
            label8.Location = new Point(944, 120);
            label8.Name = "label8";
            label8.Size = new Size(476, 32);
            label8.TabIndex = 39;
            label8.Text = "Change your current password with new one";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label9.ForeColor = Color.Olive;
            label9.Location = new Point(341, 120);
            label9.Name = "label9";
            label9.Size = new Size(282, 32);
            label9.TabIndex = 40;
            label9.Text = "Change your current data";
            // 
            // Form5
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 44, 51);
            ClientSize = new Size(1462, 605);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(btn_changepass);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(txt_newpass_confirm);
            Controls.Add(txt_newpass);
            Controls.Add(txt_oldpass);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label7);
            Controls.Add(lbl_acc_type);
            Controls.Add(label6);
            Controls.Add(button2);
            Controls.Add(txt_age);
            Controls.Add(txt_username);
            Controls.Add(txt_email);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(62, 120, 138);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form5";
            Text = "Form5";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btn_logout;
        private Button btn_admintools;
        private Button btn_acc;
        private Label label5;
        private Label label7;
        private Label lbl_acc_type;
        private Label label6;
        private Button button2;
        private TextBox txt_age;
        private TextBox txt_username;
        private TextBox txt_email;
        private Label label2;
        private Label label4;
        private Button btn_changepass;
        private Label label17;
        private Label label16;
        private Label label15;
        private MaskedTextBox txt_newpass_confirm;
        private MaskedTextBox txt_newpass;
        private MaskedTextBox txt_oldpass;
        private Label label3;
        private Label label8;
        private Label label9;
    }
}