using System;
using System.Threading.Tasks;
using System.Configuration;
using Alpaca.Markets;

namespace dotnet_alpaca_trade
{
	public class Account
	{

        public Account()
        {
            // SetConfiguration already called when calling EstablishTradingClient(), so
            // don't need to call it again here. 
            account = Configure.EstablishTradingClient().Result;
        }

        public Dictionary<string, string> config;
        public IAccount account;

    }
}

