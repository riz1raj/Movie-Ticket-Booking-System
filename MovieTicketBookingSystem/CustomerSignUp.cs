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
    public partial class CustomerSignUp : Form
    {
        public CustomerSignUp()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EPGSIS3\\SQLEXPRESS;Initial Catalog=MovieTicketManagementSystem;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String gender = "";
                if (radioButton1.Checked)
                {
                    gender = radioButton1.Text.ToString();
                }
                else if (radioButton2.Checked)
                {
                    gender = radioButton2.Text.ToString();
                }
                String qry = "insert into dbo.Customer_SignUp(ID,FullName,UserName,Password,MobileNo,Gender,EmailAdress,Nationality)  values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + gender + "','" + textBox6.Text + "','" + textBox7.Text + "')";

                SqlCommand sc = new SqlCommand(qry, con);
                sc.ExecuteNonQuery();

                MessageBox.Show("Succesfully Signed Up,Please Login to Continue");
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerLogin c = new CustomerLogin();
            c.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerWelcomePage cw = new CustomerWelcomePage();
            cw.ShowDialog();
            this.Close();
        }
    }
}
