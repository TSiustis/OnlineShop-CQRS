using System.Runtime.Serialization;

namespace OnlineShop.Domain.Entities.Orders;
public enum PaymentType : byte
{
    None = 0,

    [EnumMember(Value = "USD")]
    Usd = 1,
    
    [EnumMember(Value = "EUR")]
    Eur = 2,
    
    [EnumMember(Value = "GBP")]
    Gbp = 3
}
