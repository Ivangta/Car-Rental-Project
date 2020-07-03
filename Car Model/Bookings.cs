﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class Bookings
    {
        public Bookings(DateTime startDate, string clientRequestInfo, Car carToBook, RentalInfo rentalInformation) 
        {
            this.StartDate = startDate;
            this.ClientAdditionalInformation = clientRequestInfo;
            this.BookedCar = carToBook;
            this.RentalInfo = rentalInformation;
        }
        
        public DateTime StartDate { get; set; }
        public string ClientAdditionalInformation { get; set; }
        public Car BookedCar { get; set; }
        public RentalInfo RentalInfo { get; set; }

        

        
        
    }
}
