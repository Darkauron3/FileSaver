using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;

using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSAVER
{
    using BCrypt.Net;

    public partial class RecoverPassword : Form
    {
        public string recoverUsername { get; private set; }

        public RecoverPassword()
        {
            InitializeComponent();
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

        //Method for getting user's email by provided user id
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

        //Method that generates random password with 10 character, which is send when the user forgot their's
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

        //Method that sends email to the user that had forgoten their password
        public static void SendEmail(string recipientEmail, string newPassword, string username)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("filesaverprojectservice@gmail.com");
            mailMessage.To.Add(recipientEmail);
            mailMessage.Subject = "Forgot pasword";
            mailMessage.Body = "Hello " + username + " here is your new password -> " + newPassword + "\n" + "(Rembeber that you can change that password in the option My Account)\nHave a nice day :)!";

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


        //Method for chaning the user password in the database by provided user id and a new password
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


        private void resetpass_btn_Click(object sender, EventArgs e)
        {
            string username = txt_forgoten.Text;

            string usernamePattern = "^[a-zA-Z0-9]+$";
            bool isUsernameValid = Regex.IsMatch(username, usernamePattern);
            if (isUsernameValid == false)
            {
                MessageBox.Show("The username field only allow letters and numbers as input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int userid = getUserIdByUsername(username);
            if (userid == 0)
            {
                MessageBox.Show("There isn't a user with that username!");
                return;
            }
            string email = getEmailByUserId(userid);


            string new_pass = GenerateRandomPassword();
            SendEmail(email, new_pass, username);
            changeUserPassByUserId(userid, new_pass);
        }

        private void return_btn_Click_1(object sender, EventArgs e)
        {
            Login l = new Login();
            Hide();
            l.Visible = true;
        }
    }
}
