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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data source= LAPTOP-F7F5A9UO\SQLEXPRESS ;Initial catalog= GDM ;Integrated Security= true ;");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        SqlDataAdapter da0;
        DataTable dt0 = new DataTable();
        SqlDataAdapter da1;
        DataTable dt1 = new DataTable();
        SqlDataAdapter da2;
        DataTable dt2 = new DataTable();
        SqlDataAdapter da3;
        DataTable dt3 = new DataTable();
        SqlDataAdapter da4;
        DataTable dt4 = new DataTable();
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            da = new SqlDataAdapter("select emp_name,emp_salary,dep_name from employee , department where employee.dep_id = department.dep_id",con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt0.Clear();
            da0 = new SqlDataAdapter("select student.stud_id , stud_name, course.cors_id, sub_name, state, project_grade from student, subject, course, enroll where student.stud_id=enroll.stud_id and course.cors_id=enroll.cors_id and course.sub_id=subject.sub_id and student.stud_id= '"+ textBox1.Text +"'", con);
            da0.Fill(dt0);
            dataGridView2.DataSource = dt0;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dt1.Clear();
            da1 = new SqlDataAdapter("select cors_id , start_date, end_date, inst_name, sub_name from course, instructor, subject where course.inst_id = instructor.inst_id and course.sub_id = subject.sub_id ", con);
            da1.Fill(dt1);
            dataGridView3.DataSource = dt1;
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void splitContainer4_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer5_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dt3.Clear();
            da3 = new SqlDataAdapter("select cors_id, cors_days, cors_hour, cors_room from course_timing where cors_id ='" + textBox3.Text + "' ", con);
            da3.Fill(dt3);
            dataGridView5.DataSource = dt3;
        }

        private void splitContainer5_SplitterMoved_1(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dt3.Clear();
            da3 = new SqlDataAdapter("select cors_id, cors_days, cors_hour, cors_room from course_timing", con);
            da3.Fill(dt3);
            dataGridView5.DataSource = dt3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dt2.Clear();
            da2 = new SqlDataAdapter("select cors_id, count (stud_id) as 'number of students' from enroll group by cors_id ", con);
            da2.Fill(dt2);
            dataGridView4.DataSource = dt2;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            dt2.Clear();
            da2 = new SqlDataAdapter("select cors_id, count (stud_id) as 'number of students' from enroll where cors_id = '" + textBox2.Text + "' group by cors_id ", con);
            da2.Fill(dt2);
            dataGridView4.DataSource = dt2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dt0.Clear();
            da0 = new SqlDataAdapter("select student.stud_id , stud_name, course.cors_id, sub_name, state, project_grade from student, subject, course, enroll where student.stud_id=enroll.stud_id and course.cors_id=enroll.cors_id and course.sub_id=subject.sub_id ", con);
            da0.Fill(dt0);
            dataGridView2.DataSource = dt0;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dt4.Clear();
            da4 = new SqlDataAdapter("SELECT SUM (inst_salary) as instructor_salaries, sum( emp_salary) as employees_salaries FROM instructor, employee", con);
            da4.Fill(dt4);
            dataGridView6.DataSource = dt4;
        }

        private void splitContainer6_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
