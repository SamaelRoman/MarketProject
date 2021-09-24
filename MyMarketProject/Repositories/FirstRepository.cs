using MyMarketProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyMarketProject.Repositories
{
    public class FirstRepository : IRepository
    {
        public bool AddProduct(Product product)
        {
            using (DataModel1 contextDB1 = new DataModel1())
            {
                try
                {
                    contextDB1.Products.Add(product);
                    contextDB1.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            using (DataModel1 contextDB1 = new DataModel1())
            {
                try
                {
                    contextDB1.Products.Add(product);
                    await contextDB1.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool DeleteProduct(int Id)
        {
            using (DataModel1 contextDB1 = new DataModel1())
            {
                try
                {
                    Product product = contextDB1.Products.Find(Id);
                    contextDB1.Entry(product).State = EntityState.Deleted;
                    contextDB1.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

        public async Task<bool> DeleteProductAsync(int Id)
        {
            using (DataModel1 contextDB1 = new DataModel1())
            {
                try
                {
                    Product product = await contextDB1.Products.FindAsync(Id);
                    contextDB1.Entry(product).State = EntityState.Deleted;
                    await contextDB1.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool EditProduct(Product product)
        {
            using (DataModel1 contextDB1 = new DataModel1())
            {
                try
                {
                    contextDB1.Entry(product).State = EntityState.Modified;
                    contextDB1.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public async Task<bool> EditProductAsync(Product product)
        {
            using (DataModel1 contextDB1 = new DataModel1())
            {
                try
                {
                    contextDB1.Entry(product).State = EntityState.Modified;
                    await contextDB1.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public Product GetProduct(int Id)
        {
            using(DataModel1 contextDB1 = new DataModel1())
            {
                return contextDB1.Products.Find(Id);
            }
        }

        public async Task<Product> GetProductAsync(int Id)
        {
            using (DataModel1 contextDB1 = new DataModel1())
            {
                return await contextDB1.Products.FindAsync(Id);
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            using(DataModel1 contextDB1 = new DataModel1())
            {
                return contextDB1.Products.ToList();
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            using (DataModel1 contextDB1 = new DataModel1())
            {
                return await contextDB1.Products.ToListAsync();
            }
        }
    }
}