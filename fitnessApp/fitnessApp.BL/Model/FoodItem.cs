using fitnessApp.BL.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessApp.BL.Model
{
    public class FoodItem
    {
        public Food Food { get; set; }
        public double Weight { get; set; }
        public FoodItem() { }
        public FoodItem(Food food, double weight)
        {
            Food = food;
            Weight = weight;
        }
        public FoodItem(Food food) : this(food, 0) {}
    }
}
