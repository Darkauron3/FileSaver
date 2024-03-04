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
            Encryption_button = new Button();
            label7 = new Label();
            nav_panel = new Panel();
            btn_logout = new Button();
            btn_admintools = new Button();
            btn_acc = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            bot_panel = new Panel();
            label11 = new Label();
            label9 = new Label();
            label10 = new Label();
            btn_decrypt = new Button();
            pictureBox2 = new PictureBox();
            txt_decryption = new MaskedTextBox();
            label6 = new Label();
            label8 = new Label();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txt_key_encryption = new MaskedTextBox();
            label1 = new Label();
            nav_panel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            bot_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1123, 670);
            button1.Name = "button1";
            button1.Size = new Size(151, 75);
            button1.TabIndex = 1;
            button1.Text = "Log out";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Logout_clicked;
            // 
            // Encryption_button
            // 
            Encryption_button.BackColor = Color.FromArgb(62, 120, 138);
            Encryption_button.ForeColor = Color.White;
            Encryption_button.Image = (Image)resources.GetObject("Encryption_button.Image");
            Encryption_button.ImageAlign = ContentAlignment.MiddleLeft;
            Encryption_button.Location = new Point(927, 236);
            Encryption_button.Name = "Encryption_button";
            Encryption_button.Size = new Size(281, 46);
            Encryption_button.TabIndex = 4;
            Encryption_button.Text = "Browse File For Encryption";
            Encryption_button.TextAlign = ContentAlignment.MiddleRight;
            Encryption_button.UseVisualStyleBackColor = false;
            Encryption_button.Click += Encryption_button_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(321, 133);
            label7.Name = "label7";
            label7.Size = new Size(245, 66);
            label7.TabIndex = 6;
            label7.Text = "Enter a password \r\nfor encryption ";
            // 
            // nav_panel
            // 
            nav_panel.BackColor = Color.FromArgb(62, 120, 138);
            nav_panel.Controls.Add(btn_logout);
            nav_panel.Controls.Add(btn_admintools);
            nav_panel.Controls.Add(btn_acc);
            nav_panel.Controls.Add(panel1);
            nav_panel.Dock = DockStyle.Left;
            nav_panel.Location = new Point(0, 0);
            nav_panel.Name = "nav_panel";
            nav_panel.Size = new Size(225, 757);
            nav_panel.TabIndex = 11;
            // 
            // btn_logout
            // 
            btn_logout.FlatAppearance.BorderSize = 0;
            btn_logout.FlatStyle = FlatStyle.Flat;
            btn_logout.ForeColor = Color.White;
            btn_logout.Image = (Image)resources.GetObject("btn_logout.Image");
            btn_logout.ImageAlign = ContentAlignment.TopCenter;
            btn_logout.Location = new Point(3, 601);
            btn_logout.Name = "btn_logout";
            btn_logout.Size = new Size(225, 108);
            btn_logout.TabIndex = 3;
            btn_logout.Text = "Log out";
            btn_logout.TextAlign = ContentAlignment.BottomCenter;
            btn_logout.UseVisualStyleBackColor = true;
            // 
            // btn_admintools
            // 
            btn_admintools.FlatAppearance.BorderSize = 0;
            btn_admintools.FlatStyle = FlatStyle.Flat;
            btn_admintools.ForeColor = Color.White;
            btn_admintools.Image = (Image)resources.GetObject("btn_admintools.Image");
            btn_admintools.ImageAlign = ContentAlignment.TopCenter;
            btn_admintools.Location = new Point(0, 383);
            btn_admintools.Name = "btn_admintools";
            btn_admintools.Size = new Size(225, 108);
            btn_admintools.TabIndex = 2;
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
            btn_acc.Location = new Point(0, 173);
            btn_acc.Name = "btn_acc";
            btn_acc.Size = new Size(225, 108);
            btn_acc.TabIndex = 1;
            btn_acc.Text = "My Account";
            btn_acc.TextAlign = ContentAlignment.BottomCenter;
            btn_acc.UseVisualStyleBackColor = true;
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
            bot_panel.Controls.Add(label11);
            bot_panel.Controls.Add(label9);
            bot_panel.Controls.Add(label10);
            bot_panel.Controls.Add(btn_decrypt);
            bot_panel.Controls.Add(pictureBox2);
            bot_panel.Controls.Add(txt_decryption);
            bot_panel.Controls.Add(label6);
            bot_panel.Controls.Add(label8);
            bot_panel.Dock = DockStyle.Bottom;
            bot_panel.Location = new Point(225, 356);
            bot_panel.Name = "bot_panel";
            bot_panel.Size = new Size(1061, 401);
            bot_panel.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(419, 10);
            label11.Name = "label11";
            label11.Size = new Size(223, 44);
            label11.TabIndex = 20;
            label11.Text = "Decrypt file";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(752, 130);
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
            label10.Location = new Point(672, 119);
            label10.Name = "label10";
            label10.Size = new Size(87, 77);
            label10.TabIndex = 20;
            label10.Text = "2.";
            // 
            // btn_decrypt
            // 
            btn_decrypt.BackColor = Color.FromArgb(62, 120, 138);
            btn_decrypt.ForeColor = Color.White;
            btn_decrypt.Image = (Image)resources.GetObject("btn_decrypt.Image");
            btn_decrypt.ImageAlign = ContentAlignment.MiddleLeft;
            btn_decrypt.Location = new Point(702, 245);
            btn_decrypt.Name = "btn_decrypt";
            btn_decrypt.Size = new Size(281, 46);
            btn_decrypt.TabIndex = 20;
            btn_decrypt.Text = "Browse File For Encryption";
            btn_decrypt.TextAlign = ContentAlignment.MiddleRight;
            btn_decrypt.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(457, 119);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(145, 139);
            pictureBox2.TabIndex = 20;
            pictureBox2.TabStop = false;
            // 
            // txt_decryption
            // 
            txt_decryption.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_decryption.Location = new Point(52, 230);
            txt_decryption.Name = "txt_decryption";
            txt_decryption.Size = new Size(318, 41);
            txt_decryption.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(28, 119);
            label6.Name = "label6";
            label6.Size = new Size(87, 77);
            label6.TabIndex = 20;
            label6.Text = "1.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(106, 130);
            label8.Name = "label8";
            label8.Size = new Size(245, 66);
            label8.TabIndex = 19;
            label8.Text = "Enter a password \r\nfor decryption ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(644, 16);
            label2.Name = "label2";
            label2.Size = new Size(214, 44);
            label2.TabIndex = 13;
            label2.Text = "Encrypt file";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(682, 143);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(145, 139);
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
            label4.Location = new Point(900, 132);
            label4.Name = "label4";
            label4.Size = new Size(87, 77);
            label4.TabIndex = 17;
            label4.Text = "2.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(980, 143);
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
            txt_key_encryption.Size = new Size(318, 41);
            txt_key_encryption.TabIndex = 19;
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
            // Form3
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 44, 51);
            ClientSize = new Size(1286, 757);
            Controls.Add(txt_key_encryption);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(pictureBox3);
            Controls.Add(label2);
            Controls.Add(bot_panel);
            Controls.Add(nav_panel);
            Controls.Add(label7);
            Controls.Add(Encryption_button);
            Controls.Add(button1);
            Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(62, 120, 138);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form3";
            Text = "Form3";
            FormClosed += Closebutton_clicked;
            nav_panel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            bot_panel.ResumeLayout(false);
            bot_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button Encryption_button;
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
        private MaskedTextBox txt_decryption;
        private Label label11;
        private Label label9;
        private Label label10;
        private Button btn_decrypt;
        private PictureBox pictureBox2;
        private Label label1;
    }
}