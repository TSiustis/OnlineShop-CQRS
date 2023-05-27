using System.Linq.Expressions;
using OnlineShop.Domain.Entities.Products;
using OnlineShop.Domain.Helpers;

namespace OnlineShop.Application.Products.Extensions;
public static class ProductQueryExtensions
{
    public static Expression<Func<Product, bool>> IsNotDeleted(this Expression<Func<Product, bool>> predicate)
    {
        return predicate.And(product => !product.Deleted);
    }
}
