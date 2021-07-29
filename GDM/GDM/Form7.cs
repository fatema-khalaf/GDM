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
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection(@"Data source= LAPTOP-F7F5A9UO\SQLEXPRESS ;Initial catalog= GDM ;Integrated Security= true ;");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        SqlDataAdapter da2;
        DataTable dt2 = new DataTable();
        SqlDataAdapter da3;
        DataTable dt3 = new DataTable();
        public Form7()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com1 = new SqlCommand("select max (cors_id)+1 from course", con);
            SqlDataReader reader = com1.ExecuteReader();
            reader.Read();
            textBox1.Text = reader[0].ToString();
            con.Close();
            //instructor combobox
            dt.Clear();
            da = new SqlDataAdapter("select inst_id, inst_name from instructor", con);
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "inst_id";
            comboBox1.DisplayMember = "inst_name";
            DataBindings.Add("text", dt, "inst_id");
            //subject combobox
            dt3.Clear();
            da3 = new SqlDataAdapter("select sub_id, sub_name from subject", con);
            da3.Fill(dt3);
            comboBox2.DataSource = dt3;
            comboBox2.ValueMember = "sub_id";
            comboBox2.DisplayMember = "sub_name";
            

            dt2.Clear();
            da2 = new SqlDataAdapter("select * from course", con);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand com1 = new SqlCommand("INSERT INTO  [course]([start_date],[end_date],[inst_id],[sub_id])VALUES('" + textBox2.Text + "','" + textBox5.Text + "','" + comboBox1.SelectedValue + "','"+ comboBox2.SelectedValue + "')", con);
            com1.ExecuteNonQuery();

            MessageBox.Show("Added successfully");
            textBox2.Text = "";
            textBox5.Text = "";
            int id;
            id = int.Parse(textBox1.Text);
            id++;
            textBox1.Text = id.ToString();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to close..");
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dt2.Clear();
            da2 = new SqlDataAdapter("select * from course", con);
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cb = new SqlCommandBuilder(da2);
            da2.Update(dt2);
            MessageBox.Show("chainges saved successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to close without saving?");
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
