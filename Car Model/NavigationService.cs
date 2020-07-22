using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_Model
{
    public class NavigationService
    {
        private List<Bookings> reservedCarData;
        private List<Car> allCarsData;

        public void Start()
        {

            Console.WriteLine("Input a command: ");

            reservedCarData = new List<Bookings>();
            allCarsData = new List<Car>();
            string line = Console.ReadLine();
            while (line != "exit")
            {
                CommandExecution(line);

                line = Console.ReadLine();
            }
        }


        void CommandExecution( string line)
        {
            string[] command = line.Split(" ");
            switch (command[0])
            {
                case "addCar":
                        AddCar();
                    break;
            }
        }

        public void StartProgram()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Input a command: (type \"commands\" to list all commands)");

            reservedCarData = new List<Bookings>();
            allCarsData = new List<Car>();
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
                        SearchCar();
                    }
                    break;
                case "removeAllCars":
                    {
                        RemoveAllCars();
                    }
                    break;
                case "reserveCar":
                    {
                        ReserveCar();
                    }
                    break;
                case "cancelReservation":
                    {
                        CancelReservation();
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
                case "priceList":
                    {
                        PriceList();
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
            Console.WriteLine("priceList");
            Console.WriteLine("\nexit");
        }

        private void PriceList()
        {
            Console.WriteLine("For period under 3 days, price per day is 100.");
            Console.WriteLine("For period between 3 and 10 days, price per day is 80.");
            Console.WriteLine("For period between 11 and 20 days, price per day is 60.");
            Console.WriteLine("For period over 20 days, price per day is 60.");
        }

        private void AddCar()
        {
            int numberOfParameters = 10;
            string[] command = new string[numberOfParameters];

            var listOfCarElements = new Car();

            Guid idCode;
            bool checkId = false;

            while (!checkId)
            {
                Console.WriteLine("-------------------");
                Console.Write("Enter car ID: ");
                command[0] = Console.ReadLine();
                checkId = Guid.TryParse(command[0], out idCode);

                if (checkId)
                {
                    listOfCarElements.SetId(idCode);
                    Console.WriteLine("-------------------");
                    foreach (var car in allCarsData)
                    {
                        if (car.Id == idCode)
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

            idCode = Guid.Parse(command[0]);

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
                    listOfCarElements.SetCarType(carType);
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
                    listOfCarElements.SetSeats(seats);
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
            listOfCarElements.SetBrand(commandBrand, commandModel);
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
                    listOfCarElements.SetDoors(numberOfDoors);
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
                    listOfCarElements.SetGearBoxType(gearBoxType);
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
                    listOfCarElements.SetEngineSpec(capacity, horsePower, fuelType);
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
                
                listOfCarElements.SetExtras(extras);
            }

            allCarsData.Add(listOfCarElements);

            Console.WriteLine($"New car with id {idCode} created.");
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
                    var result = allCarsData.Where(x => x.Id == idCode).SingleOrDefault();

                    if (result == null)
                    {
                        Console.WriteLine("There is no such Id of car in the system!");
                    }
                    else
                    {
                        if (allCarsData.Count != 0)
                        {
                            foreach (var car in allCarsData)
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
                            allCarsData.Remove(toDelete);
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
                                bool carTypeExists = allCarsData.Exists(item => item.CarType == carType); //ss

                                if (carTypeExists)
                                {
                                    allCarsData.RemoveAll(x => x.CarType == carType);
                                    Console.WriteLine("All cars under car type " + carType + " are removed.");
                                    Console.WriteLine("-------------------");
                                }
                                else
                                {
                                    Console.WriteLine("There is no such car type!");
                                }
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

                        bool brandExists = allCarsData.Exists(item => item.Brand == brand);

                        if (brandExists)
                        {
                            allCarsData.RemoveAll(x => x.Brand == brand);
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

                        bool modelExists = allCarsData.Exists(item => item.Model == model);

                        if (modelExists)
                        {
                            allCarsData.RemoveAll(x => x.Model == model);
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
                    var result = allCarsData.Where(x => x.Id == idCode).SingleOrDefault();

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

        private void SearchCar()
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
                bool isCarFound = false;

                if (checkId)
                {
                    foreach (Car car in allCarsData)
                    {
                        if (car.Id.Equals(idCode))
                        {
                            isCarFound = true;
                        }
                    }
                    if (isCarFound)
                    {
                        Console.WriteLine("Car found and present in list.");
                    }
                    else
                    {
                        Console.WriteLine("Car not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }
        }

        private void AddReservation(Guid IdCode)
        {
            var listOfReservationElements = new Bookings();
            string[] command = new string[4];

            string idCode = IdCode.ToString();
            command[0] = idCode;
            var commandBookedCarId = Guid.Parse(command[0]);
            listOfReservationElements.SetBookedCar(commandBookedCarId);


            DateTime startDate;
            bool checkDate = false;

            while (!checkDate)
            {
                Console.WriteLine("-------------------");
                Console.Write("Enter date: ");
                command[1] = Console.ReadLine();
                checkDate = DateTime.TryParse(command[1], out startDate);

                if (checkDate)
                {
                    listOfReservationElements.SetDate(startDate);
                    Console.WriteLine("-------------------");
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }
            
            Console.Write("Enter client information: ");
            command[2] = Console.ReadLine();
            var commandClientInformation = command[2];
            listOfReservationElements.SetClientInformation(commandClientInformation);
            Console.WriteLine("-------------------");

            int period;
            bool checkPeriod = false;

            while (!checkPeriod)
            {
                Console.Write("Enter period: ");
                command[3] = Console.ReadLine();
                checkPeriod = int.TryParse(command[3], out period);

                if (checkPeriod)
                {
                    var pricePerDay = 0;

                    pricePerDay = CalculationOfTotalPrice(period, pricePerDay);

                    var totalPrice = 0;
                    listOfReservationElements.SetRentalInfo(period, pricePerDay, totalPrice);
                    Console.WriteLine($"Period is {period}, price per day is {pricePerDay} and total price totals {period * pricePerDay}.");
                    Console.WriteLine("-------------------");
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }

            reservedCarData.Add(listOfReservationElements);

            Console.WriteLine("Car has been added to reservation list.");
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

        private void ReserveCar()
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
                    var result = allCarsData.Where(x => x.Id == idCode).SingleOrDefault();

                    if (result == null)
                    {
                        Console.WriteLine("There is no such Id of car in the system!");
                        continue;
                    }

                    var reservedResult = reservedCarData.Where(x => x.BookedCar.Id == idCode).SingleOrDefault();

                    if (reservedResult == null)
                    {
                        AddReservation(idCode);
                        Console.WriteLine("Reservation process has ended.");
                    }
                    else
                    {
                        Console.WriteLine("Car has already been reserved.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }
        }

        private void CancelReservation()
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
                    var reservedResult = reservedCarData.Where(x => x.BookedCar.Id == idCode).SingleOrDefault();

                    if (reservedResult == null)
                    {
                        Console.WriteLine("There is no such Id of car in the system!");
                    }
                    else
                    {
                        reservedCarData.Remove(reservedResult);
                        Console.WriteLine("Car has been removed from the reservation list.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect parameter!");
                    continue;
                }
            }
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
            foreach (var car in allCarsData)
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
