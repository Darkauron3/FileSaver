namespace FileSAVER
{
    partial class Form1
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
            button1 = new Button();
            label1 = new Label();
            txt1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txt2 = new TextBox();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(28, 235);
            button1.Name = "button1";
            button1.Size = new Size(498, 58);
            button1.TabIndex = 0;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(226, 23);
            label1.Name = "label1";
            label1.Size = new Size(69, 30);
            label1.TabIndex = 1;
            label1.Text = "Login";
            // 
            // txt1
            // 
            txt1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt1.Location = new Point(175, 87);
            txt1.Name = "txt1";
            txt1.Size = new Size(351, 35);
            txt1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(53, 87);
            label2.Name = "label2";
            label2.Size = new Size(116, 30);
            label2.TabIndex = 3;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(58, 143);
            label3.Name = "label3";
            label3.Size = new Size(111, 30);
            label3.TabIndex = 4;
            label3.Text = "Password:";
            // 
            // txt2
            // 
            txt2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt2.Location = new Point(175, 140);
            txt2.Name = "txt2";
            txt2.Size = new Size(351, 35);
            txt2.TabIndex = 5;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(378, 217);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(148, 15);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "No account? Register here!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 334);
            Controls.Add(linkLabel1);
            Controls.Add(txt2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txt1);
            Controls.Add(label1);
            Controls.Add(button1);
            MaximumSize = new Size(585, 373);
            MinimumSize = new Size(585, 373);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txt1;
        private Label label2;
        private Label label3;
        private TextBox txt2;
        private LinkLabel linkLabel1;
    }
}