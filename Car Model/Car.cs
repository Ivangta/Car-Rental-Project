using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        //private static List<Car> listOfCars = new List<Car>();
      
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        public string AddCar(Car car)
        {
            cars.Add(car);
            return "Car added.";
        }

        public string SearchCar(Guid Id)
        {
            bool isCarFound = false;

            foreach (Car car in cars)
            {
                if (car.Id.Equals(Id))
                {
                    isCarFound = true;
                }
            }
            if (isCarFound)
            {
                return "Car found.";
            }
            else
            {
                return "Car not found.";
            }
        }

        public string ModifyCar()
        {
            Console.Write("Enter Id code: ");
            Guid IdCode = Guid.Parse(Console.ReadLine());
            var result = cars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (result == null)
            {
                throw new ArgumentNullException("There is no such Id in the system!");
            }
            else
            {
                Console.Write("Enter parameter to modify ")
            }
        }

    }
}
