using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using MySql.Data.MySqlClient;
namespace RNS
{
    public partial class teacher : Form
    {
        
        public teacher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String data, category;
            aclient ac = new aclient();
            data = notice_text.Text;
            category = type.Text;
            if (data.Equals("") || category.Equals(""))
            {
                MessageBox.Show("All fields are mandatory");

            }
            else
            {
                Thread client = new Thread(() => ac.Client(data, category));
                client.Start();

                try
                {
                    //client.Start();
                    MySqlConnection conn = connection.mdbconnect();
                    if (info.check(data))
                    {
                        DateTime dt = date.Value;
                        string deadline = dt.ToString();
                        MySqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "INSERT INTO notice (notice,deadline,category,owner) values ('" + data + "','" + deadline + "','" + type.Text + "','" + info.username + "')";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Notice submitted successfully");
                    }
                    else
                    {
                        MessageBox.Show("Notice is already displayed");
                    }
                    notice_text.Text = "";
                }
                catch (Exception ae)
                {
                    throw ae;

                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            this.Hide();
            home hm = new home();
            hm.Show();
            hm.notifyIcon1.Visible = false;
            hm.notifyIcon1.Dispose();
        }

      private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            home hm = new home();
            info.username = null;
            info.session = 0;
            this.Hide();
            hm.Show();
            hm.notifyIcon1.Visible = false;
            hm.notifyIcon1.Dispose();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change_password cp = new change_password();
            this.Hide();
            cp.Show();
            cp.choice("username");
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            change_password cp = new change_password();
            this.Hide();
            cp.Show();
            cp.choice("password");
        }

        private void myNoticesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notices n = new notices();
            this.Hide();
            n.Show();
        }

        private void facultyNoticesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            general_notice gn = new general_notice();
            gn.choice("faculty");
            this.Hide();
            gn.Show();
        }
        
    }
}
