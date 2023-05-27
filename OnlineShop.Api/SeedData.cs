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
                   new() { Name = "Women's Blouse",
                       Description = "A stylish blouse perfect for any occasion.",
                       Price = 19.99M, Stock = 15, 
                       Category = new Category("Clothing"), 
                       ImageUri = "images/shirt-1", 
                       Deleted = false },
                    new() { Name = "Men's Jeans", 
                        Description = "Comfortable and durable men's jeans.",
                        Price = 29.99M, Stock = 20, 
                        Category = new Category("Clothing"), 
                        ImageUri = "images/shirt-2", 
                        Deleted = false },
                    new() { Name = "Women's Dress", 
                        Description = "Elegant dress for formal occasions.", 
                        Price = 39.99M, Stock = 5, 
                        Category = new Category("Clothing"),
                        ImageUri = "images/shirt-3", 
                        Deleted = false },
                    new() { Name = "Men's Trousers",
                        Description = "Classy trousers suitable for work or formal events.",
                        Price = 24.99M, Stock = 18, 
                        Category = new Category("Clothing"), 
                        ImageUri = "images/shoes-1", 
                        Deleted = false },
                    new() { Name = "Women's Skirt",
                        Description = "A versatile skirt for any wardrobe.", 
                        Price = 20.99M, Stock = 25, 
                        Category = new Category("Clothing"),
                        ImageUri = "images/shoes-2", 
                        Deleted = false },
                    new() { Name = "Men's Suit Jacket", 
                        Description = "A professional suit jacket for the modern man.",
                        Price = 59.99M, Stock = 10, 
                        Category = new Category("Clothing"), 
                        ImageUri = "images/hoodie-1", 
                        Deleted = false },
                    new() { Name = "Women's Blazer",
                        Description = "A chic blazer for the stylish woman.",
                        Price = 44.99M, Stock = 15, 
                        Category = new Category("Clothing"), 
                        ImageUri = "images/hoodie-2", 
                        Deleted = false },
                    new() { Name = "Men's Sweater",
                        Description = "A cozy sweater for cooler days.",
                        Price = 34.99M, Stock = 12, 
                        Category = new Category("Clothing"), 
                        ImageUri = "images/hoodie-3", 
                        Deleted = false },
                };

                dbContext.AddRange(products);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
