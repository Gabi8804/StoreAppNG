using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.BusinessLogic;
using StoreApp.BusinessLogic.BusinessEntities;
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
    public class ProductsController : Controller
    {
        private readonly ProductHelper productHelper;
        private readonly ProductHandler productHandler;
        private readonly CategoryHandler categoryHandler;
        private readonly BrandHandler brandHandler;
        public ProductsController()
        {
            productHandler = new ProductHandler();
            brandHandler = new BrandHandler();
            categoryHandler = new CategoryHandler();
            productHelper = new ProductHelper();
        }




        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<ProductViewModel>> Get()
        {
            try
            {
                var productList = new List<ProductViewModel>();
                var products = productHandler.GetAllProducts();
                foreach (var product in products)
                {
                    productList.Add(new ProductViewModel
                    {
                        ProductId = product.ProductId,
                        BrandCategoryId = product.BrandCategoryId,
                        Name = product.Name,
                        Price = product.Price
                    });
                    
                }
                return Ok(productList);
            }
            catch (Exception)
            {
                return BadRequest("failed to get products");
            }
            return BadRequest("failed to get products");
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<ProductViewModel> Details(int id)
        {
            try
            {
                var product = productHelper.GetProductById(id);
                return Ok(product);
                
            }
            catch (Exception)
            {
                return BadRequest("failed to get products");
            }
            
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult Create([FromBody]NgProductViewModel ngProduct)
        {
            var product = new ProductViewModel()
            {
                Brand = new BrandViewModel()
                {
                    BrandId =Convert.ToInt32(ngProduct.BrandId)
                },
                Category = new CategoryViewModel()
                {
                    CategoryId = Convert.ToInt32(ngProduct.CategoryId)
                },
                Name = ngProduct.Name,
                Description = ngProduct.Description,
                Price = ngProduct.Price
            };
            try
            {
                var brandModel = new BrandModel()
                {
                    BrandId = product.Brand.BrandId,
                    Name = product.Brand.Name
                };
                var categoryModel = new CategoryModel()
                {
                    CategoryId = product.Category.CategoryId,
                    Name = product.Category.Name
                };
                var BrandCategoryId = productHandler.GetBrandCategoryId(brandModel, categoryModel);

                var productToCreate = new ProductModel
                {
                    BrandCategoryId = BrandCategoryId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    DateCreated = DateTime.Now,
                    Quantity=1
                };
                productHandler.CreateProductAndGetId(productToCreate);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("failed to get products");
            }

               
        }

    }
}
