using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace WebApplication1.Models
{
    public class MemberConnection

    {
        private readonly string connectionString = "Data Source=DESKTOP-4LPMCOV\\SQLEXPRESS;User ID=web;Password= root;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //���U
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
        //�T�{�b���O�_�s�b
        public bool isIdUsed(string _id)
        {
            string userID = _id;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM member WHERE userId = @userID");
            sqlCommand.Parameters.Add(new SqlParameter("@userID", userID));
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //�T�{�K�X
        public bool passwordCheck(string _id,string _pw)
        {
            string userID = _id, inputPW = _pw, userPW;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(@"SELECT * FROM member WHERE userId = @userID");
            sqlCommand.Parameters.Add(new SqlParameter("@userID", userID));
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                userPW = reader.GetString(reader.GetOrdinal("userPw"));
                System.Diagnostics.Debug.WriteLine("inputPW {0}, userPW {1}, compare {2}", inputPW, userPW, string.Compare(inputPW, userPW));
                if (string.Compare(inputPW, userPW) == 0)
                {
                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("�n�J���~�A�K�X����");
                    return false;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("�n�J���~�A��b���å��]�m�K�X");
                return false;
            }
           
        }
    }
}