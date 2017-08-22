using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace RNS
{
   
    public class connection
    {
        public static SqlConnection dbconnect()
        {
            
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Aniket Patil\Documents\rns.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True;");
           
            return conn;       
         }
        public static MySqlConnection mdbconnect()
        {
            string myConnectionString;
            MySqlConnection conn;

            myConnectionString = "server=127.0.0.1;uid=root;" +
                "pwd=;database=notice;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                return conn;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
           
        }
    }
}
