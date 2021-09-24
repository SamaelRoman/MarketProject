using MyMarketProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyMarketProject.Controllers
{
    public class BrandController : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public PartialViewResult Add()
        {
            return PartialView("_AddPartial", new Brand());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return Json($"Произошла ошибка, проверьте вводимые данные!");
            }
            using(DataModel1 contextDB1 = new DataModel1())
            {
                contextDB1.Brands.Add(brand);
                contextDB1.SaveChanges();
            }
            return Json($"Бренд {brand.Name} успешно добавлен");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditOrDeleteBrandTable()
        {
            List<Brand> BrandsModel;
            using(DataModel1 contextDB1 = new DataModel1())
            {
                BrandsModel = contextDB1.Brands.ToList();
            }
            return PartialView("_EditOrDeleteBrandTablePartial", BrandsModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        public ActionResult Edit(int? BrandId, string BrandName)
        {
            if(BrandName == null || BrandId == null)
            {
                return Json("Произошла ошибка проверьте вводимые данные");
            }
            using(DataModel1 contextDB = new DataModel1())
            {
                Brand CurrentBrand = contextDB.Brands.Find(BrandId);
                if (CurrentBrand != null)
                {
                    CurrentBrand.Name = BrandName;
                    contextDB.Entry(CurrentBrand).State = System.Data.Entity.EntityState.Modified;
                    contextDB.SaveChanges();
                    List<Brand> BrandsModel = contextDB.Brands.ToList();
                    return PartialView("_EditOrDeleteBrandTablePartial", BrandsModel);
                }
                else
                {
                    return Json("Произошла ошибка проверьте вводимые данные");
                }
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult Delete(int? BrandId)
        {
            if(BrandId == null)
            {
                return Json($"Произошла ошибка при удалении остутсвует id бренда!");
            }
            using(DataModel1 contextDB1 = new DataModel1())
            {
                Brand Currentbrand = contextDB1.Brands.Find(BrandId);
                if(Currentbrand == null)
                {
                    return Json($"Произошла ошибка при удалении бренд не найден!");
                }
                contextDB1.Entry(Currentbrand).State = System.Data.Entity.EntityState.Deleted;
                contextDB1.SaveChanges();
                List<Brand> BrandsModel = contextDB1.Brands.ToList();
                return PartialView("_EditOrDeleteBrandTablePartial", BrandsModel);
            }
        }

    }
}