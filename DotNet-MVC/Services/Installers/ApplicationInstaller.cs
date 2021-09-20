using DotNet_MVC.Application.Common;
using DotNet_MVC.Infrastructure;
using DotNet_MVC.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_MVC.Services.Installers
{
    public class ApplicationInstaller : IInstaller
    {
        public void InstallServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IEmailSender, EmailSender>();
        }
    }
}