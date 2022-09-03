using Alpaca.Markets;

namespace dotnet_alpaca_data
{
	// changed to an executable for now - change back to ClassLib later. 

	public class DataClient
	{
		public DataClient()
		{
			client = ConfigureDataClient.EstablishDataClient();
		}

        public static List<string> ReadQqqCsv()
        {
            List<string> tickerList = null;
            try
            {
                using (StreamReader sr = new StreamReader("/Users/matthewpotts/" +
                    "Projects/dotnet-alpaca/dotnet-alpaca-data/qqq.txt"))
                {
                    tickerList = new List<string>();
                    string line;


                    while ((line = sr.ReadLine()) != null)
                    {

                        tickerList.Add(line.Split(",")[2].Trim());
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

