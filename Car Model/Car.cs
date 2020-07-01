using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class Car
    {
        private string name;
        private List<Car> cars;

        public Car(Guid id, CarType carType, int seats, DoorsEnum doorsEnum, GearBoxEnum gearboxEnum, EngineSpec engineSpec, ICollection<Extras> extras )
        {
            this.Id = id;
            this.CarType = carType;
            this.Seats = seats;
            this.Doors = doorsEnum;
            this.GearBoxType = gearboxEnum;
            this.EngineSpec = engineSpec;
            this.Extras = new List<Extras>(extras);
        }

        public Car(string name)
        {
            this.name = Name;
            this.cars = new List<Car>();
        }

        public Guid Id { get; set; }
        public CarType CarType { get; set; }
        public int Seats { get; set; }
        public DoorsEnum Doors { get; set; }
        public GearBoxEnum GearBoxType { get; set; }
        public EngineSpec EngineSpec { get; set; }
        public ICollection<Extras> Extras { get; set; }

        private static List<Car> listOfCars = new List<Car>();
      
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Car> Cars
        {
            get { return listOfCars; }
            set { listOfCars = value; }
        }

        public string AddCar(Car car)
        {
            listOfCars.Add(car);
            return "Car added.";
        }

    }
}
