using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DishesForDay.Data;

namespace DishesForDay.Library
{
    /// <summary>
    /// This class captures all the DishesForDay relating to DishesForDay
    /// </summary>
    public class DishesForDay
    {
        public bool IsValid()
        {
            return true;
        }

        public Dish[] Dishes { get; set; }

        public string[][] DishesOfDay { get; set; }

        public DishesForDay()
        {
            Initialize();
        }

        //Initialize the table driven method
        public void Initialize()
        {
            DishesOfDay = new[] { 
                new[] {"DishType", "Morning", "Evening" }, 
                new[] {"1", "eggs", "steak" }, 
                new[] {"2", "Toast", "potato" }, 
                new[] {"3", "coffee", "wine" }, 
                new[] {"4", "NA", "cake" } };
        }

        public bool ValidateInput(string[] input)
        {
            if (input.Length < 1)
                return false;
            return true;
        }

        public bool PrintDishOfDay(int dishType, int timeOfDay)
        {
            if (DishesOfDay != null)
                if (DishesOfDay.Length > dishType)
                {
                    if (DishesOfDay[dishType].Length > timeOfDay)
                        Console.Write(String.Format(" {0},", DishesOfDay[dishType][timeOfDay]));
                    return true;
                }
                else
                {
                    Console.Write(String.Format(" {0}", "error"));
                    return false;
                }
            return false;
        }

        /// <summary>
        /// Given the dishType and timeOfDay
        /// Returns the Dish
        /// </summary>
        /// <param name="dishType"></param>
        /// <param name="timeOfDay"></param>
        /// <returns></returns>
        public string GetDishOfDay(int dishType, int timeOfDay)
        {
            //Return error if DishesOfDay is not initialized
            if (DishesOfDay == null)
                return "error";
            //Return error if DishType requested is not present 
            if (DishesOfDay.Length <= dishType)
                return "error";
            //Return error if TimeOfDay requested is not present
            if (DishesOfDay[dishType].Length <= timeOfDay)
                return "error";
            //
            return DishesOfDay[dishType][timeOfDay];
        }
    
        /// <summary>
        /// Given the time of Day and DishTypes requested
        /// Prints the Dishes for the Day.
        /// </summary>
        /// <param name="timeOfDay"></param>
        /// <param name="dishTypes"></param>
        public void PrintDishesOfDay(TimeOfDay timeOfDay, DishType[] dishTypes)
        {
            Console.Write("OutPut : ");
            var disfOfDay = GetDishOfDay((int)dishTypes[0], (int)timeOfDay);
            Console.Write(String.Format(" {0}", disfOfDay));
            for (int i = 1; i < dishTypes.Length; i++)
            {
                disfOfDay = GetDishOfDay((int)dishTypes[i], (int)timeOfDay);
                Console.Write(String.Format(", {0}", disfOfDay));
                if (disfOfDay == "error")
                    break;
            }
        }
    }
}
