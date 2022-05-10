﻿using CodeBlogFitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    public class UserController : ControllerBase
    {
        private const string USERS_FILE_NAME = "users.dat";
        //  public User User { get; }
        public List<User> Users { get; }
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
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
                IsNewUser = true;
                Save();
            }
/*
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);*/
        }

        private List<User> GetUsersData()
        {
          return  Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }

       
    }
}
