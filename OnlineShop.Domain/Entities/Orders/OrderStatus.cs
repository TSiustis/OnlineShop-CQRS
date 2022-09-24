using System.Runtime.Serialization;

namespace OnlineShop.Domain.Entities.Orders;
public enum OrderStatus
{
    None = 0,

    New = 1,

    [EnumMember(Value = "In Cart")]
    InCart = 2,
    
    Shipped = 3,

    Delivered = 4,

    Closed = 5

}
