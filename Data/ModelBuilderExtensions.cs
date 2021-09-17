using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationRB.Models;

namespace WebApplicationRB.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            System.Diagnostics.Debug.WriteLine("ModelBuilderExtensions " );
            var categories = new Category[]
            {
                new Category{ID=1,Name="Vegetables"},
                new Category{ID=2,Name="Fruits"},
                new Category{ID=3,Name="Meats"},
                new Category{ID=4,Name="Juices"},
                new Category{ID=5,Name="Cheese"}
            };
            var products = new Product[]
            {
                new Product{ID=1,Name="Pepper",Price=(decimal)12.50,CategoryID=1,Description="Direct import from Chile",Modified=DateTime.Now},
                new Product{ID=2,Name="Cucumber",Price=(decimal)14.50,CategoryID=1,Description="Cucumber,Cucumber,Very Green",Modified=DateTime.Now},
                new Product{ID=3,Name="Salami",CategoryID=3,Price=(decimal)14.24,Description="Salami,Salami,Salami",Modified=DateTime.Now},
                new Product{ID=4,Name="Tomato",Price=(decimal)17.46,CategoryID=1,Description="Spain tomato (tomato)",Modified=DateTime.Now},
                new Product{ID=5,Name="Carrot",Price=(decimal)12.16,CategoryID=5,Description="Finland carrot",Modified=DateTime.Now},
                new Product{ID=6,Name="Orange juice",Price=(decimal)3.46,CategoryID=4,Description="Juice from hawaii",Modified=DateTime.Now}
            };
            modelBuilder.Entity<Category>().HasData(new Category { ID = 1, Name = "Vegetables" }, new Category { ID = 2, Name = "Vegetables222" });
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
