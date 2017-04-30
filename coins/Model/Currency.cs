using System;
using SQLite;

namespace coins.Model
{
    public class Currency : IComparable
    {
        private string code;
        private string name;
        private string name_plural;
        private string symbol;
        private string symbol_native;
        private int decimal_digits;
        private double rounding;
        private string flag = "european-union.png";

        public string Code { get => code; set => code = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public string Symbol_native { get => symbol_native; set => symbol_native = value; }
        public int Decimal_digits { get => decimal_digits; set => decimal_digits = value; }
        public double Rounding { get => rounding; set => rounding = value; }
        public string Name_plural { get => name_plural; set => name_plural = value; }
        public string Name { get => name; set => name = value; }
        public string Flag { get => flag; set => flag = value; }

        public int CompareTo(object obj)
        {
            Currency c = (Currency)obj;
            return ((IComparable)code).CompareTo(c.Code);
        }

        public override bool Equals(object obj)
        {
			if (obj == null || GetType() != obj.GetType())
				return false;

            Currency c = (Currency)obj;
            return (c.Code.Equals(Code));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

