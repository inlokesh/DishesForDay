using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DishesForDay.Data;

namespace DishesForDay.Library
{
    /// <summary>
    /// Application Controller class for the Application
    /// </summary>
    public class DishOfDayController
    {
        public Dish[] Dishes { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DishOfDayController()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor with Dishes Data to initialize
        /// </summary>
        /// <param name="dishes"></param>
        public DishOfDayController(Dish[] dishes)
        {
            Dishes = dishes;
        }

        /// <summary>
        /// Default Initializer with Dishes data
        /// </summary>
        public void Initialize()
        {
            Dishes = new[] { 
                new Dish(DishType.Entree, "eggs", TimeOfDay.Morning) ,
                new Dish(DishType.Side, "Toast", TimeOfDay.Morning) ,
                new Dish(DishType.Drink, "coffee", TimeOfDay.Morning) ,
                new Dish(DishType.Dessert, "Not Applicable", TimeOfDay.Morning),
                new Dish(DishType.Entree, "steak", TimeOfDay.Evening) ,
                new Dish(DishType.Side, "potato", TimeOfDay.Evening) ,
                new Dish(DishType.Drink, "wine", TimeOfDay.Evening) ,
                new Dish(DishType.Dessert, "cake", TimeOfDay.Evening)
            };
        }

        /// <summary>
        /// Validates the console input to check if it null
        /// </summary>
        /// <param name="input">String Array containing the input parameters</param>
        /// <returns></returns>
        public bool ValidateInput(string[] input)
        {
            if (input.Length < 1)
                return false;
            return true;
        }

        /// <summary>
        /// Returns the Dish for the dishType and timeOfDay
        /// </summary>
        /// <param name="dishType"></param>
        /// <param name="timeOfDay"></param>
        /// <returns></returns>
        public bool GetDishOfDay(DishType[] dishType, TimeOfDay timeOfDay)
        {
            //Return error if DishesOfDay is not initialized
            if (Dishes == null)
                return false;
            //Get the dishes requested
            //var reqDishes = from dishes in Dishes.AsQueryable().Where(a => a.TimeOfDay == timeOfDay)
            //                where dishType.Contains(dishes.DishType)
            //                select dishes;
            var q = from c in dishType
                    join p in Dishes.AsQueryable().Where(a => a.TimeOfDay == timeOfDay) on c equals p.DishType into ps
                    from p in ps.DefaultIfEmpty()
                    select new { DishType = c, Name = p == null ? "Error" : p.Name, TimeOfDay = p == null ? TimeOfDay.Error : p.TimeOfDay };

            //Error 
            //Group by Requested dishes by DishTypes.
            var dishesGroup = from d in q
                              group d by d.DishType into dishTypeGroup
                              select new { DishType = dishTypeGroup.Key, Count = dishTypeGroup.Count(), Dishes = dishTypeGroup };
            //Display the first result
            var firstDishGroup = dishesGroup.First();
            if (firstDishGroup == null)
            {
                Console.Write("OutPut : Error");
                return false;
            }
            Console.Write("OutPut : " + firstDishGroup.Dishes.First().Name);
            if (firstDishGroup.Count > 1)
            {
                var firstDish = firstDishGroup.Dishes.FirstOrDefault();
                if (
                    ((firstDish.DishType == DishType.Drink) && (timeOfDay == TimeOfDay.Morning)) ||
                    ((firstDish.DishType == DishType.Side) && (timeOfDay == TimeOfDay.Evening))
                    )
                    Console.Write(String.Format("({0})", firstDishGroup.Count));
                else
                {
                    Console.Write(", Error");
                    return false;
                }
            }
            dishesGroup = dishesGroup.Skip(1);
            //Display rest of the results
            foreach (var dG in dishesGroup)
            {
                var dish = dG.Dishes.FirstOrDefault();
                if (dish == null)
                {
                    Console.Write(", Error");
                    return false;
                }
                if (dish.TimeOfDay == TimeOfDay.Error)
                {
                    Console.Write(", Error");
                    return false;
                }
                Console.Write(", " + dish.Name);
                if (dG.Count > 1)
                {
                    var d = dG.Dishes.FirstOrDefault();
                    if (
                        ((d.DishType == DishType.Drink) && (timeOfDay == TimeOfDay.Morning)) ||
                        ((d.DishType == DishType.Side) && (timeOfDay == TimeOfDay.Evening))
                        )
                        Console.Write(String.Format("({0})", dG.Count));
                    else
                    {
                        Console.Write(", Error");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Method to write dishes to Console
        /// </summary>
        /// <param name="dishTypeGroup"></param>
        public void DisplayDishes(List<IGrouping<DishType, Dish>> dishTypeGroup)
        {
            foreach (var dTG in dishTypeGroup)
            {
                Console.Write(" " + dTG);
            }
            //var firstDish = dishTypeGroup.FirstOrDefault();
            //if (firstDish != null) Console.Write("OutPut : " + firstDish.Name);
            //dishTypeGroup.Remove(firstDish);
            //foreach (var dish in dishTypeGroup)
            //{
            //    Console.Write(", " + dish.Name);
            //}
        }
    }
}
