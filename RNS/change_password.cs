using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RNS
{
    public partial class change_password : Form
    {
        public change_password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (info.username.Equals("admin"))
            {
                admin a = new admin();
                this.Hide();
                a.Show();
            }
            else
            {
                teacher t = new teacher();
                this.Hide();
                t.Show();
            }
        }
        public void change_pass(String password)
        {
            try
            {

                MySqlConnection conn = connection.mdbconnect();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update login set password='"+password+"' where username='"+info.username+"'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Password successfully Changed");
             }
            catch (Exception ae)
             {
                MessageBox.Show(ae.ToString());
             }
        
        }
        public void change_username(String username)
        {
            try
            {

                MySqlConnection conn = connection.mdbconnect();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update login set username='" + username+ "' where username='" + info.username + "'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Username successfully Changed");
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String temp;
            temp= (textBox1.Text).Trim();
            if (label1.Text.Equals("Username"))
            {
                change_username(temp);
                info.username = temp;
            }
            else
            {
                change_pass(temp);
            }
            textBox1.Text = "";
        }
        public void choice(String ch)
        {
            if (ch == "username")
            {

                label1.Text = "Username";
            }
            else
            {
                label1.Text = "Password";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
        }
    }
}
