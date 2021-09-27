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
        /// <summary>
        /// Получает список всех продуктов.
        /// </summary>
        /// <returns>Возвращает колекцию продуктов.</returns>
        IEnumerable<Product> Get();
        /// <summary>
        /// Получает список продуктов соответствующих определенной категории.
        /// </summary>
        /// <param name="CategoryId">id категории.</param>
        /// <returns>Возвращает колекцию продуктов.</returns>
        IEnumerable<Product> Get(int? CategoryId);
        /// <summary>
        /// Получает список продуктов соответствующих определенной категории и бренду.
        /// </summary>
        /// <param name="CategoryId">id категории</param>
        /// <param name="BrandId">id бренда</param>
        /// <returns>Возвращает колекцию продуктов.</returns>
        IEnumerable<Product> Get(int? CategoryId, int? BrandId);
        /// <summary>
        /// Получает список продуктов содержащих в названии искомую строку.
        /// </summary>
        /// <param name="SearchText">Строка для поиска</param>
        /// <returns>Возвращает колекцию продуктов.</returns>
        IEnumerable<Product> Search(string SearchText);
        /// <summary>
        /// Асинхорнно получает список всех продуктов.
        /// </summary>
        /// <returns>Возвращает колекцию продуктов.</returns>
        Task<IEnumerable<Product>> GetAsync();
        /// <summary>
        /// Асинхорнно получает список продуктов соответствующих определенной категории.
        /// </summary>
        /// <param name="CategoryId">id категории.</param>
        /// <returns>Возвращает колекцию продуктов.</returns>
        Task<IEnumerable<Product>> GetAsync(int? CategoryId);
        /// <summary>
        /// Асинхронно получает список продуктов соответствующих определенной категории и бренду.
        /// </summary>
        /// <param name="CategoryId">id категории</param>
        /// <param name="BrandId">id бренда</param>
        /// <returns>Возвращает колекцию продуктов.</returns>
        Task<IEnumerable<Product>> GetAsync(int? CategoryId, int? BrandId);
        /// <summary>
        /// Асинхронно получает список продуктов содержащих в названии искомую строку.
        /// </summary>
        /// <param name="SearchText">Строка для поиска</param>
        /// <returns>Возвращает колекцию продуктов.</returns>
        Task<IEnumerable<Product>> SearchAsync(string SearchText);
        /// <summary>
        /// Добавляет в базу данных новую категорию.
        /// </summary>
        /// <param name="C">Объект категории</param>
        /// <param name="CategoryBrands">Масив идентификаторов брендов, для добавления в создающуюся категорию.</param>
        /// <returns>Возвращает true если добавление прошло успешно!</returns>
        bool Add(Category C, List<int> CategoryBrands);
        /// <summary>
        /// Асинхронно добавляет в базу данных новую категорию.
        /// </summary>
        /// <param name="C">Объект категории</param>
        /// <param name="CategoryBrands">Масив идентификаторов брендов, для добавления в создающуюся категорию.</param>
        /// <returns>Возвращает true если добавление прошло успешно!</returns>
        Task<bool> AddAsync(Category C, List<int> CategoryBrands);


    }
}
