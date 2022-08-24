using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using Alpaca.Markets;

namespace dotnet_alpaca_trade
{
    public class Configure
    {
        public static Dictionary<string, string> SetConfiguration()
        {
            var section = (ConfigurationManager.GetSection("DeviceSettings/MajorCommands")
            as Hashtable)
            .Cast<System.Collections.DictionaryEntry>()
            .ToDictionary(n => n.Key.ToString(), n => n.Value.ToString());

            return section;
        }

        public static async Task<IAccount> EstablishTradingClient() // allows one to establish account instance
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