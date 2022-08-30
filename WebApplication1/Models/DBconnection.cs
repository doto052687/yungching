using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class DBconnection
    {
        private readonly string connectionString = "Data Source=DESKTOP-4LPMCOV\\SQLEXPRESS;User ID=web;Password= root;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM item");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Item item = new Item
                    {
                        id = reader.GetString(reader.GetOrdinal("id")),
                        name = reader.GetString(reader.GetOrdinal("name")),
                        quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                        price = reader.GetInt32(reader.GetOrdinal("price")),
                    };
                    items.Add(item);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return items;
        }
    }
}