using System.Linq;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Application.Data;
using DotNet_MVC.Domain.Intities;

namespace DotNet_MVC.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;


        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var obj = _db.Product.FirstOrDefault(s => s.Id == product.Id);

            if (obj != null)
            {
                if (product.ImageUrl != null)
                {
                    obj.ImageUrl = product.ImageUrl;
                }
                obj.Title = product.Title;
                obj.ISBN = product.ISBN;
                obj.ListPrice = product.ListPrice;
                obj.Price = product.Price;
                obj.Price50 = product.Price50;
                obj.Price100 = product.Price100;
                obj.Description = product.Description;
                obj.CategoryId = product.CategoryId;
                obj.Author = product.Author;
                obj.CoverTypeId = product.CoverTypeId;
                
                _db.SaveChanges();
            }
        }
    }
}