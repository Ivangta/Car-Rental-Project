using System;
using System.Collections.Generic;
using System.Text;

namespace Car_Model
{
    public class NavigationService
    {
        public void StartProgram()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Input a command: (type \"commands\" to list all commands)");

            Car car = new Car("Best Dealers");
            string line;
            line = Console.ReadLine();
            while (line != "End")
            {
                string[] separators = { ",", " " };
                string[] expectedComand = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < expectedComand.Length; i++)
                {
                    expectedComand[i] = expectedComand[i].Trim();
                }
                ExecuteCommand(expectedComand, car);
                line = Console.ReadLine();
                
                Console.WriteLine("------------------------------------------------");
            }
        }

        public void ExecuteCommand(string[] command, Car cars)
        {
            switch (command[0])
            {
                case "AddCar":
                    {
                        cars.AddCar(new Car(command[0], command[1], int.Parse(command[2]), command[3], command[4], command[5], command[6]));
                    }
                    break;
                    
           
        }

    }
}
