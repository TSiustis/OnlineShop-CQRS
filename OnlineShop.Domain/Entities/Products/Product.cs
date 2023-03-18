using OnlineShop.Domain.Common.Interfaces;

namespace OnlineShop.Domain.Entities.Products;

using OnlineShop.Domain.Common;

public class Product : Entity, IAggregateRoot, IHasDomainEvent
{ 
    public Product(int id, string name, string description, decimal price, int stock, string category)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Category = category;
    }

    public Product()
    {

    }

    /// <summary>
    /// Gets the product name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the description.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Gets or sets the stock.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity has been deleted
    /// </summary>
    public bool Deleted { get; set; }
    
    /// <summary>
    /// Gets the person that created the product.
    /// </summary>
    public string CreatedBy { get; }

    /// <summary>
    /// Gets  the person that updated the product.
    /// </summary>
    public string UpdatedBy { get; }

    /// <summary>
    /// Gets the date and time of product creation
    /// </summary>
    public DateTimeOffset CreatedOn { get; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date and time of product update
    /// </summary>
    public DateTimeOffset UpdatedOn { get; }
}
