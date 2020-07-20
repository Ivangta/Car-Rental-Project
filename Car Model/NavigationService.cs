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
                        RemoveCar();
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
                        RemoveAllCars();
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
                        RemoveAllReservations();
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
                Console.WriteLine("-------------------");
                Console.Write("Enter car ID: ");
                command[0] = Console.ReadLine();
                checkId = Guid.TryParse(command[0], out id);

                if (checkId)
                {
                    k.SetId(id);
                    Console.WriteLine("-------------------");
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
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }

            id = Guid.Parse(command[0]);

            CarType carType;
            bool checkCarType = false;

            while (!checkCarType)
            {
                Console.Write("Enter car type from options: ");
                Console.WriteLine("\n" + "1.Sedan" + "\n" + "2.Combi" + "\n" + "3.Hatchback" + "\n" + "4.SUV");
                Console.WriteLine("-------------------");
                command[1] = Console.ReadLine();
                checkCarType = Enum.TryParse(command[1], out carType);

                if (checkCarType)
                {
                    k.SetCarType(carType);
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }

            int seats;
            bool checkSeats = false;

            while (!checkSeats)
            {
                Console.WriteLine("-------------------");
                Console.Write("Enter number of seats: ");
                command[2] = Console.ReadLine();
                checkSeats = int.TryParse(command[2], out seats);

                if (checkSeats)
                {
                    k.SetSeats(seats);
                    Console.WriteLine("-------------------");
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }

            Console.Write("Enter brand: ");
            var commandBrand = command[3];
            commandBrand = Console.ReadLine();
            Console.WriteLine("-------------------");
            Console.Write("Enter model: ");
            var commandModel = command[4];
            commandModel = Console.ReadLine();
            k.SetBrand(commandBrand, commandModel);
            Console.WriteLine("-------------------");



            DoorsEnum numberOfDoors;
            bool checkDoors = false;

            while (!checkDoors)
            {
                Console.Write("Enter number of doors from options: ");
                Console.WriteLine("\n" + "1.Two" + "\n" + "2.Four");
                Console.WriteLine("-------------------");
                command[5] = Console.ReadLine();
                checkDoors = Enum.TryParse(command[5], out numberOfDoors);

                if (checkDoors)
                {
                    k.SetDoors(numberOfDoors);
                    Console.WriteLine("-------------------");
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }


            GearBoxEnum gearBoxType;
            bool checkGearBox = false;

            while (!checkGearBox)
            {
                Console.Write("Enter gearbox type from options: ");
                Console.WriteLine("\n" + "1.Manual" + "\n" + "2.Automatic" + "\n" + "3.Combined");
                Console.WriteLine("-------------------");
                command[6] = Console.ReadLine();
                checkGearBox = Enum.TryParse(command[6], out gearBoxType);

                if (checkGearBox)
                {
                    k.SetGearBoxType(gearBoxType);
                    Console.WriteLine("-------------------");
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }

            float capacity;
            int horsePower;
            FuelTypeEnum fuelType;
            bool checkCapacity = false;
            bool checkHorsePower = false;
            bool checkFuelType = false;

            while (!checkCapacity || !checkHorsePower || !checkFuelType)
            {
                Console.Write("Enter car engine capacity, horsepower and fuel type: ");
                Console.WriteLine("\n" + "Fuel type options:" + "\n" + "1.Petrol" + "\n" + "2.LPG" + "\n" + "3.Diesel" + "\n" + "4.Electric");
                Console.WriteLine("-------------------");
                string enter = Console.ReadLine();
                var engineCommand = enter.Split(" ");
                checkCapacity = float.TryParse(engineCommand[0], out capacity);
                checkHorsePower = int.TryParse(engineCommand[1], out horsePower);
                checkFuelType = Enum.TryParse(engineCommand[2], out fuelType);

                if (checkCapacity && checkHorsePower && checkFuelType)
                {
                    k.SetEngineSpec(capacity, horsePower, fuelType);
                    Console.WriteLine("-------------------");
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }

            Console.Write("Enter number of extras: ");
            int numberOfExtras = int.Parse(Console.ReadLine());

            while (numberOfExtras < 1 || numberOfExtras > 3)
            {
                Console.WriteLine("Number of extras must be between 1 and 3!");
                Console.Write("Enter number of extras: ");
                numberOfExtras = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("-------------------");

            List<string> extras = new List<string>();
            
            for (int i = 0; i < numberOfExtras; i++)
            {
                bool checkExtra = false;
                while (!checkExtra)
                {
                    Console.Write("Enter extra from options: ");
                    Console.WriteLine("\n" + "1.USB" + "\n" + "2.SunRoof" + "\n" + "3.HeatedSeat");
                    Console.WriteLine("-------------------");
                    command[i] = Console.ReadLine();
                    var extraEntry = command[i];
                    if (extraEntry == "USB" || extraEntry == "SunRoof" || extraEntry == "HeatedSeat")
                    {
                        checkExtra = true;
                        extras.Add(command[i]);
                        Console.WriteLine("-------------------");
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

        private void RemoveCar()
        {
            Guid idCode;
            string idEntry;
            bool checkId = false;

            while (!checkId)
            {
                Console.WriteLine("-------------------");
                Console.Write("Enter car ID: ");
                idEntry = Console.ReadLine();
                checkId = Guid.TryParse(idEntry, out idCode);

                if (checkId)
                {
                    Car toDelete = null;
                    var result = allCars.Where(x => x.Id == idCode).SingleOrDefault();

                    if (result == null)
                    {
                        Console.WriteLine("There is no such Id of car in the system!");
                    }
                    else
                    {
                        if (allCars.Count != 0)
                        {
                            foreach (var car in allCars)
                            {
                                if (car.Id == idCode)
                                {
                                    toDelete = car;
                                }
                                else
                                {
                                    Console.WriteLine("No such car present!");
                                }
                            }
                            allCars.Remove(toDelete);
                            Console.WriteLine("Car " + idCode + " has been removed.");
                        }
                        else
                        {
                            Console.WriteLine("No cars present in list!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }
        }

        private void RemoveAllCars()
        {
            Console.Write("Enter parameter to remove all cars by: ");
            string parameterToRemove = Console.ReadLine();

            switch (parameterToRemove)
            {
                case "carType":
                    {
                        CarType carType;
                        bool checkCarType = false;

                        while (!checkCarType)
                        {
                            Console.Write("Enter car type from options: ");
                            Console.WriteLine("\n" + "1.Sedan" + "\n" + "2.Combi" + "\n" + "3.Hatchback" + "\n" + "4.SUV");
                            Console.WriteLine("-------------------");
                            string carTypeEntry = Console.ReadLine();
                            checkCarType = Enum.TryParse(carTypeEntry, out carType);

                            if (checkCarType)
                            {
                                allCars.RemoveAll(x => x.CarType == carType);
                                Console.WriteLine("All cars under car type " + carType + " are removed.");
                                Console.WriteLine("-------------------");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect parameter!");
                                continue;
                            }
                        }
                    }
                    break;
                case "brand":
                    {
                        Console.Write("Enter brand to remove: ");
                        var brand = Console.ReadLine();

                        bool brandExists = allCars.Exists(item => item.Brand == brand);

                        if (brandExists)
                        {
                            allCars.RemoveAll(x => x.Brand == brand);
                            Console.WriteLine("Cars removed from brand " + brand);
                        }
                        else
                        {
                            Console.WriteLine("There is no such brand!");
                        }
                    }
                    break;
                case "model":
                    {
                        Console.Write("Enter model to remove: ");
                        var model = Console.ReadLine();

                        bool modelExists = allCars.Exists(item => item.Model == model);

                        if (modelExists)
                        {
                            allCars.RemoveAll(x => x.Model == model);
                            Console.WriteLine("Cars removed from brand " + model);
                        }
                        else
                        {
                            Console.WriteLine("There is no such model!");
                        }
                    }
                    break;
                default:
                    {
                        Console.WriteLine($"Parameter {parameterToRemove} has not been recognized.");
                    }
                    break;
            }
        }

        private void ModifyCar()
        {
            Guid idCode;
            string idEntry;
            bool checkId = false;

            while (!checkId)
            {
                Console.WriteLine("-------------------");
                Console.Write("Enter car ID: ");
                idEntry = Console.ReadLine();
                checkId = Guid.TryParse(idEntry, out idCode);

                if (checkId)
                {
                    var result = allCars.Where(x => x.Id == idCode).SingleOrDefault();

                    if (result == null)
                    {
                        Console.WriteLine("There is no such Id of car in the system!");
                    }
                    else
                    {
                        Console.Write("Enter parameter to modify: ");

                        string parameterToModify = Console.ReadLine();

                        switch (parameterToModify)
                        {
                            case "id":
                                {
                                    Console.WriteLine("Id cannot be modified");
                                }
                                break;
                            case "carType":
                                {
                                    CarType carType;
                                    bool checkCarType = false;

                                    while (!checkCarType)
                                    {
                                        Console.Write("Enter car type from options: ");
                                        Console.WriteLine("\n" + "1.Sedan" + "\n" + "2.Combi" + "\n" + "3.Hatchback" + "\n" + "4.SUV");
                                        Console.WriteLine("-------------------");
                                        string carTypeEntry = Console.ReadLine();
                                        checkCarType = Enum.TryParse(carTypeEntry, out carType);

                                        if (checkCarType)
                                        {
                                            result.CarType = carType;
                                            Console.WriteLine("Parameter modified.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Incorrect parameter!");
                                            continue;
                                        }
                                    }
                                }
                                break;
                            case "seats":
                                {
                                    int seats;
                                    string seatsEntry;
                                    bool checkSeats = false;

                                    while (!checkSeats)
                                    {
                                        Console.WriteLine("-------------------");
                                        Console.Write("Enter number of seats: ");
                                        seatsEntry = Console.ReadLine();
                                        checkSeats = int.TryParse(seatsEntry, out seats);

                                        if (checkSeats)
                                        {
                                            result.Seats = seats;
                                            Console.WriteLine("Parameter modified.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Incorrect parameter!");
                                            continue;
                                        }
                                    }
                                }
                                break;
                            case "doors":
                                {
                                    DoorsEnum doorsEnum;
                                    bool checkDoors = false;

                                    while (!checkDoors)
                                    {
                                        Console.Write("Enter doors from options: ");
                                        Console.WriteLine("\n" + "1.Two" + "\n" + "2.Four");
                                        Console.WriteLine("-------------------");
                                        string doorsEntry = Console.ReadLine();
                                        checkDoors = Enum.TryParse(doorsEntry, out doorsEnum);

                                        if (checkDoors)
                                        {
                                            result.Doors = doorsEnum;
                                            Console.WriteLine("Parameter modified.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Incorrect parameter!");
                                            continue;
                                        }
                                    }
                                }
                                break;
                            case "gear":
                                {
                                    GearBoxEnum gearBoxEnum;
                                    bool checkGearBox = false;

                                    while (!checkGearBox)
                                    {
                                        Console.Write("Enter gearbox from options: ");
                                        Console.WriteLine("\n" + "1.Manual" + "\n" + "2.Automatic" + "\n" + "3.Combined");
                                        Console.WriteLine("-------------------");
                                        string gearBoxEntry = Console.ReadLine();
                                        checkGearBox = Enum.TryParse(gearBoxEntry, out gearBoxEnum);

                                        if (checkGearBox)
                                        {
                                            result.GearBoxType = gearBoxEnum;
                                            Console.WriteLine("Parameter modified.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Incorrect parameter!");
                                            continue;
                                        }
                                    }
                                }
                                break;
                            default:
                                {
                                    Console.WriteLine($"Parameter {parameterToModify} has not been recognized.");
                                }
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }
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

            Console.Write("Enter rental period in days: ");
            string enter = Console.ReadLine();
            var rentalCommand = enter.Split(" ");
            var period = int.Parse(rentalCommand[0]);
            var pricePerDay = 0;

            pricePerDay = CalculationOfTotalPrice(period, pricePerDay);

            var totalPrice = 0;

            t.SetRentalInfo(period, pricePerDay, totalPrice);

            reservedCarData.Add(t);

            return "Car has been added to reservation list.";
        }

        private int CalculationOfTotalPrice(int period, int pricePerDay)
        {

            if (period < 3)
            {
                pricePerDay = 100;
            }
            else if (period >= 3 && period <= 10)
            {
                pricePerDay = 80;
            }
            else if (period > 10 || period <= 20)
            {
                pricePerDay = 60;
            }
            else if (period > 20)
            {
                pricePerDay = 50;
            }

            return pricePerDay;
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

        private void RemoveAllReservations()
        {
            Console.Write("Enter parameter to remove all reservations by: ");

            string parameterToRemove = Console.ReadLine();

            switch (parameterToRemove)
            {
                case "startDate":
                    {
                        Console.Write("Enter start date to remove by: ");
                        DateTime startDate = DateTime.Parse(Console.ReadLine());

                        bool dateExists = reservedCarData.Exists(item => item.StartDate == startDate);

                        if (dateExists)
                        {
                            reservedCarData.RemoveAll(x => x.StartDate == startDate);
                            Console.WriteLine("Reservations removed for start date: " + startDate);
                        }
                        else
                        {
                            Console.WriteLine("There is no such start date present!");
                        }
                    }
                    break;
                default:
                    {
                        Console.WriteLine($"Parameter {parameterToRemove} has not been recognized.");
                    }
                    break;
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
