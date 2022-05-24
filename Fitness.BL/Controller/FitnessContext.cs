﻿using Fitness.BL.Model;
using System.Data.Entity;

namespace Fitness.BL.Controller
{
     class FitnessContext : DbContext
    {
        public FitnessContext() : base("DBConnection") { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eating { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
