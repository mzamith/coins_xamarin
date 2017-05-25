using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coins.Model
{
    public class CurrencyDTO
    {

        public CurrencyDTO()
        {

        }

        private string from;
        private string to;

        public string From { get => from; set => from = value; }
        public string To { get => to; set => to = value; }
    }
}
