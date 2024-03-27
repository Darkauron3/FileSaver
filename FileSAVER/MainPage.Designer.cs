namespace FileSAVER
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            button1 = new Button();
            Choose_encryption_file = new Button();
            label7 = new Label();
            nav_panel = new Panel();
            btn_mainpage = new Button();
            btn_logout = new Button();
            btn_admintools = new Button();
            btn_acc = new Button();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            bot_panel = new Panel();
            lbl_decryption_choosen = new Label();
            label17 = new Label();
            btn_decrypto = new Button();
            label14 = new Label();
            label15 = new Label();
            pictureBox5 = new PictureBox();
            pictureBox2 = new PictureBox();
            label11 = new Label();
            label9 = new Label();
            label10 = new Label();
            Choose_decryption_file = new Button();
            txt_key_decryption = new MaskedTextBox();
            label6 = new Label();
            label8 = new Label();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txt_key_encryption = new MaskedTextBox();
            pictureBox4 = new PictureBox();
            label12 = new Label();
            label13 = new Label();
            btn_encrypt = new Button();
            lbl_choosen_en_file = new Label();
            label16 = new Label();
            nav_panel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            bot_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1306, 710);
            button1.Name = "button1";
            button1.Size = new Size(151, 75);
            button1.TabIndex = 1;
            button1.Text = "Log out";
            button1.UseVisualStyleBackColor = true;
            // 
            // Choose_encryption_file
            // 
            Choose_encryption_file.BackColor = Color.FromArgb(62, 120, 138);
            Choose_encryption_file.ForeColor = Color.White;
            Choose_encryption_file.Image = (Image)resources.GetObject("Choose_encryption_file.Image");
            Choose_encryption_file.ImageAlign = ContentAlignment.MiddleLeft;
            Choose_encryption_file.Location = new Point(756, 215);
            Choose_encryption_file.Name = "Choose_encryption_file";
            Choose_encryption_file.Size = new Size(281, 46);
            Choose_encryption_file.TabIndex = 4;
            Choose_encryption_file.Text = "Browse File For Encryption";
            Choose_encryption_file.TextAlign = ContentAlignment.MiddleRight;
            Choose_encryption_file.UseVisualStyleBackColor = false;
            Choose_encryption_file.Click += Choose_encryption_file_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.DarkOrange;
            label7.Location = new Point(321, 133);
            label7.Name = "label7";
            label7.Size = new Size(245, 66);
            label7.TabIndex = 6;
            label7.Text = "Enter a password \r\nfor encryption ";
            // 
            // nav_panel
            // 
            nav_panel.BackColor = Color.FromArgb(62, 120, 138);
            nav_panel.Controls.Add(btn_mainpage);
            nav_panel.Controls.Add(btn_logout);
            nav_panel.Controls.Add(btn_admintools);
            nav_panel.Controls.Add(btn_acc);
            nav_panel.Controls.Add(panel1);
            nav_panel.Dock = DockStyle.Left;
            nav_panel.Location = new Point(0, 0);
            nav_panel.Name = "nav_panel";
            nav_panel.Size = new Size(225, 797);
            nav_panel.TabIndex = 11;
            // 
            // btn_mainpage
            // 
            btn_mainpage.BackColor = Color.DarkOrange;
            btn_mainpage.FlatAppearance.BorderSize = 0;
            btn_mainpage.FlatStyle = FlatStyle.Flat;
            btn_mainpage.ForeColor = Color.White;
            btn_mainpage.Image = (Image)resources.GetObject("btn_mainpage.Image");
            btn_mainpage.ImageAlign = ContentAlignment.TopCenter;
            btn_mainpage.Location = new Point(-3, 106);
            btn_mainpage.Name = "btn_mainpage";
            btn_mainpage.Size = new Size(228, 123);
            btn_mainpage.TabIndex = 4;
            btn_mainpage.Text = "Encrypt/Decrypt File";
            btn_mainpage.TextAlign = ContentAlignment.BottomCenter;
            btn_mainpage.UseVisualStyleBackColor = false;
            // 
            // btn_logout
            // 
            btn_logout.FlatAppearance.BorderSize = 0;
            btn_logout.FlatStyle = FlatStyle.Flat;
            btn_logout.ForeColor = Color.White;
            btn_logout.Image = (Image)resources.GetObject("btn_logout.Image");
            btn_logout.ImageAlign = ContentAlignment.TopCenter;
            btn_logout.Location = new Point(3, 681);
            btn_logout.Name = "btn_logout";
            btn_logout.Size = new Size(225, 116);
            btn_logout.TabIndex = 3;
            btn_logout.Text = "Log out";
            btn_logout.TextAlign = ContentAlignment.BottomCenter;
            btn_logout.UseVisualStyleBackColor = true;
            btn_logout.Click += btn_logout_Click;
            // 
            // btn_admintools
            // 
            btn_admintools.FlatAppearance.BorderSize = 0;
            btn_admintools.FlatStyle = FlatStyle.Flat;
            btn_admintools.ForeColor = Color.White;
            btn_admintools.Image = (Image)resources.GetObject("btn_admintools.Image");
            btn_admintools.ImageAlign = ContentAlignment.TopCenter;
            btn_admintools.Location = new Point(3, 473);
            btn_admintools.Name = "btn_admintools";
            btn_admintools.Size = new Size(225, 129);
            btn_admintools.TabIndex = 2;
            btn_admintools.Text = "Admin tools";
            btn_admintools.TextAlign = ContentAlignment.BottomCenter;
            btn_admintools.UseVisualStyleBackColor = true;
            btn_admintools.Click += btn_admintools_Click;
            // 
            // btn_acc
            // 
            btn_acc.FlatAppearance.BorderSize = 0;
            btn_acc.FlatStyle = FlatStyle.Flat;
            btn_acc.ForeColor = Color.White;
            btn_acc.Image = (Image)resources.GetObject("btn_acc.Image");
            btn_acc.ImageAlign = ContentAlignment.TopCenter;
            btn_acc.Location = new Point(3, 282);
            btn_acc.Name = "btn_acc";
            btn_acc.Size = new Size(225, 108);
            btn_acc.TabIndex = 1;
            btn_acc.Text = "My Account";
            btn_acc.TextAlign = ContentAlignment.BottomCenter;
            btn_acc.UseVisualStyleBackColor = true;
            btn_acc.Click += btn_acc_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(225, 88);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Corbel", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 63);
            label1.Name = "label1";
            label1.Size = new Size(222, 18);
            label1.TabIndex = 2;
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
            // bot_panel
            // 
            bot_panel.Controls.Add(lbl_decryption_choosen);
            bot_panel.Controls.Add(label17);
            bot_panel.Controls.Add(btn_decrypto);
            bot_panel.Controls.Add(label14);
            bot_panel.Controls.Add(label15);
            bot_panel.Controls.Add(pictureBox5);
            bot_panel.Controls.Add(pictureBox2);
            bot_panel.Controls.Add(label11);
            bot_panel.Controls.Add(label9);
            bot_panel.Controls.Add(label10);
            bot_panel.Controls.Add(Choose_decryption_file);
            bot_panel.Controls.Add(txt_key_decryption);
            bot_panel.Controls.Add(label6);
            bot_panel.Controls.Add(label8);
            bot_panel.Dock = DockStyle.Bottom;
            bot_panel.Location = new Point(225, 396);
            bot_panel.Name = "bot_panel";
            bot_panel.Size = new Size(1244, 401);
            bot_panel.TabIndex = 12;
            // 
            // lbl_decryption_choosen
            // 
            lbl_decryption_choosen.AutoSize = true;
            lbl_decryption_choosen.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_decryption_choosen.ForeColor = Color.White;
            lbl_decryption_choosen.Location = new Point(531, 314);
            lbl_decryption_choosen.Name = "lbl_decryption_choosen";
            lbl_decryption_choosen.Size = new Size(0, 24);
            lbl_decryption_choosen.TabIndex = 27;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(531, 272);
            label17.Name = "label17";
            label17.Size = new Size(143, 24);
            label17.TabIndex = 26;
            label17.Text = "Choosen file:";
            // 
            // btn_decrypto
            // 
            btn_decrypto.BackColor = Color.FromArgb(62, 120, 138);
            btn_decrypto.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_decrypto.ForeColor = Color.Black;
            btn_decrypto.Image = (Image)resources.GetObject("btn_decrypto.Image");
            btn_decrypto.ImageAlign = ContentAlignment.MiddleLeft;
            btn_decrypto.Location = new Point(1001, 225);
            btn_decrypto.Name = "btn_decrypto";
            btn_decrypto.Size = new Size(165, 46);
            btn_decrypto.TabIndex = 24;
            btn_decrypto.Text = "Decrypt";
            btn_decrypto.UseVisualStyleBackColor = false;
            btn_decrypto.Click += btn_decrypto_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.DarkOrange;
            label14.Location = new Point(1001, 163);
            label14.Name = "label14";
            label14.Size = new Size(218, 33);
            label14.TabIndex = 25;
            label14.Text = "Encrypt the file!";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.White;
            label15.Location = new Point(923, 136);
            label15.Name = "label15";
            label15.Size = new Size(87, 77);
            label15.TabIndex = 24;
            label15.Text = "3.";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(833, 158);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(68, 66);
            pictureBox5.TabIndex = 25;
            pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(408, 158);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(68, 66);
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(480, 9);
            label11.Name = "label11";
            label11.Size = new Size(290, 56);
            label11.TabIndex = 20;
            label11.Text = "Decrypt file";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.DarkOrange;
            label9.Location = new Point(581, 140);
            label9.Name = "label9";
            label9.Size = new Size(249, 66);
            label9.TabIndex = 21;
            label9.Text = "Browse file that \r\nwill be decrypted";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(515, 133);
            label10.Name = "label10";
            label10.Size = new Size(87, 77);
            label10.TabIndex = 20;
            label10.Text = "2.";
            // 
            // Choose_decryption_file
            // 
            Choose_decryption_file.BackColor = Color.FromArgb(62, 120, 138);
            Choose_decryption_file.ForeColor = Color.White;
            Choose_decryption_file.Image = (Image)resources.GetObject("Choose_decryption_file.Image");
            Choose_decryption_file.ImageAlign = ContentAlignment.MiddleLeft;
            Choose_decryption_file.Location = new Point(531, 223);
            Choose_decryption_file.Name = "Choose_decryption_file";
            Choose_decryption_file.Size = new Size(281, 46);
            Choose_decryption_file.TabIndex = 20;
            Choose_decryption_file.Text = "Browse File For Decryption";
            Choose_decryption_file.TextAlign = ContentAlignment.MiddleRight;
            Choose_decryption_file.UseVisualStyleBackColor = false;
            Choose_decryption_file.Click += Choose_decryption_file_Click;
            // 
            // txt_key_decryption
            // 
            txt_key_decryption.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_key_decryption.Location = new Point(52, 228);
            txt_key_decryption.Name = "txt_key_decryption";
            txt_key_decryption.PasswordChar = '*';
            txt_key_decryption.Size = new Size(318, 41);
            txt_key_decryption.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(18, 119);
            label6.Name = "label6";
            label6.Size = new Size(87, 77);
            label6.TabIndex = 20;
            label6.Text = "1.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.DarkOrange;
            label8.Location = new Point(96, 130);
            label8.Name = "label8";
            label8.Size = new Size(245, 66);
            label8.TabIndex = 19;
            label8.Text = "Enter a password \r\nfor decryption ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(705, 9);
            label2.Name = "label2";
            label2.Size = new Size(279, 56);
            label2.TabIndex = 13;
            label2.Text = "Encrypt file";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(644, 178);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(68, 66);
            pictureBox3.TabIndex = 15;
            pictureBox3.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(243, 122);
            label3.Name = "label3";
            label3.Size = new Size(87, 77);
            label3.TabIndex = 16;
            label3.Text = "1.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(740, 132);
            label4.Name = "label4";
            label4.Size = new Size(87, 77);
            label4.TabIndex = 17;
            label4.Text = "2.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.DarkOrange;
            label5.Location = new Point(806, 133);
            label5.Name = "label5";
            label5.Size = new Size(246, 66);
            label5.TabIndex = 18;
            label5.Text = "Browse file that \r\nwill be encrypted";
            // 
            // txt_key_encryption
            // 
            txt_key_encryption.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_key_encryption.Location = new Point(277, 214);
            txt_key_encryption.Name = "txt_key_encryption";
            txt_key_encryption.PasswordChar = '*';
            txt_key_encryption.Size = new Size(318, 41);
            txt_key_encryption.TabIndex = 19;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(1058, 178);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(68, 66);
            pictureBox4.TabIndex = 20;
            pictureBox4.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.DarkOrange;
            label12.Location = new Point(1217, 133);
            label12.Name = "label12";
            label12.Size = new Size(218, 33);
            label12.TabIndex = 22;
            label12.Text = "Encrypt the file!";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(1139, 106);
            label13.Name = "label13";
            label13.Size = new Size(87, 77);
            label13.TabIndex = 21;
            label13.Text = "3.";
            // 
            // btn_encrypt
            // 
            btn_encrypt.BackColor = Color.FromArgb(62, 120, 138);
            btn_encrypt.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btn_encrypt.ForeColor = Color.Black;
            btn_encrypt.Image = (Image)resources.GetObject("btn_encrypt.Image");
            btn_encrypt.ImageAlign = ContentAlignment.MiddleLeft;
            btn_encrypt.Location = new Point(1223, 200);
            btn_encrypt.Name = "btn_encrypt";
            btn_encrypt.Size = new Size(168, 46);
            btn_encrypt.TabIndex = 23;
            btn_encrypt.Text = "Encrypt";
            btn_encrypt.UseVisualStyleBackColor = false;
            btn_encrypt.Click += btn_encrypt_Click;
            // 
            // lbl_choosen_en_file
            // 
            lbl_choosen_en_file.AutoSize = true;
            lbl_choosen_en_file.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_choosen_en_file.ForeColor = Color.White;
            lbl_choosen_en_file.Location = new Point(756, 297);
            lbl_choosen_en_file.Name = "lbl_choosen_en_file";
            lbl_choosen_en_file.Size = new Size(0, 24);
            lbl_choosen_en_file.TabIndex = 24;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label16.ForeColor = Color.White;
            label16.Location = new Point(756, 264);
            label16.Name = "label16";
            label16.Size = new Size(143, 24);
            label16.TabIndex = 25;
            label16.Text = "Choosen file:";
            // 
            // MainPage
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 44, 51);
            ClientSize = new Size(1469, 797);
            Controls.Add(label16);
            Controls.Add(lbl_choosen_en_file);
            Controls.Add(btn_encrypt);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(pictureBox4);
            Controls.Add(txt_key_encryption);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox3);
            Controls.Add(label2);
            Controls.Add(bot_panel);
            Controls.Add(nav_panel);
            Controls.Add(label7);
            Controls.Add(Choose_encryption_file);
            Controls.Add(button1);
            Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(62, 120, 138);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainPage";
            Text = "Form3";
            MouseDown += MainPage_MouseDown;
            MouseMove += MainPage_MouseMove;
            MouseUp += MainPage_MouseUp;
            nav_panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            bot_panel.ResumeLayout(false);
            bot_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button Choose_encryption_file;
        private Label label7;
        private Panel nav_panel;
        private Panel panel1;
        private Panel bot_panel;
        private PictureBox pictureBox1;
        private Button btn_acc;
        private Button btn_admintools;
        private Button btn_logout;
        private Label label2;
        private PictureBox pictureBox3;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private MaskedTextBox txt_key_encryption;
        private MaskedTextBox txt_key_decryption;
        private Label label11;
        private Label label9;
        private Label label10;
        private Button Choose_decryption_file;
        private Label label1;
        private Button btn_mainpage;
        private PictureBox pictureBox4;
        private Label label12;
        private Label label13;
        private Button btn_encrypt;
        private PictureBox pictureBox2;
        private Button btn_decrypto;
        private Label label14;
        private Label label15;
        private PictureBox pictureBox5;
        private Label lbl_choosen_en_file;
        private Label label16;
        private Label lbl_decryption_choosen;
        private Label label17;
    }
}