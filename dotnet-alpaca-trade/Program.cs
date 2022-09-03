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

            List<string> tickerList = DataClient.ReadQqqCsv();

            foreach (string ticker in tickerList)
            {

                var tickerBars = Compute5DayReturn(ticker, dataClient).Result;
                Console.WriteLine(tickerBars);
            }

        }

        public static async Task<IPage<IBar>> Compute5DayReturn(string ticker, IAlpacaDataClient dataClient)

        {
            var to = DateTime.Today;
            var from = to.AddDays(-5);

            try
            {


                var bars = await dataClient.ListHistoricalBarsAsync(
                    new HistoricalBarsRequest(ticker, from, to, BarTimeFrame.Day));


                var first = bars.Items.First().Close;
                var last = bars.Items.Last().Close;

                Console.WriteLine($"The % change of {ticker} over" +
                    $" the period {from} to {to} is {decimal.Round(((last / first) - 1) * 100, 2)}");
            }

            catch (System.AggregateException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        

    }
}