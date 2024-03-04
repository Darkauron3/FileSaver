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

namespace FileSAVER
{
    public partial class AdminTools : CustomForm
    {
        public AdminTools()
        {
            InitializeComponent();
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



        private void Form6_Load(object sender, EventArgs e)
        {
            WriteLogs();
        }
    }
}
