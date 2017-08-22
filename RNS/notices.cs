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
    public partial class notices : Form
    {
        public notices()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            load_all_notices();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (info.username == "admin")
            {
                admin ad = new admin();
                this.Hide();
                ad.Show();
            }
            else
            {
                teacher t = new teacher();
                this.Hide();
                t.Show();
            }
        }
        public void load_all_notices()
        {
            try
            {


                MySqlConnection conn = connection.mdbconnect();
                MySqlDataAdapter sda = new MySqlDataAdapter();
                MySqlCommand cmd;
                if (info.username.Equals("admin"))
                {
                    cmd = new MySqlCommand("select * from notice order by n_id desc", conn);
                }
                else
                {
                   cmd = new MySqlCommand("select * from notice where owner='" + info.username + "' order by n_id desc", conn);
                }
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string n_id = dataGridView1.SelectedRows[0].Cells["n_id"].Value.ToString();
                //MessageBox.Show(n_id);
                modify_notice mn = new modify_notice();
                mn.m_notice(Int32.Parse(n_id));
                this.Hide();
                mn.Show();
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                String n_id;
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                n_id = row.Cells["n_id"].Value.ToString();
                modify_notice mn = new modify_notice();
                mn.m_notice(Int32.Parse(n_id));
                this.Hide();
                mn.Show();
            }
        }

    }
}
