using Alpaca.Markets;

namespace dotnet_alpaca_reader
{

	public class QQQReader
	{
		public QQQReader()
		{
			client = ConfigureDataClient.EstablishDataClient();
		}

        public static List<string> ReadQqqCsv()
        {
            List<string> tickerList = null;
            try
            {
                using (StreamReader sr = new StreamReader("/Users/matthewpotts/" +
                    "Projects/dotnet-alpaca/dotnet-alpaca-reader/qqq.txt"))
                {
                    tickerList = new List<string>();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        var ticker = line.Split(",")[2].Trim();
                        string modifiedTicker = $"'{ticker}'";
                        tickerList.Add(modifiedTicker.ToUpper());
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The file could not be read. Exiting...");

            }
            return tickerList;

        }

        public Dictionary<string, string> config;
		public IAlpacaDataClient client;
	}
}

