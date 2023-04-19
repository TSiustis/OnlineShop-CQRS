namespace OnlineShop.Domain.Entities.Orders;
public enum OrderStatus
{
    None = 0,

    New = 1,

    InCart = 2,
    
    Shipped = 3,

    Delivered = 4,

    Canceled = 5

}
