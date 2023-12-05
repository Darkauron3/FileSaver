namespace FileSAVER;
using MySql.Data.MySqlClient;
using BCrypt.Net;

public partial class Form1 : CustomForm
{
    public Form1()
    {
        InitializeComponent();
    }

    //Method for entering the data to the user's logs
    private bool CreateLog(string username, string action)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        string query = "INSERT INTO login_logs (Username, Time, Action) VALUES (@username, @Time, @Action)";
        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        cmd.Parameters.AddWithValue("Username", username);
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

    //Method for sending select queries
    private String SQLSelectQuery(String query)
    {
        string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
        MySqlConnection CurrentConnection = new MySqlConnection(connstring);
        CurrentConnection.Open();

        MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
        MySqlDataReader reader = cmd.ExecuteReader();

        String result = "";
        int columns = reader.FieldCount;
        while (reader.Read())
        {
            for (int i = 0; i < columns; i++)
            {
                String postfix = ",";
                if (columns == 1 || i == columns - 1)
                {
                    postfix = "";
                }

                result += (reader.GetString(i) + postfix);
            }
            result += "\n";
        }

        reader.Close();
        CurrentConnection.Close();

        result = result.Remove(result.Length - 1);

        return result;
    }



    //CONNECT BUTTON
    private void button1_Click(object sender, EventArgs e)
    {
        try
        {

            string UsernameToCheck = txt1.Text;
            string PasswordToCheck = txt2.Text;
            string query = "SELECT pass_hash, username FROM users_passwords WHERE username='" + UsernameToCheck + "';";
            string[] a = SQLSelectQuery(query).Split(',');
            string storedHash = a[0];

            if (BCrypt.Verify(PasswordToCheck, storedHash))
            {
                bool isitlogged = CreateLog(UsernameToCheck, "Logged in");
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
            }
            else
            {
                MessageBox.Show("Wrong username or password!");

                bool isitlogged = CreateLog(UsernameToCheck, "Failed to log in");
                if (isitlogged == false)
                {
                    MessageBox.Show("Failed to insert data!");
                    return;
                }

                return;
            }

        }
        catch (MySqlException ex)
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

}


