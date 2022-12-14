using DatabaseTestingMoq.Data;
using DatabaseTestingMoq.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseTestingMoq.DAL
{
    
    public class PassRepository : IRepository<Pass>
    {
        private DatabaseTestingMoqContext _db { get; set; }
        public PassRepository(DatabaseTestingMoqContext db)
        {
            _db = db;
        }
        public void Create(Pass entity)
        {
            _db.Passes.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Pass entity)
        {
            throw new NotImplementedException();
        }

        public Pass Get(int id)
        {
            throw new NotImplementedException();
        }

        public Pass Get(Func<Pass, bool> func)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pass> GetAll()
        {
            return _db.Passes.ToList();
        }

        public ICollection<Pass> GetList(Func<Pass, bool> wherefunc)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Pass entity)
        {
            throw new NotImplementedException();
        }
    }
}
