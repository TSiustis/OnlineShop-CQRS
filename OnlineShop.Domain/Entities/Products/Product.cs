using OnlineShop.Domain.Common.Interfaces;

namespace OnlineShop.Domain.Entities.Products;

using OnlineShop.Domain.Common;

public class Product : Entity, IAggregateRoot, IHasDomainEvent
{ 
    public Product(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }
}
