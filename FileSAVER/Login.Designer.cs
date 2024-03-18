namespace FileSAVER
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            login_btn = new Button();
            label1 = new Label();
            txt1 = new TextBox();
            txt2 = new TextBox();
            forgotpass_link = new LinkLabel();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            pictureBox3 = new PictureBox();
            label4 = new Label();
            register_link = new LinkLabel();
            exit_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.DarkOrange;
            login_btn.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            login_btn.ForeColor = Color.FromArgb(41, 44, 51);
            login_btn.Location = new Point(179, 352);
            login_btn.Margin = new Padding(4, 3, 4, 3);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(169, 53);
            login_btn.TabIndex = 0;
            login_btn.Text = "Login";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Century Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(62, 120, 138);
            label1.Location = new Point(46, 18);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(202, 44);
            label1.TabIndex = 1;
            label1.Text = "Welcome!";
            // 
            // txt1
            // 
            txt1.BackColor = Color.FromArgb(41, 44, 51);
            txt1.BorderStyle = BorderStyle.None;
            txt1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            txt1.ForeColor = Color.White;
            txt1.Location = new Point(116, 117);
            txt1.Margin = new Padding(4, 3, 4, 3);
            txt1.Name = "txt1";
            txt1.Size = new Size(368, 43);
            txt1.TabIndex = 2;
            // 
            // txt2
            // 
            txt2.BackColor = Color.FromArgb(41, 44, 51);
            txt2.BorderStyle = BorderStyle.None;
            txt2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            txt2.ForeColor = Color.White;
            txt2.Location = new Point(116, 226);
            txt2.Margin = new Padding(4, 3, 4, 3);
            txt2.Name = "txt2";
            txt2.Size = new Size(369, 43);
            txt2.TabIndex = 5;
            // 
            // forgotpass_link
            // 
            forgotpass_link.AutoSize = true;
            forgotpass_link.BackColor = Color.Transparent;
            forgotpass_link.BorderStyle = BorderStyle.FixedSingle;
            forgotpass_link.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            forgotpass_link.LinkColor = Color.DarkOrange;
            forgotpass_link.Location = new Point(302, 274);
            forgotpass_link.Margin = new Padding(4, 0, 4, 0);
            forgotpass_link.Name = "forgotpass_link";
            forgotpass_link.Size = new Size(185, 27);
            forgotpass_link.TabIndex = 7;
            forgotpass_link.TabStop = true;
            forgotpass_link.Text = "Fogot password?";
            forgotpass_link.LinkClicked += linkLabel2_LinkClicked;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(62, 120, 138);
            panel1.ForeColor = Color.FromArgb(62, 120, 138);
            panel1.Location = new Point(117, 163);
            panel1.Name = "panel1";
            panel1.Size = new Size(368, 5);
            panel1.TabIndex = 10;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImageLayout = ImageLayout.None;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(46, 115);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(63, 64);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(62, 120, 138);
            panel2.ForeColor = Color.FromArgb(62, 120, 138);
            panel2.Location = new Point(117, 270);
            panel2.Name = "panel2";
            panel2.Size = new Size(368, 5);
            panel2.TabIndex = 11;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.None;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(46, 216);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(63, 64);
            pictureBox3.TabIndex = 13;
            pictureBox3.TabStop = false;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DarkOrange;
            label4.Location = new Point(47, 62);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(301, 25);
            label4.TabIndex = 14;
            label4.Text = "Please login to your account";
            // 
            // register_link
            // 
            register_link.AutoSize = true;
            register_link.BackColor = Color.Transparent;
            register_link.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            register_link.LinkColor = Color.DarkOrange;
            register_link.Location = new Point(197, 171);
            register_link.Margin = new Padding(4, 0, 4, 0);
            register_link.Name = "register_link";
            register_link.Size = new Size(288, 25);
            register_link.TabIndex = 15;
            register_link.TabStop = true;
            register_link.Text = "No account? Register Here!";
            register_link.LinkClicked += register_link_LinkClicked;
            // 
            // exit_btn
            // 
            exit_btn.BackColor = Color.Black;
            exit_btn.BackgroundImageLayout = ImageLayout.None;
            exit_btn.Image = (Image)resources.GetObject("exit_btn.Image");
            exit_btn.Location = new Point(504, -2);
            exit_btn.Name = "exit_btn";
            exit_btn.Size = new Size(51, 49);
            exit_btn.TabIndex = 16;
            exit_btn.UseVisualStyleBackColor = false;
            exit_btn.Click += button2_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 44, 51);
            ClientSize = new Size(554, 456);
            Controls.Add(exit_btn);
            Controls.Add(register_link);
            Controls.Add(panel2);
            Controls.Add(login_btn);
            Controls.Add(label4);
            Controls.Add(pictureBox3);
            Controls.Add(txt2);
            Controls.Add(forgotpass_link);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(txt1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            MouseDown += Login_MouseDown;
            MouseMove += Login_MouseMove;
            MouseUp += Login_MouseUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button login_btn;
        private Label label1;
        private TextBox txt1;
        private TextBox txt2;
        private LinkLabel forgotpass_link;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Panel panel2;
        private PictureBox pictureBox3;
        private Label label4;
        private LinkLabel register_link;
        private Button exit_btn;
    }
}