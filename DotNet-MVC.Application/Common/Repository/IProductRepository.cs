using DotNet_MVC.Domain.Intities;

namespace DotNet_MVC.Application.Common.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}