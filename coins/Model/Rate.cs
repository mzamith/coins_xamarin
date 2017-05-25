using System;
namespace coins.Model
{
    public class RateDTO
    {
        public RateDTO()
        {

        }

        private double rate;
        private DateTime date;

        public double Rate { get => rate; set => rate = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
