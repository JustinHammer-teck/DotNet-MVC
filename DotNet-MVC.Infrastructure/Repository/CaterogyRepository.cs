using System.Linq;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Application.Data;
using DotNet_MVC.Domain.Intities;

namespace DotNet_MVC.Infrastructure.Repository
{
    public class CaterogyRepository : Repository<Caterogy>, ICaterogyRepository
    {
        private readonly ApplicationDbContext _db;


        public CaterogyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Caterogy caterogy)
        {
            var obj = _db.Caterogy.FirstOrDefault(s => s.Id == caterogy.Id);

            if (obj != null)
            {
                obj.Name = caterogy.Name;

                _db.SaveChanges();
            }
        }
    }
}