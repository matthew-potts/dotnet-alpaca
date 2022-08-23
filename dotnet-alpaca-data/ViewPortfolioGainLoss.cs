using System;
using dotnet_alpaca_trade;
using Alpaca.Markets;

namespace dotnet_alpaca_data
{
    public class ViewPortfolioGainLoss : IAlpacaDataClient
    {

        public ViewPortfolioGainLoss()
        {
            // all configuration taken care of inside constructor?
            var config = base.SetConfiguration();
            API_KEY = config["KeyID"];
            API_SECRET = config["SecretID"]; // maybe have an interface that takes care of this? Some sort of derivation would be good. 
        }

        private Dictionary<string, string> config; 
        private static string API_KEY;
        private static  string API_SECRET;


    }
}