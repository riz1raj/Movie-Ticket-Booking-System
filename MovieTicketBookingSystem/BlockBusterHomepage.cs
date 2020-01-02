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
using System.IO;

namespace MovieTicketBookingSystem
{
    public partial class BlockBusterHomepage : Form
    {
        public static string user;
        public static string movie;
        public BlockBusterHomepage()
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
            string qry = "Select * from dbo.Movie_Information where Movie_Title='" + comboBox1.Text + "';";
            SqlCommand sc = new SqlCommand(qry, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = sc.ExecuteReader();

                while (myreader.Read())
                {
                    String movieTitle = myreader.GetString(1);
                    String movieGenre = myreader.GetString(2);
                    String movieSynopsis = myreader.GetString(3);
                    String movieTime = myreader.GetInt32(4).ToString();

                    label7.Text = movieTitle;
                    label5.Text = movieGenre;
                    richTextBox1.Text = movieSynopsis;
                    label6.Text = movieTime;

                    if (myreader.HasRows)
                    {
                        comboBox1.Text = myreader[1].ToString();
                        byte[] img = ((byte[])myreader[6]);

                        if (img == null)
                        {
                            pictureBox1.Image = null;

                        }

                        else
                        {
                            MemoryStream mystream = new MemoryStream(img);
                            pictureBox1.Image = Image.FromStream(mystream);
                        }
                    }
                    else {
                        MessageBox.Show("Data is not avaliable");
                    }

                }
                con.Close();
            }





            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerLogin cl = new CustomerLogin();
            cl.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            user = label8.Text;
            movie = comboBox1.Text;
            BookMovie bm = new BookMovie();
            bm.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BlockBusterHomepage_Load(object sender, EventArgs e)
        {
            label8.Text = CustomerLogin.username;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
