using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace FileSAVER
{

    using BCrypt.Net;

    public partial class MyAccount : CustomForm
    {
        System.Windows.Forms.Timer inactivityTimer = new System.Windows.Forms.Timer();

        public MyAccount()
        {
            InitializeComponent();
            string usernmae = getCurrentlyLoggedUser().username;
            int id = getUserIdByUsername(usernmae);
            UserData userdata = GetUserData(id);
            string username = userdata.Username;
            string email = userdata.Email;
            string age = userdata.Age.ToString();
            string type = userdata.Type;

            txt_username.Text = username;
            txt_email.Text = email;
            txt_age.Text = age;
            lbl_acc_type.Text = type;

            getmyEncryptedFiles(id);
            SetupTimer();
        }

        //Log out the user due to inactivity
        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            Dispose();
            Logout();
            MessageBox.Show("You have been logged out due to inactivity. This is a security measure to protect your account.");
            return;
        }

        private void SetupTimer()
        {
            inactivityTimer.Interval = 120000; // 2 minutes
            inactivityTimer.Tick += InactivityTimer_Tick;
            inactivityTimer.Enabled = true;
        }

        private bool isDragging = false;
        private int mouseX, mouseY;
        private void MyAccount_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseX = e.X;
                mouseY = e.Y;
            }
        }

        private void MyAccount_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Left += e.X - mouseX;
                this.Top += e.Y - mouseY;
            }
            // Reset the timer when the mouse is moved
            inactivityTimer.Enabled = false;
            inactivityTimer.Enabled = true;
        }

        private void MyAccount_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void getmyEncryptedFiles(int userId)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();
            string query = "SELECT * FROM user_files_info WHERE User_id=@userid AND deleted=@deleted;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@userid", userId);
            cmd.Parameters.AddWithValue("@deleted", 0);
            MySqlDataReader reader = cmd.ExecuteReader();

            int counter = 1;
            richtxt_myfiles.Clear();

            while (reader.Read()) // Use a loop to read all rows
            {
                string fileName = reader.GetString("File_name");
                string fileSize = reader.GetString("File_size");
                string fileType = reader.GetString("File_type");
                DateTime uploadDate = reader.GetDateTime("Upload_date");

                string fileDetails = $"{counter}. " +
                                     $"File Name: {fileName} " +
                                     $"\nSize: {fileSize} bytes " +
                                     $"\nType: {fileType} " +
                                     $"\nUploaded: {uploadDate.ToString()}";
                richtxt_myfiles.AppendText(fileDetails + Environment.NewLine);
                counter++;
            }

            if (counter == 1) // No files found
            {
                richtxt_myfiles.AppendText("Your account doesn't have any encrypted files yet. Encrypted files will show up here.");
            }

            CurrentConnection.Close(); // Close the connection
        }





        public class UserData
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public string Type { get; set; }
        }
        //Method for recieving data of the last logged in user
        private static UserData GetUserData(int User_id)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();
            string query = "SELECT username, email, age, type FROM users WHERE User_id=@userId AND deleted=@Deleted;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@userId", User_id);
            cmd.Parameters.AddWithValue("@Deleted", 0);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() && reader.HasRows)
            {
                UserData userData = new UserData
                {
                    Username = reader["username"].ToString(),
                    Email = reader["email"].ToString(),
                    Age = Convert.ToInt32(reader["age"]),
                    Type = reader["type"].ToString()

                };
                reader.Close();
                return userData;
            }
            reader.Close();
            CurrentConnection.Close();
            return null;

        }



        //Method for getting Id by username
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
                CurrentConnection.Close();

                return userId;
            }
            reader.Close();
            CurrentConnection.Close();

            return 0;


        }

        private string getUserPassByUserId(int userid)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();
            string query = "SELECT pass_hash FROM users_passwords WHERE User_Id=@userid AND deleted=@delete";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@delete", 0);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string pass = reader["pass_hash"].ToString();
                reader.Close();
                CurrentConnection.Close();

                return pass;
            }
            reader.Close();
            CurrentConnection.Close();

            return null;


        }


        private bool updateUserPassByUserId(int id, string pass_hash)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "UPDATE users_passwords SET pass_hash=@hash WHERE User_id=@userid AND deleted=@delete;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@hash", pass_hash);
            cmd.Parameters.AddWithValue("@userid", id);
            cmd.Parameters.AddWithValue("@delete", 0);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Insert successful");

                CurrentConnection.Close();
                return true;

            }
            else
            {
                Console.WriteLine("Insert failed");
                CurrentConnection.Close();
                return false;
            }
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

        private void btn_changepass_Click(object sender, EventArgs e)
        {
            string oldpass = txt_oldpass.Text;
            string newpass = txt_newpass.Text;
            string confirm_newpass = txt_newpass_confirm.Text;

            string passwordPattern = "^(?=.*[A-Z])(?=.*[!@#$%^&*])(.{8,})$";
            bool isPasswordValid = Regex.IsMatch(newpass, passwordPattern);
            if (isPasswordValid == false)
            {
                MessageBox.Show("The password should contain at least 8 characters, at least one uppercase character and at least one special symbol!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string username = getCurrentlyLoggedUser().username;
            int id = getUserIdByUsername(username);

            string database_hash = getUserPassByUserId(id);

            if (BCrypt.Verify(oldpass, database_hash))
            {
                if (newpass.Equals(confirm_newpass))
                {
                    string new_hash = BCrypt.HashPassword(newpass);
                    updateUserPassByUserId(id, new_hash);
                    createLog(id, "Changed password");
                    MessageBox.Show("Password changed successfuly!");
                }
                else
                {
                    MessageBox.Show("New password and confirm new password are not the same!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Wrong pasword!");
                return;
            }
        }

        //Method which is called whenever the user log out of the account
        private void Logout()
        {


            Dispose();
            Login form1 = new Login();
            form1.Show();

            //Making a log that the user has logged out of his account
            bool isitlogged = createLog(getUserIdByUsername(getCurrentlyLoggedUser().username), "Log out");
            if (isitlogged == false)
            {
                MessageBox.Show("Failed to insert data!");
                return;
            }

        }

        private void btn_mainpage_Click(object sender, EventArgs e)
        {
            MainPage m = new MainPage();
            Hide();
            m.StartPosition = FormStartPosition.CenterScreen;
            m.Visible = true;
        }

        //Method for checking if the user is admin
        private bool checkIfUserIsAdmin(int userId)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "SELECT type FROM users WHERE User_id=@userId AND deleted=@Deleted;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@Deleted", 0);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() && reader[0].Equals("admin"))
            {
                reader.Close();
                CurrentConnection.Close();
                return true;

            }
            else
            {
                reader.Close();
                CurrentConnection.Close();
                return false;
            }

        }

        private void btn_admintools_Click(object sender, EventArgs e)
        {
            string username = getCurrentlyLoggedUser().username;
            int id = getUserIdByUsername(username);
            if (checkIfUserIsAdmin(id))
            {
                AdminTools a = new AdminTools();
                Hide();
                a.StartPosition = FormStartPosition.CenterScreen;
                a.Visible = true;
            }
            else
            {
                MessageBox.Show("You are not admin, so you can't use admin tools!");
                this.Close();
                MainPage m = new MainPage();
                m.Show();
                return;
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private bool updateData(string lastUsername)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string newUsername = txt_username.Text;
            string newEmail = txt_email.Text;
            string newAge = txt_age.Text;
            int newDeletedValue = 0;
            string query = "UPDATE users SET username=@NewUsername, email = @NewEmail, age = @NewAge, deleted = @NewDeleted WHERE username = @Username;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@NewUsername", newUsername);
            cmd.Parameters.AddWithValue("@NewEmail", newEmail);
            cmd.Parameters.AddWithValue("@NewAge", newAge);
            cmd.Parameters.AddWithValue("@NewDeleted", newDeletedValue);
            cmd.Parameters.AddWithValue("@Username", lastUsername);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Insert successful");

                CurrentConnection.Close();
                return true;

            }
            else
            {
                Console.WriteLine("Insert failed");
                CurrentConnection.Close();
                return false;
            }
        }


        //Method for check if the username already exists in the database
        private bool checkForExistingUsername(string username)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE username=@Username AND deleted=@Deleted";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Deleted", 0);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
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


        private bool checkForExistingEmail(string email)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE email=@Email AND deleted=@Deleted;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Deleted", 0);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
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


        private void btn_savechanges_Click(object sender, EventArgs e)
        {

            try
            {
                string currentUser = getCurrentlyLoggedUser().username;

                if (!string.IsNullOrEmpty(currentUser))
                {
                    UserData userdata = GetUserData(getUserIdByUsername(currentUser));

                    string username = userdata.Username;
                    string email = userdata.Email;
                    string age = userdata.Age.ToString();
                    string type = userdata.Type;

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Some values are null!");
                        return;
                    }
                    if (txt_username.Text == username && txt_email.Text == email && txt_age.Text == age)
                    {
                        MessageBox.Show("There are not changes to the user. If you want to edit your account change some value of the following input fields!");
                        return;
                    }

                    string validUsernamePattern = @"^[a-zA-Z0-9_]+$";
                    string validEmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

                    if (!Regex.IsMatch((txt_email.Text), validEmailPattern))
                    {
                        MessageBox.Show("Email is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!Regex.IsMatch(txt_username.Text, validUsernamePattern))
                    {
                        MessageBox.Show("Username contains invalid characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (Convert.ToInt32(txt_age.Text) < 18 || Convert.ToInt32(txt_age.Text) > 120)
                    {
                        MessageBox.Show("Age must be over 18 and not more than 120.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (txt_username.Text == username || txt_email.Text == email || txt_age.Text == age)
                    {
                        if (txt_username.Text != username && txt_email.Text == email && txt_age.Text == age)
                        {
                            if (checkForExistingUsername(txt_username.Text))
                            {
                                MessageBox.Show("This username you choose has already been registered");
                                return;
                            }
                            else
                            {
                                bool isUpdated = updateData(currentUser);
                                if (isUpdated == false)
                                {
                                    MessageBox.Show("Error occured, new user data wasn't inserted!");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("User edited successfully!");
                                    return;
                                }
                            }

                        }
                        else if (txt_username.Text == username && txt_email.Text != email && txt_age.Text == age)
                        {
                            if (checkForExistingEmail(txt_email.Text))
                            {
                                MessageBox.Show("This email you choose has already been registered");
                                return;
                            }
                            else
                            {
                                bool isUpdated = updateData(currentUser);
                                if (isUpdated == false)
                                {
                                    MessageBox.Show("Error occured, new user data wasn't inserted!");
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("User edited successfully!");
                                    return;
                                }
                            }
                        }
                        else if (txt_username.Text == username && txt_email.Text == email && txt_age.Text != age)
                        {
                            bool isUpdated = updateData(currentUser);
                            if (isUpdated == false)
                            {
                                MessageBox.Show("Error occured, new user data wasn't inserted!");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("User edited successfully!");
                                return;
                            }
                        }
                    }

                }



            }
            catch (MySqlException e1)
            {
                MessageBox.Show("Error: " + e1.Message);
            }

        }

        private void closed_eye1_Click(object sender, EventArgs e)
        {
            closed_eye1.Visible = false;
            openeye_1.Visible = true;
            txt_oldpass.PasswordChar = '*';
        }

        private void closedeye_2_Click(object sender, EventArgs e)
        {
            closedeye_2.Visible = false;
            openeye_2.Visible = true;
            txt_newpass.PasswordChar = '*';
        }

        private void closedeye_3_Click(object sender, EventArgs e)
        {
            closedeye_3.Visible = false;
            openeye_3.Visible = true;
            txt_newpass_confirm.PasswordChar = '*';
        }

        private void openeye_1_Click_1(object sender, EventArgs e)
        {
            openeye_1.Visible = false;
            closed_eye1.Visible = true;
            txt_oldpass.PasswordChar = '\0';
        }

        private void openeye_2_Click_1(object sender, EventArgs e)
        {
            openeye_2.Visible = false;
            closedeye_2.Visible = true;
            txt_newpass.PasswordChar = '\0';
        }

        private void openeye_3_Click_1(object sender, EventArgs e)
        {
            openeye_3.Visible = false;
            closedeye_3.Visible = true;
            txt_newpass_confirm.PasswordChar = '\0';
        }
    }
}
