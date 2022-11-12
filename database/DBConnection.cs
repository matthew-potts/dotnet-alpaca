using System;
using Npgsql;
using System.Configuration;
using System.Data.SqlClient;

namespace database
{
    public class DBConnection
    {
        public DBConnection()
        {
        }
        
        public NpgsqlConnection openSqlConnection()
        {
            // Nice little way of debugging the NullReferenceException often encountered with ConfigurationManager;

            NpgsqlConnection connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString);

            connection.Open();
            Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
            Console.WriteLine("State: {0}", connection.State);

            return connection;
        }
    }
}
