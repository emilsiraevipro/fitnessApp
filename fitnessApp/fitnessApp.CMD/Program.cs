using fitnessApp.BL.Controller;
using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;

namespace fitnessApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение fitnessApp");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол:");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.E)
            {
                var food = EnterEating();
                eatingController.Add(food);
                foreach (var item in eatingController.Eating.Foods)
                { 
                    Console.WriteLine($"{item.Food} - {item.Weight}");
                }
            }
            Console.ReadLine();
        }

        private static FoodItem EnterEating()
        {
            Console.WriteLine("\nВведите имя продукта:");
            var foodName = Console.ReadLine();

            var calloriels = ParseDouble("калории");
            var proteins = ParseDouble("белки ");
            var fats = ParseDouble("жиры");
            var carbohydrates = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");

            var product = new Food(foodName, proteins, fats, carbohydrates, calloriels);

            return new FoodItem(product, weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения!");
                }
            }
            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}!");
                }
            }
        }
    }
}
