using System;
using System.Net;
using System.Collections;
using System.Threading.Tasks;
using coins.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace coins.Service
{
	public class CurrencyService
	{
		private System.Net.Http.HttpClient client;

		public CurrencyService()
		{
			client = new System.Net.Http.HttpClient();
			//client.BaseAddress = new Uri(ApiEndpoint.MAIN_ENDPOINT);
		}

		public async Task<string> GetYahooTaxAsync(string c_from, string c_to){

            var url = ApiEndpoint.YahooEndpoint(c_from, c_to);

            var response = await client.GetAsync(url);

			var stringResult = response.Content.ReadAsStringAsync().Result;

			return stringResult.Split(',')[1];

		}

        public async Task<YahooResponse> GetRateAsync(string c_from, string c_to)
		{

            var url = ApiEndpoint.RateEndpoint(c_from, c_to);

            var response = await client.GetAsync(url);

			var jsonResult = response.Content.ReadAsStringAsync().Result;
            YahooResponse rate = JsonConvert.DeserializeObject<YahooResponse>(jsonResult);

            return rate;

		}

        public async Task<ResponseRates> GetAllRates(string c_from, List<string> c_to)
        {
            var url = ApiEndpoint.AllRates(c_from, c_to.ToArray());

            var response = await client.GetAsync(url);

            var jsonResult = response.Content.ReadAsStringAsync().Result;
            ResponseRates rates = JsonConvert.DeserializeObject<ResponseRates>(jsonResult);

            return rates;
        }

        public async Task<WalletItemDTO> GetTotalValue(List<WalletItemDTO> from, string c_to)
        {
            string data = JsonConvert.SerializeObject(from);

            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var url = ApiEndpoint.TotalEndpoint(c_to);

            var response = await client.PostAsync(url, content).ConfigureAwait(false);

            var jsonResult = response.Content.ReadAsStringAsync().Result;
            WalletItemDTO item = JsonConvert.DeserializeObject<WalletItemDTO>(jsonResult);

            return item;
        }

	}
}
