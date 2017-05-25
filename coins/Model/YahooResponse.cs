using System;
namespace coins.Model
{
    public class YahooResponse
    {
        public YahooResponse()
        {

        }

        private double rate;
        private DateTime date;

        public double Rate { get => rate; set => rate = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
