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

namespace MidLabExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool flag = true;
        DateTime d;
        private void Form1_Load(object sender, EventArgs e)
        {
           d = dateTimePicker1.Value;
            flag = true;
        }
        private void button1_Click(object sender, EventArgs e)          //Add task 
        {
            

            DateTime dt = DateTime.Now;
            if (flag == true)
            {
                if (dateTimePicker1.Value.Year - dt.Year < 0)         //if user entered year from past
                {
                    MessageBox.Show("Please recheck year you picked!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dateTimePicker1.Value.Year - dt.Year == 0)         //if user entered month from past
                {
                    if (dateTimePicker1.Value.Month - dt.Month < 0)
                        MessageBox.Show("Please recheck month you picked!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    flag = false;
                }
            }
             

            if (textBox1.Text == "" || textBox2.Text == ""|| (radioButton1.Checked == false && radioButton2.Checked == false) || (radioButton3.Checked == false && radioButton4.Checked == false))
            {
                MessageBox.Show("Please enter missing fields");
                flag = false;
            }
            
            else
            {

                String TaskType = "";
                String TaskLevel = "";
                String TaskTitle = textBox1.Text;
                String TaskDescription = textBox2.Text;
                if (radioButton1.Checked == true)
                {
                    TaskType = radioButton1.Text;
                }
                else
                {
                    TaskType = radioButton2.Text;
                }
                DateTime TaskDeadline = dateTimePicker1.Value;
                if (radioButton3.Checked == true)
                {
                    TaskLevel = radioButton3.Text;
                }
                else
                {
                    TaskLevel = radioButton4.Text;
                }


                String connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mootu & Patlu\source\repos\MidLabExam\MidLabExam\todo.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);

                String query = "INSERT INTO task(TaskTitle,TaskDescription,TaskType,TaskDeadline,TaskLevel) VALUES('" + TaskTitle + "','" + TaskDescription + "','" + TaskType + "','" + TaskDeadline + "','" + TaskLevel + "')";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Task added successfully");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    dateTimePicker1.Value = d;

                }
                else
                {
                    MessageBox.Show("Task not added");
                }
                con.Close();
            }


        }

        private void button2_Click(object sender, EventArgs e)                  //Show all tasks
        {
                String connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mootu & Patlu\source\repos\MidLabExam\MidLabExam\todo.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);

                String query = "select * from task";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                con.Close();

                dataGridView1.DataSource = dt;

                if (dataGridView1.Rows.Count == 1)
                 {
                    MessageBox.Show("Please firstly enter some data to show", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


        }

        private void button3_Click(object sender, EventArgs e)                 //Show university tasks
        {
            String task= "University Task";
             String connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mootu & Patlu\source\repos\MidLabExam\MidLabExam\todo.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);

            String query = "select * from task where TaskType='"+ task+"'";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            con.Close();

            dataGridView1.DataSource = dt;

            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("No university tasks!!!!","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }


        }

        private void button4_Click(object sender, EventArgs e)                 //Show home tasks
        {
            String task = "Home Task";
            String connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mootu & Patlu\source\repos\MidLabExam\MidLabExam\todo.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);

            String query = "select * from task where TaskType='" + task + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            con.Close();

            dataGridView1.DataSource = dt;

            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("No home tasks!!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)                 //Show important tasks
        {
            String task = "Important";
            String connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mootu & Patlu\source\repos\MidLabExam\MidLabExam\todo.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);

            String query = "select * from task where TaskLevel='" + task + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            con.Close();

            dataGridView1.DataSource = dt;
            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("No Important tasks!!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button6_Click(object sender, EventArgs e)                 //Show Normal tasks
        {
            String task = "Normal";
            String connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mootu & Patlu\source\repos\MidLabExam\MidLabExam\todo.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);

            String query = "select * from task where TaskLevel='" + task + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            con.Close();

            dataGridView1.DataSource = dt;

            if (dataGridView1.Rows.Count == 1)
            {
                MessageBox.Show("No normal tasks!!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)                 //Delete specific task
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter ID to delete data");
            }
            else
            {
                String connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mootu & Patlu\source\repos\MidLabExam\MidLabExam\todo.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);

                String query = "DELETE from task where TaskID=" + textBox3.Text;
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    label11.Text = "Task deleted successfully";
                }
                else
                {
                    label11.Text = "No data to be deleted with this ID";
                }

                con.Close();
            }
            
        }

    }
}
