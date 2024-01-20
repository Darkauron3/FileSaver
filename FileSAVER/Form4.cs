using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSAVER
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
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

        private List<string> getUserData(int id) {
            string connstring = "Server=localhost;Database=mydb;User=normaluser;Password=normalusernormaluser;";
            MySqlConnection CurrentConnection = new MySqlConnection(connstring);
            CurrentConnection.Open();
            string query = "SELECT username, email, age, type FROM users WHERE User_id=@userId AND deleted=@Deleted;";
            MySqlCommand cmd = new MySqlCommand(query, CurrentConnection);
            cmd.Parameters.AddWithValue("@userId", id);
            cmd.Parameters.AddWithValue("@Deleted", 0);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> userData = new List<string>();

            if (reader.Read())
            {
                userData.Add(reader["username"].ToString());
                userData.Add(reader["email"].ToString());
                userData.Add(reader["age"].ToString());
                userData.Add(reader["type"].ToString());
            } else
            {
                return null;
            }

            reader.Close();
            CurrentConnection.Close();
            return userData;


        }

        private void btn_check_identity_Click(object sender, EventArgs e)
        {
            
            string usernameForCheck = txtUsername.Text;
            string emailForCheck = txtEmail.Text;
            int ageForCheck = Convert.ToInt32(txtAge.Text);
            string account_typeForCheck = null;
            if(rdbtn_admin.Checked )
            {
                account_typeForCheck = "admin";
            } else if(rdbtn_normal.Checked )
            {
                account_typeForCheck = "normal user";
            }

            int id = getUserIdByUsername(usernameForCheck);
            List<string> userData = new List<string>();
            userData = getUserData(id);
            string username = userData[0];
            string email = userData[1];
            int age = Convert.ToInt32(userData[2]);
            string type = userData[3];

            if(usernameForCheck.Equals(username) && emailForCheck.Equals(email) &&  ageForCheck == age && account_typeForCheck.Equals(type)) {
                MessageBox.Show("Succesfull identified!");
            } else
            {
                MessageBox.Show("User don't identified!");
                return;
            }

        }
    }
}
