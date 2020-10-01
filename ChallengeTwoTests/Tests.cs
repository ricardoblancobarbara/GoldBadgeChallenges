using System;
using System.Collections;
using System.Collections.Generic;
using _2_Claim_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2_Claim_Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CreateClaimQTestMethod()
        {
            // Arrange
            ClaimRepository _repo = new ClaimRepository();
            DateTime dateOfIncident1 = new DateTime(2018, 4, 25);
            DateTime dateOfClaim1 = new DateTime(2018, 4, 27);
            Claim carAccident = new Claim(1, (KindOfType)1, "Car accident on 465.", 400.55, dateOfIncident1, dateOfClaim1, true);

            // Act
            _repo.CreateClaimQ(carAccident);

            // Assert
            Claim expected = _repo.NextClaimQ();
            Claim actual = carAccident; 
            Assert.AreEqual(expected, actual); 
        }

        [TestMethod]
        public void NextClaimQTestMethod()
        {
            // Arrange
            ClaimRepository _repo = new ClaimRepository();
            DateTime dateOfIncident1 = new DateTime(2018, 4, 25);
            DateTime dateOfClaim1 = new DateTime(2018, 4, 27);
            Claim carAccident = new Claim(1, (KindOfType)1, "Car accident on 465.", 400.55, dateOfIncident1, dateOfClaim1, true);
            _repo.CreateClaimQ(carAccident);

            // Act
            Claim expected = _repo.NextClaimQ();

            // Assert
            Claim actual = carAccident;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadClaimQueueTestMethod()
        {
            // Arrange
            ClaimRepository _repo = new ClaimRepository();

            DateTime dateOfIncident1 = new DateTime(2018, 4, 25);
            DateTime dateOfClaim1 = new DateTime(2018, 4, 27);
            Claim carAccident = new Claim(1, (KindOfType)1, "Car accident on 465.", 400.55, dateOfIncident1, dateOfClaim1, true);
            _repo.CreateClaimQ(carAccident);

            DateTime dateOfIncident2 = new DateTime(2018, 4, 11);
            DateTime dateOfClaim2 = new DateTime(2018, 4, 12);
            Claim houseFire = new Claim(2, (KindOfType)2, "House fire in kitchen.", 4000.28, dateOfIncident2, dateOfClaim2, true);
            _repo.CreateClaimQ(houseFire);

            DateTime dateOfIncident3 = new DateTime(2018, 4, 27);
            DateTime dateOfClaim3 = new DateTime(2018, 6, 01);
            Claim stolenPancakes = new Claim(3, (KindOfType)3, "Stolen pancakes.", 4.85, dateOfIncident3, dateOfClaim3, false);
            _repo.CreateClaimQ(stolenPancakes);

            // Act
            Queue<Claim> expected = _repo.ReadClaimQueue();

            // Assert
            Queue<Claim> actual = new Queue<Claim>();
            actual.Enqueue(carAccident);
            actual.Enqueue(houseFire);
            actual.Enqueue(stolenPancakes);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNextClaimQTestMethod()    
        {
            // Arrange
            ClaimRepository _repo = new ClaimRepository();

            DateTime dateOfIncident1 = new DateTime(2018, 4, 25);
            DateTime dateOfClaim1 = new DateTime(2018, 4, 27);
            Claim carAccident = new Claim(1, (KindOfType)1, "Car accident on 465.", 400.55, dateOfIncident1, dateOfClaim1, true);
            _repo.CreateClaimQ(carAccident);

            DateTime dateOfIncident2 = new DateTime(2018, 4, 11);
            DateTime dateOfClaim2 = new DateTime(2018, 4, 12);
            Claim houseFire = new Claim(2, (KindOfType)2, "House fire in kitchen.", 4000.28, dateOfIncident2, dateOfClaim2, true);
            _repo.CreateClaimQ(houseFire);

            DateTime dateOfIncident3 = new DateTime(2018, 4, 27);
            DateTime dateOfClaim3 = new DateTime(2018, 6, 01);
            Claim stolenPancakes = new Claim(3, (KindOfType)3, "Stolen pancakes.", 4.85, dateOfIncident3, dateOfClaim3, false);
            _repo.CreateClaimQ(stolenPancakes);

            // Act
            _repo.RemoveNextClaimQ();

            // Assert
            Queue<Claim> expected = _repo.ReadClaimQueue();
            Queue<Claim> actual = new Queue<Claim>();
            actual.Enqueue(houseFire);
            actual.Enqueue(stolenPancakes);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
