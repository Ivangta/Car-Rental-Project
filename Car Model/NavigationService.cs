﻿using System;
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
                
                Console.WriteLine("------------------------------------------------");
                line = Console.ReadLine();
            }
        }

        public void ExecuteCommand(string line, Car cars)
        {
            var command = line.Split(" ");
            switch (command[0])
            {
                case "AddCar":
                    {
                        AddCar();
                    }
                    break;
                case "RemoveCar":
                    {
                        Console.WriteLine(RemoveCar());
                    }
                    break;
                case "ModifyCar":
                    {
                        ModifyCar();
                    }
                    break;
                case "SearchCar":
                    {
                        Console.WriteLine(SearchCar());
                    }
                    break;
                case "RemoveAllCars":
                    {
                        
                        Console.WriteLine(RemoveAllCars());
                    }
                    break;
                case "ReserveCar":
                    {
                        Console.WriteLine(ReserveCar());
                    }
                    break;
                case "CancelReservation":
                    {
                        Console.WriteLine(CancelReservation());
                    }
                    break;
                case "ListAllCars":
                    {
                        ListAllCars();
                    }
                    break;
                case "ListAllReservations":
                    {
                        ListAllReservations();
                    }
                    break;
            }
        }

        private void AddCar()
        {
            var k = new Car();
            string[] command = new string[8];

            Console.WriteLine("Enter Car ID: ");
            command[0] = Console.ReadLine();
            var commandId = Guid.Parse(command[0]);
            k.SetId(commandId);

            Console.WriteLine("Enter car type: ");
            command[1] = Console.ReadLine();
            var commandCarType = (CarType)Enum.Parse(typeof(CarType), (command[1]));
            k.SetCarType(commandCarType); 

            Console.WriteLine("Enter number of seats: ");
            command[2] = Console.ReadLine();
            var commandSeats = int.Parse(command[2]);
            k.SetSeats(commandSeats);

            Console.WriteLine("Enter brand: ");
            var commandBrand = command[3];
            commandBrand = Console.ReadLine();
            Console.WriteLine("Enter model: ");
            var commandModel = command[4];
            commandModel = Console.ReadLine();
            k.SetBrand(commandBrand, commandModel);

            Console.WriteLine("Enter number of doors: ");
            command[5] = Console.ReadLine();
            var commandDoors = (DoorsEnum)Enum.Parse(typeof(DoorsEnum), (command[5]));
            k.SetDoors(commandDoors);

            Console.WriteLine("Enter gearbox type: ");
            command[6] = Console.ReadLine();
            var commandGearBox = (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), (command[6]));
            k.SetGearBoxType(commandGearBox);

            Console.WriteLine("Enter Car Engine capacity, horsepower and fuel type: ");
            string enter = Console.ReadLine();
            var engineCommand = enter.Split(" ");
            var capacity = float.Parse(engineCommand[0]);
            var horsePower = int.Parse(engineCommand[1]);
            var fuelType = (FuelTypeEnum)Enum.Parse(typeof(FuelTypeEnum), (engineCommand[2]));
            k.SetEngineSpec(capacity, horsePower, fuelType);

            Console.WriteLine("Enter extras: ");
            command[7] = Console.ReadLine();
            var commandExtras = (Extras)Enum.Parse(typeof(Extras), (command[7]));
            k.SetExtras(commandExtras);

            allCars.Add(k);
        }

        public string RemoveCar()
        {
            Car toDelete = null;
            Console.WriteLine("Enter Id code of car to remove: ");
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
                        Console.WriteLine("No such car present");
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

        public string RemoveAllCars()
        {
             Console.WriteLine("Enter brand to remove: ");
             string brand = Console.ReadLine();
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
                return "There is no such Id of car in the system!";
            }
            else
            {
                Console.Write("Enter parameter to modify: ");

                string parameterToModify = Console.ReadLine();

                switch (parameterToModify)
                {
                    case "Id":
                        {
                            return "Id cannot be modified";
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

        public string SearchCar()
        {
            Console.WriteLine("Enter car Id to be searched: ");
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

        public void AddReservation(Guid IdCode)
        {
            var t = new Bookings();
            string[] command = new string[3];

            string id = IdCode.ToString();
            command[0] = id;
            var commandBookedCarId = Guid.Parse(command[0]);
            t.SetBookedCar(commandBookedCarId);

            Console.WriteLine("Enter start date: ");
            command[1] = Console.ReadLine();
            var commandDate = DateTime.Parse(command[1]);
            t.SetDate(commandDate);

            Console.WriteLine("Enter client information: ");
            command[2] = Console.ReadLine();
            var commandClientInformation = command[1];
            t.SetClientInformation(commandClientInformation);

            Console.WriteLine("Enter Rental Period and Price: ");
            string enter = Console.ReadLine();
            var rentalCommand = enter.Split(" ");
            var period = int.Parse(rentalCommand[0]);
            var price = decimal.Parse(rentalCommand[1]);
            t.SetRentalInfo(period, price);

            reservedCarData.Add(t);
        }
        public string ReserveCar()
        {
            Console.WriteLine("Enter Id code of car to reserve: ");
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
                //reservedCarData.Add(reservedResult);
            }
            else
            {
                return "Car has already been reserved.";
            }

            return "Reservation process has ended.";
        }

        public string CancelReservation()
        {
            Console.WriteLine("Enter Id code of car to cancel reservation: ");
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

        public void ListAllCars()
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
                Console.WriteLine("Extras: " + car.Extras);
            }
        }

        public void ListAllReservations()
        {
            foreach (var reservation in reservedCarData)
            {
                Console.WriteLine("Booked Car Id: " + reservation.BookedCar.Id);
                Console.WriteLine("Start Date: " + reservation.StartDate);
                Console.WriteLine("Client Additional Information: " + reservation.ClientAdditionalInformation);
                Console.WriteLine("Brand: " + reservation.RentalInfo);
            }
        }

    }
}
