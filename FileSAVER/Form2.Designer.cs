using System.Runtime.CompilerServices;

namespace FileSAVER
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txt_username = new TextBox();
            label4 = new Label();
            txt_password = new MaskedTextBox();
            txt_password_confirm = new MaskedTextBox();
            linkLabel1 = new LinkLabel();
            label5 = new Label();
            txt_email = new TextBox();
            label6 = new Label();
            txt_age = new TextBox();
            btn1 = new Button();
            btn2 = new Button();
            rdbtn1 = new RadioButton();
            rdbtn2 = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(245, 29);
            label1.Name = "label1";
            label1.Size = new Size(107, 32);
            label1.TabIndex = 0;
            label1.Text = "Register";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(83, 103);
            label2.Name = "label2";
            label2.Size = new Size(108, 27);
            label2.TabIndex = 1;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(83, 164);
            label3.Name = "label3";
            label3.Size = new Size(95, 25);
            label3.TabIndex = 2;
            label3.Text = "Password:";
            // 
            // txt_username
            // 
            txt_username.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_username.Location = new Point(190, 100);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(263, 33);
            txt_username.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(26, 211);
            label4.Name = "label4";
            label4.Size = new Size(158, 25);
            label4.TabIndex = 4;
            label4.Text = "Repeat password:";
            // 
            // txt_password
            // 
            txt_password.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_password.Location = new Point(190, 161);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(263, 33);
            txt_password.TabIndex = 7;
            // 
            // txt_password_confirm
            // 
            txt_password_confirm.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_password_confirm.Location = new Point(190, 211);
            txt_password_confirm.Name = "txt_password_confirm";
            txt_password_confirm.PasswordChar = '*';
            txt_password_confirm.Size = new Size(263, 33);
            txt_password_confirm.TabIndex = 8;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(284, 82);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(187, 15);
            linkLabel1.TabIndex = 9;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "You have an account? Log in here!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(77, 275);
            label5.Name = "label5";
            label5.Size = new Size(62, 25);
            label5.TabIndex = 10;
            label5.Text = "Email:";
            // 
            // txt_email
            // 
            txt_email.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_email.Location = new Point(190, 272);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(263, 33);
            txt_email.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(77, 331);
            label6.Name = "label6";
            label6.Size = new Size(49, 25);
            label6.TabIndex = 12;
            label6.Text = "Age:";
            // 
            // txt_age
            // 
            txt_age.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_age.Location = new Point(190, 331);
            txt_age.Name = "txt_age";
            txt_age.Size = new Size(263, 33);
            txt_age.TabIndex = 13;
            // 
            // btn1
            // 
            btn1.Location = new Point(129, 487);
            btn1.Name = "btn1";
            btn1.Size = new Size(97, 45);
            btn1.TabIndex = 14;
            btn1.Text = "Register!";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(333, 487);
            btn2.Name = "btn2";
            btn2.Size = new Size(97, 45);
            btn2.TabIndex = 15;
            btn2.Text = "Clear";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // rdbtn1
            // 
            rdbtn1.AutoSize = true;
            rdbtn1.Location = new Point(142, 417);
            rdbtn1.Name = "rdbtn1";
            rdbtn1.Size = new Size(135, 19);
            rdbtn1.TabIndex = 18;
            rdbtn1.Text = "Administrator profile";
            rdbtn1.UseVisualStyleBackColor = true;
            // 
            // rdbtn2
            // 
            rdbtn2.AutoSize = true;
            rdbtn2.Checked = true;
            rdbtn2.Location = new Point(310, 417);
            rdbtn2.Name = "rdbtn2";
            rdbtn2.Size = new Size(90, 19);
            rdbtn2.TabIndex = 19;
            rdbtn2.TabStop = true;
            rdbtn2.Text = "Normal user";
            rdbtn2.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(595, 544);
            Controls.Add(rdbtn2);
            Controls.Add(rdbtn1);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(txt_age);
            Controls.Add(label6);
            Controls.Add(txt_email);
            Controls.Add(label5);
            Controls.Add(linkLabel1);
            Controls.Add(txt_password_confirm);
            Controls.Add(txt_password);
            Controls.Add(label4);
            Controls.Add(txt_username);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(611, 583);
            MinimumSize = new Size(611, 583);
            Name = "Form2";
            Text = "Form2";
            FormClosed += Form2_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txt_username;
        private Label label4;
        private MaskedTextBox txt_password;
        private MaskedTextBox txt_password_confirm;
        private LinkLabel linkLabel1;
        private Label label5;
        private TextBox txt_email;
        private Label label6;
        private TextBox txt_age;
        private Button btn1;
        private Button btn2;
        private RadioButton rdbtn1;
        private RadioButton rdbtn2;
    }
}