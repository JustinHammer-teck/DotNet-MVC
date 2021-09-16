using DotNet_MVC.Application.Common;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Application.Data;
using DotNet_MVC.Infrastructure.Repository;

namespace DotNet_MVC.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Caterogy = new CaterogyRepository(_db);
            Covertype = new CovertypeRepository(_db);
            Procedure = new StoreProcedure(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public ICaterogyRepository Caterogy { get; private set; }
        public ICovertypeRepository Covertype { get; private set; }
        public IStoreProcedure Procedure { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}