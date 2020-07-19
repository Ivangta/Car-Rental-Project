using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class RentalInfo
    {
        public RentalInfo(int period, decimal pricePerDay, decimal totalPrice)
        {
            this.Period = period;
            this.PricePerDay = pricePerDay;
            this.TotalPrice = this.Period * this.PricePerDay;
        }

        public int Period { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal TotalPrice { get; }
    }
}
