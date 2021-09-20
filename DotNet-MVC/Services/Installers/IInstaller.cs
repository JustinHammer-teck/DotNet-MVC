using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_MVC.Services.Installers
{
    public interface IInstaller
    {
        void InstallServices(IConfiguration configuration, 
            IServiceCollection services);
        
    }
}