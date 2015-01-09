using DishesForDay.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DishesForDay.Data;

namespace DishesForDay.Test
{


    /// <summary>
    ///This is a test class for DishesForDayTest and is intended
    ///to contain all DishesForDayTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DishesForDayTest
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
            var target = new Library.DishesForDay(); // TODO: Initialize to an appropriate value
            int dishType = 1; // TODO: Initialize to an appropriate value
            int timeOfDay = 2; // TODO: Initialize to an appropriate value
            string expected = "steak"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetDishOfDay(dishType, timeOfDay);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        /// <summary>
        ///A Error test for GetDishOfDay
        ///</summary>
        [TestMethod()]
        public void TimeOfDay_OutOfBound_error_test()
        {
            var target = new Library.DishesForDay(); // TODO: Initialize to an appropriate value
            int dishType = 1; // TODO: Initialize to an appropriate value
            int timeOfDay = 3; // TODO: Initialize to an appropriate value
            string expected = "error"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetDishOfDay(dishType, timeOfDay);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        /// <summary>
        ///A test for PrintDishesOfDay
        ///</summary>
        [TestMethod()]
        public void PrintDishesOfDayTest()
        {
            //Arrange
            var target = new Library.DishesForDay(); 
            // TODO: Initialize to an appropriate value
            //target
            var timeOfDay = new TimeOfDay(); // TODO: Initialize to an appropriate value
            DishType[] dishTypes = new[]{new DishType(), new DishType(), new DishType()  }; // TODO: Initialize to an appropriate value
            //Act
            target.PrintDishesOfDay(timeOfDay, dishTypes);
            //Assert
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
