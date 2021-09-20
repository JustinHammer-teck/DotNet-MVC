using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_MVC.Services.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }
    }
}