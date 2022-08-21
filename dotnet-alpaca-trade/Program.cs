using System;
using Alpaca.Markets;
using System.Threading.Tasks;
using System.Configuration;

namespace AlpacaExample
{
    internal static class Program
    {

        public static async Task Main()
        {
            try
            {
                var client = Environments.Paper
                    .GetAlpacaTradingClient(new SecretKey(
                        ConfigurationManager.AppSettings["KeyID"],
                        ConfigurationManager.AppSettings["SecretKeyID"]));

                var clock = await client.GetClockAsync();

                if (clock != null)
                {
                    Console.WriteLine(
                    "Timestamp: {0}, NextOpen: {1}, NextClose: {2}",
                    clock.TimestampUtc, clock.NextOpenUtc, clock.NextCloseUtc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex} thrown - is there an incorrect KeyID or SecretKeyID");
            }
            
        }

    }
}