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
    public partial class AdminLoginN : Form
    {
        public AdminLoginN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String username = tbUsername.Text.ToString();
            String password = tbPassword.Text.ToString();
            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Login is Successful!!!");
                this.Hide();
                AdminHomepage hp = new AdminHomepage();
                hp.ShowDialog();

            }
            else
            {
                MessageBox.Show("Wrong Password...Check Again!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectUserPage su = new SelectUserPage();
            su.ShowDialog();
            this.Close();
        }
    }
}
