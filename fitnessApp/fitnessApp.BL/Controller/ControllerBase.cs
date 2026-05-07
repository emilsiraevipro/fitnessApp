using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace fitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        protected IDataSaver saver = new DatabasaeDataSaver();
        protected void Save<T>(string fileName, T obj)
        {
            saver.Save(fileName, obj);
        }
        protected T Load<T>(string fileName) where T: class 
        {
            return saver.Load<T>(fileName);
        }
    }
}
