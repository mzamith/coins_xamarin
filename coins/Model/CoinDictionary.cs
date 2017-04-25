using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace coins.Model
{
	public class CoinDictionary
	{

        private static CoinDictionary instance;

		private List<Currency> currencies;

		private CoinDictionary(){
            LoadJson();
        }

        public static CoinDictionary Instance {
            get {
                if (instance == null){
                    instance = new CoinDictionary();
                }
                return instance;
            }
        }

        private void LoadJson(){

			var assembly = typeof(CoinDictionary).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("coins.Model.currencies.json");

			string text = "";
			using (var reader = new System.IO.StreamReader(stream))
			{
				text = reader.ReadToEnd();
                currencies = JsonConvert.DeserializeObject<List<Currency>>(text);
                currencies.Sort();
			}
		}

		public string GetName(string coin){
			
            return currencies.Find((item) => item.Code == coin).Name;
		}

        public List<string> GetCodes(){

            List<string> codes = new List<string>();

            foreach (Currency element in currencies){
                codes.Add(element.Code);
            }

            return codes;

		}

		public Currency GetCoinFromIndex(int i){

            return currencies[i];
		}

		public bool CoinExists(string key) {
            return ((currencies.FindIndex((item) => item.Code.Equals(key))) >= 0);
		}
	}
}
