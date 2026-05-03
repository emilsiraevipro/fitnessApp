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
        public User User { get; }
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            //TODO: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }
        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользователь приложения</returns>
        /// <exception cref="FileLoadException"></exception>
        public UserController()
        {
            using (var file = new FileStream("users.json", FileMode.OpenOrCreate))
            {
                 JsonSerializer.DeserializeAsync<User>(file);
            }
            //TODO: что делать, если пользователя не прочитали?
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        async public void Save()
        {
            using (var file = new FileStream("users.json", FileMode.OpenOrCreate))
            {
               await JsonSerializer.SerializeAsync<User>(file, User, new JsonSerializerOptions { WriteIndented = true, AllowTrailingCommas = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)});
            }
        }
    }
}
