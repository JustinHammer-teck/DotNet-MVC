using DotNet_MVC.Domain.Intities;

namespace DotNet_MVC.Application.Common.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}