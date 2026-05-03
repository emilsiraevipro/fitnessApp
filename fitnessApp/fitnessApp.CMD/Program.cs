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

            var userController = new UserController(name);


            userController.Save();

        }
    }
}
