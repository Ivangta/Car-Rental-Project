using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class Bookings
    {
        public DateTime StartDate { get; set; }
        public string ClientAdditionalInformation { get; set; }
        public Car BookedCar { get; set; }
        public RentalInfo RentalInfo { get; set; }

        public void SetDate(DateTime startDate)
        {
            this.StartDate = startDate;
        }

        public void SetClientInformation(string clientAdditionalInformation)
        {
            this.ClientAdditionalInformation = clientAdditionalInformation;
        }

        public void SetBookedCar(Guid id)
        {
            this.BookedCar = new Car(id);
        }

        public void SetRentalInfo(int period, decimal pricePerDay, decimal totalPrice)
        {
            this.RentalInfo = new RentalInfo(period, pricePerDay, totalPrice);
        }




    }
}
