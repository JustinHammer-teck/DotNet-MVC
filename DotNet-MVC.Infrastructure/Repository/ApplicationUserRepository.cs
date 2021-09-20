using System.Linq;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Domain.Intities;
using DotNet_MVC.Infrastructure.Persistence;

namespace DotNet_MVC.Infrastructure.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;


        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
    }
}