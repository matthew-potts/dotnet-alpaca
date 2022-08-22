using System;
using System.Collections;
using System.Linq;
using Alpaca.Markets;
using System.Threading.Tasks;
using System.Configuration;

namespace AlpacaExample
{
    internal static class Program
    {

        public static async Task Main()
        {

            var section = (ConfigurationManager.GetSection("DeviceSettings/MajorCommands")
                as Hashtable)
                .Cast<System.Collections.DictionaryEntry>()
                .ToDictionary(n=>n.Key.ToString(), n=>n.Value.ToString());
                
            try
            {
                var client = Environments.Paper
                    .GetAlpacaTradingClient(new SecretKey(
                        section["KeyID"],
                        section["SecretKeyID"]));

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