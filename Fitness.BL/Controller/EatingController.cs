using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    public class EatingController: ControllerBase
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("user name can not be empty ", nameof(user));
            Foods = GetAllFoods();
        }

        private List<Food> GetAllFoods()
        {
           return Load<List<Food>>("foods.dat") ?? new List<Food>();
        }
    }
}
