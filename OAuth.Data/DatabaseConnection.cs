using System.Data.Common;
using System.Data.SqlClient;

namespace OAuth.Data
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly string connectionString;
        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbConnection Connection => new SqlConnection(connectionString);
    }
}
