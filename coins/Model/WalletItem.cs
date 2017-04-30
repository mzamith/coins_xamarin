using System;
using SQLite;

namespace coins.Model
{
    public class WalletItem
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string name { get; set; }
		public string amount { get; set; }
        public string flag { get; set; }

    }
}
