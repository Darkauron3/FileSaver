﻿using Google.Protobuf.Reflection;
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
using System.Text;
namespace FileSAVER;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using BCrypt.Net;
using System.Text.RegularExpressions;
using System.IO;


public partial class MainPage : CustomForm
{


    //Setting the window to take up the entire screen 
    public MainPage()
    {
        InitializeComponent();
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
            CurrentConnection.Close();

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
        //cmd.Parameters.AddWithValue("@userId", id);
        //cmd.Parameters.AddWithValue("@Deleted", 0);
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

    private bool? checkIfUserIsDeleted(int id)
    {
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
            }
            else
            {
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

        string query = "INSERT INTO user_files (User_id, key_value, Encrypted_file) VALUES (@User_id, @Pass, @File);";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@User_id", user_id);
        cmd.Parameters.AddWithValue("@Pass", hashedPass);
        cmd.Parameters.AddWithValue("@File", base64Encoded);


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
    private bool importEncryptionKeysInfo(int user_id, string filename, string filesize, string filetype, string encoding, string uploadDate)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO user_files_info (User_id, File_name, File_size, File_type, Encoding, Upload_date) VALUES (@User_id, @filename, @filesize, @filetype, @encoding, @uploaddate)";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@User_id", user_id);
        cmd.Parameters.AddWithValue("@filename", filename);
        cmd.Parameters.AddWithValue("@filesize", filesize);
        cmd.Parameters.AddWithValue("@filetype", filetype);
        cmd.Parameters.AddWithValue("@encoding", encoding);
        cmd.Parameters.AddWithValue("uploaddate", uploadDate);

        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Data inserted");
            return true;
        }
        else
        {
            Console.WriteLine("Failed to insert data");
            MessageBox.Show("Failed to insert the data!");
            return false;
        }
        CurrentConnection.Close();

    }

    private String getUserPassHash(int user_id, int file_id)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT Key_value FROM user_files WHERE User_id=@userid AND file_id=@fileid;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userid", user_id);
        cmd.Parameters.AddWithValue("@fileid", file_id);
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

    private int getFileIdByForDecryption(string last8symbols)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT file_id FROM user_files WHERE Encrypted_file_code=@file_code;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@file_code", last8symbols);
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            int file_id = Convert.ToInt32(reader["File_id"]);
            reader.Close();
            CurrentConnection.Close();
            return file_id;

        }
        else
        {
            reader.Close();
            CurrentConnection.Close();
            MessageBox.Show("Error gettin FileId!");
            return 0;
        }

    }

    private string getEncodingType(int userid, int fileid)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT Encoding FROM user_files_info WHERE User_id=@userid AND File_id=@fileid;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@fileid", fileid);
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

            Random random = new Random();
            WaitRandomTime(random, 1000, 3000);

            string lastElement = key[key.Count - 1];
            key.RemoveAt(key.Count - 1);
            key.Insert(0, lastElement);
        }
        //Then the rotated password is added to the file content
        for (int i = 0; i < key.Count; i++)
        {
            Random random = new Random();
            WaitRandomTime(random, 1000, 3000);
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
            Random random = new Random();
            WaitRandomTime(random, 1000, 3000);
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
            Random random = new Random();
            WaitRandomTime(random, 1000, 3000);
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
            Random random = new Random();
            WaitRandomTime(random, 1000, 3000);
            //If the sum is even we change the symbols from the hex -> we change frist symbol from the first hex with the second symbol from the second hex
            //like this "16" "13" - > "36" "11"
            if (sum % 2 == 0)
            {
                string newValueFori = secondValueFromNextNumber.ToString("X") + secondValueFromFirstNumber.ToString("X");
                string newValueForiplusone = firstValueFromNextNumber.ToString("X") + firstValueFromFirstNumber.ToString("X");
                file[i] = newValueFori;
                file[i + 1] = newValueForiplusone;

                //If the sum is odd we change the symbols from the hex -> we change second symbol from the first hex with the first symbol from the second hex
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

    //fourth step changes every element with even index to change the position of his hex symbols (e5 -> 5e) and position with the element on the right(index+1)
    private void fourthStepOfEncryption(List<string> file)
    {
        for (int i = 0; i < file.Count; i += 2)
        {
            Random random = new Random();
            WaitRandomTime(random, 1000, 3000);
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
            Random random = new Random();
            WaitRandomTime(random, 1000, 3000);
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
        Random random = new Random();
        WaitRandomTime(random, 1000, 3000);
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
    private void secondStepOfDecryption(List<string> file)
    {
        for (int i = file.Count - 1; i > 0; i--)
        {

            //Takes the last hex number for example "16" and separate the symbols -> "1" and "6" and converts them to int
            char[] rightNumberValues = file[i].ToCharArray();
            int firstValueFromRightNumber = int.Parse(rightNumberValues[0].ToString(), System.Globalization.NumberStyles.HexNumber);
            int secondValueFromRightNumber = int.Parse(rightNumberValues[1].ToString(), System.Globalization.NumberStyles.HexNumber);
            Random random = new Random();
            WaitRandomTime(random, 1000, 3000);
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
                string newRightValues = firstValueFromRightNumber.ToString("X") + firstValueFromLeftNumber.ToString("X");
                string newLeftValues = secondValueFromRightNumber.ToString("X") + secondValueFromLeftNumber.ToString("X");
                file[i] = newRightValues;
                file[i - 1] = newLeftValues;

                //If the sum is odd we change the symbols from the hex -> we change second symbol from the first hex with the first symbol from the second hex
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
            index = i;
        }
        Random random = new Random();
        WaitRandomTime(random, 1000, 3000);
        for (int i = index; i >= 0; i -= 3)
        {
            if (i == 1 || i == 0 || i == 2)
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
        //so we remove the last symbols which represent the key from the file so only the file content to stay
        int br = 0;
        for (int i = file.Count - 1; i >= 0; i--)
        {
            Random random = new Random();
            WaitRandomTime(random, 1000, 3000); if (br < key.Count)
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

    //When user select the option - "my account"
    private void myAccountToolStripMenuItem_Click(object sender, EventArgs e)
    {
        MyAccount m = new MyAccount();
        Hide();
        m.Visible = true;

    }



    private void Logout_clicked(object sender, EventArgs e)
    {
        Logout();
    }

    private void Closebutton_clicked(object sender, FormClosedEventArgs e)
    {
        Logout();
    }

    private int getFileIdForEncryptionBtn()
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT file_id FROM user_files ORDER BY file_id DESC LIMIT 1;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
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


    private void Encryption_button_Click(object sender, EventArgs e)
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
                /*
                 * 
                 * 
                 * 
                 *CHANGES ARE NEEDED SO, BECAUSE CYRILIC SYMBOLS ARE NOT IN THE ASCII AND NEEDS UTF-8 ENCODING 
                 *
                 *
                 *
                 *
                 *
                 */
                byte[] fileBytes = File.ReadAllBytes(filePath);
                List<string> file_hexlist = byteArrayToHexList(fileBytes);

                firstStepOfEncryption(key_hexlist, file_hexlist);
                secondStepOfEncryption(file_hexlist);
                thirdStepOfEncryption(file_hexlist);
                fourthStepOfEncryption(file_hexlist);

                //After all the encryption the List will be encoded to base 64 and stored in a string and then saved in the db 
                //Also the password will be hashed and stored into the db so when the user provide the right file with the right pass the file to start

                string username = CurrenltyLoggedUser.username;
                string key_Value = txt_key_encryption.Text;
                int userId = getUserIdByUsername(username);
                bool isItImportedKeys = importEncryptionKeys(userId, key_Value, file_hexlist);

                string name = fd.FileName;
                //gets the file size and format it into MB/GB..
                long fileSizeBytes = new FileInfo(fd.FileName).Length;
                string fileSizeString = GetFileSizeString(fileSizeBytes);
                //Gets the filetyoe if the imported file
                string fileType = System.IO.Path.GetExtension(fd.FileName);
                // Format the date and time according to MySQL DATETIME format
                DateTime currentTime = DateTime.Now;
                string uploadDate = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

                StreamReader reader = new StreamReader(filePath, detectEncodingFromByteOrderMarks: true);
                Encoding encoding = reader.CurrentEncoding;
                string enc = encoding.GetType().Name;
                reader.Close();

                bool isItImportedKeysInfo = importEncryptionKeysInfo(userId, fd.FileName, fileSizeString, fileType, enc, uploadDate);
                if (isItImportedKeys && isItImportedKeysInfo)
                {
                    MessageBox.Show("Data inserted successfully");
                }

                byte[] encryptedBytes = hexListToByteArray(file_hexlist);

                // Now, you can save the encryptedBytes array back to the file, replacing the original content
                File.WriteAllBytes(filePath, encryptedBytes);

                int fileid = getFileIdForEncryptionBtn();
                string newFilePath = Path.ChangeExtension(filePath, ".filesaver_" + fileid);
                File.Move(filePath, newFilePath);

                createEncryptedFileLog(userId, filePath);

            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }

    }


    private void button6_Click(object sender, EventArgs e)
    {
        txtUsername.Text = null;
        txtEmail.Text = null;
        txtAge.Text = null;
    }

    private void combo1_MouseClicked(object sender, MouseEventArgs e)
    {
        combo1.Items.Clear();
        writeToComboAllUsernames(combo1);
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
        //lbl_acc_type.Text = type;

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

    private void button5_Click(object sender, EventArgs e)
    {
        panel3.Enabled = false;
        panel3.Visible = false;
    }

    private string getOldFileType(int userid, int fileid)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT File_type FROM user_files_info WHERE User_id=@userid AND File_Id=@fileid;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@fileid", fileid);

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
            }
            else if (dialogResult == DialogResult.No)
            {
                combo2.Items.Clear();
                writeToComboAllUsernames(combo2);
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }

    private void Decryption_button_Click(object sender, EventArgs e)
    {
        string key = txt_key_decryption.Text;
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

                string username = getCurrentlyLoggedUser().username;
                int id = getUserIdByUsername(username);

                int file_id = ExtractFileId(fd.FileName);

                string database_pass_hash = getUserPassHash(id, file_id);
                string pass = txt_key_decryption.Text;

                if (BCrypt.Verify(pass, database_pass_hash))
                {
                    int fileId = ExtractFileId(fd.FileName);
                    firstStepOfDecryption(file_hexlist);
                    secondStepOfDecryption(file_hexlist);
                    thirdStepOfDecryption(file_hexlist);
                    fourthStepOfDeryption(file_hexlist, key_hexlist);

                    byte[] decryptedBytes = hexListToByteArray(file_hexlist);
                    File.WriteAllBytes(fd.FileName, decryptedBytes);

                    string oldFiletype = getOldFileType(id, fileId);
                    string newFilePath = Path.ChangeExtension(filePath, oldFiletype);
                    File.Move(filePath, newFilePath);

                    createDecryptedFileLog(id, filePath);
                }
                else
                {
                    MessageBox.Show("Wrong password for decryption!");
                    return;
                }
                MessageBox.Show("File decrypted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }



    private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
    {
        panel4.Enabled = true;
        panel4.Visible = true;
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

    private void button7_Click(object sender, EventArgs e)
    {
        panel4.Enabled = false;
        panel4.Visible = false;
    }

    private void clearAllLogs()
    {
        string connstring = "Server=localhost;Database=mydb;User=adminuser;Password=adminuseradminuser;";
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

    private void clearLogs_Click(object sender, EventArgs e)
    {
        richtxt1.Clear();
        clearAllLogs();

    }

    private void button8_Click(object sender, EventArgs e)
    {
        panel2.Enabled = false;
        panel2.Visible = false;
    }

    private void check_login_CheckedChanged(object sender, EventArgs e)
    {
        refreshLogs();
    }

    private void check_loginfail_CheckedChanged(object sender, EventArgs e)
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

    private void check_changedpass_CheckedChanged(object sender, EventArgs e)
    {
        refreshLogs();
    }

    private void check_accdel_CheckedChanged(object sender, EventArgs e)
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
}

