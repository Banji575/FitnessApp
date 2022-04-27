using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    public class UserController
    {
      //  public User User { get; }
      public List<User> Users { get; }
        public User CurrentUser { get; }
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name can not be empty", nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                Save();
            }
/*
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);*/
        }

        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

       
    }
}
