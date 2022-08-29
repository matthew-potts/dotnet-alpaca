using System;
using System.IO;
using Alpaca.Markets;

namespace dotnet_alpaca_data
{
	public class Program
	{
		public static async Task Main()
        {
			// purpose of this program will be to read in data on
			// all available tickers.

			// First, try on one ticker.
			
			var dir = Path.Combine("/Users/matthewpotts/" +
                "Projects/dotnet-alpaca", "dotnet-alpaca-data");

			var ticker = File.ReadAllLinesAsync(dir+"/AAPL.txt").Result;
			var aapl = (string)ticker[0];

			// will have a class which reads in all of the tickers from a
			// text file. The results from this class will then feed into a
			// method to get the bars for these tickers, and finally
			// store these bars in a (ML.NET) dataframe. 
		}
		
	}
}

