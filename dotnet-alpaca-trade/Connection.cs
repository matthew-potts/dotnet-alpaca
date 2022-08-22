using System;
using System.Threading.Tasks;
using System.Configuration;

namespace dotnet_alpaca_trade
{
	public class Connection
	{
		private static readonly HttpClient client = new HttpClient();

		static async Task CreateConnection()
        {
			//client.DefaultRequestHeaders.Accept.Clear();
			//client.DefaultRequestHeaders
			//	.Add("APCA-API-KEY-ID", ConfigurationManager.AppSettings["KeyID"]);
			//client.DefaultRequestHeaders
			//	.Add("APCA-API-SECRET-KEY", ConfigurationManager.AppSettings["SecretKeyID"]);

			//var stringTask = client.GetStringAsync($"{domain}{accountEndpoint}");

        }
	}
}

