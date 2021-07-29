using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace GDM
{
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data source= LAPTOP-F7F5A9UO\SQLEXPRESS ;Initial catalog= GDM ;Integrated Security= true ;");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("select max (sub_id)+1 from subject", con);
            SqlDataReader reader = com1.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[0].ToString();
            con.Close();

            dt.Clear();
            da = new SqlDataAdapter("select * from subject", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("INSERT INTO  [subject]([sub_name],[sub_cost],[sub_duration])VALUES('" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')", con);
            com1.ExecuteNonQuery();
            MessageBox.Show("Added successfully");
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            int id;
            id = int.Parse(textBox1.Text);
            id++;
            textBox1.Text = id.ToString();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to close..");
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dt.Clear();
            da = new SqlDataAdapter("select * from subject", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("chainges saved successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to close without saving?");
            this.Close();
        }
    }
}
