using Fitness.BL.Model;
using System;
using Fitness.BL.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Resources;

namespace FitnessApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // var culture = CultureInfo.CreateSpecificCulture("en-us");
            var culture = CultureInfo.CurrentCulture;
            Console.WriteLine(culture);
            var resourceManager = new ResourceManager("FitnessApp.CMD.Langues.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));

            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);


            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDataTime("дату рождения");
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("А - ввести упражнение");
                Console.WriteLine("Q - выход");

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key}- {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} c {item.Start.ToShortTimeString()} по {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }

     
           

            //  userController.Save();
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения:");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var activity = new Activity(name, energy);

            var begin = ParseDataTime("начала уражнения");
            var end = ParseDataTime("окончание уражнения");

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("Калорийность");
            var proteins = ParseDouble("Белки");
            var fats = ParseDouble("Жиры");
            var carbohydrates = ParseDouble("Углеводы");

            Console.WriteLine("Введите вес порции: ");
            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, proteins, fats, carbohydrates);
            return (Food:product,Weight: weight);
        }

        private static DateTime ParseDataTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value}(dd.MM.yyyy: ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Не верный формат даты");
                }

            }

            return birthDate;
        }

        private static double ParseDouble(string name) 
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Не верный формат поля {name}а");
                }

            }
        }
    }
}
