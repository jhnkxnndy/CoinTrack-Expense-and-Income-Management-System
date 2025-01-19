using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace ExpenseTracker
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainSI_Click_1(object sender, EventArgs e)
        {
            FrmSignIn signIn = new FrmSignIn();
            signIn.Show();
            signIn.BringToFront();
            this.Hide();
        }

        private void MainSU_Click_1(object sender, EventArgs e)
        {
            FrmSignUp signUp = new FrmSignUp();
            signUp.Show();
            signUp.BringToFront();
            this.Hide();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
