using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coins.Model
{
    public class ResponseRates
    {

        public ResponseRates()
        {

        }

        private RateDTO[] rates;

        public RateDTO[] Rates { get => rates; set => rates = value; }
    }
}
