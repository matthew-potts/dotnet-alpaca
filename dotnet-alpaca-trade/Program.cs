using System;
using System.Collections;
using System.Linq;
using Alpaca.Markets;
using System.Threading.Tasks;
using System.Configuration;


namespace dotnet_alpaca_trade
{
    internal static class Program
    {
        public static void Main()
        {

            IAccount account = TradingClient.EstablishTradingClient().Result;

            if (account.IsTradingBlocked)
            {
                Console.WriteLine("Account is currently restricted from trading");
            }

            Console.WriteLine($"{account.BuyingPower} is the available buying power");
        }

    }
}