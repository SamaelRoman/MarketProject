using MyMarketProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMarketProject.Repositories
{
    public interface IRepository
    {
        //Получение всех продуктов
        IEnumerable<Product> GetProducts();
        Task<IEnumerable<Product>> GetProductsAsync();

        //Получение продукта по id
        Product GetProduct(int Id);
        Task<Product> GetProductAsync(int Id);

        //Добавление продукта
        bool AddProduct(Product product);
        Task<bool> AddProductAsync(Product product);

        //Редактирование продукта
        bool EditProduct(Product product);
        Task<bool> EditProductAsync(Product product);

        //Удаление продукта
        bool DeleteProduct(int Id);
        Task<bool> DeleteProductAsync(int Id);

        //Получение всех категорий
        IEnumerable<Category> GetCategories();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        //Получение категории по id
        Category GetCategory(int Id);
        Task<Category> GetCategoryAsync(int Id);
        //Добавление категории
        bool AddCategory(Category category);
        Task<bool> AddCategoryAsync(Category category);
        //Редактирование категории
        //Удаление категории

        //Получение всех брендов
        IEnumerable<Brand> GetBrands();
        Task<IEnumerable<Brand>> GetBrandsAsync();
        //Получение бренда по id
        Brand GetBrand(int Id);
        Task<Brand> GetBrandAsync(int Id);
        //Добавление бренда
        //Редактирование бренда
        //Удаление бренда


    }
}
