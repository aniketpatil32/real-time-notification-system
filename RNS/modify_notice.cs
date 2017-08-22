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
    public partial class modify_notice : Form
    {
        public modify_notice()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                notices n = new notices();
                this.Hide();
                n.Show();     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String data=notice_data.Text;
            String category = comboBox1.Text;
            aclient ac = new aclient();
            Thread client = new Thread(()=>ac.Client(data,category));
            client.Start();

            DateTime dt = date.Value;
            string deadline = dt.ToString();
            if (data.Equals("") || category.Equals(""))
            {
                MessageBox.Show("All fields are mandatory");

            }
            else
            {

                try
                {

                    MySqlConnection conn = connection.mdbconnect();
                    MySqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "update notice set notice='" + data + "',category='" + category + "',deadline='" + deadline + "' where n_id='" + n_id + "'";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Notice successfully Updated");
                    notices n = new notices();
                    this.Hide();
                    n.Show();

                }
                catch (Exception ae)
                {
                    MessageBox.Show(ae.ToString());
                }
            }
       }
        public static int n_id;
        public static DateTime deadline;
        public void  m_notice(int temp)
        {

            try
            {
                n_id = temp;
                MySqlConnection conn = connection.mdbconnect();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select notice,category,deadline from notice where n_id='"+n_id+"'";
                MySqlDataReader mr = cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();
                while (mr.Read())
                {
                    this.notice_data.Text= mr["notice"].ToString();
                    this.comboBox1.SelectedIndex = comboBox1.Items.IndexOf(mr["category"].ToString());
                    deadline = Convert.ToDateTime(mr["deadline"]);
                    date.Value= deadline;
                    this.Show();
                   
                }
                
                conn.Close();
                
            }
            catch (Exception ae)
            {
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection conn = connection.mdbconnect();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "delete  from notice where n_id='"+ n_id +"'";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Notice successfully Removed");
                notices n = new notices();
                this.Hide();
                n.Show();
            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString()); 
            }

        }
    }
}
