using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    class ExpenseData
    {
      
        public int ID { get; set; }
        public string Category { get; set; }
        public string Item { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public string DateExpense { get; set; }


        private MySqlConnection MySqlConnection { get; }
        private MySqlCommand MySqlCommand { get; }

      
        public ExpenseData(string server, string username, string password, string database)
        {

            string connectionString = $"server={server};user id={username};password={password};database={database}";
            MySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand = new MySqlCommand();
            MySqlCommand.Connection = MySqlConnection;
        }


  
        public List<ExpenseData> GetExpenseData(string server, string username, string password, string database)
        {
            List<ExpenseData> expenseList = new List<ExpenseData>();

            try
            {
                MySqlConnection connection = new MySqlConnection($"server={server};user id={username};password={password};database={database}");
                connection.Open(); 

                string selectQuery = "SELECT * FROM expenses";

                MySqlCommand command = new MySqlCommand(selectQuery, connection); 

                using (MySqlDataReader reader = command.ExecuteReader())
                {
             
                    while (reader.Read())
                    {
                        ExpenseData expenseData = new ExpenseData(server, username, password, database);
                        expenseData.ID = (int)reader["ID"];
                        expenseData.Category = reader["Category"].ToString();
                        expenseData.Item = reader["Item"].ToString();
                        expenseData.Cost = reader["Cost"].ToString();
                        expenseData.Description = reader["Description"].ToString();
                        expenseData.DateExpense = ((DateTime)reader["DateExpense"]).ToString("MM-dd-yyyy");

                        expenseList.Add(expenseData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving category data: " + ex.Message);
            }
            return expenseList;
        }
    }
}
