using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    class IncomeData
    {
        // Properties for category data
        public int ID { get; set; }
        public string Category { get; set; }
        public string Item { get; set; }
        public string Income { get; set; }
        public string Description { get; set; }
        public string DateIncome { get; set; }

        // Constructor (if needed)

        // Method to retrieve income data from the database
        // Properties for database connection and command objects
        private MySqlConnection MySqlConnection { get; }
        private MySqlCommand MySqlCommand { get; }

        // Constructor to initialize MySqlConnection and MySqlCommand
        public IncomeData(string server, string username, string password, string database)
        {

            string connectionString = $"server={server};user id={username};password={password};database={database}";
            MySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand = new MySqlCommand();
            MySqlCommand.Connection = MySqlConnection;
        }


        // Method to retrieve category data from the database
        public List<IncomeData> GetIncomeData(string server, string username, string password, string database)
        {
            List<IncomeData> incomeList = new List<IncomeData>();

            try
            {
                MySqlConnection connection = new MySqlConnection($"server={server};user id={username};password={password};database={database}");
                connection.Open(); // Open the database connection

                string selectQuery = "SELECT * FROM income";

                MySqlCommand command = new MySqlCommand(selectQuery, connection); // Create a MySqlCommand

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Iterate through the result set and populate categoryList
                    while (reader.Read())
                    {
                        IncomeData iData = new IncomeData(server, username, password, database);
                        iData.ID = (int)reader["ID"];
                        iData.Category = reader["Category"].ToString();
                        iData.Item = reader["Item"].ToString();
                        iData.Income = reader["Income"].ToString();
                        iData.Description = reader["Description"].ToString();
                        iData.DateIncome = ((DateTime)reader["DateIncome"]).ToString("MM-dd-yyyy");

                        incomeList.Add(iData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving category data: " + ex.Message);
            }
            return incomeList;
        }
    }
}
