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
        }

        private void MyAccount_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }




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

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {

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
                    MessageBox.Show("Passord changed successfuly!");
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

        private void btn_admintools_Click(object sender, EventArgs e)
        {
            AdminTools a = new AdminTools();
            Hide();
            a.StartPosition = FormStartPosition.CenterScreen;
            a.Visible = true;
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
    }
}
