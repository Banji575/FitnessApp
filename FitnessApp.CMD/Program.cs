using Fitness.BL.Model;
using System;
using Fitness.BL.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение FitnessApp");
            Console.WriteLine("Введите имя пользоватьеля");
            var name = Console.ReadLine();
            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDataTime();
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();

            //  userController.Save();
        }

        private static DateTime ParseDataTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения(dd.MM.yyyy: ");
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
                    Console.WriteLine($"Не верный формат {name}а");
                }

            }
        }
    }
}
