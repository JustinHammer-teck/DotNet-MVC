﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet_MVC.Domain.Intities
{
    public class Product
    {
        [Key] public int Id { get; set; }

        [Display(Name = "Product Title")]
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required] public string ISBN { get; set; }
        [Required] public string Author { get; set; }
        [Required] [Range(1000, 1000000)] public double ListPrice { get; set; }
        [Required] [Range(1000, 1000000)] public double Price { get; set; }
        [Required] [Range(1000, 1000000)] public double Price50 { get; set; }
        [Required] [Range(1000, 1000000)] public double Price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required] public int CategoryId { get; set; }
        [ForeignKey("CategoryId")] public Category Category { get; set; }
        [Required] public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")] public CoverType CoverType { get; set; }
    }
}