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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data source= LAPTOP-F7F5A9UO\SQLEXPRESS ;Initial catalog= GDM ;Integrated Security= true ;");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("select max (inst_id)+1 from instructor", con);
            SqlDataReader reader = com1.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[0].ToString();
            con.Close();

            dt.Clear();
            da = new SqlDataAdapter("select * from instructor", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("INSERT INTO  [instructor]([inst_name],[inst_phone],[inst_address],[inst_salary])VALUES('" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','"+ textBox5.Text +"')", con);
            com1.ExecuteNonQuery();
            MessageBox.Show("Added successfully");
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            int id;
            id = int.Parse(textBox1.Text);
            id++;
            textBox1.Text = id.ToString();
            con.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to close..");
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dt.Clear();
            da = new SqlDataAdapter("select * from instructor", con);
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

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
