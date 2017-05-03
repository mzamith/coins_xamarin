using System;
namespace coins.Model
{
    public class Rate
    {
        public Rate()
        {

        }

        private double conversion;
        private DateTime date;

        public double Coversion { get => conversion; set => conversion = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
