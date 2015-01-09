using System;
using DishesForDay.Data;

namespace DishesForDay.Console
{
    class Program
    {
        static int Main(string[] args)
        {
            var dishOfDay = new Library.DishesForDay();

            if (args.Length >= 1 && dishOfDay.ValidateInput(args))
            {
                var input = (TimeOfDay)Enum.Parse(typeof(TimeOfDay),args[0].Replace(',',' ').Trim(), true);
                var dishes = new DishType[args.Length-1];
                for (int i = 0; i < args.Length - 1; i++)
                {
                    dishes[i] = (DishType)Enum.Parse(typeof(DishType), args[i + 1].Replace(',', ' ').Trim(), true);
                }
                dishOfDay.PrintDishesOfDay(input, dishes);
                //var dishType = args[0];
                //TODO
                //dOD.PrintDishesOfDay();
            }
            else
            {
                DisplayUsage();
            }
            return 0; // success
        }

        public static void DisplayUsage()
        {
            System.Console.WriteLine("DishesForDay (TimeOfDay, Comma Separated Entree's) ");
            System.Console.WriteLine("TimeOfDay: You must enter time of day as “morning” or “night” ");
            System.Console.WriteLine("        or shopper list for this user.");
        }
    }
}
