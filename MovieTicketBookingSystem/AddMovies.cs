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
    public partial class AddMovies : Form
    {
        public AddMovies()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EPGSIS3\\SQLEXPRESS;Initial Catalog=MovieTicketManagementSystem;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        String picLoc1 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                String movieID = textBox1.Text.ToString();
                int imovieID = Int32.Parse(movieID);

                String movieTitle = textBox2.Text.ToString();
                String movieGenre = textBox5.Text.ToString();
                String movieSynopsis = richTextBox1.Text.ToString();

                String movieTime = textBox3.Text.ToString();
                int imovieTime = Int32.Parse(movieTime);

                String movieReleaseDate = dateTimePicker1.Value.ToString();

                byte[] img = null;
                FileStream fstream = new FileStream(picLoc1, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                img = br.ReadBytes((int)fstream.Length);



                con.Open();
                String qry = "insert into dbo.Movie_Information(Movie_ID,Movie_Title,Movie_Genre,Movie_Synopsis,Movie_RunTime,Movie_ReleaseDate,Movie_Image) values('" + imovieID + "','" + movieTitle + "','" + movieGenre + "','" + movieSynopsis + "','" + imovieTime + "','" + movieReleaseDate + "',@img) ";

                SqlCommand sc = new SqlCommand(qry, con);
                sc.Parameters.Add(new SqlParameter("@img", img));
                sc.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Movie Added Successfully!!!!!!");



            }
          catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            dlg.Title = "Select Image";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picLoc1 = dlg.FileName.ToString();
                pictureBox1.ImageLocation = picLoc1;
            }
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
