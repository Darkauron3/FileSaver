namespace FileSAVER
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            label1 = new Label();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            saveFileToolStripMenuItem = new ToolStripMenuItem();
            decryptFileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            typeOfEncryptionToolStripMenuItem = new ToolStripMenuItem();
            securityOptionsToolStripMenuItem = new ToolStripMenuItem();
            accountToolStripMenuItem = new ToolStripMenuItem();
            myAccountToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            logOffToolStripMenuItem = new ToolStripMenuItem();
            adminToolsToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            lbl_acc_type = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            txt_age = new TextBox();
            txt_email = new TextBox();
            txt_username = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label2 = new Label();
            label5 = new Label();
            label3 = new Label();
            Encryption_button = new Button();
            txt_key_encryption = new MaskedTextBox();
            label7 = new Label();
            panel2 = new Panel();
            label13 = new Label();
            combo2 = new ComboBox();
            label12 = new Label();
            panel3 = new Panel();
            button5 = new Button();
            button6 = new Button();
            lbl_realtype = new Label();
            lbl_type = new Label();
            txtAge = new TextBox();
            label11 = new Label();
            txtEmail = new TextBox();
            lbl_email = new Label();
            lbl_username = new Label();
            txtUsername = new TextBox();
            btn_save_changes = new Button();
            label10 = new Label();
            combo1 = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            richtxt1 = new RichTextBox();
            txt_key_decryption = new MaskedTextBox();
            label14 = new Label();
            Decryption_button = new Button();
            panel4 = new Panel();
            btn_changepass = new Button();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            txt_newpass_confirm = new MaskedTextBox();
            txt_newpass = new MaskedTextBox();
            txt_oldpass = new MaskedTextBox();
            button7 = new Button();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(457, 20);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "Hello";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1741, 954);
            button1.Name = "button1";
            button1.Size = new Size(151, 75);
            button1.TabIndex = 1;
            button1.Text = "Log out";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Logout_clicked;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, accountToolStripMenuItem, adminToolsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1904, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "Admin Tools";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem, openFileToolStripMenuItem, saveFileToolStripMenuItem, decryptFileToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(136, 22);
            importToolStripMenuItem.Text = "New File";
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new Size(136, 22);
            openFileToolStripMenuItem.Text = "Open File";
            // 
            // saveFileToolStripMenuItem
            // 
            saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            saveFileToolStripMenuItem.Size = new Size(136, 22);
            saveFileToolStripMenuItem.Text = "Save File";
            // 
            // decryptFileToolStripMenuItem
            // 
            decryptFileToolStripMenuItem.Name = "decryptFileToolStripMenuItem";
            decryptFileToolStripMenuItem.Size = new Size(136, 22);
            decryptFileToolStripMenuItem.Text = "Decrypt File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { typeOfEncryptionToolStripMenuItem, securityOptionsToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            // 
            // typeOfEncryptionToolStripMenuItem
            // 
            typeOfEncryptionToolStripMenuItem.Name = "typeOfEncryptionToolStripMenuItem";
            typeOfEncryptionToolStripMenuItem.Size = new Size(174, 22);
            typeOfEncryptionToolStripMenuItem.Text = "Encryption options";
            // 
            // securityOptionsToolStripMenuItem
            // 
            securityOptionsToolStripMenuItem.Name = "securityOptionsToolStripMenuItem";
            securityOptionsToolStripMenuItem.Size = new Size(174, 22);
            securityOptionsToolStripMenuItem.Text = "Security options";
            // 
            // accountToolStripMenuItem
            // 
            accountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { myAccountToolStripMenuItem, changePasswordToolStripMenuItem, logOffToolStripMenuItem });
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(67, 20);
            accountToolStripMenuItem.Text = "Account ";
            // 
            // myAccountToolStripMenuItem
            // 
            myAccountToolStripMenuItem.Name = "myAccountToolStripMenuItem";
            myAccountToolStripMenuItem.Size = new Size(180, 22);
            myAccountToolStripMenuItem.Text = "My Account";
            myAccountToolStripMenuItem.Click += myAccountToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(180, 22);
            changePasswordToolStripMenuItem.Text = "Change password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // logOffToolStripMenuItem
            // 
            logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            logOffToolStripMenuItem.Size = new Size(180, 22);
            logOffToolStripMenuItem.Text = "Log off";
            logOffToolStripMenuItem.Click += logOffToolStripMenuItem_Click;
            // 
            // adminToolsToolStripMenuItem
            // 
            adminToolsToolStripMenuItem.Name = "adminToolsToolStripMenuItem";
            adminToolsToolStripMenuItem.Size = new Size(85, 20);
            adminToolsToolStripMenuItem.Text = "Admin Tools";
            adminToolsToolStripMenuItem.Click += adminToolsToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lbl_acc_type);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(txt_age);
            panel1.Controls.Add(txt_email);
            panel1.Controls.Add(txt_username);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(1144, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(729, 468);
            panel1.TabIndex = 3;
            panel1.Visible = false;
            // 
            // lbl_acc_type
            // 
            lbl_acc_type.AutoSize = true;
            lbl_acc_type.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_acc_type.ForeColor = Color.Red;
            lbl_acc_type.Location = new Point(525, 184);
            lbl_acc_type.Name = "lbl_acc_type";
            lbl_acc_type.Size = new Size(69, 31);
            lbl_acc_type.TabIndex = 12;
            lbl_acc_type.Text = "fafaf";
            // 
            // button4
            // 
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(684, 3);
            button4.Name = "button4";
            button4.Size = new Size(40, 38);
            button4.TabIndex = 11;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(175, 253);
            button3.Name = "button3";
            button3.Size = new Size(157, 45);
            button3.TabIndex = 10;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(447, 253);
            button2.Name = "button2";
            button2.Size = new Size(205, 47);
            button2.TabIndex = 9;
            button2.Text = "Save changes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txt_age
            // 
            txt_age.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_age.Location = new Point(180, 190);
            txt_age.Name = "txt_age";
            txt_age.Size = new Size(146, 29);
            txt_age.TabIndex = 7;
            // 
            // txt_email
            // 
            txt_email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_email.Location = new Point(481, 136);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(223, 29);
            txt_email.TabIndex = 6;
            // 
            // txt_username
            // 
            txt_username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_username.Location = new Point(180, 132);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(152, 29);
            txt_username.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(389, 194);
            label6.Name = "label6";
            label6.Size = new Size(140, 25);
            label6.TabIndex = 4;
            label6.Text = "Account type: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(406, 136);
            label4.Name = "label4";
            label4.Size = new Size(69, 25);
            label4.TabIndex = 2;
            label4.Text = "Email: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(350, 23);
            label2.Name = "label2";
            label2.Size = new Size(194, 40);
            label2.TabIndex = 0;
            label2.Text = "Your account";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(31, 166);
            label5.Name = "label5";
            label5.Size = new Size(57, 25);
            label5.TabIndex = 3;
            label5.Text = "Age: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(3, 108);
            label3.Name = "label3";
            label3.Size = new Size(111, 25);
            label3.TabIndex = 1;
            label3.Text = "Username: ";
            // 
            // Encryption_button
            // 
            Encryption_button.Location = new Point(1581, 542);
            Encryption_button.Name = "Encryption_button";
            Encryption_button.Size = new Size(144, 69);
            Encryption_button.TabIndex = 4;
            Encryption_button.Text = "Browse File For encryption";
            Encryption_button.UseVisualStyleBackColor = true;
            Encryption_button.Click += Encryption_button_Click;
            // 
            // txt_key_encryption
            // 
            txt_key_encryption.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_key_encryption.Location = new Point(1203, 572);
            txt_key_encryption.Name = "txt_key_encryption";
            txt_key_encryption.Size = new Size(187, 39);
            txt_key_encryption.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1213, 542);
            label7.Name = "label7";
            label7.Size = new Size(177, 15);
            label7.TabIndex = 6;
            label7.Text = "Enter a password for encryption ";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(label13);
            panel2.Controls.Add(combo2);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(combo1);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(richtxt1);
            panel2.Location = new Point(30, 93);
            panel2.Name = "panel2";
            panel2.Size = new Size(1093, 874);
            panel2.TabIndex = 7;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(172, 582);
            label13.Name = "label13";
            label13.Size = new Size(25, 20);
            label13.TabIndex = 17;
            label13.Text = "hh";
            // 
            // combo2
            // 
            combo2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            combo2.FormattingEnabled = true;
            combo2.Location = new Point(225, 442);
            combo2.Name = "combo2";
            combo2.Size = new Size(159, 28);
            combo2.TabIndex = 16;
            combo2.SelectedIndexChanged += combo2_SelectedIndexChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(173, 405);
            label12.Name = "label12";
            label12.Size = new Size(275, 20);
            label12.TabIndex = 15;
            label12.Text = "Select which account you want to delete";
            // 
            // panel3
            // 
            panel3.Controls.Add(button5);
            panel3.Controls.Add(button6);
            panel3.Controls.Add(lbl_realtype);
            panel3.Controls.Add(lbl_type);
            panel3.Controls.Add(txtAge);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(txtEmail);
            panel3.Controls.Add(lbl_email);
            panel3.Controls.Add(lbl_username);
            panel3.Controls.Add(txtUsername);
            panel3.Controls.Add(btn_save_changes);
            panel3.Location = new Point(31, 134);
            panel3.Name = "panel3";
            panel3.Size = new Size(546, 239);
            panel3.TabIndex = 14;
            // 
            // button5
            // 
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(515, 0);
            button5.Name = "button5";
            button5.Size = new Size(28, 29);
            button5.TabIndex = 15;
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(116, 192);
            button6.Name = "button6";
            button6.Size = new Size(98, 28);
            button6.TabIndex = 14;
            button6.Text = "Clear";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // lbl_realtype
            // 
            lbl_realtype.AutoSize = true;
            lbl_realtype.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_realtype.ForeColor = Color.Red;
            lbl_realtype.Location = new Point(350, 120);
            lbl_realtype.Name = "lbl_realtype";
            lbl_realtype.Size = new Size(42, 21);
            lbl_realtype.TabIndex = 13;
            lbl_realtype.Text = "Type";
            // 
            // lbl_type
            // 
            lbl_type.AutoSize = true;
            lbl_type.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_type.ForeColor = SystemColors.Control;
            lbl_type.Location = new Point(261, 117);
            lbl_type.Name = "lbl_type";
            lbl_type.Size = new Size(45, 21);
            lbl_type.TabIndex = 12;
            lbl_type.Text = "Type:";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAge.Location = new Point(91, 117);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(123, 29);
            txtAge.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label11.ForeColor = SystemColors.Control;
            label11.Location = new Point(45, 117);
            label11.Name = "label11";
            label11.Size = new Size(40, 21);
            label11.TabIndex = 10;
            label11.Text = "Age:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(318, 45);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(198, 29);
            txtEmail.TabIndex = 9;
            // 
            // lbl_email
            // 
            lbl_email.AutoSize = true;
            lbl_email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_email.ForeColor = SystemColors.Control;
            lbl_email.Location = new Point(255, 48);
            lbl_email.Name = "lbl_email";
            lbl_email.Size = new Size(51, 21);
            lbl_email.TabIndex = 8;
            lbl_email.Text = "Email:";
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_username.ForeColor = SystemColors.Control;
            lbl_username.Location = new Point(3, 50);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(84, 21);
            lbl_username.TabIndex = 7;
            lbl_username.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(91, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(123, 29);
            txtUsername.TabIndex = 6;
            // 
            // btn_save_changes
            // 
            btn_save_changes.Location = new Point(318, 192);
            btn_save_changes.Name = "btn_save_changes";
            btn_save_changes.Size = new Size(98, 28);
            btn_save_changes.TabIndex = 2;
            btn_save_changes.Text = "Save changes";
            btn_save_changes.UseVisualStyleBackColor = true;
            btn_save_changes.Click += btn_save_changes_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(173, 74);
            label10.Name = "label10";
            label10.Size = new Size(250, 20);
            label10.TabIndex = 5;
            label10.Text = "Select which user's data you will edit";
            // 
            // combo1
            // 
            combo1.FormattingEnabled = true;
            combo1.Location = new Point(213, 97);
            combo1.Name = "combo1";
            combo1.Size = new Size(158, 23);
            combo1.TabIndex = 4;
            combo1.SelectedIndexChanged += combo1_SelectedIndexChanged;
            combo1.MouseClick += combo1_MouseClicked;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15.75F, FontStyle.Underline, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(193, 0);
            label9.Name = "label9";
            label9.Size = new Size(203, 30);
            label9.TabIndex = 3;
            label9.Text = "Edit specific account";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 21.75F, FontStyle.Underline, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(821, 32);
            label8.Name = "label8";
            label8.Size = new Size(154, 40);
            label8.TabIndex = 1;
            label8.Text = "Users Logs";
            // 
            // richtxt1
            // 
            richtxt1.BackColor = Color.Black;
            richtxt1.BorderStyle = BorderStyle.FixedSingle;
            richtxt1.ForeColor = SystemColors.Info;
            richtxt1.Location = new Point(736, 97);
            richtxt1.Name = "richtxt1";
            richtxt1.Size = new Size(337, 723);
            richtxt1.TabIndex = 0;
            richtxt1.Text = "";
            // 
            // txt_key_decryption
            // 
            txt_key_decryption.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_key_decryption.Location = new Point(1203, 743);
            txt_key_decryption.Name = "txt_key_decryption";
            txt_key_decryption.Size = new Size(187, 39);
            txt_key_decryption.TabIndex = 8;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(1203, 716);
            label14.Name = "label14";
            label14.Size = new Size(177, 15);
            label14.TabIndex = 9;
            label14.Text = "Enter a password for decryption ";
            // 
            // Decryption_button
            // 
            Decryption_button.Location = new Point(1486, 722);
            Decryption_button.Name = "Decryption_button";
            Decryption_button.Size = new Size(144, 66);
            Decryption_button.TabIndex = 10;
            Decryption_button.Text = "Browse File for decryption";
            Decryption_button.UseVisualStyleBackColor = true;
            Decryption_button.Click += Decryption_button_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(button7);
            panel4.Controls.Add(btn_changepass);
            panel4.Controls.Add(label17);
            panel4.Controls.Add(label16);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(txt_newpass_confirm);
            panel4.Controls.Add(txt_newpass);
            panel4.Controls.Add(txt_oldpass);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(152, 57);
            panel4.Name = "panel4";
            panel4.Size = new Size(708, 409);
            panel4.TabIndex = 13;
            // 
            // btn_changepass
            // 
            btn_changepass.Location = new Point(325, 288);
            btn_changepass.Name = "btn_changepass";
            btn_changepass.Size = new Size(238, 44);
            btn_changepass.TabIndex = 10;
            btn_changepass.Text = "Change password";
            btn_changepass.UseVisualStyleBackColor = true;
            btn_changepass.Click += btn_changepass_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(71, 202);
            label17.Name = "label17";
            label17.Size = new Size(280, 32);
            label17.TabIndex = 9;
            label17.Text = "Confirm New Password";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(120, 130);
            label16.Name = "label16";
            label16.Size = new Size(181, 32);
            label16.TabIndex = 8;
            label16.Text = "New password";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(132, 66);
            label15.Name = "label15";
            label15.Size = new Size(169, 32);
            label15.TabIndex = 7;
            label15.Text = "Old Password";
            // 
            // txt_newpass_confirm
            // 
            txt_newpass_confirm.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_newpass_confirm.Location = new Point(357, 205);
            txt_newpass_confirm.Name = "txt_newpass_confirm";
            txt_newpass_confirm.Size = new Size(213, 33);
            txt_newpass_confirm.TabIndex = 6;
            // 
            // txt_newpass
            // 
            txt_newpass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_newpass.Location = new Point(357, 133);
            txt_newpass.Name = "txt_newpass";
            txt_newpass.Size = new Size(213, 33);
            txt_newpass.TabIndex = 5;
            // 
            // txt_oldpass
            // 
            txt_oldpass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_oldpass.Location = new Point(357, 68);
            txt_oldpass.Name = "txt_oldpass";
            txt_oldpass.Size = new Size(213, 33);
            txt_oldpass.TabIndex = 4;
            // 
            // button7
            // 
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.Location = new Point(665, 3);
            button7.Name = "button7";
            button7.Size = new Size(40, 38);
            button7.TabIndex = 13;
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel4);
            Controls.Add(Decryption_button);
            Controls.Add(label14);
            Controls.Add(txt_key_decryption);
            Controls.Add(panel2);
            Controls.Add(label7);
            Controls.Add(txt_key_encryption);
            Controls.Add(Encryption_button);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form3";
            Text = "Form3";
            FormClosed += Closebutton_clicked;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem accountToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem typeOfEncryptionToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem saveFileToolStripMenuItem;
        private ToolStripMenuItem decryptFileToolStripMenuItem;
        private ToolStripMenuItem securityOptionsToolStripMenuItem;
        private ToolStripMenuItem myAccountToolStripMenuItem;
        private ToolStripMenuItem logOffToolStripMenuItem;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Button button2;
        private TextBox txt_age;
        private TextBox txt_email;
        private TextBox txt_username;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button button4;
        private Button button3;
        private Label lbl_acc_type;
        private Button Encryption_button;
        private MaskedTextBox txt_key_encryption;
        private Label label7;
        private Panel panel2;
        private RichTextBox richtxt1;
        private Label label8;
        private ToolStripMenuItem adminToolsToolStripMenuItem;
        private Label label9;
        private Button btn_save_changes;
        private ComboBox combo1;
        private Label label10;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private Label lbl_email;
        private Label lbl_username;
        private Panel panel3;
        private Button button6;
        private Label lbl_realtype;
        private Label lbl_type;
        private TextBox txtAge;
        private Label label11;
        private Button button5;
        private ComboBox combo2;
        private Label label12;
        private Label label13;
        private MaskedTextBox txt_key_decryption;
        private Label label14;
        private Button Decryption_button;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private Panel panel4;
        private Label label15;
        private MaskedTextBox txt_newpass_confirm;
        private MaskedTextBox txt_newpass;
        private MaskedTextBox txt_oldpass;
        private Label label17;
        private Label label16;
        private Button btn_changepass;
        private Button button7;
    }
}