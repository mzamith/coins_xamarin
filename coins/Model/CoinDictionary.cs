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

        private CoinDictionary()
        {
            LoadJson();
        }

        public static CoinDictionary Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CoinDictionary();
                }
                return instance;
            }
        }

        public List<Currency> Currencies { get => currencies; set => currencies = value; }

        private void LoadJson()
        {

            var assembly = typeof(CoinDictionary).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("coins.Model.currencies.json");

            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
                Currencies = JsonConvert.DeserializeObject<List<Currency>>(text);
                Currencies.Sort();
            }
        }

        public string GetName(string coin)
        {

            return Currencies.Find((item) => item.Code == coin).Name;
        }

        public List<string> GetCodes()
        {

            List<string> codes = new List<string>();

            foreach (Currency element in Currencies)
            {
                codes.Add(element.Code);
            }

            return codes;

        }

        public Currency GetCoinFromIndex(int i)
        {

            return Currencies[i];
        }

        public Currency GetCoinFromCode(string code)
        {

            return Currencies.Find(item => item.Code == code);
        }

        public bool CoinExists(string key)
        {
            return ((Currencies.FindIndex((item) => item.Code.Equals(key))) >= 0);
        }

        public List<Currency> FilterCoins(string criteria)
        {
            criteria = (criteria == null) ? "" : criteria.ToUpper();
            List < Currency > a = Currencies.Where((item) => (item.Code.ToUpper().Contains(criteria) || 
                                                              item.Name.ToUpper().Contains(criteria) || 
                                                              item.Name_plural.ToUpper().Contains(criteria))).ToList();

            return a;
        }
    }
}
