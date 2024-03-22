namespace FileSAVER
{
    partial class AdminTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminTools));
            nav_panel = new Panel();
            btn_mainpage = new Button();
            btn_logout = new Button();
            btn_admintools = new Button();
            btn_acc = new Button();
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            richtxt1 = new RichTextBox();
            btn_showlogs = new Button();
            check_loginfail = new CheckBox();
            check_accdel = new CheckBox();
            check_changedpass = new CheckBox();
            check_decrypt = new CheckBox();
            check_encrypt = new CheckBox();
            check_newreg = new CheckBox();
            check_logout = new CheckBox();
            check_login = new CheckBox();
            clearLogs = new Button();
            combo1 = new ComboBox();
            comboBox1 = new ComboBox();
            label9 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lbl_realtype = new Label();
            label12 = new Label();
            btn_save_changes = new Button();
            txtAge = new TextBox();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            label3 = new Label();
            label10 = new Label();
            label11 = new Label();
            label2 = new Label();
            label4 = new Label();
            label13 = new Label();
            label14 = new Label();
            btn_deleteuser = new Button();
            nav_panel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            nav_panel.TabIndex = 12;
            // 
            // btn_mainpage
            // 
            btn_mainpage.FlatAppearance.BorderSize = 0;
            btn_mainpage.FlatStyle = FlatStyle.Flat;
            btn_mainpage.ForeColor = Color.White;
            btn_mainpage.Image = (Image)resources.GetObject("btn_mainpage.Image");
            btn_mainpage.ImageAlign = ContentAlignment.TopCenter;
            btn_mainpage.Location = new Point(-3, 123);
            btn_mainpage.Name = "btn_mainpage";
            btn_mainpage.Size = new Size(225, 108);
            btn_mainpage.TabIndex = 5;
            btn_mainpage.Text = "Encrypt/Decrypt File";
            btn_mainpage.TextAlign = ContentAlignment.BottomCenter;
            btn_mainpage.UseVisualStyleBackColor = true;
            btn_mainpage.Click += btn_mainpage_Click;
            // 
            // btn_logout
            // 
            btn_logout.FlatAppearance.BorderSize = 0;
            btn_logout.FlatStyle = FlatStyle.Flat;
            btn_logout.ForeColor = Color.White;
            btn_logout.Image = (Image)resources.GetObject("btn_logout.Image");
            btn_logout.ImageAlign = ContentAlignment.TopCenter;
            btn_logout.Location = new Point(0, 685);
            btn_logout.Name = "btn_logout";
            btn_logout.Size = new Size(225, 108);
            btn_logout.TabIndex = 3;
            btn_logout.Text = "Log out";
            btn_logout.TextAlign = ContentAlignment.BottomCenter;
            btn_logout.UseVisualStyleBackColor = true;
            btn_logout.Click += btn_logout_Click;
            // 
            // btn_admintools
            // 
            btn_admintools.BackColor = Color.DarkOrange;
            btn_admintools.FlatAppearance.BorderSize = 0;
            btn_admintools.FlatStyle = FlatStyle.Flat;
            btn_admintools.ForeColor = Color.White;
            btn_admintools.Image = (Image)resources.GetObject("btn_admintools.Image");
            btn_admintools.ImageAlign = ContentAlignment.TopCenter;
            btn_admintools.Location = new Point(3, 498);
            btn_admintools.Name = "btn_admintools";
            btn_admintools.Size = new Size(225, 108);
            btn_admintools.TabIndex = 2;
            btn_admintools.Text = "Admin tools";
            btn_admintools.TextAlign = ContentAlignment.BottomCenter;
            btn_admintools.UseVisualStyleBackColor = false;
            // 
            // btn_acc
            // 
            btn_acc.FlatAppearance.BorderSize = 0;
            btn_acc.FlatStyle = FlatStyle.Flat;
            btn_acc.ForeColor = Color.White;
            btn_acc.Image = (Image)resources.GetObject("btn_acc.Image");
            btn_acc.ImageAlign = ContentAlignment.TopCenter;
            btn_acc.Location = new Point(3, 311);
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
            // richtxt1
            // 
            richtxt1.BackColor = Color.Black;
            richtxt1.BorderStyle = BorderStyle.FixedSingle;
            richtxt1.ForeColor = SystemColors.Info;
            richtxt1.Location = new Point(773, 207);
            richtxt1.Name = "richtxt1";
            richtxt1.Size = new Size(444, 578);
            richtxt1.TabIndex = 0;
            richtxt1.Text = "";
            // 
            // btn_showlogs
            // 
            btn_showlogs.BackColor = Color.FromArgb(62, 120, 138);
            btn_showlogs.BackgroundImageLayout = ImageLayout.None;
            btn_showlogs.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_showlogs.ForeColor = Color.White;
            btn_showlogs.Image = (Image)resources.GetObject("btn_showlogs.Image");
            btn_showlogs.ImageAlign = ContentAlignment.MiddleLeft;
            btn_showlogs.Location = new Point(1002, 144);
            btn_showlogs.Name = "btn_showlogs";
            btn_showlogs.Size = new Size(205, 51);
            btn_showlogs.TabIndex = 40;
            btn_showlogs.Text = "Show all logs";
            btn_showlogs.TextAlign = ContentAlignment.MiddleRight;
            btn_showlogs.UseVisualStyleBackColor = false;
            btn_showlogs.Click += btn_showlogs_Click;
            // 
            // check_loginfail
            // 
            check_loginfail.AutoSize = true;
            check_loginfail.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            check_loginfail.ForeColor = Color.White;
            check_loginfail.Location = new Point(1238, 470);
            check_loginfail.Name = "check_loginfail";
            check_loginfail.Size = new Size(182, 28);
            check_loginfail.TabIndex = 39;
            check_loginfail.Text = "Failed to Log in";
            check_loginfail.UseVisualStyleBackColor = true;
            check_loginfail.CheckedChanged += check_loginfail_CheckedChanged;
            // 
            // check_accdel
            // 
            check_accdel.AutoSize = true;
            check_accdel.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            check_accdel.ForeColor = Color.White;
            check_accdel.Location = new Point(1238, 513);
            check_accdel.Name = "check_accdel";
            check_accdel.Size = new Size(207, 28);
            check_accdel.TabIndex = 38;
            check_accdel.Text = "Account deleted";
            check_accdel.UseVisualStyleBackColor = true;
            check_accdel.CheckedChanged += check_accdel_CheckedChanged;
            // 
            // check_changedpass
            // 
            check_changedpass.AutoSize = true;
            check_changedpass.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            check_changedpass.ForeColor = Color.White;
            check_changedpass.Location = new Point(1238, 561);
            check_changedpass.Name = "check_changedpass";
            check_changedpass.Size = new Size(230, 28);
            check_changedpass.TabIndex = 36;
            check_changedpass.Text = "Changed password";
            check_changedpass.UseVisualStyleBackColor = true;
            check_changedpass.CheckedChanged += check_changedpass_CheckedChanged;
            // 
            // check_decrypt
            // 
            check_decrypt.AutoSize = true;
            check_decrypt.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            check_decrypt.ForeColor = Color.White;
            check_decrypt.Location = new Point(1238, 426);
            check_decrypt.Name = "check_decrypt";
            check_decrypt.Size = new Size(182, 28);
            check_decrypt.TabIndex = 35;
            check_decrypt.Text = "Decrypted files";
            check_decrypt.UseVisualStyleBackColor = true;
            check_decrypt.CheckedChanged += check_decrypt_CheckedChanged;
            // 
            // check_encrypt
            // 
            check_encrypt.AutoSize = true;
            check_encrypt.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            check_encrypt.ForeColor = Color.White;
            check_encrypt.Location = new Point(1238, 374);
            check_encrypt.Name = "check_encrypt";
            check_encrypt.Size = new Size(176, 28);
            check_encrypt.TabIndex = 34;
            check_encrypt.Text = "Encrypted files";
            check_encrypt.UseVisualStyleBackColor = true;
            check_encrypt.CheckedChanged += check_encrypt_CheckedChanged;
            // 
            // check_newreg
            // 
            check_newreg.AutoSize = true;
            check_newreg.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            check_newreg.ForeColor = Color.White;
            check_newreg.Location = new Point(1238, 325);
            check_newreg.Name = "check_newreg";
            check_newreg.Size = new Size(138, 28);
            check_newreg.TabIndex = 33;
            check_newreg.Text = "registration";
            check_newreg.UseVisualStyleBackColor = true;
            check_newreg.CheckedChanged += check_newreg_CheckedChanged;
            // 
            // check_logout
            // 
            check_logout.AutoSize = true;
            check_logout.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            check_logout.ForeColor = Color.White;
            check_logout.Location = new Point(1238, 274);
            check_logout.Name = "check_logout";
            check_logout.Size = new Size(107, 28);
            check_logout.TabIndex = 32;
            check_logout.Text = "Log out";
            check_logout.UseVisualStyleBackColor = true;
            check_logout.CheckedChanged += check_logout_CheckedChanged;
            // 
            // check_login
            // 
            check_login.AutoSize = true;
            check_login.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            check_login.ForeColor = Color.White;
            check_login.Location = new Point(1238, 224);
            check_login.Name = "check_login";
            check_login.Size = new Size(89, 28);
            check_login.TabIndex = 31;
            check_login.Text = "Log in";
            check_login.UseVisualStyleBackColor = true;
            check_login.CheckedChanged += check_login_CheckedChanged;
            // 
            // clearLogs
            // 
            clearLogs.BackColor = Color.FromArgb(62, 120, 138);
            clearLogs.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            clearLogs.ForeColor = Color.White;
            clearLogs.Image = (Image)resources.GetObject("clearLogs.Image");
            clearLogs.ImageAlign = ContentAlignment.MiddleLeft;
            clearLogs.Location = new Point(782, 144);
            clearLogs.Name = "clearLogs";
            clearLogs.Size = new Size(205, 51);
            clearLogs.TabIndex = 30;
            clearLogs.Text = "Remove logs";
            clearLogs.TextAlign = ContentAlignment.MiddleRight;
            clearLogs.UseVisualStyleBackColor = false;
            clearLogs.Click += clearLogs_Click;
            // 
            // combo1
            // 
            combo1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            combo1.FormattingEnabled = true;
            combo1.Location = new Point(402, 133);
            combo1.Name = "combo1";
            combo1.Size = new Size(223, 38);
            combo1.TabIndex = 41;
            combo1.SelectedIndexChanged += combo1_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(382, 643);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(221, 38);
            comboBox1.TabIndex = 21;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label9.ForeColor = Color.DarkOrange;
            label9.Location = new Point(344, 77);
            label9.Name = "label9";
            label9.Size = new Size(208, 32);
            label9.TabIndex = 73;
            label9.Text = "Edit account's data";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(62, 120, 138);
            label5.Location = new Point(327, 350);
            label5.Name = "label5";
            label5.Size = new Size(58, 24);
            label5.TabIndex = 72;
            label5.Text = "Age:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(62, 120, 138);
            label6.Location = new Point(316, 279);
            label6.Name = "label6";
            label6.Size = new Size(69, 24);
            label6.TabIndex = 71;
            label6.Text = "Email:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.FromArgb(62, 120, 138);
            label7.Location = new Point(240, 401);
            label7.Name = "label7";
            label7.Size = new Size(157, 24);
            label7.TabIndex = 70;
            label7.Text = "Account type:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = Color.FromArgb(62, 120, 138);
            label8.Location = new Point(267, 207);
            label8.Name = "label8";
            label8.Size = new Size(118, 24);
            label8.TabIndex = 69;
            label8.Text = "Username:";
            // 
            // lbl_realtype
            // 
            lbl_realtype.AutoSize = true;
            lbl_realtype.BackColor = SystemColors.ActiveCaptionText;
            lbl_realtype.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_realtype.ForeColor = Color.DarkOrange;
            lbl_realtype.Location = new Point(426, 401);
            lbl_realtype.Name = "lbl_realtype";
            lbl_realtype.Size = new Size(69, 31);
            lbl_realtype.TabIndex = 68;
            lbl_realtype.Text = "fafaf";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.FromArgb(62, 120, 138);
            label12.Location = new Point(286, 9);
            label12.Name = "label12";
            label12.Size = new Size(317, 56);
            label12.TabIndex = 63;
            label12.Text = "Edit account";
            // 
            // btn_save_changes
            // 
            btn_save_changes.Anchor = AnchorStyles.Left;
            btn_save_changes.BackColor = Color.FromArgb(62, 120, 138);
            btn_save_changes.BackgroundImageLayout = ImageLayout.Center;
            btn_save_changes.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_save_changes.ForeColor = Color.White;
            btn_save_changes.Image = (Image)resources.GetObject("btn_save_changes.Image");
            btn_save_changes.ImageAlign = ContentAlignment.MiddleLeft;
            btn_save_changes.Location = new Point(361, 440);
            btn_save_changes.Margin = new Padding(10);
            btn_save_changes.Name = "btn_save_changes";
            btn_save_changes.Size = new Size(232, 46);
            btn_save_changes.TabIndex = 67;
            btn_save_changes.Text = "Save changes";
            btn_save_changes.TextAlign = ContentAlignment.MiddleRight;
            btn_save_changes.UseVisualStyleBackColor = false;
            btn_save_changes.Click += btn_save_changes_Click;
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtAge.Location = new Point(402, 341);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(223, 37);
            txtAge.TabIndex = 66;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(402, 198);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(223, 37);
            txtUsername.TabIndex = 64;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(402, 270);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(223, 37);
            txtEmail.TabIndex = 65;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(62, 120, 138);
            label3.Location = new Point(259, 144);
            label3.Name = "label3";
            label3.Size = new Size(126, 24);
            label3.TabIndex = 74;
            label3.Text = "Select user:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label10.ForeColor = Color.DarkOrange;
            label10.Location = new Point(1238, 153);
            label10.Name = "label10";
            label10.Size = new Size(137, 32);
            label10.TabIndex = 76;
            label10.Text = "Apply filters";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.FromArgb(62, 120, 138);
            label11.Location = new Point(877, 9);
            label11.Name = "label11";
            label11.Size = new Size(252, 56);
            label11.TabIndex = 75;
            label11.Text = "Users logs";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkOrange;
            label2.Location = new Point(801, 77);
            label2.Name = "label2";
            label2.Size = new Size(416, 32);
            label2.TabIndex = 77;
            label2.Text = "See the actions performed by the users";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.DarkOrange;
            label4.Location = new Point(361, 601);
            label4.Name = "label4";
            label4.Size = new Size(213, 32);
            label4.TabIndex = 79;
            label4.Text = "Delete any account";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.FromArgb(62, 120, 138);
            label13.Location = new Point(286, 535);
            label13.Name = "label13";
            label13.Size = new Size(387, 56);
            label13.TabIndex = 78;
            label13.Text = "Delete account";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label14.ForeColor = Color.FromArgb(62, 120, 138);
            label14.Location = new Point(240, 651);
            label14.Name = "label14";
            label14.Size = new Size(126, 24);
            label14.TabIndex = 80;
            label14.Text = "Select user:";
            // 
            // btn_deleteuser
            // 
            btn_deleteuser.Anchor = AnchorStyles.Left;
            btn_deleteuser.BackColor = Color.FromArgb(62, 120, 138);
            btn_deleteuser.BackgroundImageLayout = ImageLayout.Center;
            btn_deleteuser.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_deleteuser.ForeColor = Color.White;
            btn_deleteuser.Image = (Image)resources.GetObject("btn_deleteuser.Image");
            btn_deleteuser.ImageAlign = ContentAlignment.MiddleLeft;
            btn_deleteuser.Location = new Point(402, 706);
            btn_deleteuser.Margin = new Padding(10);
            btn_deleteuser.Name = "btn_deleteuser";
            btn_deleteuser.Size = new Size(191, 46);
            btn_deleteuser.TabIndex = 81;
            btn_deleteuser.Text = "Delete user";
            btn_deleteuser.TextAlign = ContentAlignment.MiddleRight;
            btn_deleteuser.UseVisualStyleBackColor = false;
            btn_deleteuser.Click += btn_deleteuser_Click;
            // 
            // AdminTools
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 44, 51);
            ClientSize = new Size(1469, 797);
            Controls.Add(btn_deleteuser);
            Controls.Add(label14);
            Controls.Add(label4);
            Controls.Add(label13);
            Controls.Add(label2);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(label3);
            Controls.Add(label9);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(lbl_realtype);
            Controls.Add(label12);
            Controls.Add(btn_save_changes);
            Controls.Add(txtAge);
            Controls.Add(txtUsername);
            Controls.Add(txtEmail);
            Controls.Add(comboBox1);
            Controls.Add(combo1);
            Controls.Add(btn_showlogs);
            Controls.Add(check_loginfail);
            Controls.Add(check_accdel);
            Controls.Add(check_changedpass);
            Controls.Add(check_decrypt);
            Controls.Add(check_encrypt);
            Controls.Add(check_newreg);
            Controls.Add(check_logout);
            Controls.Add(check_login);
            Controls.Add(clearLogs);
            Controls.Add(nav_panel);
            Controls.Add(richtxt1);
            Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminTools";
            Text = "Form6";
            Load += Form6_Load;
            MouseDown += AdminTools_MouseDown;
            MouseMove += AdminTools_MouseMove;
            MouseUp += AdminTools_MouseUp;
            nav_panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel nav_panel;
        private Button btn_logout;
        private Button btn_admintools;
        private Button btn_acc;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private RichTextBox richtxt1;
        private Button btn_showlogs;
        private CheckBox check_loginfail;
        private CheckBox check_accdel;
        private CheckBox check_changedpass;
        private CheckBox check_decrypt;
        private CheckBox check_encrypt;
        private CheckBox check_newreg;
        private CheckBox check_logout;
        private CheckBox check_login;
        private Button clearLogs;
        private ComboBox combo1;
        private Label lbl_type;
        private Label lbl_email;
        private Button btn_save_changes;
        private ComboBox comboBox1;
        private Label label9;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lbl_realtype;
        private Label label12;
        private Button btn_mainpage;
        private TextBox txtAge;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private Label label3;
        private Label label10;
        private Label label11;
        private Label label2;
        private Label label4;
        private Label label13;
        private Label label14;
        private Button btn_deleteuser;
    }
}