using System;
using System.Configuration;
using System.Collections;
using Alpaca.Markets;

namespace dotnet_alpaca_reader
{
	public class ConfigureDataClient
	{

       public static Dictionary<string, string> SetConfiguration()
       {
             var section = (ConfigurationManager.GetSection("DeviceSettings/MajorCommands")
             as Hashtable)
             .Cast<System.Collections.DictionaryEntry>()
             .ToDictionary(n => n.Key.ToString(), n => n.Value.ToString());

             return section;
       }

       public static IAlpacaDataClient EstablishDataClient()
       {
             var config = SetConfiguration();
             var client = Environments.Paper.GetAlpacaDataClient
                    (new SecretKey(config["KeyID"], config["SecretKeyID"]));

            return client;
        }
        
	}
}

