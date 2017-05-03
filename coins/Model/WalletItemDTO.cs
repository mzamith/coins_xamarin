using System;
namespace coins.Model
{
    public class WalletItemDTO
    {
        public WalletItemDTO()
        {
        }

        private string code;
        private double amount;

        public string Code { get => code; set => code = value; }
        public double Amount { get => amount; set => amount = value; }
    }
}
