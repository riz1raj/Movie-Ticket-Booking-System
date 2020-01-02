using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTicketBookingSystem
{
    public partial class AdminHomepage : Form
    {
        public AdminHomepage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddMovies am = new AddMovies();
            am.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAddedMovieDatabase amd = new ViewAddedMovieDatabase();
            amd.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLoginN al = new AdminLoginN();
            al.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookedMoviesDatabase bm = new BookedMoviesDatabase();
            bm.ShowDialog();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerDatabase cd = new CustomerDatabase();
            cd.ShowDialog();
            this.Close();
        }
    }
}
