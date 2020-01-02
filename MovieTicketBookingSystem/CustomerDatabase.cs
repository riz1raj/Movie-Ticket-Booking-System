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

namespace MovieTicketBookingSystem
{
    public partial class CustomerDatabase : Form
    {
        public CustomerDatabase()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EPGSIS3\\SQLEXPRESS;Initial Catalog=MovieTicketManagementSystem;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String qry = "Select * from dbo.Customer_SignUp";
            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String qry = "update dbo.Customer_SignUp set FullName='" + textBox1.Text + "',EmailAdress='" + textBox2.Text + "',MobileNo='" + textBox3.Text + "' where FullName='" + textBox1.Text + "'";
            SqlCommand sc = new SqlCommand(qry, con);
            sc.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHomepage ah = new AdminHomepage();
            ah.ShowDialog();
            this.Close();
        }
    }
}
