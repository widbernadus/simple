using System.Data.Common;
using System.Data.SqlClient;

namespace SimpleCrudDapper.Utility
{
    public class DbContext
    {
        private string _connectionString1;
        public DbContext()
        {
            _connectionString1 = @"Server=KSI01\SQLEXPRESS;Database=Example;User Id=Admin;Password=AdminDatabase";
        }

        public DbConnection CreateConnection1() => new SqlConnection(_connectionString1);
    }
}
