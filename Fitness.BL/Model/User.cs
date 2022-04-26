using System;

namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        #region Props
        public string Name { get; }

        public Gender Gender { get; }

        public DateTime BirthDate { get; }

        public double Weight { get; set; }

        public double Height { get; set; }
        #endregion
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Check condition
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name can not be empty or null", nameof(name));
            }
            if(Gender == null)
            {
                throw new ArgumentNullException("Gender can not be null", nameof(gender));
            }

            if (BirthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Impossible date of birth", nameof(birthDate));
            }

            if(Weight <= 0)
            {
                throw new ArgumentException("Weight can not be zero", nameof(weight));
            }

            if(Height <= 0)
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

        public override string ToString()
        {
            return Name;
        }
    }
}
