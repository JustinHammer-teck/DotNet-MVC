using System.ComponentModel.DataAnnotations;

namespace DotNet_MVC.Domain.Intities
{
    public class Caterogy
    {
        [Key] public int Id { get; set; }

        [Display(Name = "Caterogy Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}