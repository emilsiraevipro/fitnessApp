using System;namespace fitnessApp.BL.Model
{
    public class ACtivity
        
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double CaloriesPerMinute { get; set; }
        public ACtivity(string name, double caloriesPerminute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerminute;
        }
        public ACtivity() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
