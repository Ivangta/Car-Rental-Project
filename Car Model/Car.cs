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
        private List<Car> reservedCars;

        public Car()
        {
            this.Id = id;
            this.CarType = carType;
            this.Seats = seats;
            this.GearBoxType = gearboxEnum;
            this.EngineSpec = engineSpec;
            this.Extras = new List<Extras>(extras);
        }

        public Car(string name)
            
        {
            this.name = Name;
            this.cars = new List<Car>();
        }
        public void SetDoors(DoorsEnum doors)
        {
            this.Doors = doors;
        }

        public void SetBrand(string brand, string model)
        {
            this.Brand = brand;
            this.Model = model;
        }

        public Guid Id { get; set; }
        public CarType CarType { get; set; }
        public int Seats { get; set; }
        public string Brand { get; set;  }
        public string Model { get; set }
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
        public string RemoveAllCars(Guid id)
        {
            int numberOfCarsBeforeRemoval = cars.Count;
            cars.RemoveAll(x => x.Id == id);
            return "Cars Removed";
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

        public string ReserveCar(Car reservedCar)
        {
            Console.Write("Enter Id code of car: ");

            Guid IdCode = Guid.Parse(Console.ReadLine());
            var result = cars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (result == null)
            {
                throw new ArgumentNullException("There is no such Id of car in the system!");
            }

            var reservedResult = reservedCars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (reservedResult == null)
            {
                reservedCars.Add(reservedCar);
            }
            else
            {
                throw new ArgumentException("Car has already been reserved.");
            }

            return "Reservation process has ended.";
        }

        public string CancelReservation(Car reservedCar)
        {
            Console.Write("Enter Id code of car: ");

            Guid IdCode = Guid.Parse(Console.ReadLine());
            var result = cars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (result == null)
            {
                throw new ArgumentNullException("There is no such Id of car in the system!");
            }

            var reservedResult = reservedCars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (reservedResult == null)
            {
                throw new ArgumentNullException($"The car with id {Id} is not the reservation list.");
            }
            else
            {
                reservedCars.Remove(reservedCar);
            }

            return "Car has been removed from the reservation list.";
        }

        public string ModifyCar()
        {
            Console.Write("Enter Id code: ");
            Guid IdCode = Guid.Parse(Console.ReadLine());
            var result = cars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (result == null)
            {
                throw new ArgumentNullException("There is no such Id of car in the system!");
            }
            else
            {
                Console.Write("Enter parameter to modify: ");

                string parameterToModify = Console.ReadLine();

                switch (parameterToModify)
                {
                    case "Id":
                        {
                            throw new ArgumentException("Id cannot be modified");
                        }
                    case "CarType":
                        {
                            Console.Write("Enter car type: ");
                            CarType carType = (CarType)Enum.Parse(typeof(CarType), Console.ReadLine());

                            result.CarType = carType;

                        }
                        break;
                    case "Seats":
                        {
                            Console.Write("Enter number of seats: ");
                            var seats = int.Parse(Console.ReadLine());

                            result.Seats = seats;
                        }
                        break;
                    case "Doors":
                        {
                            Console.Write("Enter number of doors: ");
                            var doors = (DoorsEnum)Enum.Parse(typeof(DoorsEnum), Console.ReadLine());

                            result.Doors = doors;
                        }
                        break;
                    case "Gear":
                        {
                            Console.Write("Enter number of doors: ");
                            var gear = (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), Console.ReadLine());

                            result.GearBoxType = gear;
                        }
                        break;
                    default:
                        {
                            throw new ArgumentException($"Parameter {parameterToModify} has not been recognized.");

                        }
                }
            }
            return "Car has been modified.";
        }
            
    }
}
