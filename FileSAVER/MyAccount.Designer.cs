namespace FileSAVER
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
            btn_mainpage = new Button();
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
            btn_savechanges = new Button();
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
            closed_eye1 = new PictureBox();
            closedeye_2 = new PictureBox();
            closedeye_3 = new PictureBox();
            openeye_1 = new PictureBox();
            openeye_2 = new PictureBox();
            openeye_3 = new PictureBox();
            richtxt_myfiles = new RichTextBox();
            label10 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closed_eye1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closedeye_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)closedeye_3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)openeye_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)openeye_2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)openeye_3).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(62, 120, 138);
            panel1.Controls.Add(btn_mainpage);
            panel1.Controls.Add(btn_logout);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btn_admintools);
            panel1.Controls.Add(btn_acc);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 797);
            panel1.TabIndex = 0;
            // 
            // btn_mainpage
            // 
            btn_mainpage.BackColor = Color.Transparent;
            btn_mainpage.FlatAppearance.BorderSize = 0;
            btn_mainpage.FlatStyle = FlatStyle.Flat;
            btn_mainpage.ForeColor = Color.White;
            btn_mainpage.Image = (Image)resources.GetObject("btn_mainpage.Image");
            btn_mainpage.ImageAlign = ContentAlignment.TopCenter;
            btn_mainpage.Location = new Point(0, 120);
            btn_mainpage.Name = "btn_mainpage";
            btn_mainpage.Size = new Size(233, 108);
            btn_mainpage.TabIndex = 7;
            btn_mainpage.Text = "Encrypt/Decrypt File";
            btn_mainpage.TextAlign = ContentAlignment.BottomCenter;
            btn_mainpage.UseVisualStyleBackColor = false;
            btn_mainpage.Click += btn_mainpage_Click;
            // 
            // btn_logout
            // 
            btn_logout.FlatAppearance.BorderSize = 0;
            btn_logout.FlatStyle = FlatStyle.Flat;
            btn_logout.ForeColor = Color.White;
            btn_logout.Image = (Image)resources.GetObject("btn_logout.Image");
            btn_logout.ImageAlign = ContentAlignment.TopCenter;
            btn_logout.Location = new Point(5, 689);
            btn_logout.Name = "btn_logout";
            btn_logout.Size = new Size(225, 108);
            btn_logout.TabIndex = 6;
            btn_logout.Text = "Log out";
            btn_logout.TextAlign = ContentAlignment.BottomCenter;
            btn_logout.UseVisualStyleBackColor = true;
            btn_logout.Click += btn_logout_Click;
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
            btn_admintools.Location = new Point(0, 495);
            btn_admintools.Name = "btn_admintools";
            btn_admintools.Size = new Size(233, 108);
            btn_admintools.TabIndex = 5;
            btn_admintools.Text = "Admin tools";
            btn_admintools.TextAlign = ContentAlignment.BottomCenter;
            btn_admintools.UseVisualStyleBackColor = true;
            btn_admintools.Click += btn_admintools_Click;
            btn_admintools.MouseMove += MyAccount_MouseMove;
            // 
            // btn_acc
            // 
            btn_acc.BackColor = Color.DarkOrange;
            btn_acc.FlatAppearance.BorderSize = 0;
            btn_acc.FlatStyle = FlatStyle.Flat;
            btn_acc.ForeColor = Color.White;
            btn_acc.Image = (Image)resources.GetObject("btn_acc.Image");
            btn_acc.ImageAlign = ContentAlignment.TopCenter;
            btn_acc.Location = new Point(0, 295);
            btn_acc.Name = "btn_acc";
            btn_acc.Size = new Size(233, 115);
            btn_acc.TabIndex = 4;
            btn_acc.Text = "My Account";
            btn_acc.TextAlign = ContentAlignment.BottomCenter;
            btn_acc.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(62, 120, 138);
            label5.Location = new Point(255, 355);
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
            label7.Location = new Point(282, 161);
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
            lbl_acc_type.ForeColor = Color.DarkOrange;
            lbl_acc_type.Location = new Point(441, 355);
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
            label6.Location = new Point(316, 9);
            label6.Name = "label6";
            label6.Size = new Size(339, 56);
            label6.TabIndex = 19;
            label6.Text = "Your account";
            // 
            // btn_savechanges
            // 
            btn_savechanges.Anchor = AnchorStyles.Left;
            btn_savechanges.BackColor = Color.FromArgb(62, 120, 138);
            btn_savechanges.BackgroundImageLayout = ImageLayout.Center;
            btn_savechanges.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btn_savechanges.ForeColor = Color.White;
            btn_savechanges.Image = (Image)resources.GetObject("btn_savechanges.Image");
            btn_savechanges.ImageAlign = ContentAlignment.MiddleLeft;
            btn_savechanges.Location = new Point(450, 408);
            btn_savechanges.Margin = new Padding(10);
            btn_savechanges.Name = "btn_savechanges";
            btn_savechanges.Size = new Size(232, 46);
            btn_savechanges.TabIndex = 23;
            btn_savechanges.Text = "Save changes";
            btn_savechanges.TextAlign = ContentAlignment.MiddleRight;
            btn_savechanges.UseVisualStyleBackColor = false;
            btn_savechanges.Click += btn_savechanges_Click;
            // 
            // txt_age
            // 
            txt_age.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_age.Location = new Point(417, 295);
            txt_age.Name = "txt_age";
            txt_age.Size = new Size(308, 39);
            txt_age.TabIndex = 22;
            // 
            // txt_username
            // 
            txt_username.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_username.Location = new Point(417, 152);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(308, 39);
            txt_username.TabIndex = 20;
            // 
            // txt_email
            // 
            txt_email.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_email.Location = new Point(417, 224);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(308, 39);
            txt_email.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(62, 120, 138);
            label2.Location = new Point(331, 233);
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
            label4.Location = new Point(342, 304);
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
            btn_changepass.Location = new Point(1031, 408);
            btn_changepass.Name = "btn_changepass";
            btn_changepass.Size = new Size(271, 48);
            btn_changepass.TabIndex = 37;
            btn_changepass.Text = "Change password";
            btn_changepass.TextAlign = ContentAlignment.MiddleRight;
            btn_changepass.UseVisualStyleBackColor = false;
            btn_changepass.Click += btn_changepass_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(757, 306);
            label17.Name = "label17";
            label17.Size = new Size(250, 24);
            label17.TabIndex = 36;
            label17.Text = "Confirm New Password:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(840, 242);
            label16.Name = "label16";
            label16.Size = new Size(165, 24);
            label16.TabIndex = 35;
            label16.Text = "New password:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(850, 179);
            label15.Name = "label15";
            label15.Size = new Size(152, 24);
            label15.TabIndex = 34;
            label15.Text = "Old Password:";
            // 
            // txt_newpass_confirm
            // 
            txt_newpass_confirm.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_newpass_confirm.Location = new Point(1008, 297);
            txt_newpass_confirm.Name = "txt_newpass_confirm";
            txt_newpass_confirm.PasswordChar = '*';
            txt_newpass_confirm.Size = new Size(318, 39);
            txt_newpass_confirm.TabIndex = 33;
            // 
            // txt_newpass
            // 
            txt_newpass.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_newpass.Location = new Point(1008, 235);
            txt_newpass.Name = "txt_newpass";
            txt_newpass.PasswordChar = '*';
            txt_newpass.Size = new Size(318, 39);
            txt_newpass.TabIndex = 32;
            // 
            // txt_oldpass
            // 
            txt_oldpass.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_oldpass.Location = new Point(1008, 170);
            txt_oldpass.Name = "txt_oldpass";
            txt_oldpass.PasswordChar = '*';
            txt_oldpass.Size = new Size(318, 39);
            txt_oldpass.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(62, 120, 138);
            label3.Location = new Point(926, 11);
            label3.Name = "label3";
            label3.Size = new Size(449, 56);
            label3.TabIndex = 38;
            label3.Text = "Change password";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label8.ForeColor = Color.DarkOrange;
            label8.Location = new Point(899, 78);
            label8.Name = "label8";
            label8.Size = new Size(476, 32);
            label8.TabIndex = 39;
            label8.Text = "Change your current password with new one";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label9.ForeColor = Color.DarkOrange;
            label9.Location = new Point(340, 76);
            label9.Name = "label9";
            label9.Size = new Size(282, 32);
            label9.TabIndex = 40;
            label9.Text = "Change your current data";
            // 
            // closed_eye1
            // 
            closed_eye1.Image = (Image)resources.GetObject("closed_eye1.Image");
            closed_eye1.Location = new Point(1332, 165);
            closed_eye1.Name = "closed_eye1";
            closed_eye1.Size = new Size(52, 44);
            closed_eye1.TabIndex = 42;
            closed_eye1.TabStop = false;
            closed_eye1.Click += closed_eye1_Click;
            // 
            // closedeye_2
            // 
            closedeye_2.Image = (Image)resources.GetObject("closedeye_2.Image");
            closedeye_2.Location = new Point(1332, 230);
            closedeye_2.Name = "closedeye_2";
            closedeye_2.Size = new Size(48, 44);
            closedeye_2.TabIndex = 44;
            closedeye_2.TabStop = false;
            closedeye_2.Click += closedeye_2_Click;
            // 
            // closedeye_3
            // 
            closedeye_3.Image = (Image)resources.GetObject("closedeye_3.Image");
            closedeye_3.Location = new Point(1332, 295);
            closedeye_3.Name = "closedeye_3";
            closedeye_3.Size = new Size(55, 47);
            closedeye_3.TabIndex = 46;
            closedeye_3.TabStop = false;
            closedeye_3.Click += closedeye_3_Click;
            // 
            // openeye_1
            // 
            openeye_1.Image = (Image)resources.GetObject("openeye_1.Image");
            openeye_1.Location = new Point(1332, 161);
            openeye_1.Name = "openeye_1";
            openeye_1.Size = new Size(47, 49);
            openeye_1.TabIndex = 47;
            openeye_1.TabStop = false;
            openeye_1.Click += openeye_1_Click_1;
            // 
            // openeye_2
            // 
            openeye_2.Image = (Image)resources.GetObject("openeye_2.Image");
            openeye_2.Location = new Point(1332, 230);
            openeye_2.Name = "openeye_2";
            openeye_2.Size = new Size(50, 45);
            openeye_2.TabIndex = 48;
            openeye_2.TabStop = false;
            openeye_2.Click += openeye_2_Click_1;
            // 
            // openeye_3
            // 
            openeye_3.Image = (Image)resources.GetObject("openeye_3.Image");
            openeye_3.Location = new Point(1332, 295);
            openeye_3.Name = "openeye_3";
            openeye_3.Size = new Size(52, 47);
            openeye_3.TabIndex = 49;
            openeye_3.TabStop = false;
            openeye_3.Click += openeye_3_Click_1;
            // 
            // richtxt_myfiles
            // 
            richtxt_myfiles.BackColor = Color.FromArgb(68, 120, 138);
            richtxt_myfiles.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            richtxt_myfiles.Location = new Point(269, 577);
            richtxt_myfiles.Name = "richtxt_myfiles";
            richtxt_myfiles.Size = new Size(1188, 208);
            richtxt_myfiles.TabIndex = 50;
            richtxt_myfiles.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 18F, FontStyle.Italic, GraphicsUnit.Point);
            label10.ForeColor = Color.DarkOrange;
            label10.Location = new Point(269, 528);
            label10.Name = "label10";
            label10.Size = new Size(324, 32);
            label10.TabIndex = 51;
            label10.Text = "These are your encrypted files";
            // 
            // MyAccount
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 44, 51);
            ClientSize = new Size(1469, 797);
            Controls.Add(label10);
            Controls.Add(richtxt_myfiles);
            Controls.Add(openeye_3);
            Controls.Add(openeye_2);
            Controls.Add(openeye_1);
            Controls.Add(closedeye_3);
            Controls.Add(closedeye_2);
            Controls.Add(closed_eye1);
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
            Controls.Add(btn_savechanges);
            Controls.Add(txt_age);
            Controls.Add(txt_username);
            Controls.Add(txt_email);
            Controls.Add(panel1);
            Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.FromArgb(62, 120, 138);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MyAccount";
            Text = "Form5";
            MouseDown += MyAccount_MouseDown;
            MouseMove += MyAccount_MouseMove;
            MouseUp += MyAccount_MouseUp;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)closed_eye1).EndInit();
            ((System.ComponentModel.ISupportInitialize)closedeye_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)closedeye_3).EndInit();
            ((System.ComponentModel.ISupportInitialize)openeye_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)openeye_2).EndInit();
            ((System.ComponentModel.ISupportInitialize)openeye_3).EndInit();
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
        private Button btn_savechanges;
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
        private Button btn_mainpage;
        private PictureBox closed_eye1;
        private PictureBox closedeye_2;
        private PictureBox closedeye_3;
        private PictureBox openeye_1;
        private PictureBox openeye_2;
        private PictureBox openeye_3;
        private RichTextBox richtxt_myfiles;
        private Label label10;
    }
}