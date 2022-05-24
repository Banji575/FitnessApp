using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Callories { get; set; }

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
