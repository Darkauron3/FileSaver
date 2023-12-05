using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FileSAVER
{
    public partial class Form3 : CustomForm
    {


        //Constructor for the metod for recieving user data
        public class UserData
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public string Type { get; set; }
        }
        //Method for recieving data of the last logged in user
        private static UserData GetUserData(string username)
        {
            string query = "SELECT username, email, age, type FROM users WHERE username = @Username";

            MySqlCommand command = new MySqlCommand(query, CurrentConnection);

            command.Parameters.AddWithValue("@Username", username);
            if (!ConnectionErrorHandling()) return null;
            using (MySqlDataReader reader = command.ExecuteReader()) { 

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
                return null;
            }
        }



        //Method for getting Id by username
        private int getUserIdByUsername(string username)
        {
            if (!ConnectionErrorHandling()) return -1;
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

            return 0;


        }

        private bool checkForExistingUsername(string username)
        {
            if (!ConnectionErrorHandling()) return false;
            string query = "SELECT COUNT(*) FROM users WHERE username='" + username + "';";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                reader.Close();
                return true;
            }
            else
            {

                reader.Close();
                return false;
            }

        }

        private bool checkForExistingEmail(string email)
        {
            string query = "SELECT COUNT(*) FROM users WHERE email='" + email + "';";
            if (!ConnectionErrorHandling()) return false;
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
            
        }


        public Form3()
        {
            InitializeComponent();
        }

        private void Logout()
        {

            
            Dispose();
            Form1 form1 = new Form1();
            form1.Show();
            

            if (!ConnectionErrorHandling()) return;
            string query1 = "INSERT INTO login_logs (Username, Time, Action) VALUES (@username, @Time, @Action);";
            MySqlCommand cmd1 = new MySqlCommand(query1, CurrentConnection); 
            cmd1.Parameters.AddWithValue("@username", getCurrentlyLoggedUser().username);
            cmd1.Parameters.AddWithValue("@Time", DateTime.Now);
            cmd1.Parameters.AddWithValue("@Action", "Log out");

            int rowsAffected = cmd1.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Insert successful");

            }
            else
            {
                Console.WriteLine("Insert failed");

            }
            
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Form1 form1 = new Form1();
            form1.Show();
        }





        private void myAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string lastloguser = getCurrentlyLoggedUser().username;


            if (!string.IsNullOrEmpty(lastloguser))
            {
                UserData userdata = GetUserData(lastloguser);

                txt_username.Text = userdata.Username;
                txt_email.Text = userdata.Email;
                txt_age.Text = userdata.Age.ToString();
                txt_acc_type.Text = userdata.Type;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt_username.Text = null;
            txt_email.Text = null;
            txt_age.Text = null;
            txt_acc_type.Text = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        //SAVE CHANGES
        private void button2_Click(object sender, EventArgs e)
        {
            if (!ConnectionErrorHandling()) return;
            try
            {
                string lastUsername = getCurrentlyLoggedUser().username;

                if (!string.IsNullOrEmpty(lastUsername))
                {
                    UserData userdata = GetUserData(lastUsername);

                    string username = userdata.Username;
                    string email = userdata.Email;
                    string age = userdata.Age.ToString();
                    string type = userdata.Type;

                    if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(age) && string.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Some values are null!");
                        return;
                    }

                    if (checkForExistingEmail(email) && checkForExistingUsername(username))
                    {
                        string newUsername = txt_username.Text;
                        string newEmail = txt_email.Text;
                        string newAge = txt_age.Text;
                        string query = "UPDATE users SET username=@NewUsername, email = @NewEmail, age = @NewAge WHERE username = @Username;";
                        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);  
                        cmd.Parameters.AddWithValue("@NewUsername", newUsername);
                        cmd.Parameters.AddWithValue("@NewEmail", newEmail);
                        cmd.Parameters.AddWithValue("@NewAge", newAge);
                        cmd.Parameters.AddWithValue("@Username", lastUsername);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Insert successful");
                            CustomForm form = new CustomForm();

                            getCurrentlyLoggedUser().username = newUsername;

                        }
                        else
                        {
                            Console.WriteLine("Insert failed");
                        }
                    }
                    else
                    {
                        if (checkForExistingUsername(username) == false)
                        {
                            MessageBox.Show("This username has already been registered!");
                            return;
                        }
                        else if (checkForExistingEmail(email) == false)
                        {
                            MessageBox.Show("This email has already been registered!");
                            return;
                        }
                        
                    }
                    
                }

                
                if (!ConnectionErrorHandling()) return;
                int id = getUserIdByUsername(lastUsername);
                string query1 = "UPDATE users_passwords SET username=@NewUsername WHERE User_id = @user_id";
                MySqlCommand cmd1 = new MySqlCommand(query1, CurrentConnection);
                cmd1.Parameters.AddWithValue("@NewUsername", txt_username.Text);
                cmd1.Parameters.AddWithValue("@user_id", id);

                int rowsAffected1 = cmd1.ExecuteNonQuery();
                if (rowsAffected1 > 0)
                {
                    Console.WriteLine("Insert successful");
                }
                else
                {
                    Console.WriteLine("Insert failed");
                }
                panel1.Visible = false;
                panel1.Visible = true;
                return;
            }
            catch (MySqlException e1)
            {
                MessageBox.Show("Error: " + e1.Message);
            }

        }

        private void Logout_clicked(object sender, EventArgs e)
        {
            Logout();
        }

        private void Closebutton_clicked(object sender, FormClosedEventArgs e)
        {
            Logout();
        }
    }
}
