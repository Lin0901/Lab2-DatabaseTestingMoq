using DatabaseTestingMoq.Controllers;
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
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void CreatePassTest()
        {
            //Mock passList
            var mockSet = new Mock<DbSet<Pass>>();

            //Mock context
            var mockContext = new Mock<DatabaseTestingMoqContext>();
            mockContext.Setup(m => m.Passes).Returns(mockSet.Object);

            //Arrange and Act
            var service = new ParkingHelper(mockContext.Object);
            service.CreatePass("MITT", true, 8);

            //Assert
            mockSet.Verify(m => m.Add(It.IsAny<Pass>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void CreateParkingSpotTest()
        {
            //Mock parkingSpotList
            var parkingSpotList = new Mock<DbSet<ParkingSpot>>();

            //Mock context
            var mockContext = new Mock<DatabaseTestingMoqContext>();
            mockContext.Setup(m => m.ParkingSpot).Returns(parkingSpotList.Object);

            //Arrange & Act
            var service = new ParkingHelper(mockContext.Object);
            service.CreateParkingSpot();

            //Assert
            //verify that a specific invocation(parkingSpotList.Add(parkingSpot)) was performed on the mock
            parkingSpotList.Verify(psList => psList.Add(It.IsAny<ParkingSpot>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}