using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        #region Props

        public int Id { get; set; }
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Check condition
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name can not be empty or null", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Gender can not be null", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth", nameof(birthDate));
            }

            if(weight <= 0)
            {
                throw new ArgumentException("Weight can not be zero", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentException("Height can not be less of equal zero", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;    
            BirthDate = birthDate;  
            Weight = weight;
            Height = height;

        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name can not be empty or null");
            }

            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
