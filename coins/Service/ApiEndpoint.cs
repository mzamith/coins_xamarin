using System;
using System.Text;

namespace coins.Service{
	public class ApiEndpoint
	{
		public static string MAIN_ENDPOINT = "http://192.168.1.84:8144/wallet";
		public static string YAHOO_ENDPOINT = "http://download.finance.yahoo.com/d/quotes?f=sl1d1t1&s=";
        public static string GET_TOTAL_RATES = "/rate";
		public static string GET_RATE = "/tax";
        public static string GET_TOTAL = "/total";

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

        public static string TotalRates(string from, string[] to)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(GET_TOTAL_RATES);
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
