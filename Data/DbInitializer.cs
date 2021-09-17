using WebApplicationRB.Models;
using System;
using System.Collections.Generic;

namespace WebApplicationRB.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var categories = new List<Category>
            {
                new Category{Name="Vegetables"},
                new Category{Name="Fruits"},
                new Category{Name="Meats"},
                new Category{Name="Juices"},
                new Category{Name="Cheese"}
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();


            var products = new List<Product>
            {
                new Product{Name="Pepper",Price=(decimal)12.50,CategoryID=1,Description="Direct import from Chile",Modified=DateTime.Now},
                new Product{Name="Cucumber",Price=(decimal)14.50,CategoryID=1,Description="Cucumber,Cucumber,Very Green",Modified=DateTime.Now},
                new Product{Name="Salami",CategoryID=3,Price=(decimal)14.24,Description="Salami,Salami,Salami",Modified=DateTime.Now},
                new Product{Name="Tomato",Price=(decimal)17.46,CategoryID=1,Description="Spain tomato (tomato)",Modified=DateTime.Now},
                new Product{Name="Carrot",Price=(decimal)12.16,CategoryID=5,Description="Finland carrot",Modified=DateTime.Now},
                new Product{Name="Orange juice",Price=(decimal)3.46,CategoryID=4,Description="Juice from hawaii",Modified=DateTime.Now}
            };
            products.ForEach(p => context.Products.Add(p));

            context.SaveChanges();
        }
    }
}
