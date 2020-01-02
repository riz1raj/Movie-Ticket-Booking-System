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
    public partial class SelectUserPage : Form
    {
        public SelectUserPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLoginN al = new AdminLoginN();

            al.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerWelcomePage w = new CustomerWelcomePage();
            w.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminLoginN al = new AdminLoginN();
            al.ShowDialog();
            this.Close();
        }
    }
}
