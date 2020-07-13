using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class NavigationService
    {
        EngineSpec currentEngineSpec;
        ICollection<Extras> currentExtras;


        List<Bookings> data; //for renting
        ICollection<Car> allCars; //for cars

        public void StartProgram()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Input a command: (type \"commands\" to list all commands)");

            data = new List<Bookings>();
            allCars = new List<Car>();
            Car car = new Car("Best Dealers");
            string line = Console.ReadLine();
            while (line != "End")
            {
                ExecuteCommand(line, car);
                line = Console.ReadLine();
                
                Console.WriteLine("------------------------------------------------");
            }
        }

        public void ExecuteCommand(string line, Car cars)
        {
            var command = line.Split(" ");
            switch (command[0])
            {
                case "AddCar":
                    {
                        var k = new Car();
                        Console.WriteLine("Enter Car ID");
                        line = Console.ReadLine();
                        k.SetID(line);
                        Console.WriteLine("Enter Car Engine");
                        line = Console.ReadLine();
                        var engineCommand = line.Split(" ");
                        k.SetEngine(engineCommand[0], engineCommand[1], engineCommand[2]);
                        AddCar(new Car(Guid.Parse(command[0]), (CarType)Enum.Parse(typeof(CarType), (command[1])), int.Parse(command[2]), (DoorsEnum)Enum.Parse(typeof(DoorsEnum), (command[3])),
                            (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), (command[4])), currentEngineSpec, currentExtras));
                        allCars.Add(k);
                    }
                    break;
                case "RemoveCar":
                    {
                        RemoveCar(Guid.Parse(command[0]));
                    }
                    break;
                case "ModifyCar":
                    {
                        cars.ModifyCar();
                    }
                    break;
                case "SearchCar":
                    {
                        cars.SearchCar(Guid.Parse(command[0]));
                    }
                    break;
                case "RemoveAllCars":
                    {
                        cars.RemoveAllCars()
                    }
                    break;
                case "ReserveCar":
                    {
                        cars.ReserveCar(reservedCar);
                    }
                    break;
                case "CancelReservation":
                    {
                        cars.CancelReservation(reservedCar);
                    }
                    break;
            }
           
        }


        public string AddCar(Car car)
        {
            cars.Add(car);
            return "Car " + car.Id + " added.";
        }

        public string RemoveCar(Guid ID)
        {
            Car toDelete = null;
            foreach (var car in allCars)
            {
                if (car.Id == ID) toDelete = car;
            }
            allCars.Remove(toDelete);
            return "Car " + ID + " has been removed.";
        }


    }



}
