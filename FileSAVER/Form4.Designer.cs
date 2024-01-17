namespace FileSAVER
{
    partial class Form4
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
            label1 = new Label();
            label2 = new Label();
            txtUsername = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtAge = new TextBox();
            label6 = new Label();
            rdbtn_admin = new RadioButton();
            rdbtn_normal = new RadioButton();
            btn_check_identity = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(218, 9);
            label1.Name = "label1";
            label1.Size = new Size(291, 45);
            label1.TabIndex = 0;
            label1.Text = "Forgoten password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 67);
            label2.Name = "label2";
            label2.Size = new Size(628, 15);
            label2.TabIndex = 1;
            label2.Text = "For prooving user identity please fill the forms and if they are the same in the database you can change your password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(70, 151);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(188, 35);
            txtUsername.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 133);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 3;
            label3.Text = "Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(461, 133);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 4;
            label4.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtEmail.Location = new Point(461, 151);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(188, 35);
            txtEmail.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 214);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 6;
            label5.Text = "Age";
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtAge.Location = new Point(70, 232);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(188, 35);
            txtAge.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(461, 214);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 8;
            label6.Text = "Account type";
            // 
            // rdbtn_admin
            // 
            rdbtn_admin.AutoSize = true;
            rdbtn_admin.Location = new Point(480, 248);
            rdbtn_admin.Name = "rdbtn_admin";
            rdbtn_admin.Size = new Size(59, 19);
            rdbtn_admin.TabIndex = 9;
            rdbtn_admin.TabStop = true;
            rdbtn_admin.Text = "admin";
            rdbtn_admin.UseVisualStyleBackColor = true;
            // 
            // rdbtn_normal
            // 
            rdbtn_normal.AutoSize = true;
            rdbtn_normal.Location = new Point(545, 248);
            rdbtn_normal.Name = "rdbtn_normal";
            rdbtn_normal.Size = new Size(88, 19);
            rdbtn_normal.TabIndex = 10;
            rdbtn_normal.TabStop = true;
            rdbtn_normal.Text = "normal user";
            rdbtn_normal.UseVisualStyleBackColor = true;
            // 
            // btn_check_identity
            // 
            btn_check_identity.Location = new Point(312, 349);
            btn_check_identity.Name = "btn_check_identity";
            btn_check_identity.Size = new Size(141, 52);
            btn_check_identity.TabIndex = 11;
            btn_check_identity.Text = "Check";
            btn_check_identity.UseVisualStyleBackColor = true;
            btn_check_identity.Click += btn_check_identity_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(757, 539);
            Controls.Add(btn_check_identity);
            Controls.Add(rdbtn_normal);
            Controls.Add(rdbtn_admin);
            Controls.Add(label6);
            Controls.Add(txtAge);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsername;
        private Label label3;
        private Label label4;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtAge;
        private Label label6;
        private RadioButton rdbtn_admin;
        private RadioButton rdbtn_normal;
        private Button btn_check_identity;
    }
}