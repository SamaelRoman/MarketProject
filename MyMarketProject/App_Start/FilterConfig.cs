using MyMarketProject.filters;
using System.Web;
using System.Web.Mvc;

namespace MyMarketProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LoadCategoriesAttribute());
        }
    }
}
