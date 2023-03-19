namespace OnlineShop.Infrastructure.Persistence.DatabaseContext;

using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common.Interfaces;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Entities.Orders;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infrastructure.Persistence.Constants;
using OnlineShop.Infrastructure.Persistence.EntityConfigurations;

public class OnlineShopWriteDbContext : DbContext
{
    private readonly IDomainEventService _domainEventService;

    public OnlineShopWriteDbContext(DbContextOptions<OnlineShopWriteDbContext> options, IDomainEventService domainEventService) : base(options)
    {
        _domainEventService = domainEventService;
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Write);
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlineShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        optionsBuilder.UseSqlServer(connectionString, builder =>
        {
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            builder.MigrationsHistoryTable("__WriteEFMigrationsHistory", Schemas.Write);
            builder.MigrationsAssembly(typeof(OnlineShopWriteDbContext).Assembly.FullName);
        });
        base.OnConfiguring(optionsBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(cancellationToken);

        return result;
    }
    private async Task DispatchEvents(CancellationToken cancellationToken)
    {
        var domainEventEntities = ChangeTracker.Entries<IHasDomainEvent>()
            .SelectMany(entity => entity.Entity.DomainEvents)
            .ToArray();

        foreach (var domainEvent in domainEventEntities)
        {
            await _domainEventService.Raise(domainEvent, cancellationToken);
        }
    }
}
