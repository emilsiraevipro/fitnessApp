using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
namespace fitnessApp.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        #region Набор свойств.
        public string Name { get; } // установка через readonly(без set)
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age 
        { 
            get 
            {
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - BirthDate.Year;
                if (BirthDate > nowDate.AddYears(-age)) 
                    age--;
                return age;
            } 
        }
        #endregion
        
        public User(string name, 
                    Gender gender, 
                    DateTime birthDate, 
                    double weight, 
                    double height)
        {
            #region Проверка значений на корректность.
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name), "Имя не может быть пустым или NULL!");
            if (gender == null)
                throw new ArgumentNullException(nameof(gender), "Пол не может быть NULL!");
            if (birthDate < DateTime.Parse("1926, 1, 1") || birthDate > DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(birthDate), "Невозможная дата рождения!");
            if (weight < 0 || weight > 1000)
                throw new ArgumentOutOfRangeException(nameof(weight), "Неверное значение веса!");
            if (height > 300 || height < 0)
                throw new ArgumentOutOfRangeException(nameof(height), "Неверное значение роста!");
            #endregion
            #region Присваивание значений.
            Name = name;
            Gender = gender;
            Weight = weight;
            Height = height;
            BirthDate = birthDate;
            #endregion 
        }
        [JsonConstructor]
        public User(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException(nameof(name), "НУЛЬ!!!!");
            Name = name;
        }
        public User() { }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
