using DotNet_MVC.Domain.Intities;

namespace DotNet_MVC.Application.Common.Repository
{
    public interface ICovertypeRepository : IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}