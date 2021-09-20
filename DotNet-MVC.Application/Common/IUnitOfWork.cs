using System;
using DotNet_MVC.Application.Common.Repository;

namespace DotNet_MVC.Application.Common
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        ICovertypeRepository Covertype { get; }

        IProductRepository Product { get; }

        ICompanyRepository Company { get; }
        IApplicationUserRepository ApplicationUser { get; }
        
        IStoreProcedure Procedure { get; }

        void Save();
    }
}