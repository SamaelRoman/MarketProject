using MyMarketProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace MyMarketProject.Controllers
{
    public class ProductController : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Add()
        {
            return PartialView("_AddPartial", new Product());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(Product P,int BrandToProduct,int CategoryToProduct,HttpPostedFileBase ProductImg)
        {
            using(DataModel1 contextDB1 = new DataModel1())
            {
                P.CategoryId = CategoryToProduct;
                P.Category = contextDB1.Categories.Find(CategoryToProduct);

                P.BrandId = BrandToProduct;
                P.Brand = contextDB1.Brands.Find(BrandToProduct);
                P.Price = Convert.ToDecimal(P.Price);
                P.Img = FileDownloader.Upload(ProductImg);

                if (!ModelState.IsValid)
                {
                    return Json($"Произошла ошибка, проверьте вводимые данные!");
                }
                contextDB1.Products.Add(P);
                contextDB1.SaveChanges();
            }
            return Json($"Продукт {P.Name} успешно добавлен");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? EditProdutId)
        {
            if(EditProdutId == null)
            {
                return HttpNotFound();
            }
            Product productModel;
            using (DataModel1 contextDB1 = new DataModel1())
            {
                productModel = contextDB1.Products.Find(EditProdutId);
                if(productModel == null)
                {
                    return HttpNotFound();
                }
            }
            return View("Edit", productModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Product P,int? BrandToProduct, int? CategoryToProduct,HttpPostedFileBase ProductImg)
        {
            if(P == null || BrandToProduct == null || CategoryToProduct == null || ProductImg == null)
            {
                return View("Error");
            }
            using(DataModel1 contextDb1 = new DataModel1())
            {
                Product product = contextDb1.Products.Find(P.Id);
                if(product.Img != null)
                {
                    FileDownloader.Delete($"~/Content/ProductImg/{product.Img}");
                    product.Img = FileDownloader.Upload(ProductImg);
                }
                if(BrandToProduct != product.BrandId)
                {
                    Brand newBrand = contextDb1.Brands.Find(BrandToProduct);
                    if(newBrand != null)
                    {
                        product.BrandId = BrandToProduct;
                        product.Brand = newBrand;
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                if(CategoryToProduct != product.CategoryId)
                {
                    Category newCategory = contextDb1.Categories.Find(CategoryToProduct);
                    if(newCategory != null)
                    {
                        product.CategoryId = CategoryToProduct;
                        product.Category = newCategory;
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                product.Available = P.Available;
                product.Name = P.Name;
                product.Price = P.Price;
                contextDb1.Entry(product).State = System.Data.Entity.EntityState.Modified;
                contextDb1.SaveChanges();
                return View("Index");
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult Delete(int? DeleteProdutId)
        {
            if(DeleteProdutId == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Content("Ошибка, не был передан id продукта для удаления!", MediaTypeNames.Text.Plain);
            }
            using(DataModel1 contextDB1 = new DataModel1())
            {
                Product product = contextDB1.Products.Find(DeleteProdutId);
                if(product == null)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    return Content("Ошибка, продукт для удаления не найден!", MediaTypeNames.Text.Plain);
                }
                string ProductName = product.Name;
                contextDB1.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                contextDB1.SaveChanges();
                return Json($"Продукт {ProductName} был успешно удален!");
            }
        }
    }
}