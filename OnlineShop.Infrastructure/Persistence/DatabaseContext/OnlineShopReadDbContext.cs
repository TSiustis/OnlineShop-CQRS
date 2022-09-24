using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Infrastructure.Persistence.Constants;
using OnlineShop.Infrastructure.Persistence.EntityConfigurations;

namespace OnlineShop.Infrastructure.Persistence.DatabaseContext;

public class OnlineShopReadDbContext : DbContext
{
    public OnlineShopReadDbContext()
    {

    }

    public OnlineShopReadDbContext(DbContextOptions<OnlineShopReadDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=OnlineShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        optionsBuilder.UseSqlServer(connectionString, builder =>
        {
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            builder.MigrationsHistoryTable("__ReadEFMigrationsHistory", Schemas.Read);
            builder.MigrationsAssembly(typeof(OnlineShopReadDbContext).Assembly.FullName);
        });
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Read);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }
}