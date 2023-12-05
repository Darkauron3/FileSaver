namespace FileSAVER;
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
using System.Text.RegularExpressions;
using BCrypt.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

public partial class Form2 : CustomForm
{
    private String SQLSelectQuery(String query)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        MySqlDataReader reader = cmd.ExecuteReader();

        String result = "";
        int columns = reader.FieldCount;
        while (reader.Read())
        {
            for (int i = 0; i < columns; i++)
            {
                String postfix = ",";
                if (columns == 1 || i == columns - 1)
                {
                    postfix = "";
                }

                result += (reader.GetString(i) + postfix);
            }
            result += "\n";
        }
        reader.Close();
        CurrentConnection.Close();

        result = result.Remove(result.Length - 1);

        return result;
    }

    //Method for inserting query to table users
    private bool InsertIntoUsers(string username, string email, string age, string type) {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO users (username, email, age, type) VALUES (@value1, @value2, @value3, @value4);";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@value1", username);
        cmd.Parameters.AddWithValue("@value2", email);
        cmd.Parameters.AddWithValue("@value3", age);
        cmd.Parameters.AddWithValue("@value4", type);

        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Data inserted");
        }
        else
        {
            Console.WriteLine("Failed to insert data");
            return false;
        }
        CurrentConnection.Close();
        return true;
    }

    //Mehtod for inserting query to table users_passwords
    private bool InsertIntoUserspasswords(string pass_hash, string username)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO users_passwords (pass_hash, username) VALUES(@value1, @value2)";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@value1", pass_hash);
        cmd.Parameters.AddWithValue("@value2", username);


        

        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Data inserted");
        }
        else
        {
            Console.WriteLine("Failed to insert data");
            return false;
        }
        CurrentConnection.Close();
        return true;
    }

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

            
            string usernameToCheck = txt1.Text;
            string checkUsernameQuery = "SELECT * FROM users WHERE username='" + usernameToCheck + "';";
            string[] a = SQLSelectQuery(checkUsernameQuery).Split(',');
            if (a[0] != null)
            {
                // Username already exists, notify the user.
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
            else {
                // Username don't exist, continue the registration
                string usernamePattern = "^[a-zA-Z0-9]+$";
                bool isUsernameValid = Regex.IsMatch(txt1.Text, usernamePattern);

                string passwordPattern = "^(?=.*[A-Z])(?=.*[!@#$%^&*])(.{8,})$";
                bool isPasswordValid = Regex.IsMatch(txt2.Text, passwordPattern);

                bool isRepeatPasswordValid = txt2.Text == txt3.Text;

                string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
                bool isEmailValid = Regex.IsMatch(txt4.Text, emailPattern);

                string agePattern = @"^(1[89]|[2-9][0-9]|100)$";
                bool isAgeValid = Regex.IsMatch(txt5.Text, agePattern);

                if (isUsernameValid == false)
                {
                    MessageBox.Show("The username field only allow letters and numbers as input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (isPasswordValid == false)
                {
                    MessageBox.Show("The password should contain at least 8 characters, at least one uppercase character and at least one special symbol!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (isRepeatPasswordValid == false)
                {
                    MessageBox.Show("The password and the repeated password are not the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (isEmailValid == false)
                {
                    MessageBox.Show("The email is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (isAgeValid == false)
                {
                    MessageBox.Show("The age should be in this range: 18-100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



            }


                    if (rdbtn1.Checked == true)
                    {
                            try
                            {
                                bool isitInserted = InsertIntoUsers(txt1.Text, txt4.Text, txt5.Text, "admin");
                                if (isitInserted == false)
                                {
                                 MessageBox.Show("Failed to insert the data");
                                 return;
                                }

                                string hashedPassword = BCrypt.HashPassword(txt2.Text);
                                bool isitInserted2 = InsertIntoUserspasswords(hashedPassword, txt1.Text);
                                if (isitInserted2 == false)
                                {
                                    MessageBox.Show("Failed to insert the data");
                                    return;
                                }




                   /////////do rdbtn2.Cheked sum stignal 
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        

                    }
                    else if (rdbtn2.Checked == true)
                    {
                        string connectionString2 = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
                        using (MySqlConnection connection2 = new MySqlConnection(connectionString2))
                        {
                            try
                            {
                                connection2.Open();

                                string insertQuery = "INSERT INTO users (username, email, age, type) VALUES (@value1, @value2, @value3, @value4)";
                                MySqlCommand cmd2 = new MySqlCommand(insertQuery, connection2);
                                cmd2.Parameters.AddWithValue("@value1", txt1.Text);
                                cmd2.Parameters.AddWithValue("@value2", txt4.Text);
                                cmd2.Parameters.AddWithValue("@value3", txt5.Text);
                                cmd2.Parameters.AddWithValue("@value4", "normal user");


                                int rowsAffected = cmd2.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    Console.WriteLine("Data inserted successfuly");
                                }

                                string insertQuery1 = "INSERT INTO users_passwords (pass_hash, username) VALUES(@value1, @value2)";
                                MySqlCommand cmdd = new MySqlCommand(insertQuery1, connection2);
                                string password = txt2.Text;
                                string hashpass = BCrypt.HashPassword(password);
                                cmdd.Parameters.AddWithValue("@value1", hashpass);
                                cmdd.Parameters.AddWithValue("@value2", txt1.Text);

                                int rowsAffected2 = cmdd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Data inserted successfuly");
                                }
                                connection2.Close();
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }

                    }



                }

                connection.Close();
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

