using DotNet_MVC.Application.Common;
using DotNet_MVC.Infrastructure;
using DotNet_MVC.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_MVC.Services.Installers
{
    public class GenericInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddInfrastructure(configuration);
        }
    }
}