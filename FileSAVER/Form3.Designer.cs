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
            panel1 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            txt_acc_type = new TextBox();
            txt_age = new TextBox();
            txt_email = new TextBox();
            txt_username = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
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
            button1.Location = new Point(845, 898);
            button1.Name = "button1";
            button1.Size = new Size(151, 75);
            button1.TabIndex = 1;
            button1.Text = "Log out";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Logout_clicked;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, accountToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1008, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
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
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(txt_acc_type);
            panel1.Controls.Add(txt_age);
            panel1.Controls.Add(txt_email);
            panel1.Controls.Add(txt_username);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(110, 126);
            panel1.Name = "panel1";
            panel1.Size = new Size(770, 650);
            panel1.TabIndex = 3;
            panel1.Visible = false;
            // 
            // button4
            // 
            button4.Location = new Point(654, 598);
            button4.Name = "button4";
            button4.Size = new Size(111, 47);
            button4.TabIndex = 11;
            button4.Text = "Exit";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(229, 325);
            button3.Name = "button3";
            button3.Size = new Size(185, 40);
            button3.TabIndex = 10;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(522, 324);
            button2.Name = "button2";
            button2.Size = new Size(185, 41);
            button2.TabIndex = 9;
            button2.Text = "Save changes";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txt_acc_type
            // 
            txt_acc_type.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_acc_type.Location = new Point(562, 232);
            txt_acc_type.Name = "txt_acc_type";
            txt_acc_type.Size = new Size(158, 29);
            txt_acc_type.TabIndex = 8;
            // 
            // txt_age
            // 
            txt_age.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_age.Location = new Point(235, 232);
            txt_age.Name = "txt_age";
            txt_age.Size = new Size(146, 29);
            txt_age.TabIndex = 7;
            // 
            // txt_email
            // 
            txt_email.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_email.Location = new Point(538, 125);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(169, 29);
            txt_email.TabIndex = 6;
            // 
            // txt_username
            // 
            txt_username.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txt_username.Location = new Point(298, 125);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(152, 29);
            txt_username.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(426, 232);
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
            label5.Location = new Point(181, 232);
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
            label4.Location = new Point(477, 125);
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
            label3.Location = new Point(181, 125);
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
            label2.Location = new Point(286, 28);
            label2.Name = "label2";
            label2.Size = new Size(194, 40);
            label2.TabIndex = 0;
            label2.Text = "Your account";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1008, 985);
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
        private TextBox txt_acc_type;
        private TextBox txt_age;
        private TextBox txt_email;
        private TextBox txt_username;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button button4;
        private Button button3;
    }
}