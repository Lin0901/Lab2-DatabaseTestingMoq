using DatabaseTestingMoq.Data;
using DatabaseTestingMoq.Models;

namespace DatabaseTestingMoq.DAL
{
    
    public class PassRepository : IRepository<Pass>
    {
        public DatabaseTestingMoqContext _db { get; set; }
        public void Create(Pass entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public ICollection<Pass> GetList(Func<Pass, bool> wherefunc)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Pass entity)
        {
            throw new NotImplementedException();
        }
    }
}
