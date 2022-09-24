using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Application.Common.Pagination;

namespace OnlineShop.Application.Customer.Dto;
public class CustomerFilterDto : PaginationFilter
{
    public CustomerFilterDto(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    public bool SortDirection { get; set; }
}
