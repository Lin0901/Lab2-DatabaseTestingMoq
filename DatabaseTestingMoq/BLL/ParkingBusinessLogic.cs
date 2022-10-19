using DatabaseTestingMoq.DAL;
using DatabaseTestingMoq.Models;

namespace DatabaseTestingMoq.BLL
{
    public class PassBusinessLogic
    {
        private IRepository<Pass> passRepo;
        private IRepository<ParkingSpot> parkingSpotRepo;

        public PassBusinessLogic(IRepository<Pass> repo, IRepository<ParkingSpot> parkingSpotRepo)
        {
            this.passRepo = repo;
            this.parkingSpotRepo = parkingSpotRepo;
        }

        public ICollection<Pass> GetAllPasses()
        {
            return passRepo.GetAll().ToList();
        }

        public ICollection<ParkingSpot> GetAllParkingSpots()
        {
            return parkingSpotRepo.GetAll().ToList();
        }

        public void CreatePass(int capacity, string purchase)
        {
            if (purchase.Length >= 3 && purchase.Length <= 20 && capacity >= 0)
            {
                Pass pass = new Pass(purchase, capacity);
                passRepo.Create(pass);
                passRepo.Save();
            }
            else
            {
                throw new Exception();
            }
        }

        public void CreateParkingSpot()
        {
            ParkingSpot parkingSpot = new ParkingSpot();
            parkingSpotRepo.Create(parkingSpot);
            parkingSpotRepo.Save();
        }
    }
}
