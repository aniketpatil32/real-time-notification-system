using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using MySql.Data.MySqlClient;
namespace RNS
{
   
    public partial class home : Form
    {
        
        void sm()
        {
            aserver ap = new aserver();
            ap.Server();
        }
        public home()
        {
            
                info.validity();
            InitializeComponent();     
            if(info.flag==0)
            {
                //MessageBox.Show("in constructor");
            Thread server = new Thread(sm);
            server.Start();
            info.flag=1;
            }
            if (info.n_count == 0)
            {
                
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = true;
                info.n_count = 1;
            }
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            info.username = (username.Text).Trim();
            info.password = (password.Text).Trim();
            MySqlConnection conn;
            conn = connection.mdbconnect();
            MySqlCommand cmd = conn.CreateCommand();           
            cmd.CommandText="select * from login where username='"+info.username+"'and password='"+info.password+"'";
            MySqlDataReader md = cmd.ExecuteReader();
            while (md.Read())
            {
                count = count + 1;
            }
            

        if(count>=1)
          {
                                 
            if (info.username == "admin")
            {
                this.Hide();
                admin ad = new admin();
                ad.Show();
                info.session = 1;
            }
            else
            {
                this.Hide();
                teacher tc = new teacher();
                tc.Show();
                info.session = 2;
            }
            }
            else
            {
            MessageBox.Show("login unsuccessful","Try again");
            password.Text = "";
            }
        conn.Close();
        }
            
        private void faculty_Click(object sender, EventArgs e)
        {
            if (info.session == 1)
            {
                this.Hide();
                admin a = new admin();
                a.Show();
            }
            else if (info.session == 2)
            {
                this.Hide();
                teacher t = new teacher();
                t.Show();
            }
            label1.Show();
            username.Show();
            password.Show();
            label2.Show();
            label3.Show();
            button1.Show();
           
        }

        private void se_Click(object sender, EventArgs e)
        {
           
            general_notice gn = new general_notice();
            this.Hide();
            gn.choice("se");
            gn.Show();
             
        }

        private void te_Click(object sender, EventArgs e)
        {
            general_notice gn = new general_notice();
            this.Hide();
            gn.choice("te");
            gn.Show();
        }

        private void be_Click(object sender, EventArgs e)
        {
            general_notice gn = new general_notice();
            this.Hide();
            gn.choice("be");
            gn.Show();
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void home_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

       

   }
    public static class info
    {
        public static int flag = 0, session = 0,n_count=0;
        public static String username=null, password;
        

        public static void validity()
        {
            try
            {
                DateTime deadline, today = DateTime.Today; ;
                MySqlConnection conn = connection.mdbconnect();
                MySqlConnection conn1 = connection.mdbconnect();
                MySqlCommand cmd = conn.CreateCommand();
                MySqlCommand cmd1 = conn1.CreateCommand();
                cmd.CommandText = "select * from notice";
                MySqlDataReader md = cmd.ExecuteReader();
                while (md.Read())
                {
                   // MessageBox.Show("in");
                    deadline = Convert.ToDateTime(md["deadline"]);
                    int result = DateTime.Compare(today, deadline);
                    if (result > 0)
                    {
                        cmd1.CommandText = "update notice set status='invalid' where n_id='" + md["n_id"] + "'";
                       
                        cmd1.ExecuteNonQuery();
                    }
                }
                
            }
            catch (Exception e)
            {
                
            }
        
        }
        public static Boolean check(String data)
        {
            int count=0;
            try
            {
                MySqlConnection conn;
                conn = connection.mdbconnect();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from notice where notice='" + data + "'";
                MySqlDataReader md = cmd.ExecuteReader();
                while (md.Read())
                {
                    count = count + 1;
                }
             if (count>=1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            
            }
            
        }
       /* public static  void cc(String data,String category)
        {
            MessageBox.Show("method executed");
            aclient ac = new aclient();
            ac.Client(data,category);
        }*/
        
    }
}
