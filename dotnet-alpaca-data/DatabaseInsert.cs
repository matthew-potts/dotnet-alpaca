using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using Npgsql;

namespace dotnet_alpaca_data
{
    public class Program
    {
        public static void Main()
        {
            var sqlConnection = EstablishConnection();
            sqlConnection.Open();

            /* This will be very inefficient for now. Basically, put all the tickers into a list,
             * and then insert them into tickersEnum.
             * 
             * Before doing this, however, need to edit the tables to make sure that
             * they're autoincrementing!
             */

            InsertValues("tickersEnum", new List<string>() { "1, 'AAPL'", "2, 'META'" }, sqlConnection);
        }

        public static void ReadQuery(string tableName, string cols, NpgsqlConnection sqlConnection)
        {
            string queryString = $"SELECT {cols} FROM \"{tableName}\";";

            NpgsqlCommand sqlCommand = new NpgsqlCommand(queryString, sqlConnection);

            NpgsqlDataReader reader = sqlCommand.ExecuteReader();

            // Call Read before accessing data.
            while (reader.Read())
            {
                ReadSingleRow((IDataRecord)reader);
            }

            // Call Close when done reading.
            reader.Close();
            
        }

        public static void InsertValues(string tableName, List<string> values, NpgsqlConnection sqlConnection)

        {
            foreach (string valSet in values)
            {
                string queryString = $"INSERT INTO \"{tableName}\"" +
                $" VALUES ({valSet});";

                NpgsqlCommand sqlCommand = new NpgsqlCommand(queryString, sqlConnection);

                NpgsqlDataReader reader = sqlCommand.ExecuteReader();

                reader.Close();
            }
        }

        public static void InsertValues(string cols, string tableName, List<string> values, NpgsqlConnection sqlConnection)
        {

            foreach (string valSet in values)
            {
                string queryString = $"INSERT INTO \"{tableName}\"" +
                $"({cols}) VALUES ({valSet});";

                NpgsqlCommand sqlCommand = new NpgsqlCommand(queryString, sqlConnection);

                NpgsqlDataReader reader = sqlCommand.ExecuteReader();

                reader.Close();
            }
        }

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }

        public static NpgsqlConnection EstablishConnection()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString);
            return sqlConnection;
        }

        /* WRITE AN EXECUTE FUNCTION ? */
        
    }
}

