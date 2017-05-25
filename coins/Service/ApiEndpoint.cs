using System;
namespace coins.Service{
	public class ApiEndpoint
	{
		public static string MAIN_ENDPOINT = "http://localhost:8144/wallet";
		public static string YAHOO_ENDPOINT = "http://download.finance.yahoo.com/d/quotes?f=sl1d1t1&s=";
		public static string GET_RATE = MAIN_ENDPOINT + "/tax";

        public static string YahooEndpoint(string _from, string _to){
			return YAHOO_ENDPOINT + _from + _to + "=X";
		}

		public static string RateEndpoint(string _from, string _to)
		{
            return GET_RATE + "?from=" + _from + "&to=" +_to;
		}
	}
}
