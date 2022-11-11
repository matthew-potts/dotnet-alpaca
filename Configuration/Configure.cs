using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using Alpaca.Markets;


namespace dotnet_alpaca_config
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
    }
}
