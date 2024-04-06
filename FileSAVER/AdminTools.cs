using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FileSAVER.MainPage;

namespace FileSAVER
{
    public partial class AdminTools : CustomForm
    {
        System.Windows.Forms.Timer inactivityTimer = new System.Windows.Forms.Timer();
        public AdminTools()
        {
            InitializeComponent();
            SetupTimer();
        }

        //Log out the user due to inactivity
        private void InactivityTimer_Tick(object sender, EventArgs e)
        {
            Logout();
            MessageBox.Show("You have been logged out due to inactivity. This is a security measure to protect your account.");
        }

        private void SetupTimer()
        {
            inactivityTimer.Interval = 120000; // 2 minutes
            inactivityTimer.Tick += InactivityTimer_Tick;
            inactivityTimer.Enabled = true;
        }

        //Methods allowing user to move freely the form around his screen
        private bool isDragging = false;
        private int mouseX, mouseY;
        private void AdminTools_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseX = e.X;
                mouseY = e.Y;
            }
        }

        private void AdminTools_MouseMove(object sender, MouseEventArgs e)
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

        private void AdminTools_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        //Constructor for the metod for recieving user data
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


        //Update the new user data for the user's account for panel2
        private bool updateUserDataPanel3(string lastUsername)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string newUsername = txtUsername.Text;
            string newEmail = txtEmail.Text;
            string newAge = txtAge.Text;
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

        //Method for getting username by provided id
        private string getUsernameById(int id)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "SELECT username FROM users WHERE User_id='" + id + "';";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@userId", id);
            cmd.Parameters.AddWithValue("@Deleted", 0);
            MySqlDataReader reader = cmd.ExecuteReader();

            string username = null;
            if (reader.Read())
            {
                username = reader[0].ToString();
            }
            else
            {
                MessageBox.Show("User with this id doesn't exist!");
                return null;
            }

            reader.Close();
            CurrentConnection.Close();
            return username;

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

        //Method for getting the logs from the database so they can be displayed in the richtextbox
        private List<string> getLogs(List<string> logs)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "SELECT * FROM login_logs;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int userId = Convert.ToInt32(reader["Users_User_id"]);
                string username = getUsernameById(userId);
                string log = $"Username: {username} \n Time at the action: {reader.GetDateTime(reader.GetOrdinal("Time"))}  \n Action: {reader.GetString("Action")}";
                logs.Add(log);
            }
            reader.Close();
            CurrentConnection.Close();
            return logs;
        }

        //Method for writing all usernames to the ComboBox from the database
        private void writeToComboAllUsernames(ComboBox combo)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "SELECT username FROM users WHERE deleted=@deleted;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@deleted", 0);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                combo.Items.Add(reader["username"]);
            }
            reader.Close();
            CurrentConnection.Close();
        }

        //
        private void combo1_MouseClicked(object sender, MouseEventArgs e)
        {
            combo1.Items.Clear();
            writeToComboAllUsernames(combo1);
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

        private void WriteLogs()
        {
            string lastUsername = getCurrentlyLoggedUser().username;
            int userId = getUserIdByUsername(lastUsername);
            if (checkIfUserIsAdmin(userId))
            {
                List<string> logs = new List<string>();
                getLogs(logs);
                string allLogs = string.Join(Environment.NewLine + Environment.NewLine, logs);
                richtxt1.Text = allLogs;
                writeToComboAllUsernames(combo1);
                writeToComboAllUsernames(comboBox1);


            }
            else
            {
                MessageBox.Show("You are not admin user, so you can't use admin tools!");
                return;
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


        private void clearAllLogs()
        {
            string connstring = "Server=localhost;Database=mydb;User=adminuser;Password=adminuser1234!;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "TRUNCATE TABLE login_logs;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected >= 0)
            {
                Console.WriteLine("Insert successful");
                CurrentConnection.Close();

            }
            else
            {
                Console.WriteLine("Insert failed");
                CurrentConnection.Close();
                MessageBox.Show("Erorr occured cleaning the logs!");
                return;
            }
        }

        private void refreshLogs()
        {
            List<string> filtered_logs = new List<string>();
            List<string> logs = new List<string>();
            getLogs(logs);

            foreach (string log in logs)
            {
                if ((check_login.Checked && log.Contains("Action: Logged in")) ||
               (check_logout.Checked && log.Contains("Action: Log out")) ||
               (check_newreg.Checked && log.Contains("Action: New Account registered")) ||
               (check_encrypt.Checked && log.Contains("Action: File encrypted")) ||
               (check_decrypt.Checked && log.Contains("Action: File decrypted")) ||
               (check_changedpass.Checked && log.Contains("Action: Changed password")) ||
               (check_loginfail.Checked && log.Contains("Action: Failed to log in") ||
               (check_accdel.Checked && log.Contains("Action: Account deleted"))))
                {
                    filtered_logs.Add(log);
                }
            }

            string filteredLogsText = string.Join(Environment.NewLine + Environment.NewLine, filtered_logs);
            richtxt1.Text = filteredLogsText;
        }


        //Method for changing the deleted column for a deleted user in table users 
        private bool changeDeletedToTrueForUsers(int id)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "UPDATE users SET deleted=@deleted WHERE User_id=@user_id;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@deleted", 1);
            cmd.Parameters.AddWithValue("@user_id", id);

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


        private void Form6_Load(object sender, EventArgs e)
        {
            WriteLogs();
        }

        private void btn_save_changes_Click(object sender, EventArgs e)
        {
            try
            {
                string choosenUser = combo1.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(choosenUser))
                {
                    UserData userdata = GetUserData(getUserIdByUsername(choosenUser));

                    string username = userdata.Username;
                    string email = userdata.Email;
                    string age = userdata.Age.ToString();
                    string type = userdata.Type;

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Some values are null!");
                        return;
                    }
                    if (txtUsername.Text == username && txtEmail.Text == email && txtAge.Text == age)
                    {
                        MessageBox.Show("There are not changes to the user. If you want to edit your account change some value of the following input fields!");
                        return;
                    }


                    if (txtUsername.Text == username || txtEmail.Text == email || txtAge.Text == age)
                    {
                        if (txtUsername.Text != username && txtEmail.Text == email && txtAge.Text == age)
                        {
                            if (checkForExistingUsername(txtUsername.Text))
                            {
                                MessageBox.Show("This username you choose has already been registered");
                                return;
                            }
                            else
                            {
                                bool isUpdated = updateUserDataPanel3(choosenUser);
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
                        else if (txtUsername.Text == username && txtEmail.Text != email && txtAge.Text == age)
                        {
                            if (checkForExistingEmail(txtEmail.Text))
                            {
                                MessageBox.Show("This email you choose has already been registered");
                                return;
                            }
                            else
                            {
                                bool isUpdated = updateUserDataPanel3(choosenUser);
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
                        else if (txtUsername.Text == username && txtEmail.Text == email && txtAge.Text != age)
                        {
                            bool isUpdated = updateUserDataPanel3(choosenUser);
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

        //Method for changing the deleted column for a deleted user in table users_passwords
        private bool changeDeletedToTrueForUsersPasswords(int id)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "UPDATE users_passwords SET deleted=@deleted WHERE User_id=@user_id;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@deleted", 1);
            cmd.Parameters.AddWithValue("@user_id", id);

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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                comboBox1.Text = comboBox1.SelectedItem.ToString();
            }

        }

        private void check_login_CheckedChanged(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void check_logout_CheckedChanged(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void check_newreg_CheckedChanged(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void check_encrypt_CheckedChanged(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void check_decrypt_CheckedChanged(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void check_loginfail_CheckedChanged(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void check_accdel_CheckedChanged(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void check_changedpass_CheckedChanged(object sender, EventArgs e)
        {
            refreshLogs();
        }

        private void btn_showlogs_Click(object sender, EventArgs e)
        {
            List<string> logs = new List<string>();
            getLogs(logs);
            string allLogs = string.Join(Environment.NewLine + Environment.NewLine, logs);
            richtxt1.Text = allLogs;
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

        private void btn_acc_Click(object sender, EventArgs e)
        {
            MyAccount m = new MyAccount();
            Hide();
            m.StartPosition = FormStartPosition.CenterScreen;
            m.Visible = true;
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void clearLogs_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wanna delete all the logs, they can't be tuned back after that?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                richtxt1.Clear();
                clearAllLogs();
            }
            else
            {
                return;
            }

        }

        private void combo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choosenUser = combo1.SelectedItem.ToString();
            int id = getUserIdByUsername(choosenUser);

            UserData userdata = GetUserData(id);

            string username = userdata.Username;
            string email = userdata.Email;
            string age = userdata.Age.ToString();
            string type = userdata.Type;

            txtUsername.Text = username;
            txtEmail.Text = email;
            txtAge.Text = age;
            lbl_realtype.Text = type;
        }

        private void btn_deleteuser_Click(object sender, EventArgs e)
        {
            try
            {
                string choosenUser = comboBox1.SelectedItem.ToString();
                comboBox1.Text = " ";
                DialogResult dialogResult = MessageBox.Show("Are you sure you wanna delete this user?", "Deleting user", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = getUserIdByUsername(choosenUser);
                    bool isDeletedUsers = changeDeletedToTrueForUsers(id);
                    bool isDeletedUsersPasswords = changeDeletedToTrueForUsersPasswords(id);
                    bool isCreatedLog = createLog(id, "Account deleted");
                    if (isDeletedUsers && isDeletedUsersPasswords && isCreatedLog)
                    {
                        comboBox1.Items.Clear();
                        List<string> logs = new List<string>();
                        getLogs(logs);
                        string allLogs = string.Join(Environment.NewLine + Environment.NewLine, logs);
                        richtxt1.Text = allLogs;
                        writeToComboAllUsernames(comboBox1);

                        MessageBox.Show("Successfully deleted user -> " + choosenUser);

                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    comboBox1.Items.Clear();
                    writeToComboAllUsernames(comboBox1);
                }
                combo1.Items.Clear();
                writeToComboAllUsernames(combo1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
