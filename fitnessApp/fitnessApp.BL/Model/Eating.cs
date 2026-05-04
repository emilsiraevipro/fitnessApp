using fitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessApp.BL.Tests
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    public class Eating
    {
        public DateTime Moment { get; }
        public List<FoodItem> Foods { get; }
        public User User { get; }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "Пользователь не может быть NULL");
            Moment = DateTime.UtcNow;
            Foods = new List<FoodItem>();
        }

        public void Add(FoodItem food)
        {
            var product = Foods.FirstOrDefault(f => f.Food.Name.Equals(food.Food.Name));

            if (product == null)
            {
                Foods.Add(food);
            }
            else
            {
                product.Weight += food.Weight;
            }
        }
    }
}
