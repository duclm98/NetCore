using Microsoft.EntityFrameworkCore;
using NetCore.Data.Entities;

namespace NetCore.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserId = 1,
                    Username = "duclm21",
                    Password = "$2a$05$pUOMJMojqb9AEY9ua8mMTOqa70Qyq4kFMiCWKPS8VaCh2N27OP6Ou" // 123456a@
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    Name = "Category 1",
                },
                new Category()
                {
                    CategoryId = 2,
                    Name = "Category 2"
                },
                new Category()
                {
                    CategoryId = 3,
                    Name = "Category 3"
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    Name = "Product 1",
                    Price = 100
                },
                new Product()
                {
                    ProductId = 2,
                    Name = "Product 2",
                    Price = 200
                },
                new Product()
                {
                    ProductId = 3,
                    Name = "Product 3",
                    Price = 600
                },
                new Product()
                {
                    ProductId = 4,
                    Name = "Product 4",
                    Price = 400
                },
                new Product()
                {
                    ProductId = 5,
                    Name = "Product 5",
                    Price = 900
                }
            );
        }
    }
}
