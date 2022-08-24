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


		public Dictionary<string, string> config;
		public IAlpacaDataClient client;
	}
}

