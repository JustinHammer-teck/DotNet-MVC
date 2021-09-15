using System;
using System.Collections.Generic;
using System.Text;
using DotNet_MVC.Domain.Intities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNet_MVC.Application.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Caterogy> Caterogy { get; set; }
    }
}