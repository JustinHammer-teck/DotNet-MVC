using System.Collections.Generic;
using DotNet_MVC.Domain.Intities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNet_MVC.Domain.ViewModel
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        public IEnumerable<SelectListItem> CoverTypeList { get; set; }
    }
}