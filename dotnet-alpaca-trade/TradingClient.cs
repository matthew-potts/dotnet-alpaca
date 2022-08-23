using System;
using System.Threading.Tasks;
using System.Configuration;
using Alpaca.Markets;

namespace dotnet_alpaca_trade
{
	public class TradingClient
	{
        public static async Task<IAccount> EstablishTradingClient()
        {
            var config = Configure.SetConfiguration();

            var client = Alpaca.Markets.Environments.Paper
                .GetAlpacaTradingClient(new SecretKey(config["KeyID"]
                , config["SecretKeyID"]));

            var account = await client.GetAccountAsync();

            return account;
            
        }
    }
}

