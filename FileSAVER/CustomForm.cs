using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSAVER
{
    public class CustomUser {
        public string username;
        public string type;

        public CustomUser(string username) {
            this.username = username;
        }
    }

    public class CustomForm : Form
    {
        protected static CustomUser CurrenltyLoggedUser;
        protected static MySqlConnection CurrentConnection;

        public void setCurrentlyLoggedUser(CustomUser user) {
            CurrenltyLoggedUser = user;
        }

        public CustomUser getCurrentlyLoggedUser() {
            if (getCurrentlyLoggedUser == null) {
                throw new Exception();
            }
            return CurrenltyLoggedUser;
        }


        public static bool ConnectionErrorHandling()
        {
            if (CurrentConnection.State == ConnectionState.Open)
            {
                return true;
            }
            else {
                MessageBox.Show("Connection error!");
                return false;
            }

        }

    }
}
