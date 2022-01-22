using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AssignmentAPI.Shared
{
    public class SqlConnectionHelper
    {
        private static string _connectionString;

        private static string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["TEST"].ConnectionString;
                }
                return _connectionString;
            }
        }

        public static async Task<SqlConnection> GetConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync().ConfigureAwait(false);
            return connection;
        }

        public static SqlConnection GetConnectionSync()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

    }
}