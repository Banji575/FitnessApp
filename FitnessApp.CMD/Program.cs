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

             Console.WriteLine(userController.CurrentUser);
            Console.ReadLine(); 

          //  userController.Save();
        }
    }
}
