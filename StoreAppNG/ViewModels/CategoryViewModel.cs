using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreAppNG.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public string Name { get; set; }

    }
}