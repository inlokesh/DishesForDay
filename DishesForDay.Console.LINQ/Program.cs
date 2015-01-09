using System;
using DishesForDay.Data;

namespace DishesForDay.Console.LINQ
{
    class Program
    {
        static int Main(string[] args)
        {
            var dishOfDayController = new Library.DishOfDayController();

            if (args.Length >= 1 && dishOfDayController.ValidateInput(args))
            {
                var input = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), args[0].Replace(',', ' ').Trim(), true);
                var dishes = new DishType[args.Length - 1];
                for (int i = 0; i < args.Length - 1; i++)
                {
                    dishes[i] = (DishType)Enum.Parse(typeof(DishType), args[i + 1].Replace(',', ' ').Trim(), true);
                }
                bool result = dishOfDayController.GetDishOfDay(dishes, input);
                System.Console.Write(result);
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
