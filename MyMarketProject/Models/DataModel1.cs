using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyMarketProject.Models
{
    public class DataModel1 : DbContext
    {
        public DataModel1():base("DefaultConnection") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(C => C.Brands).
                WithMany(B => B.Categories).
                Map(C => C.MapLeftKey("CategoryId").
                MapRightKey("BrandId").
                ToTable("CategoryBrand"));
            base.OnModelCreating(modelBuilder);
        }
    }
}