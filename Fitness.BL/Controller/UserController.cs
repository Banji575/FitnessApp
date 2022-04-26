﻿using Fitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    internal class UserController
    {
        public User User { get; }

        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException("User can not be null", nameof(user));
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

        public User Load()
        {
            var formatter = new BinaryFormatter();
            using(var fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;    
            }
        }
    }
}
