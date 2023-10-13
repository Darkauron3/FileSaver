namespace FileSAVER;
using MySql.Data.MySqlClient;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string connstring = "server=localhost;uid=test;pwd=zbegomc3;database=mydb";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connstring;
            conn.Open();
            string sql = "select * from persons";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MessageBox.Show("lastName " + reader["LastName"] + " fName " + reader["FirstName"] + " city " + reader["City"]);
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.ToString());
        }




    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Form2 form2 = new Form2();
        Hide();
        form2.Show();


    }

}
