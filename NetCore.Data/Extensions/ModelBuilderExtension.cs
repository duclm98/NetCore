using Microsoft.EntityFrameworkCore;
using NetCore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = 1,
                    Name = "Category 1",
                },
                new Category()
                {
                    ID = 2,
                    Name = "Category 2"
                },
                new Category()
                {
                    ID = 3,
                    Name = "Category 3"
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product() {
                    ID = 1,
                    Name = "Product 1",
                    Price = 100
                },
                new Product()
                {
                    ID = 2,
                    Name = "Product 2",
                    Price = 200
                },
                new Product()
                {
                    ID = 3,
                    Name = "Product 3",
                    Price = 600
                },
                new Product()
                {
                    ID = 4,
                    Name = "Product 4",
                    Price = 400
                }
            );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { CategoryID = 1, ProductID = 1},
                new ProductInCategory() { CategoryID = 1, ProductID = 2},
                new ProductInCategory() { CategoryID = 1, ProductID = 3},
                new ProductInCategory() { CategoryID = 1, ProductID = 4},
                new ProductInCategory() { CategoryID = 2, ProductID = 1 },
                new ProductInCategory() { CategoryID = 2, ProductID = 2 },
                new ProductInCategory() { CategoryID = 2, ProductID = 3 },
                new ProductInCategory() { CategoryID = 2, ProductID = 4 },
                new ProductInCategory() { CategoryID = 3, ProductID = 1 },
                new ProductInCategory() { CategoryID = 3, ProductID = 2 },
                new ProductInCategory() { CategoryID = 3, ProductID = 3 },
                new ProductInCategory() { CategoryID = 3, ProductID = 4 }
            );
        }
    }
}
