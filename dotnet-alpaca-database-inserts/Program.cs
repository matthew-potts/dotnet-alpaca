using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

using Npgsql;

namespace dotnet_alpaca_database_inserts
{
	public class Program
	{
		public Program()
		{

		}

		public static void InsertIntoDatabase()
        {
            string queryString = "SELECT * FROM \"tickersEnum\";";
            using (NpgsqlConnection sqlConnection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["dbConnect"].ConnectionString))
            {
                sqlConnection.Open();

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
        }
		
		private static void ReadSingleRow(IDataRecord dataRecord)
		{
			Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
		}
	}
}

