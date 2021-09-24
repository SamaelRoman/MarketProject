using MyMarketProject.Controllers;
using MyMarketProject.Models;
using MyMarketProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyMarketProject.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;
        public CategoryService(IRepository repository)
        {
            this.repository = repository;
        }
        public IEnumerable<Product> Get()
        {
            return repository.GetProducts();
        }

        public IEnumerable<Product> Get(int? CategoryId)
        {
            return repository.GetProducts().Where(P => P.CategoryId == CategoryId);
        }

        public IEnumerable<Product> Get(int? CategoryId, int? BrandId)
        {
            return repository.GetProducts().Where(P => P.CategoryId == CategoryId && P.BrandId == BrandId);
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await repository.GetProductsAsync();
        }

        public async Task<IEnumerable<Product>> GetAsync(int? CategoryId)
        {
            var result = await repository.GetProductsAsync();
            return result.Where(P => P.CategoryId == CategoryId);
        }

        public async Task<IEnumerable<Product>> GetAsync(int? CategoryId, int? BrandId)
        {
            var result = await repository.GetProductsAsync();
            return result.Where(P => P.CategoryId == CategoryId && P.BrandId == BrandId);
        }

        public IEnumerable<Product> Search(string SearchText)
        {
            return repository.GetProducts().Where(P => P.Name.Contains(SearchText));
        }

        public async Task<IEnumerable<Product>> SearchAsync(string SearchText)
        {
            var result = await repository.GetProductsAsync();
            return result.Where(P => P.Name.NewContains(SearchText,StringComparison.OrdinalIgnoreCase));
        }
    }
}