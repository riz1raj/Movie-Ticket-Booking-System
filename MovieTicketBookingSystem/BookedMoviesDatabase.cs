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
    public partial class BookedMoviesDatabase : Form
    {
        public BookedMoviesDatabase()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EPGSIS3\\SQLEXPRESS;Initial Catalog=MovieTicketManagementSystem;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String qry = "Select * from dbo.Movie_Book";
            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String qry = "select * from dbo.Movie_Book where BookID like '%" + textBox1.Text.ToString() + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 10, 10);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHomepage ah = new AdminHomepage();
            ah.ShowDialog();
            this.Close();
        }
    }
}
