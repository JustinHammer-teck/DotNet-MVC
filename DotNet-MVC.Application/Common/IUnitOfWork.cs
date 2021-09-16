using System;
using DotNet_MVC.Application.Common.Repository;

namespace DotNet_MVC.Application.Common
{
    public interface IUnitOfWork : IDisposable
    {
        ICaterogyRepository Caterogy { get; }

        ICovertypeRepository Covertype { get; }

        IStoreProcedure Procedure { get; }

        void Save();
    }
}