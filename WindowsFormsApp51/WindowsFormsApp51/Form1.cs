using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp51
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\WindowsFormsApp51\WindowsFormsApp51\db.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string name = textBox1.Text;
                string fami = textBox2.Text;
                string age1 = textBox3.Text;
                string mobi = textBox4.Text;
                string query = "";
                if (button1.Text == "ثبت")
                    query = $"INSERT INTO students (name,family,age,mobile) VALUES " +
                        $"('{name}','{fami}','{age1}','{mobi}')";
                else
                {
                    string id = comboBox1.SelectedItem.ToString().Split(':')[0];
                    query = $"UPDATE students SET name='{name}'," +
                        $"family='{fami}',age='{age1}',mobile='{mobi}' WHERE id='{id}'";
                }
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                int i = sqlCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Successful");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                }
                sqlConnection.Close();
                ShowList();
                button1.Text = "ثبت";
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowList();
        }
        void ShowList()
        {
            try
            {
                comboBox1.Items.Clear();
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\WindowsFormsApp51\WindowsFormsApp51\db.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string query = "SELECT * FROM Students";
                SqlCommand sql = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["id"] + ":" + reader["name"] + " " + reader["family"]);
                }

                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                sqlConnection.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\WindowsFormsApp51\WindowsFormsApp51\db.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string id = comboBox1.SelectedItem.ToString().Split(':')[0];
                string query = $"DELETE FROM students WHERE id='{id}'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                int i = sqlCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Successful");
                }
                sqlConnection.Close();
                ShowList();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gheir\source\repos\WindowsFormsApp51\WindowsFormsApp51\db.mdf;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string id = comboBox1.SelectedItem.ToString().Split(':')[0];

                string query = "SELECT * FROM Students WHERE id='" + id + "'";
                SqlCommand sql = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["name"].ToString();
                    textBox2.Text = reader["family"].ToString();
                    textBox3.Text = reader["age"].ToString();
                    textBox4.Text = reader["mobile"].ToString();
                    
                }

                sqlConnection.Close();
                button1.Text = "ویرایش";
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
    }
}
