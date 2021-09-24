namespace MyMarketProject.Migrations
{
    using global::MyMarketProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModel1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataModel1 context)
        {
            //context.Brands.Add(new Models.Brand() { Id = 1, Name = "Huawei" });
            //context.Brands.Add(new Models.Brand() { Id = 2, Name = "Xiaomi" });
            //context.Brands.Add(new Models.Brand() { Id = 3, Name = "Meizu" });
            //context.Brands.Add(new Models.Brand() { Id = 4, Name = "Lenono" });
            //context.Brands.Add(new Models.Brand() { Id = 5, Name = "Apple" });
            //context.Brands.Add(new Models.Brand() { Id = 6, Name = "Samsung" });
            //context.SaveChanges();

            //context.Categories.Add(new Models.Category() { Id = 1, Name = "Смартфоны"});
            //context.Categories.Add(new Models.Category() { Id = 2, Name = "Ноутбуки и ПК" });
            //context.Categories.Find(1).Brands.Add(context.Brands.Find(1));
            //context.Categories.Find(1).Brands.Add(context.Brands.Find(2));
            //context.Categories.Find(1).Brands.Add(context.Brands.Find(3));
            //context.Categories.Find(1).Brands.Add(context.Brands.Find(4));
            //context.Categories.Find(1).Brands.Add(context.Brands.Find(5));
            //context.Categories.Find(1).Brands.Add(context.Brands.Find(6));

            //context.Categories.Find(2).Brands.Add(context.Brands.Find(4));
            //context.Categories.Find(2).Brands.Add(context.Brands.Find(5));
            //context.SaveChanges();

            //context.Products.Add(new Models.Product()
            //{
            //    Id = 1,
            //    Name = "XIAOMI Redmi Note 10 4/128 Gb Dual Sim Onyx Gray",
            //    Available = true,
            //    Img = "01.png",
            //    Price = 5999.0m,
            //    Category = context.Categories.Find(1),
            //    Brand = context.Brands.Find(2)
            //});
            //context.Products.Add(new Models.Product()
            //{
            //    Id = 2,
            //    Name = "SAMSUNG Galaxy S21 Ultra 12/256 Gb Dual Sim Phantom Black (SM-G998BZKGSEK)",
            //    Available = true,
            //    Img = "02.png",
            //    Price = 5999.0m,
            //    Category = context.Categories.Find(1),
            //    Brand = context.Brands.Find(6)
            //});
            //context.SaveChanges();
        }
    }
}
