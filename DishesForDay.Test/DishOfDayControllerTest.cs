using DishesForDay.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DishesForDay.Data;
using System.Collections.Generic;

namespace DishesForDay.Test
{


    /// <summary>
    ///This is a test class for DishOfDayControllerTest and is intended
    ///to contain all DishOfDayControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DishOfDayControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetDishOfDay
        ///</summary>
        [TestMethod()]
        public void GetDishOfDayTest()
        {
            DishOfDayController target = new DishOfDayController(); // TODO: Initialize to an appropriate value
            var dishType = new[]
            {
            DishType.Entree, 
            DishType.Side, 
            DishType.Drink, 
            DishType.Dessert
            }; // TODO: Initialize to an appropriate value
            TimeOfDay timeOfDay = TimeOfDay.Morning; // TODO: Initialize to an appropriate value
            IEnumerable<Dish> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Dish> actual;
            actual = target.GetDishOfDay(dishType, timeOfDay);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
