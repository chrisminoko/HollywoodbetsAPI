using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SportAPISever.Context
{
    public class DbService
    {
        private static readonly string ConnectionString = "Server=(LocalDb)\\LocalDb;Database=HollywoodbetsDB;Trusted_Connection=true;";
        public static SqlConnection sqlConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            return connection;
        }
     
    }
}
