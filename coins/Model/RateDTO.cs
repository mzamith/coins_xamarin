using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coins.Model
{
    public class RateDTO
    {

        public RateDTO()
        {

        }

        private CurrencyDTO currency;
        public double amount;
        public CurrencyDTO Conversion { get => currency; set => currency = value; }
        public double Value { get => amount; set => amount= value; }

    }
}
