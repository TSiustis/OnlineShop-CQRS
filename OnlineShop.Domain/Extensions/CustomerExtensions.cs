using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.Entities.Customers;
using OnlineShop.Domain.Helpers;

namespace OnlineShop.Domain.Extensions;
public static class  CustomerExtensions
{
    public static Expression<Func<Customer, bool>> AndHasFirstName(
        this Expression<Func<Customer, bool>> predicate, string firstName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            return predicate;
        }

        return predicate.And(customer => customer.FirstName == firstName);
    }

    public static Expression<Func<Customer, bool>> AndHasLastName(
        this Expression<Func<Customer, bool>> predicate, string lastName)
    {
        if (string.IsNullOrEmpty(lastName))
        {
            return predicate;
        }

        return predicate.And(customer => customer.LastName == lastName);
    }

    public static Expression<Func<Customer, bool>> AndHasEmail(
        this Expression<Func<Customer, bool>> predicate, string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            return predicate;
        }

        return predicate.And(customer => customer.Email == email);
    }

    public static Expression<Func<Customer, bool>> AndHasPhoneNumber(
        this Expression<Func<Customer, bool>> predicate, string phoneNumber)
    {
        if (string.IsNullOrEmpty(phoneNumber))
        {
            return predicate;
        }

        return predicate.And(customer => customer.PhoneNumber == phoneNumber);
    }
}
