using fitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace fitnessApp.BL
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    public class Eating
    {
        public DateTime Moment { get; }
        public List<FoodItem> Foods { get; private set; } 
        public User User { get; }
        public Eating(User user, DateTime moment, List<FoodItem> foods)
        {
            User = user ??  throw new ArgumentNullException(nameof(user), "Пользователь не может быть NULL");
            Moment = moment;
            Foods = foods ?? new List<FoodItem>();
        }
        [JsonConstructor]
        public Eating(User user , List<FoodItem> foods)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "Пользователь не может быть NULL");
            Moment = DateTime.UtcNow;
            Foods = foods ?? new List<FoodItem>();
        }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "Пользователь не может быть NULL");
            Moment = DateTime.UtcNow;
            Foods = new List<FoodItem>();
        }

        public void Add(FoodItem food)
        {
            var product = Foods.SingleOrDefault(f => f.Food.Name.Equals(food.Food.Name));

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
