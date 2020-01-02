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
    public partial class BookMovie : Form
    {
        public BookMovie()
        {
            InitializeComponent();
            fillcombobox();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EPGSIS3\\SQLEXPRESS;Initial Catalog=MovieTicketManagementSystem;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public void fillcombobox()
        {
            string qry = "Select * from dbo.Movie_Information";
            SqlCommand sc = new SqlCommand(qry, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = sc.ExecuteReader();
                while (myreader.Read())
                {
                    String Movie_Title = myreader.GetString(1);
                    comboBox1.Items.Add(Movie_Title);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double p1 = 0;


            if (comboBox2.SelectedIndex == 0)
            {
                if (comboBox3.SelectedIndex == 0)
                {
                    p1 += 300;
                }
                if (comboBox3.SelectedIndex == 1)
                {
                    p1 += 350;
                }
            }
            if (comboBox2.SelectedIndex == 1)
            {
                if (comboBox3.SelectedIndex == 0)
                {
                    p1 += 350;
                }
                if (comboBox3.SelectedIndex == 1)
                {
                    p1 += 400;
                }

            }
            double totaltopay = Convert.ToDouble(textBox2.Text) * p1;
            textBox3.Text = totaltopay.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            String qry = "insert into dbo.Movie_Book(BookID,UserName,Movie_Title,TotalCustomer,SelectQuality,SelectSit,ShowTime,PriceToPay) values('" + textBox1.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + textBox3.Text + "')";
            SqlCommand sc = new SqlCommand(qry, con);
            
            sc.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Booking Completed Successfully !!!!!!");
        }

        private void BookMovie_Load(object sender, EventArgs e)
        {
            textBox4.Text = BlockBusterHomepage.user;
            comboBox1.Text = BlockBusterHomepage.movie;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            BlockBusterHomepage bh = new BlockBusterHomepage();
            bh.ShowDialog();
            this.Close();
        }
    }
}
