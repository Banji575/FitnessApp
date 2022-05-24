using System;


namespace Fitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get;}
        public double CaloriesPerMinute { get; set; }

        public Activity(string name, double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
