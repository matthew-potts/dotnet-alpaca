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
            config = Configure.SetConfiguration();
            account = Configure.EstablishTradingClient().Result;
        }

        public Dictionary<string, string> config;
        public IAccount account;

    }
}

