using Guna.UI2.WinForms.Enums;
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

    public partial class FrmSignUp : Form
    {
        private MySqlConnection connection;
        private DataTable sqlDt;

        public FrmSignUp()
        {
            InitializeComponent();
            InitializeDatabase();

        }
        private void InitializeDatabase()
        {
            string server = "127.0.0.1";
            string username = "root";
            string password = "mysql_admin081105";
            string database = "expensetracker";

            string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            connection = new MySqlConnection(connectionString);
            sqlDt = new DataTable();
        }

        public bool checkConnection()
        {
            return (connection.State == ConnectionState.Closed) ? true : false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSignIn signIn = new FrmSignIn();
            signIn.Show();
            signIn.BringToFront();

            this.Hide();
        }

        private void FrmSignUp_Load(object sender, EventArgs e)
        {
            

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            SUPassword.PasswordChar = guna2CheckBox1.Checked ? '\0' : '*';
        }

        private void SUButton_Click(object sender, EventArgs e)
        {
            if (SUUsername.Text == "" || SUPassword.Text == "")
            {
                MessageBox.Show("Please fill up all the needed information.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();

                string selectUsername = "SELECT * FROM user_info WHERE username = @Username";

                using (MySqlCommand checkUser = new MySqlCommand(selectUsername, connection))
                {
                    checkUser.Parameters.AddWithValue("@Username", SUUsername.Text.Trim());

                    MySqlDataAdapter adapter = new MySqlDataAdapter(checkUser);
                    adapter.Fill(sqlDt);

                    if (sqlDt.Rows.Count > 0)
                    {
                        string tempUser = SUUsername.Text.Substring(0, 1).ToUpper() + SUUsername.Text.Substring(1);
                        MessageBox.Show(tempUser + " is already existing.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (SUPassword.Text.Length < 2)
                    {
                        MessageBox.Show("Your password is too short. Create at least 8 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string insertData = "INSERT INTO user_info (Username, Password, DateCreated) VALUES (@username, @pass, @date)";

                        using (MySqlCommand insertUser = new MySqlCommand(insertData, connection))
                        {
                            insertUser.Parameters.AddWithValue("@username", SUUsername.Text.Trim());
                            insertUser.Parameters.AddWithValue("@pass", SUPassword.Text.Trim());
                            insertUser.Parameters.AddWithValue("@date", DateTime.Now);

                            insertUser.ExecuteNonQuery();
                            MessageBox.Show("Account Created Successfully!", "Created Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FrmSignIn signIn = new FrmSignIn();
                            signIn.Show();
                            this.Hide();
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
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
