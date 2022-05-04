using System;

namespace Fitness.BL.Model
{
    public class Food
    {
        public string Name { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        public double Callories { get; }

        public Food(string name) : this(name, 0,0,0,0)
        {
            Name = name;
        }

        public Food(string name, double callories, double proteins, double fats, double carbohydates)
        {
            Name = name;
            Callories = callories / 100f;
            Proteins = proteins / 100f;
            Carbohydrates = carbohydates / 100f;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
