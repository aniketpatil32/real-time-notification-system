using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace RNS
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            aclient ac = new aclient();
            String data = notice_text.Text;
            String category = type.Text;
            DateTime dt = date.Value;
            string deadline = dt.ToString();
            if (data.Equals("") || category.Equals(""))
            {
                MessageBox.Show("All fields are mandatory");

            }
            else
            {

                Thread client = new Thread(() => ac.Client(data, category));
                try
                {
                    client.Start();
                    MySqlConnection conn = connection.mdbconnect();
                    if (info.check(data))
                    {

                        MySqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "INSERT INTO notice (notice,deadline,category,owner,approve) values ('" + data + "','" + deadline + "','" + type.Text + "','" + info.username + "','yes')";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Notice successfully published");
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

        private void button5_Click(object sender, EventArgs e)
        {
            management m = new management();
            this.Hide();
            m.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
                this.Hide();
                home hm = new home();
                hm.Show();
                hm.notifyIcon1.Visible = false;
                hm.notifyIcon1.Dispose();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            change_password ch = new change_password();
            this.Hide();
            ch.choice("password");
            ch.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info.username = null;
            info.session = 0;
            this.Hide();
            home hm = new home();
            hm.Show();
            hm.notifyIcon1.Visible = false;
            hm.notifyIcon1.Dispose();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            management m = new management();
            m.user_choice("add");
            this.Hide();
            m.Show();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            management m = new management();
            m.user_choice("delete");
            this.Hide();
            m.Show();
        }

        private void showUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            all_users au = new all_users();
            this.Hide();
            au.Show();
        }

        private void editNoticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notices n = new notices();
            this.Hide();
            n.Show();
        }

        private void facultyNoticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            general_notice gn = new general_notice();
            gn.choice("faculty");
            this.Hide();
            gn.Show();
        }

       
       
    }
}
