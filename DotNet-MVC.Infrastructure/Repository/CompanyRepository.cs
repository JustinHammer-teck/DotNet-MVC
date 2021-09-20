using System.Linq;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Domain.Intities;
using DotNet_MVC.Infrastructure.Persistence;

namespace DotNet_MVC.Infrastructure.Repository
{
    public class CompanyRepository : Repository<Company> , ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            var obj = _db.CoverType.FirstOrDefault(s => s.Id == company.Id);

            if (obj != null)
            {
                obj.Name = company.Name;

                _db.SaveChanges();
            }
        }
    }
}