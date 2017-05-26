using System;
using System.Text;

namespace coins.Service{
	public class ApiEndpoint
	{
		public static string MAIN_ENDPOINT = "http://192.168.1.67:8144/wallet";
		public static string YAHOO_ENDPOINT = "http://download.finance.yahoo.com/d/quotes?f=sl1d1t1&s=";
        public static string GET_ALL_RATES = MAIN_ENDPOINT + "/rate";
		public static string GET_RATE = MAIN_ENDPOINT + "/tax";
        public static string GET_TOTAL = MAIN_ENDPOINT + "/total";

        public static string YahooEndpoint(string _from, string _to){
			return YAHOO_ENDPOINT + _from + _to + "=X";
		}

		public static string RateEndpoint(string _from, string _to)
		{
            return GET_RATE + "?from=" + _from + "&to=" +_to;
		}

        public static string TotalEndpoint(string _to)
        {
            return GET_TOTAL + "?to=" + _to;
        }

        public static string AllRates(string from, string[] to)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(GET_ALL_RATES);
            sb.Append("?from=");
            sb.Append(from);

            foreach (var temp in to)
            {
                sb.Append("&to=");
                sb.Append(temp);
            }

            return sb.ToString();
        }
	}
}
