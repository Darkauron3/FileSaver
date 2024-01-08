using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        //Setting the window to take up the entire screen 
        public Form3()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        /*
         * !!!!!!!! ----------------------------------------------------------------------------
         * !!!!!!!
         * !!!!!!                                   -!-
         * !!!!!  ZA VRUSHTANE NA PANEL1 V DESIGNERA V PROPERTIES V LOCATION NAPISHI (986, 410)
         * !!!!!
         * !!!!!!
         * !!!!!!!------------------------------------------------------------------------------
         */






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
            string query = "SELECT username, email, age, type FROM users WHERE User_id='" + User_id + "';";
            MySqlCommand command = new MySqlCommand(query, CurrentConnection);
            using (MySqlDataReader reader = command.ExecuteReader())
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

        private bool checkForExistingUsername(string username)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE username='" + username + "';";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
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

        private bool checkForExistingEmail(string email)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();
            string query = "SELECT COUNT(*) FROM users WHERE email='" + email + "';";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count > 0)
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

        //Method for making a log in login_logs
        private bool CreateLog(int User_id, string action)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "INSERT INTO login_logs (User_id, Time, Action) VALUES (@User_id, @Time, @Action)";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("User_id", User_id);
            cmd.Parameters.AddWithValue("Time", DateTime.Now);
            cmd.Parameters.AddWithValue("Action", action);

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
        //Update the new user data for the user's account
        private bool updateUserData(string lastUsername)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

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
                panel1.Visible = false;
                panel1.Visible = true;

                getCurrentlyLoggedUser().username = newUsername;
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


        //Method which is called whenever the user log out of the account
        private void Logout()
        {


            Dispose();
            Form1 form1 = new Form1();
            form1.Show();

            //Making a log that the user has logged out of his account
            bool isitlogged = CreateLog(getUserIdByUsername(getCurrentlyLoggedUser().username), "Log out");
            if (isitlogged == false)
            {
                MessageBox.Show("Failed to insert data!");
                return;
            }

        }

        //Log out from the StripMenu
        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
        }

        //Method turning bytes array to arraylist with hexidecimal represantation
        static ArrayList byteArrayToHexArrayList(byte[] bytes)
        {
            ArrayList hexValues = new ArrayList();

            foreach (byte b in bytes)
            {
                hexValues.Add(b.ToString("X2")); // "X2" formats the byte as a two-digit hexadecimal number
            }

            return hexValues;
        }

        //Method making a string to arrayList of hexidecimal symbols
        static ArrayList stringToHexArrayList(string input)
        {
            ArrayList hexValues = new ArrayList();

            // Convert the string to an array of bytes
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);

            // Convert each byte to its hexadecimal representation
            foreach (byte b in bytes)
            {
                hexValues.Add(b.ToString("X2")); // "X2" formats the byte as a two-digit hexadecimal number
            }

            return hexValues;
        }

        //1st part of my encryption algorithm -> shuffle the file with the key 
        private void firstStepOfEncryption(ArrayList key, ArrayList file)
        {

            for (int i = 0; i < key.Count; i++)
            {
                Debug.WriteLine(key[i]);
            }
            

            /*char[] evenIndex;
            for (int i = 2, i < key.Length; i += 2)
            {
                int summary  = key[i] + key[i + 1];
                if (summary % 2 == 0 ) {
                   file[file.Length -1] = 
                }
                
            }*/
        }




        //When user select the option - "my account"
        private void myAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            string lastloguser = getCurrentlyLoggedUser().username;


            if (!string.IsNullOrEmpty(lastloguser))
            {
                UserData userdata = GetUserData(getUserIdByUsername(lastloguser));

                txt_username.Text = userdata.Username;
                txt_email.Text = userdata.Email;
                txt_age.Text = userdata.Age.ToString();
                lbl_acc_type.Text = userdata.Type;
            }

        }

        //Clear button
        private void button3_Click(object sender, EventArgs e)
        {
            txt_username.Text = null;
            txt_email.Text = null;
            txt_age.Text = null;
            lbl_acc_type.Text = null;
        }

        //Exit button
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        //SAVE CHANGES
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string lastUsername = getCurrentlyLoggedUser().username;

                if (!string.IsNullOrEmpty(lastUsername))
                {
                    UserData userdata = GetUserData(getUserIdByUsername(lastUsername));

                    string username = userdata.Username;
                    string email = userdata.Email;
                    string age = userdata.Age.ToString();
                    string type = userdata.Type;

                    if (txt_username.Text == username && txt_email.Text == email && txt_age.Text == age)
                    {
                        MessageBox.Show("No changes has been applied! If you want to save new changes you need to edit some value!");
                        return;
                    }

                    if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(age) && string.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Some values are null!");
                        return;
                    }

                    if (checkForExistingEmail(email) && checkForExistingUsername(username))
                    {
                        bool isUpdated = updateUserData(lastUsername);
                        if (isUpdated == false)
                        {
                            MessageBox.Show("Error occured, new user data wasn't inserted!");
                            return;
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

        private void Browse_button_Click(object sender, EventArgs e)
        {
            
            string key = txt_key_encryption.Text;
            ArrayList key_hexlist = stringToHexArrayList(key);

            OpenFileDialog fd = new OpenFileDialog();

            fd.Filter = "All Files (*.*)|*.*";
            fd.Multiselect = false;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string filePath = fd.FileName;

                try
                {
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    ArrayList file_hexlist = byteArrayToHexArrayList(fileBytes);

                    ArrayList modifiedFileHexList = new ArrayList(file_hexlist);
                    foreach (string hex in file_hexlist)
                    {
                       modifiedFileHexList.Add(hex);
                    }
                    firstStepOfEncryption(key_hexlist, modifiedFileHexList);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error " + ex.Message);
                }
            }

        }

       
    }
}
