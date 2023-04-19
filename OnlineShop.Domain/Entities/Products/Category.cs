using OnlineShop.Domain.Common;

namespace OnlineShop.Domain.Entities.Products
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public Category(string name)
        {
            Name = name;
        }
    }
}
