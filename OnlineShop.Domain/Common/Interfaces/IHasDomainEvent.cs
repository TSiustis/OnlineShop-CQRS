using System.Collections.Generic;

namespace OnlineShop.Domain.Common.Interfaces;
    public interface IHasDomainEvent
    {
        List<DomainEvent> DomainEvents { get; set; }
    }