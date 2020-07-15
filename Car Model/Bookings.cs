using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class Bookings
    {
        public Bookings() 
        {
            //this.StartDate = startDate;
            //this.ClientAdditionalInformation = clientRequestInfo;
            //this.BookedCar = carToBook;
            //this.RentalInfo = rentalInformation;
        }
        
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
            //this.BookedCar.Id = id;
            this.BookedCar = new Car(id);
        }

        public void SetRentalInfo(int period, decimal price)
        {
            this.RentalInfo = new RentalInfo(period, price);
            //this.RentalInfo.Period = period;
            //this.RentalInfo.Price = price;
        }




    }
}
