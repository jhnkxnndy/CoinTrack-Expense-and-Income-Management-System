using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class MainInterface : Form
    {
     
        private void SomeMethod()
        {
            string username = FrmSignIn.ClassSignIn.LoggedInUsername;
            // Do something with username
        }
        public MainInterface()
        {
            InitializeComponent();
          
        }


        private void dashColor()
        {
            OverviewBtn.FillColor = Color.Gainsboro;
            IncomeBtn.FillColor = Color.FromArgb(179, 200, 207);
            IncomeExp.FillColor = Color.FromArgb(179, 200, 207);
            CategoryBtn.FillColor = Color.FromArgb(179, 200, 207);
        }

        private void incomebtnColor()
        {
            OverviewBtn.FillColor = Color.FromArgb(179, 200, 207);
            IncomeBtn.FillColor = Color.Gainsboro;
            IncomeExp.FillColor = Color.FromArgb(179, 200, 207);
            CategoryBtn.FillColor = Color.FromArgb(179, 200, 207);
        }

        private void incomeExpColor()
        {
            OverviewBtn.FillColor = Color.FromArgb(179, 200, 207);
            IncomeBtn.FillColor = Color.FromArgb(179, 200, 207);
            IncomeExp.FillColor = Color.Gainsboro;
            CategoryBtn.FillColor = Color.FromArgb(179, 200, 207);
        }

        private void categoryBtn()
        {
            OverviewBtn.FillColor = Color.FromArgb(179, 200, 207);
            IncomeBtn.FillColor = Color.FromArgb(179, 200, 207);
            IncomeExp.FillColor = Color.FromArgb(179, 200, 207);
            CategoryBtn.FillColor = Color.Gainsboro;
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CategoryBtn_Click(object sender, EventArgs e)
        {
            CategoriesFrm categoriesFrm = new CategoriesFrm();
            guna2Panel3.Controls.Add(categoriesFrm);
            categoriesFrm.Show();
            categoriesFrm.BringToFront();
            categoryBtn();
        }

        private void IncomeBtn_Click(object sender, EventArgs e)
        {
            IncomeFrm incomeFrm = new IncomeFrm();
            incomeFrm.TopLevel = false;
            guna2Panel3.Controls.Add(incomeFrm);
            incomeFrm.Show();
            incomeFrm.BringToFront();
            incomebtnColor();
        }

        private void IncomeExp_Click(object sender, EventArgs e)
        {
            ExpenseFrm expenseFrm = new ExpenseFrm();
            expenseFrm.TopLevel = false;
            guna2Panel3.Controls.Add(expenseFrm);
            expenseFrm.Show();
            expenseFrm.BringToFront();

            incomeExpColor();
        }

        private void MainInterface_Load(object sender, EventArgs e)
        {
            UsernameLbl.Text = FrmSignIn.ClassSignIn.LoggedInUsername;
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OverviewBtn_Click(object sender, EventArgs e)
        {
            DashboardFrm dashboardFrm = new DashboardFrm();
            dashboardFrm.TopLevel = false;
            guna2Panel3.Controls.Add(dashboardFrm);
            dashboardFrm.Show();
            dashboardFrm.BringToFront();
            dashColor();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to LOGOUT, " + UsernameLbl.Text + "?", "Confirmation Message",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
