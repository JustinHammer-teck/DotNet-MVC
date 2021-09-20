using System.Linq;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Domain.Intities;
using DotNet_MVC.Infrastructure.Persistence;

namespace DotNet_MVC.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;


        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var obj = _db.Category.FirstOrDefault(s => s.Id == category.Id);

            if (obj != null)
            {
                obj.Name = category.Name;

                _db.SaveChanges();
            }
        }
    }
}