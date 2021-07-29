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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data source= LAPTOP-F7F5A9UO\SQLEXPRESS ;Initial catalog= GDM ;Integrated Security= true ;");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        SqlDataAdapter da2;
        DataTable dt2 = new DataTable();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("select max (emp_id)+1 from employee", con);
            SqlDataReader reader = com1.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[0].ToString();
            con.Close();

            dt.Clear();
            da = new SqlDataAdapter("select dep_id, dep_name from department", con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "dep_id";
            comboBox1.DisplayMember = "dep_name";
           

            dt2.Clear();
            da2 = new SqlDataAdapter("select * from employee", con);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
           
            SqlCommand com1 = new SqlCommand("INSERT INTO  [employee]([emp_name],[emp_phone],[emp_address],[emp_salary],[dep_id])VALUES('" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" +comboBox1.SelectedValue+ "')", con);
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

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to close without saving?");
            this.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da2);
            da2.Update(dt2);
            MessageBox.Show("chainges saved successfully");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dt2.Clear();
            da2 = new SqlDataAdapter("select * from employee", con);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
