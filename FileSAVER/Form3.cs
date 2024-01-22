using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            panel1.Enabled = false;
            panel1.Visible = false;
            panel2.Enabled = false;
            panel2.Visible = false;
            panel3.Enabled = false;
            panel3.Visible = false;

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

                return userId;
            }
            reader.Close();
            CurrentConnection.Close();

            return 0;


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
            } else
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
            } else
            {
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

            string query = "INSERT INTO login_logs (User_id, Time, Action) VALUES (@User_id, @Time, @Action)";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("User_id", User_id);
            cmd.Parameters.AddWithValue("Time", DateTime.Now);
            cmd.Parameters.AddWithValue("Action", action);

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Data inserted");
            } else
            {
                Console.WriteLine("Failed to insert data");
                return false;
            }
            CurrentConnection.Close();
            return true;

        }
        //Update the new user data for the user's account for panel1
        private bool updateUserDataPanel1(string lastUsername)
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
                panel1.Visible = false;
                panel1.Visible = true;

                getCurrentlyLoggedUser().username = newUsername;
                CurrentConnection.Close();
                return true;

            } else
            {
                Console.WriteLine("Insert failed");
                CurrentConnection.Close();
                return false;
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

            } else
            {
                Console.WriteLine("Insert failed");
                CurrentConnection.Close();
                return false;
            }

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

            } else
            {
                reader.Close();
                CurrentConnection.Close();
                return false;
            }

        }
        //Method for getting username by provided id
        private string getUsernameById(int id)
        {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();

            string query = "SELECT username FROM users WHERE User_id='" + id + "';";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            //cmd.Parameters.AddWithValue("@userId", id);
            //cmd.Parameters.AddWithValue("@Deleted", 0);
            MySqlDataReader reader = cmd.ExecuteReader();

            string username = null;
            if (reader.Read())
            {
                username = reader[0].ToString();
            } else
            {
                MessageBox.Show("User with this id doesn't exist!");
                return null;
            }

            reader.Close();
            CurrentConnection.Close();
            return username;

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
                int userId = Convert.ToInt32(reader["User_id"]);
                string username = getUsernameById(userId);
                string log = $"Username: {username} \n Time at the action: {reader.GetString("Time")}  \n Action: {reader.GetString("Action")}";
                logs.Add(log);
            }
            reader.Close();
            CurrentConnection.Close();
            return logs;
        }

        private bool? checkIfUserIsDeleted(int id) {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();
            string query = "SELECT deleted FROM users WHERE User_id=@userId;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@userId", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToInt32(reader["deleted"]) == 1)
                {
                    reader.Close();
                    CurrentConnection.Close();
                    return true;
                } else {
                    reader.Close();
                    CurrentConnection.Close();
                    return false;
                }
            }
            return null;
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

        //Method which is called whenever the user log out of the account
        private void Logout()
        {


            Dispose();
            Form1 form1 = new Form1();
            form1.Show();

            //Making a log that the user has logged out of his account
            bool isitlogged = createLog(getUserIdByUsername(getCurrentlyLoggedUser().username), "Log out");
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
        static List<string> byteArrayToHexList(byte[] bytes)
        {
            List<string> hexValues = new List<string>();

            foreach (byte b in bytes)
            {
                hexValues.Add(b.ToString("X2")); // "X2" formats the byte as a two-digit hexadecimal number
            }

            return hexValues;
        }

        //Method making a string to arrayList of hexidecimal symbols
        static List<string> stringToHexArrayList(string input)
        {
            List<string> hexValues = new List<string>();

            // Convert the string to an array of bytes
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);

            // Convert each byte to its hexadecimal representation
            foreach (byte b in bytes)
            {
                hexValues.Add(b.ToString("X2")); // "X2" formats the byte as a two-digit hexadecimal number
            }

            return hexValues;
        }
        //Method for changing the deleted column for a deleted user in table users 
        private bool changeDeletedToTrueForUsers(int id) {
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

            } else
            {
                Console.WriteLine("Insert failed");
                CurrentConnection.Close();
                return false;
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

            } else
            {
                Console.WriteLine("Insert failed");
                CurrentConnection.Close();
                return false;
            }
        }

        //1st part of my encryption algorithm -> shuffle the file with the key 
        private void firstStepOfEncryption(List<string> key, List<string> file)
        {
            Debug.Write("Key before encryption:");
            for (int i = 0; i < key.Count; i++)
            {
                Debug.Write(key[i] + " ");
            }
            Debug.Write("\n");

            Debug.Write(" file before encryption:");
            for (int i = 0; i < file.Count; i++)
            {
                Debug.Write(file[i] + " ");
            }
            Debug.Write("\n");




            for (int i = 0; i < key.Count; i++)
            {
                int number = Convert.ToInt32(key[i]);
                String onehex = key[i];
                int edinici = number % 10;
                int desetici = number / 10;
                int sum = edinici + desetici;
                if (sum % 2 == 0)
                {
                    file.Add(key[i]);
                } else
                {
                    file.Insert(0, key[i]);
                }
            }


            Debug.Write("Key after encryption:");
            for (int i = 0; i < key.Count; i++)
            {
                Debug.Write(key[i] + " ");
            }
            Debug.Write("\n");

            Debug.Write(" file after encryption:");
            for (int i = 0; i < file.Count; i++)
            {
                Debug.Write(file[i] + " ");
            }

        }

        //second step of my encryption is every 3rd hex number to change position with the element with his's index - 2
        private void secondStepOfEncryption(List<string> file)
        {

            for (int i = 2; i < file.Count; i += 3)
            {
                string a = file[i - 2];
                file[i - 2] = file[i];
                file[i] = a;
            }
        }

        //3rd step of encryption is shuffle the symbols for every hexidecimal pair if the sum between 2 of the hex is odd or even they trade some of them values
        private void thirdStepOfEncryption(List<string> file)
        {
            for (int i = 0; i < file.Count - 1; i++)
            {
                
                //Takes the first hex number for example "16" and separate the symbols -> "1" and "6" and converts them to int
                char[] firstNumberValues = file[i].ToCharArray();
                int firstValueFromFirstNumber = int.Parse(firstNumberValues[0].ToString(), System.Globalization.NumberStyles.HexNumber); 
                int secondValueFromFirstNumber = int.Parse(firstNumberValues[1].ToString(), System.Globalization.NumberStyles.HexNumber);

                //Takes the second hex number for example "13" and separate the symbols -> "1" and "3 and converts them to int
                char[] nextNumberValues = file[i + 1].ToCharArray();
                int firstValueFromNextNumber = int.Parse(nextNumberValues[0].ToString(), System.Globalization.NumberStyles.HexNumber); 
                int secondValueFromNextNumber = int.Parse(nextNumberValues[1].ToString(), System.Globalization.NumberStyles.HexNumber); 

                //Makes the summary of numbers in the hex
                int sumFirstHex = firstValueFromFirstNumber + secondValueFromFirstNumber;//for example if the first hex is 16 sum = 1 + 6 = 7
                int sumSecondHex = firstValueFromNextNumber + secondValueFromNextNumber;//for example if the second hex is 13 sum = 1 + 3 = 4
                int sum = sumFirstHex + sumSecondHex;//Makes the sum of the sums of the hex symbols - > 7 + 4 = 11

                //If the sum is even we change the symbols from the hex -> we change frist symbol from the first hex with the second symbol from the second hex
                //like this "16" "13" - > "36" "11"
                if (sum % 2 == 0)
                {
                    string newValueFori = secondValueFromNextNumber.ToString() + secondValueFromFirstNumber.ToString();
                    string newValueForiplusone = firstValueFromNextNumber.ToString() + firstValueFromFirstNumber.ToString();
                    file[i] = newValueFori;
                    file[i + 1] = newValueForiplusone;

                    //If the sum is odd we change the symbols from the hex -> we change second symbol from the first hex with the first symbol from the second hex
                    //like this "16" "13" - > "13" "63"
                } else
                {
                    string newValueFori = firstValueFromFirstNumber.ToString() + firstValueFromNextNumber.ToString();
                    string newValueForiplusone = secondValueFromFirstNumber.ToString() + secondValueFromNextNumber.ToString();
                    file[i] = newValueFori;
                    file[i + 1] = newValueForiplusone;
                }


            }
        }

        //fourth step changes every element with even index to change the position of his hex symbols (e5 -> 5e) and position with the element on the right(index+1)
        private void fourthStepOfEncryption(List<string> file)
        {
            for (int i = 0; i < file.Count; i += 2)
            {
                //If file.Count is odd the last element can't get replaced because is alone, so it breaks
                if (i + 1 >= file.Count) break;
                char[] hex_value = file[i].ToCharArray();
                
                //Rotating the symbols of an every second elemnet
                char first_hex_value = hex_value[0];
                hex_value[0] = hex_value[1];
                hex_value[1] = first_hex_value;

                //Actualizing the actual file with the edited elements which had roatated their symbols
                file[i] = "";
                foreach (char hex_char in hex_value)
                {
                    file[i] += hex_char;
                }
                //Every elemnt change position with the elemnt on the right
                string element = file[i + 1];
                file[i + 1] = file[i];
                file[i] = element;
            }
            //When the file count is odd number the last hex number can't change position with number, because is the last number, so the
            //last hex number after encryption stays the same and in the same position, that's why we change it with the first element
            if (file.Count % 2 != 0)
            {
                string firstEl = file[0];
                file[0] = file[file.Count - 1];
                file[file.Count - 1] = firstEl;
            }

        }
        //Method for decryption the fourth step of decryption
        private void firstStepOfDecryption(List<string> file)
        {

            //In the encryption step when the count of all of the hex numbers are odd, the last number can change its position because its the last, so the encryption 
            //changes the last element with the first so here first before other reverse decryption we need to change the first with the last element
            // !(THIS IS ONLY FOR ODD file.Count)!
            if (file.Count % 2 != 0)
            {
                string firstEl = file[0];
                file[0] = file[file.Count - 1];
                file[file.Count - 1] = firstEl; 
            }

            //First reverse the shuffle make the elements in the right order
            for (int i = 0; i < file.Count; i += 2)
            {
                if (i + 1 >= file.Count) break;//When the file.Count is odd it has to break so the last elemnt doesn't change or edit 
                                               //in some way because its changed with the first element look the if above
                string element = file[i + 1];
                file[i + 1] = file[i];
                file[i] = element;
            }
            //Change the rotated symbols on every second element
            for (int i = 0; i < file.Count; i += 2)
            {
                if (i + 1 >= file.Count) break; //When the file.Count is odd it has to break so the last elemnt doesn't change or edit 
                                                //in some way because its changed with the first element look the if above
                char[] hex_value = file[i].ToCharArray();
                char first_hex_value = hex_value[0];
                hex_value[0] = hex_value[1];
                hex_value[1] = first_hex_value;

                file[i] = new string(hex_value);
            }

        }
        //Method for decryption of the third step of encryption
        private void secondStepOfDecryption(List<string> file) {
            for (int i = file.Count-1; i > 0; i--) {

                //Takes the last hex number for example "16" and separate the symbols -> "1" and "6" and converts them to int
                char[] rightNumberValues = file[i].ToCharArray();
                int firstValueFromRightNumber = int.Parse(rightNumberValues[0].ToString(), System.Globalization.NumberStyles.HexNumber);
                int secondValueFromRightNumber = int.Parse(rightNumberValues[1].ToString(), System.Globalization.NumberStyles.HexNumber);

                //Takes the hex number before the last hex number for example "13" and separate the symbols -> "1" and "3" and converts them to int
                char[] leftNumberValues = file[i - 1].ToCharArray();
                int firstValueFromLeftNumber = int.Parse(leftNumberValues[0].ToString(), System.Globalization.NumberStyles.HexNumber);
                int secondValueFromLeftNumber = int.Parse(leftNumberValues[1].ToString(), System.Globalization.NumberStyles.HexNumber);

                //Makes the summary of numbers in the hex
                int sumRightHex = firstValueFromRightNumber + secondValueFromRightNumber;//for example if the first hex is 16 sum = 1 + 6 = 7
                int sumLeftHex = firstValueFromLeftNumber + secondValueFromLeftNumber;//for example if the second hex is 13 sum = 1 + 3 = 4
                int sum = sumLeftHex + sumRightHex;//Makes the sum of the sums of the hex symbols - > 7 + 4 = 11

                //If the sum is even we change the symbols from the hex -> we change frist symbol from the first hex with the second symbol from the second hex
                //like this "16" "13" - > "36" "11"
                if (sum % 2 == 0)
                {
                    string newRightValues = firstValueFromRightNumber.ToString() + firstValueFromLeftNumber.ToString();
                    string newLeftValues = secondValueFromRightNumber.ToString() + secondValueFromLeftNumber.ToString();
                    file[i] = newRightValues;
                    file[i - 1] = newLeftValues;

                    //If the sum is odd we change the symbols from the hex -> we change second symbol from the first hex with the first symbol from the second hex
                    //like this "16" "13" - > "13" "63"
                } else
                {
                    string newRightValues = secondValueFromLeftNumber.ToString() + secondValueFromRightNumber.ToString();
                    string newLeftValues = firstValueFromLeftNumber.ToString() + firstValueFromRightNumber.ToString();
                    file[i] = newRightValues;
                    file[i-1] = newLeftValues;

                }


            }
        }


        //When user select the option - "my account"
        private void myAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Enabled = true;
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
            panel1.Enabled = false;
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

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Some values are null!");
                        return;
                    }

                    if (txt_username.Text == username && txt_email.Text == email && txt_age.Text == age)
                    {
                        MessageBox.Show("No changes has been applied! If you want to save new changes you need to edit some value!");
                        return;
                    }
                    if (txt_username.Text != username && txt_email.Text == email && txt_age.Text == age)
                    {
                        if (checkForExistingUsername(txt_username.Text))
                        {
                            MessageBox.Show("This username you choose has already been registered");
                            return;
                        } else
                        {
                            bool isUpdated = updateUserDataPanel1(lastUsername);
                            if (isUpdated == false)
                            {
                                MessageBox.Show("Error occured, new user data wasn't inserted!");
                                return;
                            } else
                            {
                                MessageBox.Show("User edited successfully!");
                                return;
                            }
                        }

                    } else if (txt_username.Text == username && txt_email.Text != email && txt_age.Text == age)
                    {
                        if (checkForExistingEmail(txt_email.Text))
                        {
                            MessageBox.Show("This email you choose has already been registered");
                            return;
                        } else
                        {
                            bool isUpdated = updateUserDataPanel1(lastUsername);
                            if (isUpdated == false)
                            {
                                MessageBox.Show("Error occured, new user data wasn't inserted!");
                                return;
                            } else
                            {
                                MessageBox.Show("User edited successfully!");
                                return;
                            }
                        }
                    } else if (txt_username.Text == username && txt_email.Text == email && txt_age.Text != age)
                    {
                        if (Convert.ToInt32(txt_age.Text) < 18)
                        {
                            MessageBox.Show("The age must be 18 or over!");
                            return;
                        }
                        bool isUpdated = updateUserDataPanel1(lastUsername);
                        if (isUpdated == false)
                        {
                            MessageBox.Show("Error occured, new user data wasn't inserted!");
                            return;
                        } else
                        {
                            MessageBox.Show("User edited successfully!");
                            return;
                        }
                    } else if (txt_username.Text != username && txt_email.Text != email && txt_age.Text == age)
                    {
                        bool isUpdated = updateUserDataPanel1(lastUsername);
                        if (isUpdated == false)
                        {
                            MessageBox.Show("Error occured, new user data wasn't inserted!");
                            return;
                        } else
                        {
                            MessageBox.Show("User edited successfully!");
                            return;
                        }
                    } else if (txt_username.Text != username && txt_email.Text == email && txt_age.Text != age)
                    {
                        if (Convert.ToInt32(txt_age.Text) < 18)
                        {
                            MessageBox.Show("The age must be 18 or over!");
                            return;
                        }
                        bool isUpdated = updateUserDataPanel1(lastUsername);
                        if (isUpdated == false)
                        {
                            MessageBox.Show("Error occured, new user data wasn't inserted!");
                            return;
                        } else
                        {
                            MessageBox.Show("User edited successfully!");
                            return;
                        }
                    } else if (txt_username.Text == username && txt_email.Text != email && txt_age.Text != age)
                    {
                        if (Convert.ToInt32(txt_age.Text) < 18)
                        {
                            MessageBox.Show("The age must be 18 or over!");
                            return;
                        }
                        bool isUpdated = updateUserDataPanel1(lastUsername);
                        if (isUpdated == false)
                        {
                            MessageBox.Show("Error occured, new user data wasn't inserted!");
                            return;
                        } else
                        {
                            MessageBox.Show("User edited successfully!");
                            return;
                        }
                    } else if (txt_username.Text != username && txt_email.Text != email && txt_age.Text != age)
                    {
                        if (Convert.ToInt32(txt_age.Text) < 18)
                        {
                            MessageBox.Show("The age must be 18 or over!");
                            return;
                        }
                        bool isUpdated = updateUserDataPanel1(lastUsername);
                        if (isUpdated == false)
                        {
                            MessageBox.Show("Error occured, new user data wasn't inserted!");
                            return;
                        } else
                        {
                            MessageBox.Show("User edited successfully!");
                            return;
                        }
                    }

                }
            } catch (MySqlException e1)
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
            List<string> key_hexlist = stringToHexArrayList(key);

            OpenFileDialog fd = new OpenFileDialog();

            fd.Filter = "All Files (*.*)|*.*";
            fd.Multiselect = false;

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string filePath = fd.FileName;

                try
                {
                    byte[] fileBytes = File.ReadAllBytes(filePath);
                    List<string> file_hexlist = byteArrayToHexList(fileBytes);
                    List<string> test = new List<string> {"84", "21", "51"};
                    //firstStepOfEncryption(key_hexlist, file_hexlist);
                    //secondStepOfEncryption(file_hexlist);
                    //thirdStepOfEncryption(file_hexlist);
                    //fourthStepOfEncryption(file_hexlist);
                    //firstStepOfDecryption(file_hexlist);

                    thirdStepOfEncryption(test);

                    Debug.WriteLine("Original 84 21 51");
                    Debug.WriteLine("");
                    Debug.WriteLine("--After Encryption------------------------------------------------------------------------");
                    for (int y = 0; y < test.Count; y++)
                    {
                        Debug.Write(test[y] + " ");
                    }
                    Debug.WriteLine("-----------------------------------------------------------------------------");


                    secondStepOfDecryption(test);


                    Debug.WriteLine("");
                    Debug.WriteLine("--After Decryption------------------------------------------------------------------------");
                    for (int y = 0; y < test.Count; y++)
                    {
                        Debug.Write(test[y] + " ");
                    }
                    Debug.WriteLine("-----------------------------------------------------------------------------");



                } catch (Exception ex)
                {
                    MessageBox.Show("error " + ex.Message);
                }
            }

        }

        private void adminToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string lastUsername = getCurrentlyLoggedUser().username;
            int userId = getUserIdByUsername(lastUsername);
            if (checkIfUserIsAdmin(userId))
            {
                panel2.Enabled = true;
                panel2.Visible = true;
                List<string> logs = new List<string>();
                getLogs(logs);
                string allLogs = string.Join(Environment.NewLine + Environment.NewLine, logs);
                richtxt1.Text = allLogs;
                writeToComboAllUsernames(combo1);
                writeToComboAllUsernames(combo2);


            } else
            {
                MessageBox.Show("You are not admin user, so you can't use admin tools!");
                return;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtUsername.Text = null;
            txtEmail.Text = null;
            txtAge.Text = null;
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
            lbl_acc_type.Text = type;


            panel3.Visible = true;
            panel3.Enabled = true;

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
                            } else
                            {
                                bool isUpdated = updateUserDataPanel3(choosenUser);
                                if (isUpdated == false)
                                {
                                    MessageBox.Show("Error occured, new user data wasn't inserted!");
                                    return;
                                } else
                                {
                                    MessageBox.Show("User edited successfully!");
                                    return;
                                }
                            }

                        } else if (txtUsername.Text == username && txtEmail.Text != email && txtAge.Text == age)
                        {
                            if (checkForExistingEmail(txtEmail.Text))
                            {
                                MessageBox.Show("This email you choose has already been registered");
                                return;
                            } else
                            {
                                bool isUpdated = updateUserDataPanel3(choosenUser);
                                if (isUpdated == false)
                                {
                                    MessageBox.Show("Error occured, new user data wasn't inserted!");
                                    return;
                                } else
                                {
                                    MessageBox.Show("User edited successfully!");
                                    return;
                                }
                            }
                        } else if (txtUsername.Text == username && txtEmail.Text == email && txtAge.Text != age)
                        {
                            bool isUpdated = updateUserDataPanel3(choosenUser);
                            if (isUpdated == false)
                            {
                                MessageBox.Show("Error occured, new user data wasn't inserted!");
                                return;
                            } else
                            {
                                MessageBox.Show("User edited successfully!");
                                return;
                            }
                        }
                    }

                }



            } catch (MySqlException e1)
            {
                MessageBox.Show("Error: " + e1.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Enabled = false;
            panel3.Visible = false;
        }

        private void combo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string choosenUser = combo2.SelectedItem.ToString();
                DialogResult dialogResult = MessageBox.Show("Are you sure you wanna delete this user?", "Deleting user", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int id = getUserIdByUsername(choosenUser);
                    bool isDeletedUsers = changeDeletedToTrueForUsers(id);
                    bool isDeletedUsersPasswords = changeDeletedToTrueForUsersPasswords(id);
                    bool isCreatedLog = createLog(id, "Account deleted");
                    if (isDeletedUsers && isDeletedUsersPasswords && isCreatedLog)
                    {
                        combo2.Items.Clear();
                        List<string> logs = new List<string>();
                        getLogs(logs);
                        string allLogs = string.Join(Environment.NewLine + Environment.NewLine, logs);
                        richtxt1.Text = allLogs;
                        writeToComboAllUsernames(combo2);
                        
                        MessageBox.Show("Successfully deleted user -> " + choosenUser);
                        
                    }
                } else if (dialogResult == DialogResult.No)
                {
                    combo2.Items.Clear();
                    writeToComboAllUsernames(combo2);
                }

            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
