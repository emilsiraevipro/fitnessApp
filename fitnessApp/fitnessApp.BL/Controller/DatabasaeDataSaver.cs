using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessApp.BL.Controller
{
    public class DatabasaeDataSaver<T> : IDataSaver<T> where T: class
    {
        T IDataSaver<T>.Load()
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().First(k => true);
                return result;
            }
        }

        void IDataSaver<T>.Save(T item)
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
                //Type? type = Type.GetType("item"); так неверно, хз почему
            }
        }
    }
}
