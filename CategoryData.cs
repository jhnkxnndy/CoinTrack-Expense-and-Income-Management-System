using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
namespace ExpenseTracker
{

    class CategoryData
    {

        private MySqlConnection MySqlConnection { get; }
        private MySqlCommand MySqlCommand { get; }

 
        public CategoryData(string server, string username, string password, string database)
        {
   
            string connectionString = $"server={server};user id={username};password={password};database={database}";
            MySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand = new MySqlCommand();
            MySqlCommand.Connection = MySqlConnection;
        }

      

 
        public List<CategoryData> GetCategoryData(string server, string username, string password, string database)
        {
            List<CategoryData> categoryList = new List<CategoryData>();

            try
            {
                MySqlConnection connection = new MySqlConnection($"server={server};user id={username};password={password};database={database}");
                connection.Open(); 

                string selectQuery = "SELECT * FROM categories";

                MySqlCommand command = new MySqlCommand(selectQuery, connection); 

                using (MySqlDataReader reader = command.ExecuteReader())
                {
               
                    while (reader.Read())
                    {
                        CategoryData categoryData = new CategoryData(server, username, password, database);
                        categoryData.ID = reader.GetInt32("ID");
                        categoryData.Category = reader.GetString("Category");
                        categoryData.Type = reader.GetString("Type");
                        categoryData.Status = reader.GetString("Status");
                        categoryData.Date = ((DateTime)reader["DateInserted"]).ToString("MM-dd-yyyy");

                        categoryList.Add(categoryData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving category data: " + ex.Message);
            }

            return categoryList;
        }


        public int ID { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }
}
