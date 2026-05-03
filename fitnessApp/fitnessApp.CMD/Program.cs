using fitnessApp.BL.Controller;
using fitnessApp.BL.Model;

namespace fitnessApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложения fitnessApp");

            Console.WriteLine("Введите имя пользователя");

            var name = Console.ReadLine();

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birrrthdate = DateTime.TryParse(Console.ReadLine(), out DateTime birthDate);

            Console.WriteLine("Введите вес");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост");
            var height = double.Parse(Console.ReadLine());

            var userContrroller = new UserController(name, gender, birthDate, weight, height);

            userContrroller.Save();

        }
    }
}
