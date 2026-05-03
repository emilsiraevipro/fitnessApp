using fitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace fitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public List<User> Users { get; } = new List<User>();
        public User CurrentUser { get; }
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName)) 
                throw new ArgumentNullException(nameof(userName), "Имя пользователя не может быть пустым");

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
            }
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения</returns>
        /// <exception cref="FileLoadException"></exception>
        private List<User> GetUsersData()
        {
            if (!File.Exists("users.json") || new FileInfo("users.json").Length == 0) 
                return new List<User>();
            using (var file = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                var users = JsonSerializer.Deserialize<List<User>>(file);
                Console.WriteLine("Чтение данных из файла завершено!");
                return users;
            }
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            using (var file = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize<List<User>>(file, Users, new JsonSerializerOptions 
                { 
                    WriteIndented = true, 
                    AllowTrailingCommas = true, 
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                });
                Console.WriteLine("Данные были записаны в файл");
            }
        }
    }
}
