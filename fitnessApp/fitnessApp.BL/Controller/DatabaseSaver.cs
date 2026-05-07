using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessApp.BL.Controller
{
    public class DatabaseSaver : IDataSaver
    {
         List<T> IDataSaver.Load<T>()
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(k => true).ToList();
                return result;
            }
        }

        void IDataSaver.Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
