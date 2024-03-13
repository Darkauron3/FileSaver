namespace FileSAVER
{
    partial class RecoverPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoverPassword));
            label2 = new Label();
            txt_forgoten = new MaskedTextBox();
            label12 = new Label();
            resetpass_btn = new Button();
            return_btn = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(62, 120, 138);
            label2.Location = new Point(78, 9);
            label2.Name = "label2";
            label2.Size = new Size(465, 56);
            label2.TabIndex = 14;
            label2.Text = "Forgoten password";
            // 
            // txt_forgoten
            // 
            txt_forgoten.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            txt_forgoten.Location = new Point(223, 129);
            txt_forgoten.Name = "txt_forgoten";
            txt_forgoten.Size = new Size(318, 41);
            txt_forgoten.TabIndex = 20;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.DarkOrange;
            label12.Location = new Point(1, 104);
            label12.Name = "label12";
            label12.Size = new Size(216, 66);
            label12.TabIndex = 23;
            label12.Text = "Please enter\r\nyour username:";
            // 
            // resetpass_btn
            // 
            resetpass_btn.BackColor = Color.FromArgb(62, 120, 138);
            resetpass_btn.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point);
            resetpass_btn.Image = (Image)resources.GetObject("resetpass_btn.Image");
            resetpass_btn.ImageAlign = ContentAlignment.MiddleLeft;
            resetpass_btn.Location = new Point(160, 209);
            resetpass_btn.Name = "resetpass_btn";
            resetpass_btn.Size = new Size(238, 43);
            resetpass_btn.TabIndex = 24;
            resetpass_btn.Text = "Reset password";
            resetpass_btn.TextAlign = ContentAlignment.MiddleRight;
            resetpass_btn.UseVisualStyleBackColor = false;
            resetpass_btn.Click += resetpass_btn_Click;
            // 
            // return_btn
            // 
            return_btn.BackColor = Color.FromArgb(41, 44, 51);
            return_btn.Image = (Image)resources.GetObject("return_btn.Image");
            return_btn.Location = new Point(1, -2);
            return_btn.Name = "return_btn";
            return_btn.Size = new Size(70, 67);
            return_btn.TabIndex = 25;
            return_btn.UseVisualStyleBackColor = false;
            return_btn.Click += return_btn_Click_1;
            // 
            // RecoverPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 44, 51);
            ClientSize = new Size(555, 308);
            Controls.Add(return_btn);
            Controls.Add(resetpass_btn);
            Controls.Add(label12);
            Controls.Add(txt_forgoten);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RecoverPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RecoverPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private MaskedTextBox txt_forgoten;
        private Label label12;
        protected Button resetpass_btn;
        private Button return_btn;
    }
}