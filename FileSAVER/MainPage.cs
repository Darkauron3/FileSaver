using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
namespace FileSAVER;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BCrypt.Net;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Threading;
using System.Timers;


public partial class MainPage : CustomForm
{
    System.Windows.Forms.Timer inactivityTimer = new System.Windows.Forms.Timer();

    public MainPage()
    {
        InitializeComponent();
        SetupTimer();
    }

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


    //3 method for mouse movement, so the user can drag the windows around his screen
    private bool isDragging = false;
    private int mouseX, mouseY;
    private void MainPage_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            mouseX = e.X;
            mouseY = e.Y;
        }
    }

    private void MainPage_MouseMove(object sender, MouseEventArgs e)
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

    private void MainPage_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = false;
        }
    }


    //Constructor for UserData
    public class UserData
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Type { get; set; }
    }
    //Method for recieving data of user by user_id
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
    //Method for creating a log about an encrypted file
    private bool createEncryptedFileLog(int userid, string filepath)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO login_logs (users_User_id, Time, Action) VALUES (@User_id, @Time, @Action)";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);

        cmd.Parameters.AddWithValue("@User_id", userid);
        cmd.Parameters.AddWithValue("@Time", DateTime.Now);
        cmd.Parameters.AddWithValue("@Action", "File encrypted -> " + filepath);

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
    //Method for creating a log about an decrypted file
    private bool createDecryptedFileLog(int userid, string filepath)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO login_logs (users_User_id, Time, Action) VALUES (@User_id, @Time, @Action)";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);

        cmd.Parameters.AddWithValue("@User_id", userid);
        cmd.Parameters.AddWithValue("@Time", DateTime.Now);
        cmd.Parameters.AddWithValue("@Action", "File decrypted -> " + filepath);

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

    private bool importEncryptionKeys(int user_id, string key, List<string> file)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        //The password for the file to be encrypted and decrypted, has to be stored in the db in form of a hash
        string hashedPass = BCrypt.HashPassword(key);

        //The file content is save from a List<string> to string variable and then encoded to base 64 and then saved in the db
        string fileContent = string.Join(Environment.NewLine, file);
        string base64Encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(fileContent));

        string query = "INSERT INTO user_files (User_id, key_value, Encrypted_file, deleted) VALUES (@User_id, @Pass, @File, @deleted);";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@User_id", user_id);
        cmd.Parameters.AddWithValue("@Pass", hashedPass);
        cmd.Parameters.AddWithValue("@File", base64Encoded);
        cmd.Parameters.AddWithValue("@deleted", 0);


        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Data inserted");
            CurrentConnection.Close();
            return true;
        }
        else
        {
            Console.WriteLine("Failed to insert data");
            MessageBox.Show("Failed to insert the data!");
            CurrentConnection.Close();
            return false;

        }

    }


    //Method for inserting inforamtion about encrypted file in the table user_files_info 
    private bool importEncryptionKeysInfo(int user_id, string filename, string filesize, string filetype, string uploadDate)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO user_files_info (User_id, File_name, File_size, File_type, Upload_date, deleted) VALUES (@User_id, @filename, @filesize, @filetype, @uploaddate, @deleted)";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@User_id", user_id);
        cmd.Parameters.AddWithValue("@filename", filename);
        cmd.Parameters.AddWithValue("@filesize", filesize);
        cmd.Parameters.AddWithValue("@filetype", filetype);
        cmd.Parameters.AddWithValue("@uploaddate", uploadDate);
        cmd.Parameters.AddWithValue("@deleted", 0);

        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Data inserted");
            CurrentConnection.Close();
            return true;
        }
        else
        {
            Console.WriteLine("Failed to insert data");
            MessageBox.Show("Failed to insert the data!");
            CurrentConnection.Close();
            return false;
        }


    }

    private String getUserPassHash(int user_id, int file_id)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT Key_value FROM user_files WHERE User_id=@userid AND file_id=@fileid AND deleted=@deleted;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userid", user_id);
        cmd.Parameters.AddWithValue("@fileid", file_id);
        cmd.Parameters.AddWithValue("@deleted", 0);
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            string pass_hash = reader["Key_value"].ToString();
            CurrentConnection.Close();
            reader.Close();

            return pass_hash;
        }

        reader.Close();
        CurrentConnection.Close();

        return null;
    }

    private string getEncodingType(int userid, int fileid)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT Encoding FROM user_files_info WHERE User_id=@userid AND File_id=@fileid AND deleted=@deleted;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@fileid", fileid);
        cmd.Parameters.AddWithValue("@deleted", 0);
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            string encoding = reader["Encoding"].ToString();
            reader.Close();
            CurrentConnection.Close();
            return encoding;

        }
        else
        {
            reader.Close();
            CurrentConnection.Close();
            MessageBox.Show("Error gettin Encoding type!");
            return null;
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

    static void WaitRandomTime(Random random, int minMilliseconds, int maxMilliseconds)
    {
        int randomMilliseconds = random.Next(minMilliseconds, maxMilliseconds + 1);
        Console.WriteLine($"Waiting for {randomMilliseconds} milliseconds...");
        System.Threading.Thread.Sleep(randomMilliseconds);
    }


    //1st part of my encryption algorithm -> shuffle the file with the key 
    private void firstStepOfEncryption(List<string> key, List<string> file)
    {
        //We rotate the key for example if its 12 34 56 , now is 56 34 12
        for (int i = 0; i < key.Count; i++)
        {
            if (key == null || key.Count == 0)
                return;

            string lastElement = key[key.Count - 1];
            key.RemoveAt(key.Count - 1);
            key.Insert(0, lastElement);
        }
        //Then the rotated password is added to the file content
        for (int i = 0; i < key.Count; i++)
        {
            file.Add(key[i]);
        }

    }

    //second step of my encryption is every 3rd hex number to change position with the element with his's index - 2 and change positions
    //to the other numbers left which are with index i and i+3
    private void secondStepOfEncryption(List<string> file)
    {
        //Change's every third elemnt with the elemnt with his index-2
        //For example "84" "21" "51" "54" "78" "96" ->  "51" "21" "84" "96" "78" "54" 
        for (int i = 2; i < file.Count; i += 3)
        {
            string a = file[i - 2];
            file[i - 2] = file[i];
            file[i] = a;
        }

        //16 32 14 60 50 30 we need to scramble i=1 i+=3 numbers so we just change positions of 32 with 50 and it will look like this
        //16 50 14 60 32 30 the step over this will change the other numbers so finnaly will look like this 14 50 16 30 32 60 which is well scrambled
        //and it can be easily reversable for decryption.

        for (int i = 1; i < file.Count; i += 3)
        {

            if (i + 3 >= file.Count) //if i + 3 doesn't exist we break
            {
                break;
            }
            string element = file[i + 3];
            file[i + 3] = file[i];
            file[i] = element;
        }
    }

    //3rd step of encryption is shuffle the symbols for every hexidecimal pair
    //if the sum between 2 of the hex is odd or even they trade some of them values
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
            //If the sum is even we change the symbols from the hex -> we change frist symbol
            //from the first hex with the second symbol from the second hex
            //like this "16" "13" - > "36" "11"
            if (sum % 2 == 0)
            {
                string newValueFori = secondValueFromNextNumber.ToString("X") + secondValueFromFirstNumber.ToString("X");
                string newValueForiplusone = firstValueFromNextNumber.ToString("X") + firstValueFromFirstNumber.ToString("X");
                file[i] = newValueFori;
                file[i + 1] = newValueForiplusone;

                //If the sum is odd we change the symbols from the hex -> we change second symbol from the first hex with the
                //first symbol from the second hex
                //like this "16" "13" - > "13" "63"
            }
            else
            {
                string newValueFori = firstValueFromFirstNumber.ToString("X") + firstValueFromNextNumber.ToString("X");
                string newValueForiplusone = secondValueFromFirstNumber.ToString("X") + secondValueFromNextNumber.ToString("X");
                file[i] = newValueFori;
                file[i + 1] = newValueForiplusone;
            }


        }
    }

    //fourth step changes every element with even index to change the position of his hex symbols (e5 -> 5e)
    //and position with the element on the right(index+1)
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
        //When the file count is odd number the last hex number can't change position with number,
        //because is the last number, so the
        //last hex number after encryption stays the same and in the same position, that's why we
        //change it with the first element
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
        //In the encryption step when the count of all of the
        //hex numbers are odd, the last number can change its
        //position because its the last, so the encryption 
        //changes the last element with the first so here first
        //before other reverse decryption we need to change the
        //first with the last element
        // !(THIS IS ONLY FOR ODD file.Count)!
        if (file.Count % 2 != 0)
        {
            string firstEl = file[0];
            file[0] = file[file.Count - 1];
            file[file.Count - 1] = firstEl;
        }
        //First reverse the shuffle and make the elements in
        //the right order
        for (int i = 0; i < file.Count; i += 2)
        {
            if (i + 1 >= file.Count) break;//When the file.Count
                                           //is odd it has to break so the last elemnt doesn't change or edit 
                                           //in some way because its changed with the first element look the if above
            string element = file[i + 1];
            file[i + 1] = file[i];
            file[i] = element;
        }
        //Change the rotated symbols on every second element
        for (int i = 0; i < file.Count; i += 2)
        {
            if (i + 1 >= file.Count) break; //When the file.Count is odd it has
                                            //to break so the last elemnt doesn't change or edit 
                                            //in some way because its changed with the first element look the if above
            char[] hex_value = file[i].ToCharArray();
            char first_hex_value = hex_value[0];
            hex_value[0] = hex_value[1];
            hex_value[1] = first_hex_value;

            file[i] = new string(hex_value);
        }

    }
    //Method for decryption of the third step of encryption
    private void secondStepOfDecryption(List<string> file)
    {
        for (int i = file.Count - 1; i > 0; i--)
        {

            //Takes the last hex number for example "16" and separate the symbols -> "1" and "6" and converts them to int
            char[] rightNumberValues = file[i].ToCharArray();
            int firstValueFromRightNumber = int.Parse(rightNumberValues[0].ToString(), System.Globalization.NumberStyles.HexNumber);
            int secondValueFromRightNumber = int.Parse(rightNumberValues[1].ToString(), System.Globalization.NumberStyles.HexNumber);
            //Takes the hex number before the last hex number for example "13" and separate the symbols -> "1" and "3" and
            //converts them to int
            char[] leftNumberValues = file[i - 1].ToCharArray();
            int firstValueFromLeftNumber = int.Parse(leftNumberValues[0].ToString(), System.Globalization.NumberStyles.HexNumber);
            int secondValueFromLeftNumber = int.Parse(leftNumberValues[1].ToString(), System.Globalization.NumberStyles.HexNumber);

            //Makes the summary of numbers in the hex
            int sumRightHex = firstValueFromRightNumber + secondValueFromRightNumber;//for example if the first hex
                                                                                     //is 16 sum = 1 + 6 = 7
            int sumLeftHex = firstValueFromLeftNumber + secondValueFromLeftNumber;//for example if the second hex
                                                                                  //is 13 sum = 1 + 3 = 4
            int sum = sumLeftHex + sumRightHex;//Makes the sum of the sums of the hex symbols - > 7 + 4 = 11

            //If the sum is even we change the symbols from the hex -> we change frist symbol from the first hex with the
            //second symbol from the second hex
            //like this "16" "13" - > "36" "11"
            if (sum % 2 == 0)
            {
                string newRightValues = firstValueFromRightNumber.ToString("X") + firstValueFromLeftNumber.ToString("X");
                string newLeftValues = secondValueFromRightNumber.ToString("X") + secondValueFromLeftNumber.ToString("X");
                file[i] = newRightValues;
                file[i - 1] = newLeftValues;

                //If the sum is odd we change the symbols from the hex -> we change second symbol from the first hex with
                //the first symbol from the second hex
                //like this "16" "13" - > "13" "63"
            }
            else
            {
                string newRightValues = secondValueFromLeftNumber.ToString("X") + secondValueFromRightNumber.ToString("X");
                string newLeftValues = firstValueFromLeftNumber.ToString("X") + firstValueFromRightNumber.ToString("X");
                file[i] = newRightValues;
                file[i - 1] = newLeftValues;

            }
        }
    }

    private void thirdStepOfDecryption(List<string> file)
    {
        //Here we change the numbers that are being rotated in the encryption metod, so the number i and i+3 have to be changed
        //and if i+3 doesn't exist we break
        int index = 0;
        for (int i = 1; i < file.Count; i += 3)
        {
            index = i;//Here we find the index of the last element which participated in the shuffle so next for cycle we
                      //can know from which element to start reversing 
        }
        for (int i = index; i >= 0; i -= 3)
        {
            if (i == 1 || i == 0 || i == 2) //if the index is below 3 we break, because this
                                            //means that the last two elements have changed and there are no other elements to change 
            {
                break;
            }
            string element = file[i - 3];
            file[i - 3] = file[i];
            file[i] = element;
        }
        //Change's every third elemnt with the elemnt with his index-2
        //For example "84" "21" "51" "54" "78" "96" ->  "51" "21" "84" "96" "78" "54" 
        for (int i = 2; i < file.Count; i += 3)
        {
            string a = file[i - 2];
            file[i - 2] = file[i];
            file[i] = a;
        }
    }
    //Removes all the symbols from the key so only the original file will be left
    private void fourthStepOfDeryption(List<string> file, List<string> key)
    {
        //so we remove the last symbols which represent the key from the
        //file so only the file content to stay
        int br = 0;
        for (int i = file.Count - 1; i >= 0; i--)
        {
            if (br < key.Count)
            {
                file.RemoveAt(i);
                br++;
            }
            else
            {
                return;
            }

        }

    }
    //Method for getting the size of the file string
    static string GetFileSizeString(long fileSizeBytes)
    {
        string[] suffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        const int byteConversion = 1024;
        if (fileSizeBytes == 0)
        {
            return "0" + suffixes[0];
        }

        int place = Convert.ToInt32(Math.Floor(Math.Log(fileSizeBytes, byteConversion)));
        double num = Math.Round(fileSizeBytes / Math.Pow(byteConversion, place), 1);
        return $"{num}{suffixes[place]}";
    }

    private byte[] hexListToByteArray(List<string> hexList)
    {
        // Create a byte array to store the result
        byte[] byteArray = new byte[hexList.Count];

        // Convert each hexadecimal string back to bytes and store them in the byte array
        for (int i = 0; i < hexList.Count; i++)
        {
            // Parse the hexadecimal string to a byte
            byte b = byte.Parse(hexList[i], System.Globalization.NumberStyles.HexNumber);

            // Store the byte in the byte array
            byteArray[i] = b;
        }

        // Return the byte array
        return byteArray;
    }

    private string hexListToString(List<string> hexList)
    {
        StringBuilder sb = new StringBuilder();
        foreach (string hex in hexList)
        {
            sb.Append((char)Convert.ToInt32(hex, 16));
        }
        return sb.ToString();
    }

    private int getFileIdForEncryptionBtn()
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT file_id FROM user_files WHERE deleted = @deleted ORDER BY file_id DESC LIMIT 1;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@deleted", 0);
        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            int fileId = Convert.ToInt32(reader["file_id"]);
            reader.Close();
            CurrentConnection.Close();
            return fileId;
        }
        else
        {
            reader.Close();
            CurrentConnection.Close();
            MessageBox.Show("Error getting the fileid!");
            return 0;
        }
    }



    private string getOldFileType(int userid, int fileid)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT File_type FROM user_files_info WHERE User_id=@userid AND File_Id=@fileid AND deleted=@deleted;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@fileid", fileid);
        cmd.Parameters.AddWithValue("@deleted", 0);

        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            string filetype = reader["File_type"].ToString();
            reader.Close();
            CurrentConnection.Close();

            return filetype;
        }
        reader.Close();
        CurrentConnection.Close();

        return null;


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

    private byte[] HexStringToByteArray(string hexString)
    {
        byte[] bytes = new byte[hexString.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        }
        return bytes;
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

    static int ExtractFileId(string filename)
    {
        // Define the regular expression pattern to match numbers
        string pattern = @"\d+$";

        // Use Regex.Match to find the first occurrence of the pattern in the filename
        Match match = Regex.Match(filename, pattern);

        // Check if a match is found
        if (match.Success)
        {
            // Convert the matched value to an integer and return
            return int.Parse(match.Value);
        }
        else
        {
            // Return -1 or throw an exception indicating that no numbers were found
            throw new InvalidOperationException("No numbers found in the filename.");
        }
    }

    private void btn_acc_Click(object sender, EventArgs e)
    {
        MyAccount m = new MyAccount();
        Hide();
        m.StartPosition = FormStartPosition.CenterScreen;
        m.Visible = true;
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
    //Logout from navigiotion bar
    private void btn_logout_Click(object sender, EventArgs e)
    {
        Logout();
    }

    private List<int> checkForDeltedFile()
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "SELECT file_id, user_id FROM user_files WHERE deleted=@deleted ORDER BY file_id ASC LIMIT 1;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@deleted", 1);
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            int fileid = Convert.ToInt32(reader["file_id"]);
            int userid = Convert.ToInt32(reader["User_Id"]);
            List<int> ids = new List<int>();
            ids.Clear();
            ids.Add(fileid);
            ids.Add(userid);
            return ids;
        }
        else
        {
            List<int> ids = new List<int>();
            ids.Clear();
            ids.Add(0);
            return ids;
        }
    }

    private bool writeNewFileOverDeletedFileUserFiles(int fileid, int userid, string key_value, string encryptedfile)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "UPDATE user_files SET User_id=@userid, Key_value=@key,Encrypted_file=@encryptedfile, deleted=@deleted WHERE file_id=@fileid;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@key", key_value);
        cmd.Parameters.AddWithValue("@encryptedfile", encryptedfile);
        cmd.Parameters.AddWithValue("@deleted", 0);
        cmd.Parameters.AddWithValue("@fileid", fileid);


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


    private bool writeNewFileOverDeletedFileUserFilesInfo(int fileid, int userid, string filename, string filesize, string filetype, string uploaddate)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "UPDATE user_files_info SET User_id=@userid, File_name=@filename, File_size=@filesize, File_type=@filetype, Upload_date=@uploaddate,deleted=@deleted WHERE file_id=@fileid;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@filename", filename);
        cmd.Parameters.AddWithValue("@filesize", filesize);
        cmd.Parameters.AddWithValue("@filetype", filetype);
        cmd.Parameters.AddWithValue("@uploaddate", uploaddate);
        cmd.Parameters.AddWithValue("@deleted", 0);
        cmd.Parameters.AddWithValue("@fileid", fileid);


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

    //Encrypt button
    private void btn_encrypt_Click(object sender, EventArgs e)
    {
        string key = txt_key_encryption.Text;
        string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{16,}$";
        if (!Regex.IsMatch(key, pattern))
        {
            // Password does not meet the criteria
            MessageBox.Show("Password must have at least 1 uppercase character, 1 number, 1 special character, and be at least 16 characters long.");
            return;
        }

        if (String.IsNullOrEmpty(key))
        {
            MessageBox.Show("Please first enter password for the file, then select the file!");
            return;
        }
        List<string> key_hexlist = stringToHexArrayList(key);

        string filePath = lbl_choosen_en_file.Text;

        try
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            List<string> file_hexlist = byteArrayToHexList(fileBytes);

            firstStepOfEncryption(key_hexlist, file_hexlist);
            secondStepOfEncryption(file_hexlist);
            secondStepOfEncryption(file_hexlist);
            thirdStepOfEncryption(file_hexlist);
            thirdStepOfEncryption(file_hexlist);
            fourthStepOfEncryption(file_hexlist);



            //After all the encryption the List will be encoded to base 64 and stored in a string and then saved in the database
            //Also the password will be hashed and stored into the database 

            string username = CurrenltyLoggedUser.username;
            string key_Value = txt_key_encryption.Text;
            int userId = getUserIdByUsername(username);


            //If there is file with column deleted=1, th enew file will take the place of the deletedfile
            List<int> ids = checkForDeltedFile();
            if (ids.Count > 1)//if there is deleted file this new file takes the place of the deleted file
            {
                int fileeid = ids[0];
                int useerid = ids[1];

                string hashedPass = BCrypt.HashPassword(key_Value);
                string fileContent = string.Join(Environment.NewLine, file_hexlist);
                string base64Encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(fileContent));
                bool isItImported = writeNewFileOverDeletedFileUserFiles(fileeid, userId, hashedPass, base64Encoded);


                string namee = lbl_choosen_en_file.Text;
                //gets the file size and format it into MB/GB..
                long fileSizeBytess = new FileInfo(lbl_choosen_en_file.Text).Length;
                string fileSizeStringg = GetFileSizeString(fileSizeBytess);
                //Gets the filetyoe if the imported file
                string fileTypee = System.IO.Path.GetExtension(lbl_choosen_en_file.Text);
                // Format the date and time according to MySQL DATETIME format
                DateTime currentTimee = DateTime.Now;
                string uploadDatee = currentTimee.ToString("yyyy-MM-dd HH:mm:ss");

                bool isItImportedInfo = writeNewFileOverDeletedFileUserFilesInfo(fileeid, userId, namee, fileSizeStringg, fileTypee, uploadDatee);

                byte[] encryptedBytes = hexListToByteArray(file_hexlist);

                // Now, you can save the encryptedBytes array back to the file, replacing the original content
                File.WriteAllBytes(filePath, encryptedBytes);

                if (isItImported && isItImportedInfo)
                {
                    //Telling the user to don't change file extension because there is the fileid which is needed in the decryption process
                    MessageBox.Show("IMPORTANT! Don't change the file extension, this program after encrypting your file will change the file extension with a new one called .filesaver_(number) its important, because the extension holds the id of your file in the database and if you change this extension you may never decrypt your file back!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("File encrypted successfully!");
                }


                string newFilePath = Path.ChangeExtension(filePath, ".filesaver_" + fileeid);
                File.Move(filePath, newFilePath);

                createEncryptedFileLog(useerid, filePath);

                lbl_choosen_en_file.Text = null;
                txt_key_encryption.Text = null;

            }
            else if (ids.Count == 1)// if there isn't a decrpyted file, is created a new insert in the table
            {
                bool isItImportedKeys = importEncryptionKeys(userId, key_Value, file_hexlist);

                string name = lbl_choosen_en_file.Text;
                //gets the file size and format it into MB/GB..
                long fileSizeBytes = new FileInfo(lbl_choosen_en_file.Text).Length;
                string fileSizeString = GetFileSizeString(fileSizeBytes);
                //Gets the filetyoe if the imported file
                string fileType = System.IO.Path.GetExtension(lbl_choosen_en_file.Text);
                // Format the date and time according to MySQL DATETIME format
                DateTime currentTime = DateTime.Now;
                string uploadDate = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

                //Import information about the ecnrypted file in the user_files_info table
                bool isItImportedKeysInfo = importEncryptionKeysInfo(userId, lbl_choosen_en_file.Text, fileSizeString, fileType, uploadDate);
                if (isItImportedKeys && isItImportedKeysInfo)
                {
                    //Telling the user to don't change file extension because there is the fileid which is needed in the decryption process
                    MessageBox.Show("IMPORTANT! Don't change the file extension, this program after encrypting your file will change the file extension with a new one called .filesaver_(number) its important, because the extension holds the id of your file in the database and if you change this extension you may never decrypt your file back!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("File encrypted successfully!");
                }

                byte[] encryptedBytes = hexListToByteArray(file_hexlist);

                // Now, you can save the encryptedBytes array back to the file, replacing the original content
                File.WriteAllBytes(filePath, encryptedBytes);

                int fileid = getFileIdForEncryptionBtn();
                string newFilePath = Path.ChangeExtension(filePath, ".filesaver_" + fileid);
                File.Move(filePath, newFilePath);

                createEncryptedFileLog(userId, filePath);
                lbl_choosen_en_file.Text = null;
                txt_key_encryption.Text = null;
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show("error " + ex.Message);
        }

    }

    //Method changing the deleted column to 1, so after decryption files can be removed form the databased in the table user_files
    private bool setDeleteToTrueUserFiles(int fileid, int userid)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "UPDATE user_files SET deleted=@deleted WHERE file_id=@fileid AND User_id=@userid;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@deleted", 1);
        cmd.Parameters.AddWithValue("@fileid", fileid);
        cmd.Parameters.AddWithValue("@userid", userid);

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

    //Method changing the deleted column to 1, so after decryption files can be removed form the databased in the table user_files_info
    private bool setDeleteToTrueUserFilesInfo(int fileid, int userid)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "UPDATE user_files_info SET deleted=@deleted WHERE file_id=@fileid AND User_id=@userid;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@deleted", 1);
        cmd.Parameters.AddWithValue("@fileid", fileid);
        cmd.Parameters.AddWithValue("@userid", userid);

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


    //Decryption button
    private void btn_decrypto_Click(object sender, EventArgs e)
    {
        string key = txt_key_decryption.Text;

        string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{16,}$";
        if (!Regex.IsMatch(key, pattern))
        {
            // Password does not meet the criteria
            MessageBox.Show("Password must have at least 1 uppercase character, 1 number, 1 special character, and be at least 16 characters long.");
            return;
        }

        if (String.IsNullOrEmpty(key))
        {
            MessageBox.Show("Please first enter password for the file, then select the file!");
            return;
        }
        List<string> key_hexlist = stringToHexArrayList(key);

        string filePath = lbl_decryption_choosen.Text;

        try
        {
            byte[] fileBytes = File.ReadAllBytes(filePath);
            List<string> file_hexlist = byteArrayToHexList(fileBytes);

            string username = getCurrentlyLoggedUser().username;
            int id = getUserIdByUsername(username);

            int file_id = ExtractFileId(lbl_decryption_choosen.Text);

            string database_pass_hash = getUserPassHash(id, file_id);
            string pass = txt_key_decryption.Text;



            if (BCrypt.Verify(pass, database_pass_hash))
            {
                int fileId = ExtractFileId(lbl_decryption_choosen.Text);

                firstStepOfDecryption(file_hexlist);
                secondStepOfDecryption(file_hexlist);
                secondStepOfDecryption(file_hexlist);
                thirdStepOfDecryption(file_hexlist);
                thirdStepOfDecryption(file_hexlist);
                fourthStepOfDeryption(file_hexlist, key_hexlist);

                byte[] decryptedBytes = hexListToByteArray(file_hexlist);
                File.WriteAllBytes(lbl_decryption_choosen.Text, decryptedBytes);

                string oldFiletype = getOldFileType(id, fileId);
                string newFilePath = Path.ChangeExtension(filePath, oldFiletype);
                File.Move(filePath, newFilePath);

                createDecryptedFileLog(id, filePath);
                setDeleteToTrueUserFiles(file_id, id);
                setDeleteToTrueUserFilesInfo(file_id, id);
            }
            else
            {
                MessageBox.Show("Wrong password for decryption!");
                return;
            }
            MessageBox.Show("File decrypted successfully!");
            txt_key_decryption.Text = null;
            lbl_decryption_choosen.Text = null;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
        lbl_decryption_choosen.Text = null;
        txt_key_decryption.Text = null;
    }

    private void Choose_encryption_file_Click(object sender, EventArgs e)
    {
        OpenFileDialog fd = new OpenFileDialog();


        fd.Filter = "All Files (*.*)|*.*";
        fd.Multiselect = false;

        if (fd.ShowDialog() == DialogResult.OK)
        {
            string filePath = fd.FileName;

            try
            {
                lbl_choosen_en_file.Text = filePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

    private void Choose_decryption_file_Click(object sender, EventArgs e)
    {

        OpenFileDialog fd = new OpenFileDialog();

        fd.Filter = "All Files (*.*)|*.*";
        fd.Multiselect = false;

        if (fd.ShowDialog() == DialogResult.OK)
        {
            string filePath = fd.FileName;

            try
            {
                lbl_decryption_choosen.Text = filePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}


