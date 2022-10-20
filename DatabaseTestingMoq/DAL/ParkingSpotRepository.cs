using DatabaseTestingMoq.Data;
using DatabaseTestingMoq.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTestingMoq.DAL
{
    public class ParkingSpotRepository : IRepository<ParkingSpot>
    {
        private DatabaseTestingMoqContext _db { get; set; }
        public ParkingSpotRepository(DatabaseTestingMoqContext db)
        {
            _db = db;
        }
        public void Create(ParkingSpot entity)
        {
            _db.ParkingSpot.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(ParkingSpot entity)
        {
            throw new NotImplementedException();
        }

        public ParkingSpot Get(int id)
        {
            throw new NotImplementedException();
        }

        public ParkingSpot Get(Func<ParkingSpot, bool> func)
        {
            throw new NotImplementedException();
        }

        public ICollection<ParkingSpot> GetAll()
        {
            return _db.ParkingSpot.ToList();
        }

        public ICollection<ParkingSpot> GetList(Func<ParkingSpot, bool> wherefunc)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ParkingSpot entity)
        {
            throw new NotImplementedException();
        }
    }
}
