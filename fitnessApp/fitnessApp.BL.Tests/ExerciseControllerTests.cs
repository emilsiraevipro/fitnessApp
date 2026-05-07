using fitnessApp.BL.Controller;
using fitnessApp.BL.Model;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessApp.BL.Controller
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(50, 500));
            //Act
            exerciseController.Add((activity, DateTime.Now, DateTime.Now.AddHours(1)));

            //Asert
            Assert.AreEqual(activityName, exerciseController.Activities.First().Name);
        }
    }
}
