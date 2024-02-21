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
            txtUsername.Location = new Point(195, 138);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(289, 35);
            txtUsername.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 120);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 3;
            label3.Text = "Username";
            // 
            // btn_check_identity
            // 
            btn_check_identity.Location = new Point(257, 179);
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
            ClientSize = new Size(707, 291);
            Controls.Add(btn_check_identity);
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
        private Button btn_check_identity;
    }
}