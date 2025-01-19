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

namespace ExpenseTracker
{
    public partial class IncomeFrm : Form
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

        public IncomeFrm()
        {
            InitializeComponent();
            displayIncomeData();
            displayCategoryList();
        }

   
        public void displayIncomeData()
        {
            IncomeData iData = new IncomeData(server, username, password, database);
            List<IncomeData> incomeData = iData.GetIncomeData(server, username, password, database);

            guna2DataGridView1.DataSource = incomeData;
        }

        public void displayCategoryList()
        {

            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();

                string SelectData = "SELECT Category FROM categories WHERE type = @Type AND status = @Status"; // Removed "AND amount = @Amount" assuming you don't need it for now

                using (MySqlCommand cmd = new MySqlCommand(SelectData, connection))
                {
                    cmd.Parameters.AddWithValue("@Type", "Income"); // Assuming "Income" is the correct value for filtering
                    cmd.Parameters.AddWithValue("@Status", "Active");
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string categoryName = reader["Category"].ToString();
                        IncomeCatCB.Items.Add(categoryName);
                    }
                }
            }
        }

        private void IncomeFrm_Load(object sender, EventArgs e)
        {
            displayIncomeData();
            DTDate.Value = DateTime.Today;
          //  DTDate.MaxDate = DateTime.Today;

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void IncomeAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (IncomeCatCB.SelectedIndex == -1 || IncomeItemTxt.Text == "" || IncomeText.Text == "")
                {
                    MessageBox.Show("Fill all the blank fields!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
                    {
                        connection.Open();

                        string InsertData = "INSERT INTO income (Category, Item, Income, Description, DateIncome, DateInserted) " +
                            "VALUES(@cat, @item, @income, @desc, @dateinc, @datein)";

                        using (MySqlCommand cmd = new MySqlCommand(InsertData, connection))
                        {
                            cmd.Parameters.AddWithValue("@cat", IncomeCatCB.SelectedItem);
                            cmd.Parameters.AddWithValue("@item", IncomeItemTxt.Text);

                            // Convert the income input to a decimal value
                            decimal income;
                            if (!decimal.TryParse(IncomeText.Text, out income))
                            {
                                MessageBox.Show("Invalid income amount! Please enter a valid number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return; // Exit the process if the input is not a valid number
                            }
                            cmd.Parameters.AddWithValue("@income", income);

                            cmd.Parameters.AddWithValue("@desc", IncomeDescTxt.Text);
                            cmd.Parameters.AddWithValue("@dateinc", DTDate.Value);

                            DateTime today = DateTime.Now;
                            cmd.Parameters.AddWithValue("@datein", today);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Added Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        displayIncomeData();
                        clearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IncomeUpdBtn_Click(object sender, EventArgs e)
        {
            if (IncomeCatCB.SelectedIndex == -1 || IncomeItemTxt.Text == "" || IncomeText.Text == "")
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
                        // convert the input to a decimal value
                        decimal income;
                        if (!decimal.TryParse(IncomeText.Text, out income))
                        {
                            MessageBox.Show("Invalid income amount! Please enter a valid number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Exit the process if the input is not a valid number
                        }

                        using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
                        {
                            connection.Open();

                            string updateData = "UPDATE income SET Category = @cat, Item = @item, " +
                            "Income = @income, Description = @desc, DateIncome = @dateinc, DateInserted = @datein WHERE ID = @id";

                            using (MySqlCommand cmd = new MySqlCommand(updateData, connection))
                            {
                                cmd.Parameters.AddWithValue("@cat", IncomeCatCB.SelectedItem);
                                cmd.Parameters.AddWithValue("@item", IncomeItemTxt.Text);
                                cmd.Parameters.AddWithValue("@income", income); // Use the converted income value
                                cmd.Parameters.AddWithValue("@desc", IncomeDescTxt.Text);
                                cmd.Parameters.AddWithValue("@dateinc", DTDate.Value);
                                cmd.Parameters.AddWithValue("@id", getID);

                                DateTime today = DateTime.Now;
                                cmd.Parameters.AddWithValue("@datein", today);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Updated Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        displayIncomeData();
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


        }

        private void IncomeClrBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        public void clearFields()
        {
            IncomeCatCB.SelectedIndex = -1;
            IncomeItemTxt.Text = "";
            IncomeText.Text = "";
            IncomeDescTxt.Text = "";

        }

        private void IncomeDelBtn_Click(object sender, EventArgs e)
        {
            if (IncomeCatCB.SelectedIndex == -1 || IncomeItemTxt.Text == "" || IncomeText.Text == "")
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

                        string DeleteData = "DELETE FROM income WHERE id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(DeleteData, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", getID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Deleted Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Reset auto-increment 
                        ResetAutoIncrement(connection);

                        connection.Close();
                    }
                    displayIncomeData();
                    clearFields();
                }
            }
        }

        private void ResetAutoIncrement(MySqlConnection connection)
        {
            string resetAutoIncrementQuery = "ALTER TABLE income AUTO_INCREMENT = 1";

            using (MySqlCommand cmd = new MySqlCommand(resetAutoIncrementQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void guna2DataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
                getID = (int)row.Cells[0].Value;
                IncomeCatCB.SelectedItem = row.Cells[1].Value.ToString();
                IncomeItemTxt.Text = row.Cells[2].Value.ToString();
                IncomeText.Text = row.Cells[3].Value.ToString();
                IncomeDescTxt.Text = row.Cells[4].Value.ToString();
                DTDate.Value = DateTime.ParseExact(row.Cells[5].Value.ToString(), "MM-dd-yyyy", CultureInfo.InvariantCulture);



            }
        }
    }
}

