using Guna.UI2.WinForms;
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


    public partial class FrmSignIn : Form
    {
        public static class ClassSignIn
        {
            public static string LoggedInUsername { get; set; }
            public static string DashUser { get; set; }
        }

        private MySqlConnection connection;

        public FrmSignIn()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            SIPassword.PasswordChar = SIShowPass.Checked ? '\0' : '*';
        }
        private void InitializeDatabaseConnection()
        {
            string server = "127.0.0.1";
            string username = "root";
            string password = "mysql_admin081105";
            string database = "expensetracker";

            string connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
            connection = new MySqlConnection(connectionString);
        }

        private void SIButton_Click(object sender, EventArgs e)
        {
            string username = SIUsername.Text.Trim();
            string password = SIPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();

                string query = "SELECT * FROM user_info WHERE Username = @username AND Password = @password";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Login successful
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // You can perform any additional actions here after successful login,
                            // such as opening a new form or updating the UI.

                            string loggedInUsername = reader.GetString("Username");

                            // Set the username in the OverviewForm
                            ClassSignIn.LoggedInUsername = SIUsername.Text;
                            ClassSignIn.DashUser = SIUsername.Text;

                            // Open the OverviewForm
                            MainInterface mainInterface = new MainInterface();
                            mainInterface.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Login failed
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                connection.Close();
            }
        }

        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.ShowDialog();
            mainForm.BringToFront();
            this.Hide();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            form1.BringToFront();
            this.Hide();
        }
    }
}