using MyMarketProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyMarketProject.Services
{
    public interface ICategoryService
    {
        IEnumerable<Product> Get();
        IEnumerable<Product> Get(int? CategoryId);
        IEnumerable<Product> Get(int? CategoryId, int? BrandId);
        IEnumerable<Product> Search(string SearchText);
        Task<IEnumerable<Product>> GetAsync();
        Task<IEnumerable<Product>> GetAsync(int? CategoryId);
        Task<IEnumerable<Product>> GetAsync(int? CategoryId, int? BrandId);
        Task<IEnumerable<Product>> SearchAsync(string SearchText);

    }
}
