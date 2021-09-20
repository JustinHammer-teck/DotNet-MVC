using DotNet_MVC.Application.Common;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Application.Data;
using DotNet_MVC.Domain.Intities;
using DotNet_MVC.Infrastructure.Repository;

namespace DotNet_MVC.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Covertype = new CovertypeRepository(_db);
            Procedure = new StoreProcedure(_db);
            Product = new ProductRepository(_db);
            Company = new CompanyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public ICategoryRepository Category { get; private set; }
        public ICovertypeRepository Covertype { get; private set; }
        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; }
        public IStoreProcedure Procedure { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}