using System;namespace fitnessApp.BL.Model
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public double CaloriesPerMinute { get; set; }
        public Activity() { }
        public Activity(string name, double caloriesPerminute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerminute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
