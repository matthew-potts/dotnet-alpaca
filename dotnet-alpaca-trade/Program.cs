using System;
using System.Collections;
using System.Linq;
using Alpaca.Markets;
using System.Threading.Tasks;
using System.Configuration;
using dotnet_alpaca_data;


namespace dotnet_alpaca_trade
{
    internal static class Program
    {
        public static async Task Main(string[] args)
        {

            IAccount account = new Account().account;
            IAlpacaDataClient dataClient = new DataClient().client;

            // Interesting! tickerList doesn't exist in the current context - out of scope?
            await Compute5DayReturn("AAPL", dataClient);

            foreach (string ticker in ReadQqqCsv())
            {
                Console.WriteLine(ticker);
            }


        }

        public static async Task Compute5DayReturn(string ticker, IAlpacaDataClient dataClient)
        {
            var to = DateTime.Today;
            var from = to.AddDays(-5);

            var bars = await dataClient.ListHistoricalBarsAsync(
                new HistoricalBarsRequest(ticker, from, to, BarTimeFrame.Day));


            var first = bars.Items.First().Close;
            var last = bars.Items.Last().Close;

            Console.WriteLine($"The % change of {ticker} over" +
                $" the period {from} to {to} is {decimal.Round(((last / first) - 1) * 100, 2)}");
        }

        public static List<string> ReadQqqCsv()
        {
            List<string> tickerList = null;
            try
            {
                using (StreamReader sr = new StreamReader("/Users/matthewpotts/" +
                    "Projects/dotnet-alpaca/dotnet-alpaca-data/qqq.txt"))
                {
                    string line;
                    

                    while ((line = sr.ReadLine()) != null)
                    {

                        tickerList.Add(line.Split(",")[2]);
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

    }
}