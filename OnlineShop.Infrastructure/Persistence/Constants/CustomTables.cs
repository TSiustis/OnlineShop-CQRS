namespace OnlineShop.Infrastructure.Persistence.Constants;
public class CustomTables
{
    public static class Names
    {
        public const string Orders = "orders";
        public const string Customers = "customers";
        public const string Products = "products";
        public const string OrderItem = "order_item";
    }

    public static readonly IReadOnlyDictionary<string, string> PrimaryKeys = new Dictionary<string, string>
    {
        [Names.Orders] = "pk_orders",
        [Names.Customers] = "pk_customers",
        [Names.Products] = "pk_products"
    };
}
