using System.ComponentModel.DataAnnotations;

namespace DotNet_MVC.Domain.Intities
{
    public class CoverType
    {
        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Cover Type")]
        public string Name { get; set; }
    }
}