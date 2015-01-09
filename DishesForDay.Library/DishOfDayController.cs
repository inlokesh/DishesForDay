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
    class DishOfDayController
    {

        public Dish[] Dishes { get; set; }

        public DishOfDayController()
        {
            Initialize();
        }

        public DishOfDayController(Dish[] dishes)
        {
            Dishes = dishes;
        }

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
        /// Returns the Dish for the dishType and timeOfDay
        /// </summary>
        /// <param name="dishType"></param>
        /// <param name="timeOfDay"></param>
        /// <returns></returns>
        public IEnumerable<Dish> GetDishOfDay(DishType[] dishType, TimeOfDay timeOfDay)
        {
            //Return error if DishesOfDay is not initialized
            if (Dishes == null)
                return null;
            //Return error if DishType requested is not present 
            var ds = from dishes in Dishes.AsQueryable().Where(a=>a.TimeOfDay==timeOfDay)
                      where dishType.Contains(dishes.DishType)
                      select dishes;
            return ds;                
        }

        /// <summary>
        /// Method to write dishes to Console
        /// </summary>
        /// <param name="dishes"></param>
        public void DisplayDishes(List<Dish> dishes)
        {
            var firstDish = dishes.FirstOrDefault();
            if (firstDish != null) Console.Write("OutPut : " + firstDish.Name);
            dishes.Remove(firstDish);
            foreach (var dish in dishes)
            {
                Console.Write(", " + dish.Name);
            }
        }
    }
}
