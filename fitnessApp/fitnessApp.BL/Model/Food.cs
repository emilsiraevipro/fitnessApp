using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace fitnessApp.BL.Tests
{
    public class Food
    {
        public string Name { get; set; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калории за 100 грамм продукта
        /// </summary>
        public double Calorries { get; set; }

        public Food(string name) : this(name,0.0,0.0,0.0,0.0){}


        [JsonConstructor]
        public Food(string name, double proteins, double fats, double carbohydrates, double calorries)
        {
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name), "Имя не может быть пустым") : name;
            Proteins = proteins < 0 ? throw new ArgumentNullException(nameof(proteins), "Белки не могут быть равны 0") : proteins / 100.0;
            Fats = fats < 0 ? throw new ArgumentNullException(nameof(fats), "Белки не могут быть равны 0") : fats / 100.0;
            Carbohydrates = carbohydrates < 0 ? throw new ArgumentNullException(nameof(carbohydrates), "Жиры не могут быть равны 0") : carbohydrates / 100.0;
            Calorries = calorries < 0 ? throw new ArgumentNullException(nameof(calorries), "Калории не могут быть равны 0") : calorries / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
