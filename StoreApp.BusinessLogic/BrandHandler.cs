using StoreApp.BusinessLogic.BusinessEntities;
using StoreApp.DataAccess;
using StoreApp.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.BusinessLogic
{
   public class BrandHandler
    {
        private readonly GenericRepository<Brand> brandRepo;
        private readonly BrandRepository<Brand> brandCustomRepo;

        public BrandHandler()
        {
            brandRepo = new GenericRepository<Brand>();
            brandCustomRepo = new BrandRepository<Brand>();
        }

        public BrandModel GetById(int id)
        {
            var brand = brandRepo.ReadById(id);
            return new BrandModel(){
                BrandId=brand.BrandId,
                Name = brand.Name
            };
        }
        public List<BrandModel> GetBrands()
        {
            var brandList = brandRepo.ReadAll();
            var brandListBL = new List<BrandModel>();
            foreach (var brand in brandList)
            {

                brandListBL.Add(new BrandModel()
                {
                    Name = brand.Name,
                    BrandId = brand.BrandId,
                });
            }
            return brandListBL;
        }

        public List<BrandModel> ReadByIds(List<int> brandIdsList)
        {
            var brandList = new List<BrandModel>();
            foreach (var b in brandCustomRepo.ReadByIds(brandIdsList))
            {
                brandList.Add(
                    new BrandModel
                    {
                        BrandId = b.BrandId,
                        Name = b.Name
                    }
                );
            }
            return brandList;
        }
    }
}
