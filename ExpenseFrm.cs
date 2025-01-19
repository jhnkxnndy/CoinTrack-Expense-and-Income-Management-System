using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExpenseTracker
{
    public partial class ExpenseFrm : Form
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
        public ExpenseFrm()
        {
            InitializeComponent();
            displayExpenseData();
            displayCategoryList();
        }

        public void displayExpenseData()
        {
            ExpenseData eData = new ExpenseData(server, username, password, database);
            List<ExpenseData> expenseData = eData.GetExpenseData(server, username, password, database);

            guna2DataGridView1.DataSource = expenseData;
        }

        public void displayCategoryList()
        {

            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                string SelectData = "SELECT Category FROM categories WHERE type = @Type AND status = @Status"; 

                using (MySqlCommand cmd = new MySqlCommand(SelectData, connection))
                {
                    cmd.Parameters.AddWithValue("@Type", "Expenses"); 
                    cmd.Parameters.AddWithValue("@Status", "Active");
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string categoryName = reader["Category"].ToString();
                        ExpenseCatCB.Items.Add(categoryName);
                    }
                }
            }
        }

        private void ExpenseFrm_Load(object sender, EventArgs e)
        {
            DTDate.Value = DateTime.Today;
     
        }

        private void ExpenseAddBtn_Click(object sender, EventArgs e)
        {
            if (ExpenseCatCB.SelectedIndex == -1 || ExpenseItem.Text == "" || ExpenseCost.Text == "")
            {
                MessageBox.Show("Fill all the blank fields!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
           
                    decimal cost;
                    if (!decimal.TryParse(ExpenseCost.Text, out cost))
                    {
                        MessageBox.Show("Invalid cost amount! Please enter a valid number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; 
                    }

                    using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
                    {
                        connection.Open();

                        string InsertData = "INSERT INTO expenses (Category, Item, Cost, Description, DateExpense, DateInserted) " +
                            "VALUES(@cat, @item, @cost, @desc, @dateexp, @datein)";

                        using (MySqlCommand cmd = new MySqlCommand(InsertData, connection))
                        {
                            cmd.Parameters.AddWithValue("@cat", ExpenseCatCB.SelectedItem);
                            cmd.Parameters.AddWithValue("@item", ExpenseItem.Text);
                            cmd.Parameters.AddWithValue("@cost", cost); 
                            cmd.Parameters.AddWithValue("@desc", ExpenseDesc.Text);
                            cmd.Parameters.AddWithValue("@dateexp", DTDate.Value);

                            DateTime today = DateTime.Now;
                            cmd.Parameters.AddWithValue("@datein", today);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Added Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    displayExpenseData();
                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void clearFields()
        {
            ExpenseCatCB.SelectedIndex = -1;
            ExpenseItem.Text = "";
            ExpenseCost.Text = "";
            ExpenseDesc.Text = "";

        }

        private void ExpenseClrBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void ExpenseUpdBtn_Click(object sender, EventArgs e)
        {
            if (ExpenseCatCB.SelectedIndex == -1 || ExpenseItem.Text == "" || ExpenseCost.Text == "")
            {
                MessageBox.Show("Fill all the blank fields!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to UPDATE this category with an ID: " + getID + "?", "Confirmation Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                     
                        decimal cost;
                        if (!decimal.TryParse(ExpenseCost.Text, out cost))
                        {
                            MessageBox.Show("Invalid cost amount! Please enter a valid number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; 
                        }

                        using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
                        {
                            connection.Open();

                            string updateData = "UPDATE expensetracker.expenses SET Category = @cat, Item = @item, Cost = @cost, Description = @desc, DateExpense = @dateexp, DateInserted = @datein WHERE ID = @id;";

                            using (MySqlCommand cmd = new MySqlCommand(updateData, connection))
                            {
                                cmd.Parameters.AddWithValue("@cat", ExpenseCatCB.Text.Trim());
                                cmd.Parameters.AddWithValue("@item", ExpenseItem.Text.Trim());
                                cmd.Parameters.AddWithValue("@desc", ExpenseDesc.Text.Trim());
                                cmd.Parameters.AddWithValue("@dateexp", DTDate.Value);
                                cmd.Parameters.AddWithValue("@id", getID);

                  
                                cmd.Parameters.AddWithValue("@cost", cost);

                                DateTime now = DateTime.Now;
                                cmd.Parameters.AddWithValue("@datein", now);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearFields();
                                }
                                else
                                {
                                    MessageBox.Show("No records were updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    clearFields();
                                }
                            }
                            displayExpenseData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private int getID = 0;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                getID = (int)row.Cells[0].Value;
                ExpenseCatCB.SelectedItem = row.Cells[1].Value.ToString();
                ExpenseItem.Text = row.Cells[2].Value.ToString();
                ExpenseCost.Text = row.Cells[3].Value.ToString();
                ExpenseDesc.Text = row.Cells[4].Value.ToString();
                DTDate.Value = DateTime.ParseExact(row.Cells[5].Value.ToString(), "MM-dd-yyyy", CultureInfo.InvariantCulture);

            }
        }

        private void ExpenseDltBtn_Click(object sender, EventArgs e)
        {
            if (ExpenseCatCB.SelectedIndex == -1 || ExpenseItem.Text == "" || ExpenseCost.Text == "")
            {
                MessageBox.Show("Fill all the blank fields!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to DELETE this category with an ID: " + getID + "?", "Confirmation Message",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
                    {
                        connection.Open();

                        string DeleteData = "DELETE FROM expenses WHERE id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(DeleteData, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deleted Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        
                        ResetAutoIncrement(connection);

                        connection.Close();
                    }
                    displayExpenseData();
                    clearFields();
                }
            }
        }
        private void ResetAutoIncrement(MySqlConnection connection)
        {
            string resetAutoIncrementQuery = "ALTER TABLE expenses AUTO_INCREMENT = 1";

            using (MySqlCommand cmd = new MySqlCommand(resetAutoIncrementQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
