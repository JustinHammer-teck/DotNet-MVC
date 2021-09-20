using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;

namespace DotNet_MVC.Domain.Intities
{
    public class ApplicationUser : IdentityUser
    {
        [Required] public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")] public Company Company { get; set; }
        [NotMapped] public string Role { get; set; }
    }
}