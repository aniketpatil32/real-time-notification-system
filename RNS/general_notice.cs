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
    public partial class general_notice : Form
    {
        
        public general_notice()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            home h = new home();
            this.Hide();
            h.Show();
           h.notifyIcon1.Visible =false;
           h.notifyIcon1.Dispose();

        }
        public void choice(String ch)
        {
            if (ch.Equals("se"))
            {

                se_notice();
            }
            else if (ch.Equals("te"))
            {
                te_notice();

            }
            else if (ch.Equals("be"))
            {

                be_notice();

            }
            else if (ch.Equals("faculty"))
            {
                faculty_notice();
            }
        }
        public void se_notice()
        {
            try
            {
                this.Text = "SE Notices";
                this.Refresh();
                MySqlConnection conn = connection.mdbconnect();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand("select n_id as notice_id ,notice as title,deadline from notice where  (status='valid' ) and (category='se' or category='all') order by n_id desc;", conn);
                DataTable dt = new DataTable();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                this.dataGridView1.DataSource = bs;
                sda.Update(dt);
                conn.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                MessageBox.Show(e.ToString());
            }
        }
        public void te_notice()
        {
            try
            {

                this.Text = "TE Notices";
                this.Refresh();
                MySqlConnection conn = connection.mdbconnect();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand("select n_id as notice_id ,notice as title,deadline from notice where  (status='valid') and (category='te' or category='all') order by n_id desc;", conn);
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


            }
        }

        public void be_notice()
        {
            try
            {

                this.Text = "BE Notices";
                this.Refresh();
                MySqlConnection conn = connection.mdbconnect();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand("select n_id as notice_id ,notice as title,deadline from notice where  (status='valid') and (category='be' or category='all') order by n_id desc;", conn);
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


            }
        }
        public void faculty_notice()
        {
            try
            {
                this.Text = "Faculty Notices";
                this.Refresh();
                MySqlConnection conn = connection.mdbconnect();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand("select n_id as notice_id ,notice as title,deadline from notice where  (status='valid') and (category='faculty' or category='all') order by n_id desc;", conn);
                DataTable dt = new DataTable();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                this.dataGridView1.DataSource = bs;
                sda.Update(dt);
                conn.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                MessageBox.Show(e.ToString());
            }
        }

        
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string notice= dataGridView1.SelectedRows[0].Cells["title"].Value.ToString();
                MessageBox.Show(notice);           
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String notice;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                notice = row.Cells["title"].Value.ToString();
                MessageBox.Show(notice);
            }
        }

    }
}
