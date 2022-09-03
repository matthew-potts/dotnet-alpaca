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

            List<string> tickerList = DataClient.ReadQqqCsv();

            foreach (string ticker in tickerList)
            {
                try
                {
                    var tickerBars = GetBars(ticker, dataClient).Result;
                    Console.WriteLine(tickerBars);
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public static async Task<IPage<IBar>> GetBars(string ticker, IAlpacaDataClient dataClient)

        {
            var to = DateTime.Today;
            var from = to.AddDays(-5);

            var bars = await dataClient.ListHistoricalBarsAsync(
                new HistoricalBarsRequest(ticker, from, to, BarTimeFrame.Day));

            return bars;
            
        }        
    }
}