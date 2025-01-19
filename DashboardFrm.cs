using MySql.Data.MySqlClient;
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
    public partial class DashboardFrm : Form
    {
        MySqlConnection mySqlConnection = new MySqlConnection();
        MySqlCommand mySqlCommand = new MySqlCommand();
        MySqlDataReader mySqlDataReader;
        DataTable myDataTable = new DataTable();
        MySqlDataAdapter data_adapter = new MySqlDataAdapter();
        String SqlQuery;

        string server = "127.0.0.1";
        string username = "root";
        string password = "mysql_admin081105";
        string database = "expensetracker";
        public DashboardFrm()
        {
            InitializeComponent();

            Balance();

            incomeToday();
            incomeYesterday();
            incomeThisMonth();
            incomeThisYear();

            expensesToday();
            expensesYesterday();
            expensesThisMonth();
            expensesThisYear();

            incomeTotal();
            expensesTotal();


     
            Timer timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            timer.Start();

   
            Timer_Tick(null, null);
        }

        private void DashboardFrm_Load(object sender, EventArgs e)
        {

        }

        public void Balance()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                DateTime today = DateTime.Today;
                string incomeQuery = "SELECT SUM(Income) FROM income WHERE DATE(DateIncome) <= @date";
                string expenseQuery = "SELECT SUM(Cost) FROM expenses WHERE DATE(DateExpense) <= @date";

                decimal totalIncome = 0;
                decimal totalExpense = 0;

                using (MySqlCommand cmd = new MySqlCommand(incomeQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@date", today);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalIncome = Convert.ToDecimal(result);
                    }
                }

                using (MySqlCommand cmd = new MySqlCommand(expenseQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@date", today);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        totalExpense = Convert.ToDecimal(result);
                    }
                }

                decimal totalBalance = totalIncome - totalExpense;
                currentBal.Text = totalBalance.ToString("C");
            }
        }

        public void incomeToday()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                DateTime today = DateTime.Today;
                string query = "SELECT SUM(Income) FROM income WHERE DATE(DateIncome) = @dateinc";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@dateinc", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal todayIncome = Convert.ToDecimal(result);
                        this.todayIncome.Text = todayIncome.ToString("C");
                    }
                    else
                    {
                        todayIncome.Text = "₱0.00";
                    }
                }
            }
        }

        public void incomeYesterday()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                string query = "SELECT SUM(Income) FROM income WHERE DATE(DateIncome) = CURDATE() - INTERVAL 1 DAY";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal yesterdayCost = Convert.ToDecimal(result);
                        yesterdayIncome.Text = yesterdayCost.ToString("C");
                    }
                    else
                    {
                        yesterdayIncome.Text = "₱0.00";
                    }
                }
            }
        }

        public void incomeThisMonth()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                DateTime today = DateTime.Now.Date;
                DateTime startMonth = new DateTime(today.Year, today.Month, 1);
                DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);

                string query = "SELECT SUM(Income) FROM income WHERE DateIncome >= @startMonth AND DateIncome <= @endMonth";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@startMonth", startMonth);
                    cmd.Parameters.AddWithValue("@endMonth", endMonth);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal monthCost = Convert.ToDecimal(result);
                        monthIncome.Text = monthCost.ToString("C");
                    }
                    else
                    {
                        monthIncome.Text = "₱0.00";
                    }
                }
            }
        }

        public void incomeThisYear()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                DateTime today = DateTime.Now.Date;
                DateTime startYear = new DateTime(today.Year, 1, 1);
                DateTime endYear = startYear.AddYears(1).AddDays(-1);

                string query = "SELECT SUM(Income) FROM income WHERE DateIncome >= @startYear AND DateIncome <= @endYear";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@startYear", startYear);
                    cmd.Parameters.AddWithValue("@endYear", endYear);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal yearCost = Convert.ToDecimal(result);
                        yearIncome.Text = yearCost.ToString("C");
                    }
                    else
                    {
                        yearIncome.Text = "₱0.00";
                    }
                }
            }
        }

        public void expensesToday()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                DateTime today = DateTime.Today;
                string query = "SELECT SUM(Cost) FROM expenses WHERE DATE(DateExpense) = @dateexp";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@dateexp", today);

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal expensesToday = Convert.ToDecimal(result);
                        this.todayExpenses.Text = expensesToday.ToString("C");
                    }
                    else
                    {
      
                        todayExpenses.Text = "₱0.00";
                    }
                }
            }
        }

        public void expensesYesterday()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                string query = "SELECT SUM(Cost) FROM expenses WHERE DATE(DateExpense) = CURDATE() - INTERVAL 1 DAY";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal yesterdayCost = Convert.ToDecimal(result);
                        yesterdayExpenses.Text = yesterdayCost.ToString("C");
                    }
                    else
                    {
                        yesterdayExpenses.Text = "₱0.00";
                    }
                }
            }
        }

        public void expensesThisMonth()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                DateTime today = DateTime.Now.Date;
                DateTime startMonth = new DateTime(today.Year, today.Month, 1);
                DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);

                string query = "SELECT SUM(Cost) FROM expenses WHERE DateExpense >= @startMonth AND DateExpense <= @endMonth";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@startMonth", startMonth);
                    cmd.Parameters.AddWithValue("@endMonth", endMonth);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal monthCost = Convert.ToDecimal(result);
                        monthExpenses.Text = monthCost.ToString("C");
                    }
                    else
                    {
                        monthExpenses.Text = "₱0.00";
                    }
                }
            }
        }

        public void expensesThisYear()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                DateTime today = DateTime.Now.Date;
                DateTime startYear = new DateTime(today.Year, 1, 1);
                DateTime endYear = startYear.AddYears(1).AddDays(-1);

                string query = "SELECT SUM(Cost) FROM expenses WHERE DateExpense >= @startYear AND DateExpense <= @endYear";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@startYear", startYear);
                    cmd.Parameters.AddWithValue("@endYear", endYear);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal yearCost = Convert.ToDecimal(result);
                        yearExpenses.Text = yearCost.ToString("C");
                    }
                    else
                    {
                        yearExpenses.Text = "₱0.00";
                    }
                }
            }
        }

        public void incomeTotal()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                string query = "SELECT SUM(Income) FROM income";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal incomeTotal = Convert.ToDecimal(result);
                        totalIncome.Text = incomeTotal.ToString("C");
                    }
                    else
                    {
                        totalIncome.Text = "₱0.00";
                    }
                }
            }
        }

        public void expensesTotal()
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                string query = "SELECT SUM(Cost) FROM expenses";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        decimal expensesTotal = Convert.ToDecimal(result);
                        totalExpenses.Text = expensesTotal.ToString("C");
                    }
                    else
                    {
                        totalExpenses.Text = "₱0.00";
                    }
                }
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OverviewFrm_Load(object sender, EventArgs e)
        {
        
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
     
            DTText.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void DTText_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void todayExpenses_Click(object sender, EventArgs e)
        {

        }

        private void monthIncome_Click(object sender, EventArgs e)
        {

        }
    }
}
