using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace fitnessApp.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException(nameof(name), "Имя не может быть пустым или null");
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
        public Gender()
        {
            
        }
    }
}
