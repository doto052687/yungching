using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace WebApplication1.Models
{
    public class MemberConnection

    {
        private readonly string connectionString = "Data Source=DESKTOP-4LPMCOV\\SQLEXPRESS;User ID=web;Password= root;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //µù¥U
        public void register(Member member)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO member (userId,userPw) VALUES (@id,@pw)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", member.userID));
            sqlCommand.Parameters.Add(new SqlParameter("@pw", member.userPW));

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();



        }

    }
}