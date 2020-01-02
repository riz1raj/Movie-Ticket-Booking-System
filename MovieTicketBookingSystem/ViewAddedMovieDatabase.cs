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
    public partial class ViewAddedMovieDatabase : Form
    {
        public ViewAddedMovieDatabase()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EPGSIS3\\SQLEXPRESS;Initial Catalog=MovieTicketManagementSystem;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String qry = "Select * from dbo.Movie_Information";
            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                con.Open();
                String qry = "update dbo.Movie_Information set Movie_ReleaseDate='" + dateTimePicker1.Value + "' where Movie_ID='" + textBox1.Text + "'";
                SqlCommand sc = new SqlCommand(qry, con);
                sc.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHomepage ah = new AdminHomepage();
            ah.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            String qry = "Delete from Movie_Information where Movie_ID='" + textBox1.Text + "'";
            SqlCommand sc = new SqlCommand(qry, con);
            sc.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfully");
        }
    }
}
