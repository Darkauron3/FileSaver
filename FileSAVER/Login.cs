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

    //The functions enable users to move the form around their screen.
    //This functionality is provided by the title bar in Windows, which I removed due to design considerations. 
    private bool isDragging = false;
    private int mouseX, mouseY;
    private void Login_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            mouseX = e.X;
            mouseY = e.Y;
        }
    }

    private void Login_MouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            this.Left += e.X - mouseX;
            this.Top += e.Y - mouseY;
        }
    }

    private void Login_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = false;
        }
    }



    //Method that creates logs about action in the table login_logs
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
        }
        else
        {
            Console.WriteLine("Failed to insert data");
            return false;
        }
        CurrentConnection.Close();
        return true;

    }

    //A method for retrieving a password hash from the database for a specific user.
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

    //Method that checks if the provided username is already registered in the database
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



    //Login button
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
                    bool isitlogged = CreateLog(userId, "Logged in");
                    if (isitlogged == false)
                    {
                        MessageBox.Show("Failed to insert data!");
                        return;
                    }

                    MainPage form3 = new MainPage();
                    CustomUser currentUser = new CustomUser(UsernameToCheck);


                    setCurrentlyLoggedUser(currentUser);
                    Hide();
                    form3.StartPosition = FormStartPosition.CenterScreen;
                    form3.Show();

                }
                else
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
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
                return;
            }


        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }



    //Forgot password link
    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        RecoverPassword r = new RecoverPassword();
        Hide();
        r.Visible = true;
    }

    //Exit button
    private void button2_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void register_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Register r = new Register();
        Hide();
        r.Visible = true;
    }

    private void open_eye_Click(object sender, EventArgs e)
    {
        open_eye.Visible = false;
        closed_eye.Visible = true;
        txt2.PasswordChar = '\0';
    }

    private void closed_eye_Click(object sender, EventArgs e)
    {
        closed_eye.Visible = false;
        open_eye.Visible = true;
        txt2.PasswordChar = '*';
    }
}

