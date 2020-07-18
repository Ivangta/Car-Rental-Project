using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Car_Model
{
    public class Car 
    {
        public Car()
        {

        }

        public Car(Guid id)
        {
            this.Id = id;
        }
       
        public Guid Id { get; set; }
        public CarType CarType { get; set; }
        public int Seats { get; set; }
        public string Brand { get; set;  }
        public string Model { get; set; }
        public DoorsEnum Doors { get; set; }
        public GearBoxEnum GearBoxType { get; set; }
        public EngineSpec EngineSpec { get; set; }
        public Extras Extras { get; set; }

        public void SetId(Guid id)
        {
            this.Id = id;
        }
        public void SetCarType(CarType carType)
        {
            this.CarType = carType;
        }
        public void SetSeats(int seats)
        {
            this.Seats = seats;
        }
        public void SetBrand(string brand, string model)
        {
            this.Brand = brand;
            this.Model = model;
        }
        public void SetDoors(DoorsEnum doors)
        {
            this.Doors = doors;
        }
        public void SetGearBoxType(GearBoxEnum gearBoxType)
        {
            this.GearBoxType = gearBoxType;
        }
        public void SetEngineSpec(float capacity, int horsePower, FuelTypeEnum fuelType)
        {
            this.EngineSpec = new EngineSpec(capacity, horsePower, fuelType);
        }
        public void SetExtras(Extras extras)
        {
            this.Extras = extras;
        }


    }
}
