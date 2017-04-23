using System;
using System.Net;
using System.Threading.Tasks;
using coins.Model;
using Newtonsoft.Json;

namespace coins.Service
{
	public class CurrencyService
	{
		private System.Net.Http.HttpClient client;

		public CurrencyService()
		{
			client = new System.Net.Http.HttpClient();
			client.BaseAddress = new Uri(ApiEndpoint.MAIN_ENDPOINT);
		}

		public async Task<string> GetYahooTaxAsync(string c_from, string c_to){

			var response = await client.GetAsync(ApiEndpoint.YahooEndpoint(c_from, c_to));

			var stringResult = response.Content.ReadAsStringAsync().Result;

			return stringResult.Split(',')[1];

		} 
	}
}
