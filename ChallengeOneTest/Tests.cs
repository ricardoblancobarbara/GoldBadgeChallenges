using System;
using _1_Cafe_Repository;
using _1_Cafe_Console; // ????
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ChallengeOneTests
{
    [TestClass]
    public class ChallengeOneTests  
    {
        // AAA
        // Arrange Act Assert
        // Testing - Run code to make sure it works
        // Why - So it won't break when we say it's done
        // When - Anytime you're not writing a throwaway project
        // What - Methods

        // ARRANGE
        // Set up the necessary pieces to run our code
        // If you use a name in the full constructor, make that name a variable

        // string firstName = "Nick";
        // string lastName = "Perry";
        // int id = 1;
        // DateTime myBirthday = new DateTime(2000, 8, 29);

        // ACT
        // Run code we want to make sure works

        // User testUser = new User(firstName, lastName, id, myBirthday);

        // ASSERT (Ensure a condition)
        // AreEqual - value you expect, value you got from the code

        // Assert.AreEqual(lastName, testUser.FirstName);
        // Assert.AreEqual(firstName, testUser.FirstName);


        // [TestMethod]
        // public void TestMethod1()
        // {
        //    // Make Nick Perry - Blank Constructor
        //    User user = new User();
        //    user.FirstName = "Nick";
        //    user.LastName = "Perry";
        //    user.BirthDate = new DateTime(2000, 8, 29);
        //    // Make Nick Perry - Full Constructor
        //    User nickPerry = new User("Nick", "Perry", 1, new DateTime(2000, 8, 29));
        //    Console.WriteLine(nickPerry.GetAgeInYears());
        // }


        // LIST OF METHODS TO TEST:
        // (We'll test only repository methods)

        // Repository

        // AddMealToList
        // GetMealByID
        // GetMealList
        // UpdateMealByID
        // DeleteMealByID

        [TestMethod]
        public void AddMealToListTestMethod()
        {
            // Arrange
            MealRepository _repo = new MealRepository();
            List<string> royaleIngredients = new List<string> { "double burger", "burger buns", "american cheese", "bacon", "lettuce", "tomato", "egg" };
            Meal royale = new Meal(1,
                "Royale",
                "Double burger with thick-sliced American cheese, hardwood-smoked bacon,\n" +
                "lettuce, vine-ripened tomato, and top with a fried egg and mayonnaise.",
                royaleIngredients,
                3.5);

            // Act
            _repo.AddMealToList(royale);

            // Assert
            Meal expected = _repo.GetMealByID(1); // This is the info previously introduced to the repository and recovered
            Meal actual = royale; // This is the info introduced by hand at the top.
            Assert.AreEqual(expected, actual); // So, this are two differents things that are equal, so it's correct.
        }

        [TestMethod]
        public void GetMealByIDTestMethod()
        { 
            // Arrange
            MealRepository _repo = new MealRepository();
            List<string> royaleIngredients = new List<string> { "double burger", "burger buns", "american cheese", "bacon", "lettuce", "tomato", "egg" };
            Meal royale = new Meal(1,
                "Royale",
                "Double burger with thick-sliced American cheese, hardwood-smoked bacon,\n" +
                "lettuce, vine-ripened tomato, and top with a fried egg and mayonnaise.",
                royaleIngredients,
                3.5);
            _repo.AddMealToList(royale);

            // Act
            Meal expected = _repo.GetMealByID(1);

            // Assert
            Meal actual = royale;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMealListTestMethod()
        {
            // Arrange
            MealRepository _repo = new MealRepository();

            List<string> royaleIngredients = new List<string> { "double burger", "burger buns", "american cheese", "bacon", "lettuce", "tomato", "egg" };
            Meal royale = new Meal(1, 
                "Royale", 
                "Double burger with thick-sliced American cheese, hardwood-smoked bacon,\n" +
                "lettuce, vine-ripened tomato, and top with a fried egg and mayonnaise.", 
                royaleIngredients, 
                3.5);
            _repo.AddMealToList(royale);

            List<string> westernBBQIngredients = new List<string> { "double burger", "burger buns", "american cheese", "bacon", "onions", "barbecue sauce" };
            Meal westernBBQ = new Meal(2,
                "Western BBQ and Bacon",
                "Double burger with thick-sliced American cheese, hardwood-smoked bacon,\n" +
                "diced and fried onions, and sweet and smoky BBQ sauce.",
                westernBBQIngredients,
                3.8);
            _repo.AddMealToList(westernBBQ);

            List<string> grilledPortobelloIngredients = new List<string> { "double burger", "burguer buns", "swiss cheese", "onions", "garlic mayonnaise" };
            Meal grilledPortobello = new Meal(3,
                "Grilled Portobello and Swiss Cheese",
                "Double burger with fresh portobello mushrooms, Swiss cheese, caramelized onions and garlic mayonnaise.",
                grilledPortobelloIngredients,
                3.9);
            _repo.AddMealToList(grilledPortobello);

            // Act
            List<Meal> expected = _repo.GetMealList();
            
            // Assert
            List<Meal> actual = new List<Meal>();
            actual.Add(royale);
            actual.Add(westernBBQ);
            actual.Add(grilledPortobello);
                        
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdatetMealByIDTestMethod()
        {
            // Arrange
            MealRepository _repo = new MealRepository();

            List<string> royaleIngredients = new List<string> { "double burger", "burger buns", "american cheese", "bacon", "lettuce", "tomato", "egg" };
            Meal royale = new Meal(1,
                "Royale",
                "Double burger with thick-sliced American cheese, hardwood-smoked bacon,\n" +
                "lettuce, vine-ripened tomato, and top with a fried egg and mayonnaise.",
                royaleIngredients,
                3.5);
            _repo.AddMealToList(royale);

            List<string> grilledPortobelloIngredients = new List<string> { "double burger", "burguer buns", "swiss cheese", "onions", "garlic mayonnaise" };
            Meal grilledPortobello = new Meal(1,
                "Grilled Portobello and Swiss Cheese",
                "Double burger with fresh portobello mushrooms, Swiss cheese, caramelized onions and garlic mayonnaise.",
                grilledPortobelloIngredients,
                3.9);

            // OPTION: 1
            // Act
            bool expected = _repo.UpdateMealByID(1, grilledPortobello);

            // Assert
            bool actual = true;
            Assert.AreEqual(expected, actual);

            //// OPTION: 2
            //// Assert
            //Assert.IsTrue(_repo.UpdateMealByID(1, grilledPortobello));

            //// OPTION: 3
            //// Act
            //_repo.UpdateMealByID(1, grilledPortobello);

            //// Assert
            //Meal expected = _repo.GetMealByID(1);
            //Meal actual = royale; // (it should be grilledPortobello)
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteMealByIDTestMethod()
        {
            // Arrange
            MealRepository _repo = new MealRepository();
            List<string> royaleIngredients = new List<string> { "double burger", "burger buns", "american cheese", "bacon", "lettuce", "tomato", "egg" };
            Meal royale = new Meal(1,
                "Royale",
                "Double burger with thick-sliced American cheese, hardwood-smoked bacon,\n" +
                "lettuce, vine-ripened tomato, and top with a fried egg and mayonnaise.",
                royaleIngredients,
                3.5);
            _repo.AddMealToList(royale);

            // Act
            bool expected = _repo.DeleteMealByID(1);

            // Assert
            bool actual = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
