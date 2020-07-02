using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class NavigationService
    {
        EngineSpec currentEngineSpec;
        ICollection<Extras> currentExtras;
        public void StartProgram()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Input a command: (type \"commands\" to list all commands)");

            Car car = new Car("Best Dealers");
            string line = Console.ReadLine();
            
            while (line != "End")
            {
                //string[] separators = { ",", " " };
                //string[] expectedComand = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                //for (int i = 0; i < expectedComand.Length; i++)
                //{
                //    expectedComand[i] = expectedComand[i].Trim();
                //}
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
                        cars.AddCar(new Car(Guid.Parse(command[0]), (CarType)Enum.Parse(typeof(CarType), (command[1])), int.Parse(command[2]), (DoorsEnum)Enum.Parse(typeof(DoorsEnum), (command[3])),
                            (GearBoxEnum)Enum.Parse(typeof(GearBoxEnum), (command[4])), currentEngineSpec, currentExtras));
                    }
                    break;
                


            }
           
        }

    }
}
