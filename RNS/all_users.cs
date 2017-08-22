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
    public partial class all_users : Form
    {
        public all_users()
        {
            InitializeComponent();
            show_all_users();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin a = new admin();
            this.Hide();
            a.Show();
        }
        public void show_all_users()
        {
            try
            {


                MySqlConnection conn = connection.mdbconnect();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                MySqlCommand cmd;

                cmd = new MySqlCommand("select username from login ", conn);

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
                MessageBox.Show(e.ToString());
            }
        }
    }
}
