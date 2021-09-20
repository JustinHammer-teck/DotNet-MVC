﻿using DotNet_MVC.Application.Common;
using DotNet_MVC.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet_MVC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            
            
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IEmailSender, EmailSender>();

            return services;
        }
    }
}