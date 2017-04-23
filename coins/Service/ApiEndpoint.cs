using System;
namespace coins.Service
{
	public class ApiEndpoint
	{
		public static string MAIN_ENDPOINT = "http://localhost:8090/";
		public static string YAHOO_ENDPOINT = "http://download.finance.yahoo.com/d/quotes?f=sl1d1t1&s=";
		public static string GET_RATE = "tax";

		public static string YahooEndpoint(string _from, string _to){
			return YAHOO_ENDPOINT + _from + _to + "=X";
		}
	}
}
