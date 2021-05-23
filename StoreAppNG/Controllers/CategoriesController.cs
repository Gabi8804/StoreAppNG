using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.BusinessLogic;
using StoreAppNG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreAppNG.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriesController : Controller
    {
        private readonly ProductHelper productHelper;
        private readonly ProductHandler productHandler;
        private readonly CategoryHandler categoryHandler;
        private readonly BrandHandler brandHandler;
        public CategoriesController()
        {
            productHandler = new ProductHandler();
            brandHandler = new BrandHandler();
            categoryHandler = new CategoryHandler();
            productHelper = new ProductHelper();
        }




        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<CategoryViewModel>> Get()
        {
            try
            {
                var categoryList = new List<CategoryViewModel>();
                var categories = categoryHandler.GetCategories();
                foreach (var category in categories)
                {
                    categoryList.Add(new CategoryViewModel
                    {
                        CategoryId=category.CategoryId,
                        Name = category.Name,
                    });
                    
                }
                return Ok(categoryList);
            }
            catch (Exception)
            {
                return BadRequest("failed to get products");
            }
            
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<BrandViewModel>> GetBrands(int id)
        {
            try
            {
                var brandsOfCategory = productHandler.GetBrandsOfSelectedCategory(id);
                var listOfBrands = new List<BrandViewModel>();

                foreach (var b in brandsOfCategory)
                {
                    listOfBrands.Add(new BrandViewModel
                    {
                        BrandId = b.BrandId,
                        Name = b.Name
                    });
                }
                return Ok(listOfBrands);

            }
            catch (Exception)
            {
                return BadRequest("failed to get brands");
            }

        }
        

    }
}
