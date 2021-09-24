using MyMarketProject.filters;
using MyMarketProject.Models;
using MyMarketProject.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyMarketProject.Controllers
{
    
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: Category
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Get(int? CategoryId, int? BrandId, int Page=1)
        {
            if (CategoryId == null)
            {
                return HttpNotFound();
            }
            if (BrandId == null)
            {
                int PageSize = 4;
                IEnumerable<Product> products;
                products = await categoryService.GetAsync(CategoryId);

                ViewBag.CategoryId = CategoryId;
                ViewBag.BrandId = null;
                products = FilterPrice(Request.Cookies.Get("RangeMin"), Request.Cookies.Get("RangeMax"), products);
                products = SortBy(Request.Cookies.Get("SortByAttr"), products);
                return View("Products",products.ToPagedList(Page,PageSize));
            }
            else
            {
                int PageSize = 4;
                IEnumerable<Product> products;
                products = await categoryService.GetAsync(CategoryId,BrandId);

                ViewBag.CategoryId = CategoryId;
                ViewBag.BrandId = BrandId;
                products = FilterPrice(Request.Cookies.Get("RangeMin"), Request.Cookies.Get("RangeMax"), products);
                products = SortBy(Request.Cookies.Get("SortByAttr"), products);
                return View("Products",products.ToPagedList(Page, PageSize));
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> Search(string SearchText,int Page=1)
        {
            int PageSize = 4;
            var SearchResult = await categoryService.SearchAsync(SearchText);
            SearchResult = FilterPrice(Request.Cookies.Get("RangeMin"), Request.Cookies.Get("RangeMax"), SearchResult);
            SearchResult = SortBy(Request.Cookies.Get("SortByAttr"), SearchResult);
            ViewBag.SearchText = SearchText;
            return View("Search", SearchResult.ToPagedList(Page,PageSize));

        }
        private IEnumerable<Product> SortBy(HttpCookie SortByAttr, IEnumerable<Product> products)
        {
            if (SortByAttr != null)
            {
                switch (SortByAttr.Value.ToLower())
                {
                    case "ascending":
                        return products.OrderByDescending(p => p.Price);
                    case "descending":
                        return products.OrderBy(p => p.Price);
                    default:
                        return products;
                }
            }
            return products;
        }
        private IEnumerable<Product> FilterPrice(HttpCookie minPrice, HttpCookie maxPrice, IEnumerable<Product> products)
        {
            int? _minPrice = null;
            if (minPrice != null)
            {
                if (!string.IsNullOrWhiteSpace(minPrice.Value))
                {
                    _minPrice = Convert.ToInt32(minPrice.Value);
                }
            }
            int? _maxPrice = null;
            if (maxPrice != null)
            {
                if (!string.IsNullOrWhiteSpace(maxPrice.Value))
                {
                    _maxPrice = Convert.ToInt32(maxPrice.Value);
                }
            }
            decimal? MinPrice = _minPrice ?? int.MinValue;
            decimal? MaxPrice = _maxPrice ?? int.MaxValue;
            return products.Where(P => Convert.ToInt32(P.Price) >= MinPrice && Convert.ToInt32(P.Price) <= MaxPrice);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public PartialViewResult Add()
        {
            return PartialView("_AddPartial", new Category());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Add(Category C,List<int> CategoryBrands)
        {
            if(!ModelState.IsValid)
            {
                return Json($"Произошла ошибка, проверьте вводимые данные!");
            }
            using(DataModel1 contextDB1 = new DataModel1())
            {                
                foreach(var B in CategoryBrands)
                {
                    C.Brands.Add(contextDB1.Brands.Find(B));
                }
                contextDB1.Categories.Add(C);
                contextDB1.SaveChanges();
            }

            return Json($"Категория {C.Name} успешно добавлена");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditOrDeleteCategoryTable()
        {
            List<Category> CategoriesModel;
            using(DataModel1 contextDB1 = new DataModel1())
            {
                CategoriesModel = contextDB1.Categories.Include("Brands").ToList();
                
            }
            return PartialView("_EditOrDeleteCategoryTablePartial", CategoriesModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? EditCategoryId)
        {
            if(EditCategoryId == null)
            {
                return Json("Произошла ошибка отсутствует id категории!");
            }
            Category categoryModel;
            using(DataModel1 contextDB1 = new DataModel1())
            {
                categoryModel = contextDB1.Categories.Find(EditCategoryId);
                if(categoryModel == null)
                {
                    return Json("Произошла ошибка указанная категория не найдена!");
                }
                contextDB1.Entry(categoryModel).Collection("Brands").Load();
                return PartialView("_EditParial", categoryModel);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch]
        public ActionResult Edit(Category C, List<int> BrandsInCategory)
        {
            if(C.Name == null)
            {
                return Json("Произошла ошибка название категории не может быть пустым");
            }
            using(DataModel1 contextDB1 = new DataModel1())
            {
                Category CurrentCategory = contextDB1.Categories.Find(C.Id);
                if(CurrentCategory == null)
                {
                    return Json($"Произошла ошибка категория с id = {C.Id} не найдена!");
                }
                CurrentCategory.Name = C.Name;
                CurrentCategory.Brands = null;
                if(BrandsInCategory != null)
                {
                    foreach (var B in BrandsInCategory)
                    {
                        CurrentCategory.Brands.Add(contextDB1.Brands.Find(B));
                    }                   
                }
                contextDB1.Entry(CurrentCategory).State = System.Data.Entity.EntityState.Modified;
                contextDB1.SaveChanges();
                List<Category> CategoriesModel;
                CategoriesModel = contextDB1.Categories.ToList();
                return PartialView("_EditOrDeleteCategoryTablePartial", CategoriesModel);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public ActionResult Delete(int? CategoryId)
        {
            if(CategoryId == null)
            {
                return Json("Произошла ошибка остутсвует Id категории");
            }
            Category CurrentCategory;
            using(DataModel1 contextDB1 = new DataModel1())
            {
                CurrentCategory = contextDB1.Categories.Find(CategoryId);
                if(CurrentCategory == null)
                {
                    return Json($"Произошла ошибка категория с id = {CategoryId} не найдена!");
                }
                contextDB1.Entry(CurrentCategory).State = System.Data.Entity.EntityState.Deleted;
                contextDB1.SaveChanges();
                List<Category> CategoriesModel;
                CategoriesModel = contextDB1.Categories.ToList();
                return PartialView("_EditOrDeleteCategoryTablePartial", CategoriesModel);
            }
        }

    }
}