using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car_Model
{
    public class NavigationService
    {
        List<Bookings> reservedCarData; //for renting
        List<Car> allCars; //for cars, changed to List from ICollection

        public void StartProgram()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Input a command: (type \"commands\" to list all commands)");

            reservedCarData = new List<Bookings>();
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
            string[] command = new string[20];
            command = line.Split(" ");
            switch (command[0])
            {
                case "AddCar":
                    {
                        AddCar(command);
                    }
                    break;
                case "RemoveCar":
                    {
                        RemoveCar(Guid.Parse(command[1]));
                    }
                    break;
                case "ModifyCar":
                    {
                        ModifyCar();
                    }
                    break;
                case "SearchCar":
                    {
                        SearchCar(Guid.Parse(command[1]));
                    }
                    break;
                case "RemoveAllCars":
                    {
                        Console.WriteLine("Enter brand to remove: ");
                        RemoveAllCars(command[1]);
                    }
                    break;
                case "ReserveCar":
                    {
                        Console.WriteLine("Enter Id code of car to reserve: ");
                        ReserveCar(Guid.Parse(command[1]));
                    }
                    break;
                case "CancelReservation":
                    {
                        Console.WriteLine("Enter Id code of car to cancel reservation: ");
                        CancelReservation(Guid.Parse(command[1]));
                    }
                    break;
            }
           
        }

        private void AddCar(string[] command)
        {
            var k = new Car();
            Console.WriteLine("Enter Car ID: ");
            var commandId = Guid.Parse(command[1]);
            commandId = Guid.Parse(Console.ReadLine());
            k.SetId(commandId);

            Console.WriteLine("Enter car type: ");
            var commandCarType = (CarType)Enum.Parse(typeof(CarType), (command[2]));
            commandCarType = (CarType)Enum.Parse(typeof(CarType), Console.ReadLine());
            k.SetCarType(commandCarType);

            Console.WriteLine("Enter number of seats: ");
            var commandSeats = int.Parse(command[3]);
            commandSeats = int.Parse(Console.ReadLine());
            k.SetSeats(commandSeats);

            Console.WriteLine("Enter brand: ");
            var commandBrand = command[4];
            Console.WriteLine("Enter model: ");
            commandBrand = Console.ReadLine();
            var commandModel = command[5];
            commandModel = Console.ReadLine();
            k.SetBrand(commandBrand, commandModel);

            Console.WriteLine("Enter number of doors: ");
            var commandDoors = (DoorsEnum)Enum.Parse(typeof(DoorsEnum), (command[6]));
            commandDoors = (DoorsEnum)Enum.Parse(typeof(DoorsEnum), Console.ReadLine());
            k.SetDoors(commandDoors);

            Console.WriteLine("Enter gearbox type: ");
            var commandGearBox = (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), (command[7]));
            commandGearBox = (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), Console.ReadLine());
            k.SetGearBoxType(commandGearBox);

            Console.WriteLine("Enter Car Engine capacity, horsepower and fuel type: ");
            string enter = Console.ReadLine();
            var engineCommand = enter.Split(" ");
            var capacity = float.Parse(engineCommand[0]);
            capacity = float.Parse(Console.ReadLine());
            var horsePower = int.Parse(engineCommand[1]);
            horsePower = int.Parse(Console.ReadLine());
            horsePower = int.Parse(Console.ReadLine());
            var fuelType = (FuelTypeEnum)Enum.Parse(typeof(FuelTypeEnum), (engineCommand[2]));
            fuelType = (FuelTypeEnum)Enum.Parse(typeof(FuelTypeEnum), Console.ReadLine());
            k.SetEngineSpec(capacity, horsePower, fuelType);

            Console.WriteLine("Enter extras: ");
            var commandExtras = (Extras)Enum.Parse(typeof(Extras), (command[8]));
            commandExtras = (Extras)Enum.Parse(typeof(Extras), Console.ReadLine());
            k.SetExtras(commandExtras);

            allCars.Add(k);
        }

        public string RemoveCar(Guid Id)
        {
            Car toDelete = null;
            foreach (var car in allCars)
            {
                if (car.Id == Id) toDelete = car;
            }
            allCars.Remove(toDelete);
            return "Car " + Id + " has been removed.";
        }

        public string RemoveAllCars(string brand)
        {
             allCars.RemoveAll(x => x.Brand == brand);
             return "Cars Removed from brand " + brand;
        }

        public string ModifyCar()
        {
            Console.Write("Enter Id code: ");
            Guid IdCode = Guid.Parse(Console.ReadLine());
            var result = allCars.Where(x => x.Id == IdCode).SingleOrDefault();

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

        public string SearchCar(Guid Id)
        {
            bool isCarFound = false;

            foreach (Car car in allCars)
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

        public string ReserveCar(Guid IdCode)
        {
            var result = allCars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (result == null)
            {
                throw new ArgumentNullException("There is no such Id of car in the system!");
            }

            var reservedResult = reservedCarData.Where(x => x.BookedCar.Id == IdCode).SingleOrDefault();

            if (reservedResult == null)
            {
                reservedCarData.Add(reservedResult);
            }
            else
            {
                throw new ArgumentException("Car has already been reserved.");
            }

            return "Reservation process has ended.";
        }

        public string CancelReservation(Guid IdCode)
        {
            var result = allCars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (result == null)
            {
                throw new ArgumentNullException("There is no such Id of car in the system!");
            }

            var reservedResult = reservedCarData.Where(x => x.BookedCar.Id == IdCode).SingleOrDefault();

            if (reservedResult == null)
            {
                throw new ArgumentNullException($"The car with id {IdCode} is not the reservation list.");
            }
            else
            {
                reservedCarData.Remove(reservedResult);
            }

            return "Car has been removed from the reservation list.";
        }

    }
}
