using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using dotnet_alpaca_config;
using Alpaca.Markets;

namespace dotnet_alpaca_trade
{
    public class EstablishTradingClient
    {
        public static async Task<IAccount> establishTradingClient() // allows one to establish account instance
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
