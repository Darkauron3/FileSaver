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

    private bool checkForExistingUsername(String query)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            CurrentConnection.Close();
            reader.Close();
            return true;
        }
        else
        {
            CurrentConnection.Close();
            reader.Close();
            return false;
        }

    }


    //Method for inserting query to table users
    private bool InsertIntoUsers(string username, string email, int age, string type)
    {
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
    private bool InsertIntoUserspasswords(int User_id, string pass_hash)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO users_passwords (User_id,pass_hash) VALUES(@value1, @value2)";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@value1", User_id);
        cmd.Parameters.AddWithValue("@value2", pass_hash);

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
    //Method for checking if there is already registered admin
    private bool checkForExistingAdmin() {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "SELECT COUNT(*) FROM users WHERE type='admin'";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

        if (userCount > 0)
        {
            CurrentConnection.Close();
            return true;
        }
        else {
            CurrentConnection.Close();
            return false;
        }

    }

    //Method returning the userId by username
    private int getUserIdByUsername(string username)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT User_id FROM users WHERE username='" + username + "';";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);

        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            int userId = Convert.ToInt32(reader["User_id"]);
            reader.Close();

            return userId;
        }
        reader.Close();
        CurrentConnection.Close();

        return 0;
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


            string usernameToCheck = txt_username.Text;
            string checkUsernameQuery = "SELECT * FROM users WHERE username='" + usernameToCheck + "';";
            bool isUsernameExists = checkForExistingUsername(checkUsernameQuery);

            if (isUsernameExists)
            {
                // Username already exists, notify the user.
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;

            }
            else
            {
                // Username don't exist, continue the registration
                string usernamePattern = "^[a-zA-Z0-9]+$";
                bool isUsernameValid = Regex.IsMatch(txt_username.Text, usernamePattern);

                string passwordPattern = "^(?=.*[A-Z])(?=.*[!@#$%^&*])(.{8,})$";
                bool isPasswordValid = Regex.IsMatch(txt_password.Text, passwordPattern);

                bool isRepeatPasswordValid = txt_password.Text == txt_password_confirm.Text;

                string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
                bool isEmailValid = Regex.IsMatch(txt_email.Text, emailPattern);

                string agePattern = @"^(1[89]|[2-9][0-9]|100)$";
                bool isAgeValid = Regex.IsMatch(txt_age.Text, agePattern);

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
                    if (checkForExistingAdmin()) {
                        MessageBox.Show("There is alreadey registered administrator!");
                        return;
                    }

                    bool isitInserted = InsertIntoUsers(txt_username.Text, txt_email.Text, Convert.ToInt32(txt_age.Text), "admin");
                    if (isitInserted == false)
                    {
                        MessageBox.Show("Failed to insert the data");
                        return;
                    }

                    string hashedPassword = BCrypt.HashPassword(txt_password.Text);
                    bool isitInserted2 = InsertIntoUserspasswords(getUserIdByUsername(txt_username.Text), hashedPassword);
                    if (isitInserted2 == false)
                    {
                        MessageBox.Show("Failed to insert the data");
                        return;
                    }

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }


            }
            else if (rdbtn2.Checked == true)
            {

                try
                {
                    bool isitInserted = InsertIntoUsers(txt_username.Text, txt_email.Text, Convert.ToInt32(txt_age.Text), "normal user");
                    if (isitInserted == false)
                    {
                        MessageBox.Show("Failed to insert the data");
                        return;
                    }

                    string hashedPassword = BCrypt.HashPassword(txt_password.Text);
                    bool isitInserted2 = InsertIntoUserspasswords(getUserIdByUsername(txt_username.Text), hashedPassword);
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error MySql: " + ex.Message);
                }
                catch (System.FormatException ex1)
                {
                    MessageBox.Show("Error invalid format: " + ex1.Message);
                    return;
                }
                catch (System.OverflowException ex2) {
                    MessageBox.Show("Error - Too long input: " + ex2.Message);
                }

            }

            MessageBox.Show("Data inserted!");
            Close();
            Form1 formm1 = new Form1();
            formm1.Show();

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
        txt_username.Text = null;
        txt_password.Text = null;
        txt_password_confirm.Text = null;
        txt_email.Text = null;
        txt_age.Text = null;
    }


}

