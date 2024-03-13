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
using System.Data.SqlClient;

public partial class Register : CustomForm
{

    public Register()
    {
        InitializeComponent();
    }

    private bool isDragging = false;
    private int mouseX, mouseY;
    private void Register_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            mouseX = e.X;
            mouseY = e.Y;
        }
    }

    private void Register_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            this.Left += e.X - mouseX;
            this.Top += e.Y - mouseY;
        }
    }

    private void Register_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = false;
        }
    }

    //Method for inserting query to table users
    private bool InsertIntoUsers(string username, string email, int age, string type)
    {
        try
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            // Check if there are any deleted users
            string query = "SELECT User_id FROM users WHERE deleted = 1;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                // If there are deleted users, update the first one found with the new data
                reader.Read();
                int deletedUserId = reader.GetInt32(0);
                reader.Close();

                query = "UPDATE users SET username = @username, email = @email, age = @age, type = @type, deleted = 0 WHERE User_id = @userId;";
                cmd = new MySqlCommand(query, CurrentConnection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@userId", deletedUserId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data updated for the existing user");
                    CurrentConnection.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to update data for the existing user");
                    CurrentConnection.Close();
                    return false;
                }
            }
            else
            {
                // If there are no deleted users, insert a new user
                reader.Close();

                query = "INSERT INTO users (username, email, age, type, deleted) VALUES (@value1, @value2, @value3, @value4, @value5);";
                cmd = new MySqlCommand(query, CurrentConnection);
                cmd.Parameters.AddWithValue("@value1", username);
                cmd.Parameters.AddWithValue("@value2", email);
                cmd.Parameters.AddWithValue("@value3", age);
                cmd.Parameters.AddWithValue("@value4", type);
                cmd.Parameters.AddWithValue("@value5", 0);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data inserted");
                    CurrentConnection.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to insert data");
                    CurrentConnection.Close();
                    return false;
                }
            }
        }
        catch (MySqlException ex)
        {
            if (ex.Number == 1062) // Unique constraint violation error number
            {
                string conectionstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
                MySqlConnection Currentconnection = new MySqlConnection(conectionstring);
                Currentconnection.Open();

                string query = "SELECT COUNT(*) FROM users WHERE (username = @username OR email = @email) AND deleted = 0;";
                MySqlCommand cmd = new MySqlCommand(query, Currentconnection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);

                int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                if (userCount > 0)
                {
                    Currentconnection.Close();
                    // Handle the exception and notify the user
                    string errorMessage = ex.Message.ToLower();
                    if (errorMessage.Contains("username"))
                    {
                        MessageBox.Show("Error: The username you're trying to use already exists. Please choose a different username.");
                    }
                    else if (errorMessage.Contains("email"))
                    {
                        MessageBox.Show("Error: The email you're trying to use already exists. Please choose a different email.");
                    }
                    else
                    {
                        // Handle other constraint violations
                        MessageBox.Show("Error: The data you're trying to insert violates a unique constraint. Please check your data.");
                    }
                    return false;
                }
                return false;
            }
            else
            {
                // Handle other SQL exceptions
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            MessageBox.Show("Error: " + ex.Message);
            return false;
        }
    }

    //Mehtod for inserting query to table users_passwords
    private bool InsertIntoUserspasswords(int User_id, string pass_hash)
    {
        try
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            // Check if there are any deleted users
            string query = "SELECT User_id FROM users_passwords WHERE deleted = 1;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                // If there are deleted users, update the first one found with the new data
                reader.Read();
                int deletedUserId = reader.GetInt32(0);
                reader.Close();

                query = "UPDATE users_passwords SET pass_hash = @pass_hash, deleted = 0 WHERE User_id = @deletedUserId;";
                cmd = new MySqlCommand(query, CurrentConnection);
                cmd.Parameters.AddWithValue("@pass_hash", pass_hash);
                cmd.Parameters.AddWithValue("@deletedUserId", deletedUserId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data updated for the existing user password");
                    CurrentConnection.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to update data for the existing user password");
                    CurrentConnection.Close();
                    return false;
                }
            }
            else
            {
                // If there are no deleted users, insert a new user password
                reader.Close();

                query = "INSERT INTO users_passwords (User_id, pass_hash, deleted) VALUES (@value1, @value2, @value3);";
                cmd = new MySqlCommand(query, CurrentConnection);
                cmd.Parameters.AddWithValue("@value1", User_id);
                cmd.Parameters.AddWithValue("@value2", pass_hash);
                cmd.Parameters.AddWithValue("@value3", 0);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Data inserted");
                    CurrentConnection.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to insert data");
                    CurrentConnection.Close();
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }

    }
    //Method for checking if there is already registered admin
    private bool checkForExistingAdmin()
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "SELECT COUNT(*) FROM users WHERE type='admin' AND deleted='0'";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

        if (userCount > 0)
        {
            CurrentConnection.Close();
            return true;
        }
        else
        {
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
        string query = "SELECT User_id FROM users WHERE username=@Username AND deleted=@Deleted;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@Username", username);
        cmd.Parameters.AddWithValue("@Deleted", 0);

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

    //Method for making a log in login_logs
    private bool createLog(int User_id, string action)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO login_logs (users_User_id, Time, Action) VALUES (@User_id, @Time, @Action)";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);

        cmd.Parameters.AddWithValue("@User_id", User_id);
        cmd.Parameters.AddWithValue("@Time", DateTime.Now);
        cmd.Parameters.AddWithValue("@Action", action);

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



    private void btn1_Click(object sender, EventArgs e)
    {

        try
        {
            string usernameToCheck = txt_username.Text;

            // Username don't exist, continue the registration
            string usernamePattern = "^[a-zA-Z0-9]+$";
            bool isUsernameValid = Regex.IsMatch(txt_username.Text, usernamePattern);

            string passwordPattern = "^(?=.*[A-Z])(?=.*[!@#$%^&*])(.{8,})$";
            bool isPasswordValid = Regex.IsMatch(txt_pass.Text, passwordPattern);

            bool isRepeatPasswordValid = txt_pass.Text == txt_passconfirm.Text;

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

            if (rdbtn1.Checked == true)
            {
                try
                {
                    if (checkForExistingAdmin())
                    {
                        MessageBox.Show("There is alreadey registered administrator!");
                        return;
                    }
                    bool isItInsertedUsers = InsertIntoUsers(txt_username.Text, txt_email.Text, Convert.ToInt32(txt_age.Text), "admin");
                    string hashedPassword = BCrypt.HashPassword(txt_pass.Text);
                    bool isItInsertedUserpasswords = InsertIntoUserspasswords(getUserIdByUsername(txt_username.Text), hashedPassword);

                    if (isItInsertedUsers == false || isItInsertedUserpasswords == false)
                    {
                        return;
                    }
                    else if (isItInsertedUsers && isItInsertedUserpasswords)
                    {
                        MessageBox.Show("Data inserted successfuly!");
                        string username = txt_username.Text;
                        int id = getUserIdByUsername(username);
                        createLog(id, "New account registered");
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
                    bool isItInsertedUsers = InsertIntoUsers(txt_username.Text, txt_email.Text, Convert.ToInt32(txt_age.Text), "normal user");
                    string hashedPassword = BCrypt.HashPassword(txt_pass.Text);
                    bool isItInsertedUserpasswords = InsertIntoUserspasswords(getUserIdByUsername(txt_username.Text), hashedPassword);
                    if (isItInsertedUsers == false || isItInsertedUserpasswords == false)
                    {
                        return;
                    }
                    else if (isItInsertedUsers && isItInsertedUserpasswords)
                    {
                        MessageBox.Show("Data inserted successfuly!");
                        string username = txt_username.Text;
                        int id = getUserIdByUsername(username);
                        createLog(id, "New account registered");
                    }
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
                catch (System.OverflowException ex2)
                {
                    MessageBox.Show("Error - Too long input: " + ex2.Message);
                }

            }
            Close();
            Login formm1 = new Login();
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


    private void button1_Click(object sender, EventArgs e)
    {
        Login l = new Login();
        Hide();
        l.Visible = true;
    }
}

