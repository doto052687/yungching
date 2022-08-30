using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class DBconnection
    {
        private readonly string connectionString = "Data Source=DESKTOP-4LPMCOV\\SQLEXPRESS;User ID=web;Password= root;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
        public List<Item> getItems()
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
                System.Diagnostics.Debug.WriteLine("資料庫為空");
            }
            sqlConnection.Close();
            return items;
        }

        public Item getItem(string _id)
        {
            string id = _id;
            Item item = new Item();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM item WHERE id = @id");
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    item.id = reader.GetString(reader.GetOrdinal("id"));
                    item.name = reader.GetString(reader.GetOrdinal("name"));
                    item.quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                    item.price = reader.GetInt32(reader.GetOrdinal("price"));

                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("無此商品");
            }

            return item;
        }
        public void updateItem(Item item)
        {
            System.Diagnostics.Debug.WriteLine("item.id= {0}",item.id);
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(@"UPDATE item SET name = @name, quantity = @quantity, price = @price WHERE id = @id ");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id",item.id));
            sqlCommand.Parameters.Add(new SqlParameter("@name",item.name));
            sqlCommand.Parameters.Add(new SqlParameter("@quantity",item.quantity));
            sqlCommand.Parameters.Add(new SqlParameter("@price",item.price));
            
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

    }
}