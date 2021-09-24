using MyMarketProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMarketProject.filters
{
    public class LoadCategoriesAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           using(DataModel1 contextDB1 = new DataModel1())
           {
                List<Category> Categories = contextDB1.Categories.ToList();
                foreach (var C in Categories)
                {
                    contextDB1.Entry(C).Collection("Brands").Load();
                }
                List<Brand> Brands = contextDB1.Brands.ToList();
                foreach (var B in Brands)
                {
                    contextDB1.Entry(B).Collection("Categories").Load();
                }
                filterContext.Controller.ViewBag.SiteCategories = Categories;
                filterContext.Controller.ViewBag.SiteBrands = Brands;
            }          
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}