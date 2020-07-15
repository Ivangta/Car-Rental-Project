using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class RentalInfo
    {
        public RentalInfo(int period, decimal price)
        {
            this.Period = period;
            this.Price = price;
        }

        public int Period { get; set; }
        public decimal Price { get; set; }
    }
}
