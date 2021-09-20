using DotNet_MVC.Domain.Intities;

namespace DotNet_MVC.Application.Common.Repository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company company);
    }
}