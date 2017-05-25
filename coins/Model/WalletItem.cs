using System;
using SQLite;

namespace coins.Model
{
    public class WalletItem
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
        public string code { get; set; }
		public string name { get; set; }
		public string name_plural { get; set; }
		public string symbol { get; set; }
		public string symbol_native { get; set; }
		public int decimal_digits { get; set; }
		public double rounding { get; set; }
		public string flag { get; set; }
        public double amount { get; set; }
        public string formatted_amount { get; set; }

        public WalletItem(){}

        public WalletItem(string code, double amount){
            var coin = CoinDictionary.Instance.GetCoinFromCode(code);

            this.code = coin.Code;
            this.name = coin.Name;
            this.name_plural = coin.Name_plural;
            this.symbol = coin.Symbol;
            this.symbol_native = coin.Symbol_native;
            this.decimal_digits = coin.Decimal_digits;
            this.rounding = coin.Rounding;
            this.flag = coin.Flag;
            this.amount = amount;
            this.formatted_amount = string.Format("{0:0.00}", amount);
        }

        public WalletItem(WalletItemDTO dto) : this(dto.Coin, dto.Value){
            
        }
    }
}
