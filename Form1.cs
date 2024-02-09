using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vezba5._1c
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (
                SqlConnection konekcija = new SqlConnection
                (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SkolaDB.mdf;Integrated Security=True")
                )
            {
                SqlDataAdapter adapter = new SqlDataAdapter
                    (textBox1.Text, konekcija);
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (
              SqlConnection konekcija = new SqlConnection
              (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SkolaDB.mdf;Integrated Security=True")
              )
            {
                string upit = "SELECT * FROM " +
                comboBox1.Text;
                SqlDataAdapter adapter = new SqlDataAdapter
                    (upit, konekcija);
                DataSet ds = new DataSet();
                try
                {
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
