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
    public partial class request : Form
    {
        public request()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            load_pending_notices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin ad = new admin();
            this.Hide();
            ad.Show();
        }
        public void load_pending_notices()
        {
            try
            {


                MySqlConnection conn = connection.mdbconnect();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                MySqlCommand cmd;
                
                    cmd = new MySqlCommand("select * from notice where approve='no' ", conn);
               
        
                DataTable dt = new DataTable();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                sda.Update(dt);
                conn.Close();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n_id;
            String notice_data=null;
            n_id = Int32.Parse(textBox1.Text);
            try
            {


                MySqlConnection conn = connection.mdbconnect();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand("select notice from notice where n_id='"+n_id+"' ", conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    notice_data = dr["notice"].ToString();
                }
                MessageBox.Show(notice_data);
                conn.Close();

            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           int n_id;
            String data=null;
           n_id=Int32.Parse(textBox1.Text);
           
            try
            {


                MySqlConnection conn = connection.mdbconnect();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand("update notice set approve='yes' where n_id='"+n_id+"'", conn);
                cmd.ExecuteNonQuery();
                cmd=new MySqlCommand("select notice from notice where n_id='"+n_id+"'",conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                    data=dr["notice"].ToString();
                    }
                //Thread client = new Thread(() => info.cc(data));
                //client.Start();
                MessageBox.Show("Notice is Approved");
                conn.Close();
                load_pending_notices();

            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString());

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }
    }
}
