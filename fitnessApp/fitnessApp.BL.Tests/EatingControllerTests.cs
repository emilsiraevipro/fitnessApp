using fitnessApp.BL.Model;
using fitnessApp.BL.Tests;
using System;
using System.Collections.Generic;
using System.Text;

namespace fitnessApp.BL.Controller
{
    [TestClass()]
    [DoNotParallelize]
    public class EatingControllerTests
    {
        [TestMethod()]
        [DoNotParallelize]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));
            FoodItem foodItem = new FoodItem(food, 100);
            //Act
            eatingController.Add(foodItem);

        }
    }
}
