using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car_Model
{
    public class NavigationService
    {
        private List<Bookings> reservedCarData;
        private List<Car> allCars; 

        public void StartProgram()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Input a command: (type \"commands\" to list all commands)");

            reservedCarData = new List<Bookings>();
            allCars = new List<Car>();
            string line = Console.ReadLine();
            while (line != "exit")
            {
                ExecuteCommand(line);
                
                Console.WriteLine("------------------------------------------------");
                line = Console.ReadLine();
            }
        }

        void ExecuteCommand(string line)
        {
            var command = line.Split(" ");
            switch (command[0])
            {
                case "addCar":
                        AddCar();
                    break;
                case "removeCar":
                    {
                        Console.WriteLine(RemoveCar());
                    }
                    break;
                case "modifyCar":
                    {
                        ModifyCar();
                    }
                    break;
                case "searchCar":
                    {
                        Console.WriteLine(SearchCar());
                    }
                    break;
                case "removeAllCars":
                    {
                        
                        Console.WriteLine(RemoveAllCars());
                    }
                    break;
                case "reserveCar":
                    {
                        Console.WriteLine(ReserveCar());
                    }
                    break;
                case "cancelReservation":
                    {
                        Console.WriteLine(CancelReservation());
                    }
                    break;
                case "removeAllReservations":
                    {
                        Console.WriteLine(RemoveAllReservations());
                    }
                    break;
                case "listAllCars":
                    {
                        ListAllCars();
                    }
                    break;
                case "listAllReservations":
                    {
                        ListAllReservations();
                    }
                    break;
                case "commands":
                    {
                        ListCommands();
                    }
                    break;
                case "exit":
                    {
                    }
                    break;
                default:
                    Console.WriteLine("Command does not exist");
                    break;
            }
        }

        private void ListCommands()
        {
            Console.WriteLine("addCar");
            Console.WriteLine("removeCar");
            Console.WriteLine("modifyCar");
            Console.WriteLine("searchCar");
            Console.WriteLine("removeAllCars");
            Console.WriteLine("reserveCar");
            Console.WriteLine("cancelReservation");
            Console.WriteLine("removeAllReservations");
            Console.WriteLine("listAllCars");
            Console.WriteLine("listAllReservations");
            Console.WriteLine("\nexit");
        }

        private void AddCar()
        {
            int numberOfParameters = 10;
            string[] command = new string[numberOfParameters];

            var k = new Car();

            Guid id;
            bool checkId = false;

            while (!checkId)
            {
                Console.Write("Enter car ID: ");
                command[0] = Console.ReadLine();
                checkId = Guid.TryParse(command[0], out id);
                if (checkId)
                {
                    k.SetId(id);

                    foreach (var car in allCars)
                    {
                        if (car.Id == id)
                        {
                            Console.WriteLine("Id is already present in the list");
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect id parameter!");
                    continue;
                }
            }

            id = Guid.Parse(command[0]);

            Console.Write("Enter car type: ");
            command[1] = Console.ReadLine();
            var commandCarType = (CarType)Enum.Parse(typeof(CarType), (command[1]));
            k.SetCarType(commandCarType); 

            Console.Write("Enter number of seats: ");
            command[2] = Console.ReadLine();
            var commandSeats = int.Parse(command[2]);
            k.SetSeats(commandSeats);

            Console.Write("Enter brand: ");
            var commandBrand = command[3];
            commandBrand = Console.ReadLine();
            Console.Write("Enter model: ");
            var commandModel = command[4];
            commandModel = Console.ReadLine();
            k.SetBrand(commandBrand, commandModel);

            Console.Write("Enter number of doors: ");
            command[5] = Console.ReadLine();
            var commandDoors = (DoorsEnum)Enum.Parse(typeof(DoorsEnum), (command[5]));
            k.SetDoors(commandDoors);

            Console.Write("Enter gearbox type: ");
            command[6] = Console.ReadLine();
            var commandGearBox = (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), (command[6]));
            k.SetGearBoxType(commandGearBox);

            Console.Write("Enter car engine capacity, horsepower and fuel type: ");
            string enter = Console.ReadLine();
            var engineCommand = enter.Split(" ");
            var capacity = float.Parse(engineCommand[0]);
            var horsePower = int.Parse(engineCommand[1]);
            var fuelType = (FuelTypeEnum)Enum.Parse(typeof(FuelTypeEnum), (engineCommand[2]));
            k.SetEngineSpec(capacity, horsePower, fuelType);
            

            Console.Write("Enter number of extras: ");
            int numberOfExtras = int.Parse(Console.ReadLine());

            while (numberOfExtras < 1 || numberOfExtras > 3)
            {
                Console.Write("Number of extras must be between 1 and 3!");
                numberOfExtras = int.Parse(Console.ReadLine());
            }

            List<string> extras = new List<string>();
            
            for (int i = 0; i < numberOfExtras; i++)
            {
                bool checkExtra = false;
                while (!checkExtra)
                {
                    Console.Write("Enter extra: ");
                    command[i] = Console.ReadLine();
                    var extraEntry = command[i];
                    if (extraEntry == "USB" || extraEntry == "SunRoof" || extraEntry == "HeatedSeat")
                    {
                        checkExtra = true;
                        extras.Add(command[i]);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect extra!");
                        continue;
                    }
                }
                
                k.SetExtras(extras);
            }

            allCars.Add(k);

            Console.WriteLine($"New car with id {id} created.");
        }

        private string RemoveCar()
        {
            Car toDelete = null;
            Console.Write("Enter Id code of car to remove: ");
            Guid Id = Guid.Parse(Console.ReadLine());
            if (allCars.Count != 0)
            {
                foreach (var car in allCars)
                {
                    if (car.Id == Id)
                    {
                        toDelete = car;
                    }
                    else
                    {
                        Console.WriteLine("No such car present!");
                    }
                }
                allCars.Remove(toDelete);
                return "Car " + Id + " has been removed.";
            }
            else
            {
                return "No cars present in list!";
            }
        }

        private string RemoveAllCars()
        {
            Console.Write("Enter parameter to remove all cars by: ");

            string parameterToRemove = Console.ReadLine();

            switch (parameterToRemove)
            {
                case "carType":
                    {
                        Console.Write("Enter car type to remove: ");
                        CarType carType = (CarType)Enum.Parse(typeof(CarType), Console.ReadLine());

                        allCars.RemoveAll(x => x.CarType == carType);
                        return "Cars removed from brand " + carType;
                    }
                case "brand":
                    {
                        Console.Write("Enter brand to remove: ");
                        var brand = Console.ReadLine();

                        allCars.RemoveAll(x => x.Brand == brand);
                        return "Cars removed from brand " + brand;
                    }
                case "model":
                    {
                        Console.Write("Enter model to remove: ");
                        var model = Console.ReadLine();

                        allCars.RemoveAll(x => x.Model == model);
                        return "Cars removed from model " + model;
                    }
                default:
                    {
                        return $"Parameter {parameterToRemove} has not been recognized.";
                    }
            }
        }

        private string ModifyCar()
        {
            Console.Write("Enter Id code: ");
            Guid IdCode = Guid.Parse(Console.ReadLine());
            var result = allCars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (result == null)
            {
                return "There is no such Id of car in the system!";
            }
            else
            {
                Console.Write("Enter parameter to modify: ");

                string parameterToModify = Console.ReadLine();

                switch (parameterToModify)
                {
                    case "id":
                        {
                            return "Id cannot be modified";
                        }
                    case "carType":
                        {
                            Console.Write("Enter car type: ");
                            CarType carType = (CarType)Enum.Parse(typeof(CarType), Console.ReadLine());

                            result.CarType = carType;
                        }
                        break;
                    case "seats":
                        {
                            Console.Write("Enter number of seats: ");
                            var seats = int.Parse(Console.ReadLine());

                            result.Seats = seats;
                        }
                        break;
                    case "doors":
                        {
                            Console.Write("Enter number of doors: ");
                            var doors = (DoorsEnum)Enum.Parse(typeof(DoorsEnum), Console.ReadLine());

                            result.Doors = doors;
                        }
                        break;
                    case "gear":
                        {
                            Console.Write("Enter gear: ");
                            var gear = (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), Console.ReadLine());

                            result.GearBoxType = gear;
                        }
                        break;
                    default:
                        {
                            return $"Parameter {parameterToModify} has not been recognized.";
                        }
                }
            }
            return "Car has been modified.";
        }

        private string SearchCar()
        {
            Console.Write("Enter car Id to be searched: ");
            Guid Id = Guid.Parse(Console.ReadLine());
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
                return "Car found and present in list.";
            }
            else
            {
                return "Car not found.";
            }
        }

        private string AddReservation(Guid IdCode)
        {
            var t = new Bookings();
            string[] command = new string[3];

            string id = IdCode.ToString();
            command[0] = id;
            var commandBookedCarId = Guid.Parse(command[0]);
            t.SetBookedCar(commandBookedCarId);

            Console.Write("Enter start date: ");
            command[1] = Console.ReadLine();
            var commandDate = DateTime.Parse(command[1]);
            t.SetDate(commandDate);

            Console.Write("Enter client information: ");
            command[2] = Console.ReadLine();
            var commandClientInformation = command[2];
            t.SetClientInformation(commandClientInformation);

            Console.Write("Enter rental period in days and total rental price for the period: ");
            string enter = Console.ReadLine();
            var rentalCommand = enter.Split(" ");
            var period = int.Parse(rentalCommand[0]);
            var price = decimal.Parse(rentalCommand[1]);
            t.SetRentalInfo(period, price);

            reservedCarData.Add(t);

            return "Car has been added to reservation list.";
        }
        private string ReserveCar()
        {
            Console.Write("Enter Id code of car to reserve: ");
            Guid IdCode = Guid.Parse(Console.ReadLine());

            var result = allCars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (result == null)
            {
                return "There is no such Id of car in the system!";
            }

            var reservedResult = reservedCarData.Where(x => x.BookedCar.Id == IdCode).SingleOrDefault();

            if (reservedResult == null)
            {
                AddReservation(IdCode);
            }
            else
            {
                return "Car has already been reserved.";
            }

            return "Reservation process has ended.";
        }

        private string CancelReservation()
        {
            Console.Write("Enter Id code of car to cancel reservation: ");
            Guid IdCode = Guid.Parse(Console.ReadLine());

            var result = allCars.Where(x => x.Id == IdCode).SingleOrDefault();

            if (result == null)
            {
                return "There is no such Id of car in the system!";
            }

            var reservedResult = reservedCarData.Where(x => x.BookedCar.Id == IdCode).SingleOrDefault();

            if (reservedResult == null)
            {
                return $"The car with id {IdCode} is not the reservation list.";
            }
            else
            {
                reservedCarData.Remove(reservedResult);
            }

            return "Car has been removed from the reservation list.";
        }

        private string RemoveAllReservations()
        {
            Console.Write("Enter parameter to remove all reservations by: ");

            string parameterToRemove = Console.ReadLine();

            switch (parameterToRemove)
            {
                case "period":
                    {
                        Console.Write("Enter period to remove by: ");
                        var period = int.Parse(Console.ReadLine());

                        reservedCarData.RemoveAll(x => x.RentalInfo.Period == period);
                        return "Reservations removed for period: " + period;
                    }
                case "startDate":
                    {
                        Console.Write("Enter start date to remove by: ");
                        DateTime startDate = DateTime.Parse(Console.ReadLine());

                        reservedCarData.RemoveAll(x => x.StartDate == startDate);
                        return "Reservations removed for start date: " + startDate;
                    }
                
                default:
                    {
                        return $"Parameter {parameterToRemove} has not been recognized.";
                    }
            }
        }

        private void ListAllCars()
        {
            foreach (var car in allCars)
            {
                Console.WriteLine("Id: " + car.Id);
                Console.WriteLine("Car Type: " + car.CarType);
                Console.WriteLine("Seats: " + car.Seats);
                Console.WriteLine("Brand: " + car.Brand);
                Console.WriteLine("Model: " + car.Model);
                Console.WriteLine("Doors: " + car.Doors);
                Console.WriteLine("Gear Box: " + car.GearBoxType);
                Console.WriteLine("Capacity: " + car.EngineSpec.Capacity);
                Console.WriteLine("Horsepower: " + car.EngineSpec.HorsePower);
                Console.WriteLine("Fuel Type: " + car.EngineSpec.FuelType);

                foreach (var extra in car.Extras.Extras)
                {
                    Console.Write("Extra: ");
                    Console.WriteLine(extra);
                }
                Console.WriteLine();
            }
        }

        private void ListAllReservations()
        {
            foreach (var reservation in reservedCarData)
            {
                Console.WriteLine("Booked Car Id: " + reservation.BookedCar.Id);
                Console.WriteLine("Start Date: " + reservation.StartDate);
                Console.WriteLine("Client Additional Information: " + reservation.ClientAdditionalInformation);
                Console.WriteLine("Period in days: " + reservation.RentalInfo.Period);
                Console.WriteLine("Price per day: " + reservation.RentalInfo.PricePerDay);
                Console.WriteLine("Total price: " + reservation.RentalInfo.TotalPrice);
                Console.WriteLine();
            }
        }

    }
}
