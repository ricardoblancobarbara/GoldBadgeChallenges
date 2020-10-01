using System;
using System.Collections.Generic;
using _3_Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _3_Badge_Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CreateBadgeTestMethod()
        {
            // Arrange
            BadgeRepository _repo = new BadgeRepository();

            List<string> developerDoors = new List<string> { "A7" };
            Badge developer = new Badge(12345, developerDoors, "Developer");

            // Act
            _repo.CreateBadge(12345, developer);

            // Assert
            Badge expected = _repo.ReadBadgeByID(12345);
            Badge actual = developer;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadAllBadgeTestMethod()
        {
            // Arrange
            BadgeRepository _repo = new BadgeRepository();

            List<string> developerDoors = new List<string> { "A7" };
            Badge developer = new Badge(12345, developerDoors, "Developer");
            _repo.CreateBadge(12345, developer);

            List<string> claimAgentDoors = new List<string> { "A1", "A4", "B1", "B2" };
            Badge claimAgent = new Badge(22345, claimAgentDoors, "Claim Agent");
            _repo.CreateBadge(22345, claimAgent);

            List<string> accountantDoors = new List<string> { "A4", "A5" };
            Badge accountant = new Badge(32345, accountantDoors, "Accountant");
            _repo.CreateBadge(32345, accountant);

            // Act
            Dictionary<int, Badge> expected = _repo.ReadAllBadge();

            // Assert
            Dictionary<int, Badge> actual = new Dictionary<int, Badge>();
            actual.Add(12345, developer);
            actual.Add(22345, claimAgent);
            actual.Add(32345, accountant);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateBadgeTestMethod()
        {
            // Arrange
            BadgeRepository _repo = new BadgeRepository();

            List<string> developerDoors = new List<string> { "A7" };
            Badge developer = new Badge(12345, developerDoors, "Developer");
            _repo.CreateBadge(12345, developer);

            List<string> claimAgentDoors = new List<string> { "A1", "A4", "B1", "B2" };
            Badge claimAgent = new Badge(22345, claimAgentDoors, "Claim Agent");
            _repo.CreateBadge(22345, claimAgent);

            // OPTION: 1
            // Act
            bool expected = _repo.UpdateBadge(12345, claimAgent);

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
        public void DeletebadgeTestMethod() 
        {
            // Arrange
            BadgeRepository _repo = new BadgeRepository();

            List<string> developerDoors = new List<string> { "A7" };
            Badge developer = new Badge(12345, developerDoors, "Developer");
            _repo.CreateBadge(12345, developer);

            // Act
            bool expected = _repo.DeleteBadge(12345);

            // Assert
            bool actual = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadBadgeByIDTestMethod()
        {
            // Arrange
            BadgeRepository _repo = new BadgeRepository();
            List<string> developerDoors = new List<string> { "A7" };
            Badge developer = new Badge(12345, developerDoors, "Developer");
            _repo.CreateBadge(12345, developer);

            // Act
            Badge expected = _repo.ReadBadgeByID(12345);

            // Assert
            Badge actual = developer;
            Assert.AreEqual(expected, actual);
        }
    }
}
