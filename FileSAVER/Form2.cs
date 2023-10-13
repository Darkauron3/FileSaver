using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using MySql.Data.MySqlClient;

namespace FileSAVER
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
            Form1 formm1 = new Form1();
            formm1.Show();

        }

        private void btn1_Click(object sender, EventArgs e)
        {

            try
            {
                if (txt2.TextLength < 8)
                {
                    MessageBox.Show("The password should contain at least 8 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int size = txt2.Text.Length;
                int br = 0;
                for (int i = 0; i < size; i++)
                {
                    char a = txt2.Text[i];

                    if (char.IsUpper(a))
                    {
                        br++;
                    }
                }

                if (br == 0)
                {
                    MessageBox.Show("The password should contain at least one uppercase character!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int size1 = txt4.Text.Length;
                int br1 = 0;
                for (int i = 0; i < size1; i++)
                {
                    char a = txt4.Text[i];
                    if (a.Equals('@'))
                    {
                        br1++;
                    }
                }
                if (br1 != 1)
                {
                    MessageBox.Show("The email should contain one '@'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (int.Parse(txt5.Text) < 18 || int.Parse(txt5.Text) > 100)
                {
                    MessageBox.Show("The age should be in this range 18-100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txt1.Text.Length > 100 || txt2.Text.Length > 100 || txt3.Text.Length > 100 || txt4.Text.Length > 100 || txt5.Text.Length > 100)
                {
                    MessageBox.Show("The text-boxes should cointain not more than 1000 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!txt2.Text.Equals(txt3.Text))
                {
                    MessageBox.Show("The password and the repeated password are not the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Exception Message: " + ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(ex.StackTrace);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Exception Message: " + ex.Message);
                Console.WriteLine("Stack Trace:");
                Console.WriteLine(ex.StackTrace);
            }

            if (rdbtn1.Checked == true)
            {
                string connection = "Server=localhost;Database=myDatabase;User=adminuser;Password=adminuseradminuser;";

            }
            else if (rdbtn2.Checked == true)
            {



            }


        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txt1.Text = null;
            txt2.Text = null;
            txt3.Text = null;
            txt4.Text = null;
            txt5.Text = null;
        }


    }
}
