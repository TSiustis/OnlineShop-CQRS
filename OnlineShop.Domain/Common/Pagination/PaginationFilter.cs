using System.Linq.Expressions;

namespace OnlineShop.Domain.Common.Pagination;
public class PaginationFilter<T> where T : Entity
{
    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;

    public int GetSkipCount()
    {
        return (PageNumber - 1) * PageSize;
    }

    public Expression<Func<T, bool>> SearchFilter { get; set; }
}
