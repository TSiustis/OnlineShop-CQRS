using OnlineShop.Domain.Common;
using OnlineShop.Domain.Common.Interfaces;

namespace OnlineShop.Domain.Entities.Customers;
public class Customer : Entity, IAggregateRoot, IHasDomainEvent
{
    /// <summary>
    /// Gets the first name.
    /// </summary>
    public string FirstName { get;  set; } = string.Empty;

    /// <summary>
    /// Gets the last name.
    /// </summary>
    public string LastName { get;  set; } = string.Empty;

    /// <summary>
    /// Gets the address.
    /// </summary>
    public Address Address { get; set; }

    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets the phone number.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    public Customer()
    {
        
    }

    public Customer(string firstName, string lastName, Address address, string email, string phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public Customer(int id, string firstName, string lastName, Address address, string email, string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
