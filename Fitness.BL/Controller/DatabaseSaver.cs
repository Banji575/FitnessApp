using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class DatabaseSaver : IDataSaver
    {
        public T Load<T>(string fileName)
        {
            using (var db = new FitnessContext())
            {
             
            }
        }

        public void Save(string fileName, object item)
        {
            using (var db = new FitnessContext())
            {
                var type = item.GetType();
                if (type == typeof(User))
                {
                    db.Users.Add(item as User);
                }
                else if (type == typeof(Gender))
                {
                    db.Genders.Add(item as Gender);
                }
                else if (type == typeof(Food))
                {
                    db.Foods.Add(item as Food);
                }
                else if (type == typeof(Exercise))
                {
                    db.Exercises.Add(item as Exercise);
                }
                else if(type == typeof(Eating))
                {
                    db.Eating.Add(item as Eating);
                }
                else if(type == typeof(Activity))
                {
                    db.Activities.Add(item as Activity);
                }
               
                db.SaveChanges();
            }
        }
    }
}
