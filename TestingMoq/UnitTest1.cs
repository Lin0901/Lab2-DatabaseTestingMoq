using DatabaseTestingMoq.BLL;
using DatabaseTestingMoq.Controllers;
using DatabaseTestingMoq.DAL;
using DatabaseTestingMoq.Data;
using DatabaseTestingMoq.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;



namespace TestingMoq
{
    [TestClass]
    public class UnitTest1
    {
        private PassBusinessLogic PassBusinessLogic;
        [TestInitialize]
        public void Initialize()
        {

        }

        public UnitTest1()
        {
            // mock data
            var passesData = new List<Pass>
            {
                new Pass("Pass1", 5) {ID = 1},
                new Pass("Pass2", 5) {ID = 2},
                new Pass("Pass3", 5) {ID = 3},
                new Pass("Pass4", 5) {ID = 4},
                new Pass("Pass5", 5) {ID = 5},
            }.AsQueryable();

            // mock DbSets
            var mocDbSet = new Mock<DbSet<Pass>>();
            mocDbSet.As<IQueryable<Pass>>().Setup(m => m.Provider).Returns(passesData.Provider);
            mocDbSet.As<IQueryable<Pass>>().Setup(m => m.Expression).Returns(passesData.Expression);
            mocDbSet.As<IQueryable<Pass>>().Setup(m => m.ElementType).Returns(passesData.ElementType);
            mocDbSet.As<IQueryable<Pass>>().Setup(m => m.GetEnumerator()).Returns(passesData.GetEnumerator);
         
            // mock context setups
            var mocContext = new Mock<DatabaseTestingMoqContext>();
            
        }

        [TestMethod]
        public void CreatePassTest(ParkingHelper parkingHelper)
        {

            var passes = new List<Pass>();
            var queryablePasses = passes.AsQueryable();
            var mockPassDbSet = new Mock<DbSet<Pass>>();
            var mockParkingSpotDbSet = new Mock<DbSet<ParkingSpot>>();

            mockPassDbSet.As<IQueryable<Pass>>().Setup(x => x.Provider).Returns(queryablePasses.Provider);
            mockPassDbSet.As<IQueryable<Pass>>().Setup(x => x.Expression).Returns(queryablePasses.Expression);
            mockPassDbSet.As<IQueryable<Pass>>().Setup(x => x.ElementType).Returns(queryablePasses.ElementType);
            mockPassDbSet.As<IQueryable<Pass>>().Setup(x => x.GetEnumerator()).Returns(queryablePasses.GetEnumerator());

            Pass creatPass = parkingHelper.CreatePass("MITT", true, 8);

            Assert.AreEqual(passes, creatPass);
        }

        [TestMethod]
        public void CreateParkingSpotTest()
        {
            // arrange
            List<ParkingSpot> assertedParkingSpots = new List<ParkingSpot>
            {
                new ParkingSpot{ID = 1},
                new ParkingSpot{ID = 2},
            };

            // act
            PassBusinessLogic.CreateParkingSpot();

            // assert
            Assert.AreEqual(assertedParkingSpots.Count(), PassBusinessLogic.GetAllParkingSpots().Count());
        }
    }
}