using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreAppNG.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public int BrandCategoryId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public List<SpecificationsViewModel> Specifications { get; set; }

        public CategoryViewModel Category { get; set; }
        public BrandViewModel Brand { get; set; }
        
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public ProductViewModel()
        {
            Brands = new List<SelectListItem>();
            Categories = new List<SelectListItem>();
            Category = new CategoryViewModel();
            Brand = new BrandViewModel();
        }

    }
}
