using Microsoft.AspNetCore.Mvc;
using StoreApp.BusinessLogic;
using StoreApp.BusinessLogic.BusinessEntities;
using StoreAppNG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp.Controllers
{
    public class SpecificationsController : Controller
    {
        private readonly SpecificationsHandler specsHandler;

        public SpecificationsController()
        {
            specsHandler = new SpecificationsHandler();
        }
        // GET: Specifications
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public ActionResult Create(SpecificationsListViewModel spec)
        {
            var specViewModelList = new List<SpecificationsViewModel>();
            var specsList = specsHandler.GetSpecs(spec.CategoryId);
            var catSpecsList = specsHandler.GetCatSpecs(spec.CategoryId);

            foreach (var s in specsList)
            {
                specViewModelList.Add(new SpecificationsViewModel
                {
                    Name = s.Name,
                    SpecId = s.SpecId,
                    CatSpecId = catSpecsList
                    .Where(x => x.SpecId == s.SpecId & x.CategoryId== spec.CategoryId)
                    .Select(x => x.CategorySpecsId)
                    .First(),
                    Value =s.Value

                }) ;
            }
            var specs = new SpecificationsListViewModel()
            {
                ProductId = spec.ProductId,
                Specifications = specViewModelList,
                CategoryId=spec.CategoryId
            };

            return View(specs);
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateSpec(SpecificationsListViewModel specs)
        {
            if (ModelState.IsValid)
            {
            var prod_CatSpedList = new List<Prod_CatSpecModel>();
            foreach(var s in specs.Specifications)
            {
                prod_CatSpedList.Add(new Prod_CatSpecModel
                {
                    ProductId=specs.ProductId,
                    SpecValue=s.Value,
                    CategorySpecId=s.CatSpecId
                });
            }
            specsHandler.Create(prod_CatSpedList);
                return RedirectToAction("Index", "Product");
            }
            return View(specs);
        }
    }
}