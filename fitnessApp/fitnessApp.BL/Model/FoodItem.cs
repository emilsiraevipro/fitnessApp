using fitnessApp.BL.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace fitnessApp.BL.Model
{
    public class FoodItem
    {
        public int Id { get; set; }
        public Food Food { get; set; }
        public double Weight { get; set; }
        //public FoodItem() { },.llZZZZZZZZZZZ 

        [JsonConstructor]
        public FoodItem(Food food, double weight)
        {
            Food = food;
            Weight = weight;
        }
        //public FoodItem(Food food) : this(food, 0) {}
        public FoodItem()
        {
        }
    }
}
