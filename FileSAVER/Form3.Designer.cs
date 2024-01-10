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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Browse_button = new Button();
            txt_key_encryption = new MaskedTextBox();
            label7 = new Label();
            panel2 = new Panel();
            label8 = new Label();
            richtxt1 = new RichTextBox();
            button5 = new Button();
            label9 = new Label();
            combo1 = new ComboBox();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            accountToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { myAccountToolStripMenuItem, logOffToolStripMenuItem });
            accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            accountToolStripMenuItem.Size = new Size(67, 20);
            accountToolStripMenuItem.Text = "Account ";
            // 
            // myAccountToolStripMenuItem
            // 
            myAccountToolStripMenuItem.Name = "myAccountToolStripMenuItem";
            myAccountToolStripMenuItem.Size = new Size(139, 22);
            myAccountToolStripMenuItem.Text = "My Account";
            myAccountToolStripMenuItem.Click += myAccountToolStripMenuItem_Click;
            // 
            // logOffToolStripMenuItem
            // 
            logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            logOffToolStripMenuItem.Size = new Size(139, 22);
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
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(1038, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(729, 412);
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
            button4.Location = new Point(227, 328);
            button4.Name = "button4";
            button4.Size = new Size(348, 47);
            button4.TabIndex = 11;
            button4.Text = "Exit";
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(58, 190);
            label5.Name = "label5";
            label5.Size = new Size(57, 25);
            label5.TabIndex = 3;
            label5.Text = "Age: ";
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(30, 132);
            label3.Name = "label3";
            label3.Size = new Size(111, 25);
            label3.TabIndex = 1;
            label3.Text = "Username: ";
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
            // Browse_button
            // 
            Browse_button.Location = new Point(1408, 523);
            Browse_button.Name = "Browse_button";
            Browse_button.Size = new Size(144, 69);
            Browse_button.TabIndex = 4;
            Browse_button.Text = "Browse File For encryption";
            Browse_button.UseVisualStyleBackColor = true;
            Browse_button.Click += Browse_button_Click;
            // 
            // txt_key_encryption
            // 
            txt_key_encryption.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txt_key_encryption.Location = new Point(1156, 553);
            txt_key_encryption.Name = "txt_key_encryption";
            txt_key_encryption.Size = new Size(187, 39);
            txt_key_encryption.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1108, 535);
            label7.Name = "label7";
            label7.Size = new Size(257, 15);
            label7.TabIndex = 6;
            label7.Text = "Enter a password for encryption and decryption";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(combo1);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(richtxt1);
            panel2.Location = new Point(111, 93);
            panel2.Name = "panel2";
            panel2.Size = new Size(897, 874);
            panel2.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(636, 40);
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
            richtxt1.Location = new Point(534, 98);
            richtxt1.Name = "richtxt1";
            richtxt1.Size = new Size(337, 723);
            richtxt1.TabIndex = 0;
            richtxt1.Text = "";
            // 
            // button5
            // 
            button5.Location = new Point(204, 171);
            button5.Name = "button5";
            button5.Size = new Size(112, 28);
            button5.TabIndex = 2;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(96, 21);
            label9.Name = "label9";
            label9.Size = new Size(203, 30);
            label9.TabIndex = 3;
            label9.Text = "Edit specific account";
            // 
            // combo1
            // 
            combo1.FormattingEnabled = true;
            combo1.Location = new Point(164, 94);
            combo1.Name = "combo1";
            combo1.Size = new Size(121, 23);
            combo1.TabIndex = 4;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel2);
            Controls.Add(label7);
            Controls.Add(txt_key_encryption);
            Controls.Add(Browse_button);
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
        private Button Browse_button;
        private MaskedTextBox txt_key_encryption;
        private Label label7;
        private Panel panel2;
        private RichTextBox richtxt1;
        private Label label8;
        private ToolStripMenuItem adminToolsToolStripMenuItem;
        private Label label9;
        private Button button5;
        private ComboBox combo1;
    }
}