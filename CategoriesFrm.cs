using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ExpenseTracker
{

    public partial class CategoriesFrm : UserControl
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
      

        public CategoriesFrm()
        {
            InitializeComponent();
            LoadData();
        }

     
        public void LoadData()
        {
            CategoryData cData = new CategoryData(server, username, password, database);
            List<CategoryData> listData = cData.GetCategoryData(server, username, password, database);

            guna2DataGridView1.DataSource = listData;

        }

        private void CategoriesFrm_Load(object sender, EventArgs e)
        {
   
            guna2DataGridView1.Refresh();
        }
        public void displayCategoryList()
        {
            CategoriesFrm categoriesFrm = new CategoriesFrm();

        }



        private void Category_Add_Click(object sender, EventArgs e)
        {
            if (CategoryText.Text == "" || TypeCB.SelectedIndex == -1 || StatusCB.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the blank fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
                    {
                        connection.Open();
                        {


                            string insertData = "INSERT INTO categories (Category, Type, Status, DateInserted) " +
                                                "VALUES(@category, @type, @status, @date)";

                            using (MySqlCommand cmd = new MySqlCommand(insertData, connection))
                            {
                                cmd.Parameters.AddWithValue("@category", CategoryText.Text.Trim());
                                cmd.Parameters.AddWithValue("@type", TypeCB.SelectedItem);
                                cmd.Parameters.AddWithValue("@status", StatusCB.SelectedItem);

                                DateTime now = DateTime.Now;
                                cmd.Parameters.AddWithValue("@date", now);

                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    mySqlConnection.Close();
                }
                LoadData();
            }
        }

        private int getID = 0;


        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                getID = Convert.ToInt32(row.Cells[0].Value);
                CategoryText.Text = row.Cells[1].Value.ToString();
                TypeCB.SelectedItem = row.Cells[2].Value.ToString();
                StatusCB.SelectedItem = row.Cells[3].Value.ToString();
            }
        }

        private void Category_Update_Click(object sender, EventArgs e)
        {
            if (CategoryText.Text == "" || TypeCB.SelectedItem.ToString() == "" || StatusCB.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item first.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to UPDATE this category with an ID: " + getID + "?", "Confirmation Message",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
                    {
                        connection.Open();

                        string updateData = "UPDATE categories SET Category = @category, Type = @type, Status = @status, DateInserted = @date WHERE ID = @id";

                        using (MySqlCommand cmd = new MySqlCommand(updateData, connection))
                        {
                            cmd.Parameters.AddWithValue("@category", CategoryText.Text.Trim());
                            cmd.Parameters.AddWithValue("@type", TypeCB.SelectedItem);
                            cmd.Parameters.AddWithValue("@status", StatusCB.SelectedItem);

                            DateTime now = DateTime.Now;
                            cmd.Parameters.AddWithValue("@date", now);

                      
                            cmd.Parameters.AddWithValue("@id", getID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("No records were updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ClearFields();
                            }
                        }
                        LoadData();
                        connection.Close();
                    }
                }
            }

        }

        private void Category_Delete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection("server=" + server + ";user id=" + username + ";password=" + password + ";database=" + database))
            {
                connection.Open();



                if (CategoryText.Text == "" || TypeCB.SelectedItem.ToString() == "" || StatusCB.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an item first.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to DELETE this category with an ID: " + getID + "?", "Confirmation Message",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string deleteData = "DELETE FROM categories WHERE ID = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteData, connection))
                        {

                      
                            cmd.Parameters.AddWithValue("@id", getID);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
                                guna2DataGridView1.Refresh();

               
                                LoadData();

                  
                                ResetAutoIncrement(connection);
                                ClearFields();
                            }
                            else
                            {
                                MessageBox.Show("No records were deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ClearFields();
                            }

                        }
                    }
                }
            }
        }

        private void ResetAutoIncrement(MySqlConnection connection)
        {
            string resetAutoIncrementQuery = "ALTER TABLE categories AUTO_INCREMENT = 1";

            using (MySqlCommand cmd = new MySqlCommand(resetAutoIncrementQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void ClearFields()
        {
            CategoryText.Clear();
            TypeCB.SelectedIndex = -1;
            StatusCB.SelectedIndex = -1;
        }

        private void Category_Clear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }

    }
