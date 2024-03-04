namespace FileSAVER;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System;

public partial class Login : CustomForm
{
    public Login()
    {
        InitializeComponent();
    }


    //Method for entering the data to the user's logs
    private bool CreateLog(int User_id, string action)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO login_logs (users_User_id, Time, Action) VALUES (@User_id, @Time, @Action);";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@User_id", User_id);
        cmd.Parameters.AddWithValue("@Time", DateTime.Now);
        cmd.Parameters.AddWithValue("@Action", action); 

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

    //Method for sending select queries
    private String getPasswordByUserId(int User_id)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT pass_hash FROM users_passwords WHERE User_id=@userId AND deleted=@Deleted;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userId", User_id);
        cmd.Parameters.AddWithValue("@Deleted", 0);
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            string pass_hash = reader["pass_hash"].ToString();
            CurrentConnection.Close();
            reader.Close();

            return pass_hash;
        }

        reader.Close();
        CurrentConnection.Close();

        return null;
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


    private bool checkForExistingUsername(string username)
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
            reader.Close();

            return true;
        }
        reader.Close();
        CurrentConnection.Close();

        return false;
    }

    public static string GenerateRandomPassword(int length = 10)
    {
        const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        var random = new Random();
        var password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            password.Append(validChars[random.Next(validChars.Length)]);
        }

        return password.ToString();
    }

    // Send email with new password
    public static void SendEmail(string recipientEmail, string newPassword, string username)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("filesaverprojectservice@gmail.com");
        mailMessage.To.Add(recipientEmail);
        mailMessage.Subject = "Forgot pasword";
        mailMessage.Body = "Hello " + username + " here is your new password -> " + newPassword + "\n" + "(Rembeber that if you want you can change it when you log in and go to Account/Change password.)\nHave a nice day :)!";

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("filesaverprojectservice@gmail.com", "mbry mkne ezic zief");
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mailMessage);
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        MessageBox.Show("Email has been sent to you!");
    }

    private string getEmailByUserId(int userid)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "SELECT email FROM users WHERE User_id=@userid AND deleted=@Deleted;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@userid", userid);
        cmd.Parameters.AddWithValue("@Deleted", 0);

        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            string email = reader["email"].ToString();
            reader.Close();

            return email;
        }
        reader.Close();
        CurrentConnection.Close();

        return null;
    }

    private void changeUserPassByUserId(int userid, string newpass)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();
        string query = "UPDATE users_passwords SET pass_hash=@hash WHERE User_id=@userid;";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("@hash", BCrypt.HashPassword(newpass));
        cmd.Parameters.AddWithValue("@userid", userid);
        int rowsAffected = cmd.ExecuteNonQuery();
        if (rowsAffected > 0)
        {
            Console.WriteLine("Update successful");
            CurrentConnection.Close();
        }
        else
        {
            MessageBox.Show("Erorr updating the new password!");
            CurrentConnection.Close();
            return;
        }
    }


    //CONNECT BUTTON
    private void button1_Click(object sender, EventArgs e)
    {
        try
        {

            string UsernameToCheck = txt1.Text;
            string PasswordToCheck = txt2.Text;
            int userId = getUserIdByUsername(UsernameToCheck);
            string storedHash = getPasswordByUserId(userId);     

            bool isUsernameValid = checkForExistingUsername(UsernameToCheck);
            if (isUsernameValid)
            {
                if (BCrypt.Verify(PasswordToCheck, storedHash))
                {
                    bool isitlogged = CreateLog(userId,"Logged in");
                    if (isitlogged == false)
                    {
                        MessageBox.Show("Failed to insert data!");
                        return;
                    }

                    MainPage form3 = new MainPage();
                    CustomUser currentUser = new CustomUser(UsernameToCheck);


                    setCurrentlyLoggedUser(currentUser);
                    Hide();
                    form3.Show();
                } else
                {
                    MessageBox.Show("Wrong username or password!");

                    bool isitlogged = CreateLog(userId, "Failed to log in");
                    if (isitlogged == false)
                    {
                        MessageBox.Show("Failed to insert data!");
                        return;
                    }

                    return;
                }
            } else
            {
                MessageBox.Show("Wrong username or password!");
                return;
            }


        } catch (MySqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }

    //Register link
    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Register form2 = new Register();
        Hide();
        form2.Show();


    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        string username = Interaction.InputBox("Enter your username", "Forgotten password", "Provide username of the account you forgot the password");

        string usernamePattern = "^[a-zA-Z0-9]+$";
        bool isUsernameValid = Regex.IsMatch(username, usernamePattern);
        if (isUsernameValid == false)
        {
            MessageBox.Show("The username field only allow letters and numbers as input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        int userid = getUserIdByUsername(username);
        if (userid == 0) {
            MessageBox.Show("There isn't a user with that username!");
            return;
        }
        string email = getEmailByUserId(userid);
        

        string new_pass = GenerateRandomPassword();
        SendEmail(email, new_pass, username);
        changeUserPassByUserId(userid, new_pass);


    }
}

