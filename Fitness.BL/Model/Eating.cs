using System;
using System.Collections.Generic;

namespace Fitness.BL.Model
{
    public class Eating
    {
        public DateTime Moment { get; }
        public List<Food> Foods { get; }
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
