using System;
namespace coins.Model
{
    public class WalletItemDTO
    {
        public WalletItemDTO()
        {
        }

        private string coin;
        private double value;

        public string Coin { get => coin; set => coin = value; }
        public double Value { get => value; set => this.value = value; }
    }
}
