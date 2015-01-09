using System;

namespace DishesForDay.Data
{
    public class Dish
    {
        public String Name { get; set; }
        public DishType DishType { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public Dish(DishType dishType, string name)
        {
            DishType = dishType;
            Name = name;
            TimeOfDay = TimeOfDay.Morning;
        }
        public Dish(DishType dishType, string name, TimeOfDay timeOfDay)
        {
            DishType = dishType;
            Name = name;
            TimeOfDay = timeOfDay;
        }
    }
}
