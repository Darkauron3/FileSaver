namespace FileSAVER;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using System.ComponentModel.Design.Serialization;

public partial class Form1 : CustomForm
{
    public Form1()
    {
        InitializeComponent();
    }


    //Method for entering the data to the user's logs
    private bool CreateLog(int User_id, string action)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO login_logs (User_id, Time, Action) VALUES (@User_id, @Time, @Action);";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("User_id", User_id);
        cmd.Parameters.AddWithValue("Time", DateTime.Now);
        cmd.Parameters.AddWithValue("Action", action); ;

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
                    bool isitlogged = CreateLog(userId, "Logged in");
                    if (isitlogged == false)
                    {
                        MessageBox.Show("Failed to insert data!");
                        return;
                    }

                    Form3 form3 = new Form3();
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
        Form2 form2 = new Form2();
        Hide();
        form2.Show();


    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Form4 form4 = new Form4();
        Hide();
        form4.Show();

    }
}

