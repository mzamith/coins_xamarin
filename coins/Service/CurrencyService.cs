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

		public async Task<Currency> GetTaxAsync(Currency from, string to){

			var response = await client.GetAsync(ApiEndpoint.GET_RATE);

			var jsonResult = response.Content.ReadAsStringAsync().Result;

			var currencyResult = JsonConvert.DeserializeObject<Currency>(jsonResult);

			return currencyResult;

		} 
	}
}
