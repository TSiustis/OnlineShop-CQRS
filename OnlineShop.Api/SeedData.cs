using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities.Products;

namespace OnlineShop.Api
{
    public class SeedData
    {
        public static async Task EnsureSeedData(DbContext dbContext)
        {
            if (!dbContext.Set<Product>().Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Product 1",
                        Description = "This is the description for Product 1",
                        Price = 9.99M,
                        Stock = 10,
                        Category = new Category("Category 1"),
                        ImageUri = "https://example.com/product1.jpg",
                        Deleted = false
                    },
                    new Product
                    {
                        Name = "Product 2",
                        Description = "This is the description for Product 2",
                        Price = 19.99M,
                        Stock = 5,
                        Category = new Category( "Category 2"),
                        ImageUri = "https://example.com/product2.jpg",
                        Deleted = false
                    },
                    // add more products as needed
                };

                dbContext.AddRange(products);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
