using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace fitnessApp.BL.Controller
{
    public class EatingController: ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.json";
        private const string EATINGS_FILE_NAME = "eatings.json";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get;  }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user), "Пользователь не может быть пустым или NULL!");
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public EatingController()
        {
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }

        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
           return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
    }
}
