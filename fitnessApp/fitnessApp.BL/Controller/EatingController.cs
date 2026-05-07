using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;
using System.Text;
using System.Text.Json;

namespace fitnessApp.BL.Controller
{
    public class EatingController: ControllerBase<Eating>
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get;  }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user), "Пользователь не может быть пустым или NULL!");
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(FoodItem food )
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Food.Name);
            if(product == null)
            {
                Foods.Add(food.Food);
                Eating.Add(food);
                Save();
            }
            else
            {
                Eating.Add(food);
                Save();
            }
        }

        private Eating GetEating()
        {
            Eating eating = Load<Eating>().FirstOrDefault();
            if(eating != null)
            {
            if (eating.User == user) { return eating; }
            }
            return new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        private void Save()
        {
            Save(Foods);
            Save(new List<Eating>());
        }
    }
}
