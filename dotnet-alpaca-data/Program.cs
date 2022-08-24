using System;
using Alpaca.Markets;

namespace dotnet_alpaca_data
{
	public class Program
	{
		public static async Task Main()
        {
			// purpose of this program will be to read in data on
			// all available tickers.
			var client = new DataClient();
			string symbol = "AAPL";
			DateTime start = DateTime.Today.AddDays(-1);
			DateTime end = DateTime.Today;
			var timeframe = BarTimeFrame.Day;

			//var bars = await client.ListHistorialBarsAsync
        }
		
	}
}

