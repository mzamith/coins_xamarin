using System;
using SQLite;

namespace coins.Model
{
	public class Currency
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string name { get; set; }
		public float amount { get; set; }

		public string getLongName(){
			return CoinDictionary.GetName(name);
		}
	}
}

