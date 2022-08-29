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

            var to = DateTime.Today;
            var from = to.AddDays(-5);

            string ticker = "AAPL";

            var bars = await dataClient.ListHistoricalBarsAsync(
                new HistoricalBarsRequest(ticker, from, to, BarTimeFrame.Day));


            var first = bars.Items.First().Close;
            var last = bars.Items.Last().Close;

            Console.WriteLine($"The % change of {ticker} over" +
                $" the period {from} to {to} is {decimal.Round(((last / first) - 1) * 100, 2)}");


        }

    }
}