namespace OnlineShop.Domain.Common;

public class Address : ValueObject
{
    public string Street { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    public string ZipCode { get; set; }

    private Address()
    {
        
    }

    public Address(string street, string city, string country, string zipCode)
    {
        Street = street;
        City = city;
        Country = country;
        ZipCode = zipCode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return Country;
        yield return ZipCode;
    }

    protected override int GetHashCodeCore()
    {
        throw new NotImplementedException();
    }
}
