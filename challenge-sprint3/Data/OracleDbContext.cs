using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace challenge_sprint3.Data
{
    public class OracleDbContext
    {
        private readonly string _connectionString;


        public OracleDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }


        public IDbConnection CreateConnection()
        {
            return new OracleConnection(_connectionString);
        }
    }
}
