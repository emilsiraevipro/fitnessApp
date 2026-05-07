using fitnessApp.BL.Controller;
using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace fitnessApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Здравствуйте");
            Console.WriteLine("-------------------------");
            Console.Write("Введите ваше имя:");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
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
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход из");
                var key = Console.ReadKey();
                switch(key.Key)
                {
                    case ConsoleKey.E:
                        var food = EnterEating();
                        eatingController.Add(food);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"{item.Food} - {item.Weight}");
                        }
                        break;
                    case ConsoleKey.A:
                        var activities = EnterExercise();
                        exerciseController.Add(activities);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} - {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
                }
        }

        private static (Activity activity, DateTime begin, DateTime end) EnterExercise()
        {
            Console.Write("\nВведите имя упражнения:");
            var actName = Console.ReadLine();
            var calloriels = ParseDouble("калории");
            var activity = new Activity(actName, calloriels);

            var begin = DateTime.Now;
            var end = DateTime.Now.AddHours(1);

            return ( activity,  begin,  end);
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
