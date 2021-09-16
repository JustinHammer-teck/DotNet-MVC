using DotNet_MVC.Domain.Intities;

namespace DotNet_MVC.Application.Common.Repository
{
    public interface ICaterogyRepository : IRepository<Caterogy>
    {
        void Update(Caterogy caterogy);
    }
}