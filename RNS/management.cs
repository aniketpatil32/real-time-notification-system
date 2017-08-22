using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace RNS
{
    public partial class management : Form
    {
        public static MySqlConnection conn;
        public management()
        {
            InitializeComponent();
        }

           private void delete_Click(object sender, EventArgs e)
           {
            String uname, pwd;
            uname = username.Text;
            Thread delete = new Thread(() => delete_user(uname));
            delete.Start();
            username.Text = "";
          }
        void delete_user(String username)
        {
            try
            {
                conn = connection.mdbconnect();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Delete from login where username='"+username+"'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("user "+username+" is deleted from database");
            }
            catch (Exception e)
            {

                MessageBox.Show("error while deleting user");
            }
        
        }
        public static void add_user(String username,String password)
        {
            try
            {
                conn = connection.mdbconnect();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into login(username,password) values('"+username+"','"+password+"')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("User "+ username + " is Added to database");
            }
            catch (Exception e)
            {

                MessageBox.Show("User is Already  present");
            }

        }

        private void add_Click(object sender, EventArgs e)
        {
            String uname, pwd;
            uname = username.Text;
            pwd = password.Text;
            Thread add = new Thread(()=>add_user(uname,pwd));
            add.Start();
            username.Text = "";
            password.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            this.Hide();
            a.Show();
        }
        public void user_choice(String ch)
        {
            if (ch.Equals("add"))
            {
                username.Show();
                password.Show();
                label2.Show();
                label3.Show();
                add.Show();

            }
            else if (ch.Equals("delete"))
            {
                password.Hide();
                add.Hide();
                label3.Hide();
                label2.Show();
                username.Show();
                delete.Show();
            }       
        
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               add.PerformClick();
            }
        }

    }
}
