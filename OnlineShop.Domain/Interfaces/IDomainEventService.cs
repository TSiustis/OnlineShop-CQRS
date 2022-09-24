using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    using OnlineShop.Domain.Common;

    public interface IDomainEventService
    {
        Task Raise(DomainEvent domainEvent, CancellationToken cancellationToken);
    }
}
