using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Customer.Commands.AddCustomer;
using OnlineShop.Application.Customer.Commands.DeleteCustomer;
using OnlineShop.Application.Customer.Commands.UpdateCustomer;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Application.Customer.Queries.GetCustomer;
using OnlineShop.Application.Customer.Queries.GetCustomers;
using OnlineShop.Domain.Entities.Customers;

namespace OnlineShop.Api.Controllers;

public class CustomersController : ApiController
{

    /// <summary>
    /// Gets a customer with specified id.
    /// </summary>
    /// <param name="id">Id to search for.</param>
    /// <returns>The customer with the specified id</returns>
    [HttpGet("customers/{id:int}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var result = await Mediator.Send(new GetCustomerQuery(id));

        return Ok(result);
    }

    /// <summary>
    /// Gets the list of all customers.
    /// </summary>
    /// <returns>The list of customers.</returns>
    [HttpGet("customers")]
    public async Task<ActionResult<IList<CustomerDto>>> GetCustomers()
    {
        var result = await Mediator.Send(new GetCustomersQuery());

        return Ok(result);
    }

    /// <summary>
    /// Creates a new Customer.
    /// </summary>
    /// <param name="customerInputDto">Input fields.</param>
    /// <returns>Customer</returns>
    [HttpPost("customers")]
    public async Task<ActionResult> AddCustomer(CustomerInputDto customerInputDto)
    {
        await Mediator.Send(new AddCustomerCommand(customerInputDto));

        return StatusCode(201);
    }

    /// <summary>
    /// Updates an existing Customer.
    /// </summary>
    /// <param name="customerInputDto">Input fields.</param>
    /// <returns>Customer</returns>
    [HttpPut("customers")]
    public async Task<ActionResult> UpdateCustomer(CustomerInputDto customerInputDto)
    {
        await Mediator.Send(new UpdateCustomerCommand(customerInputDto));

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing Customer.
    /// </summary>
    /// <param name="id">Id of the customer to be deleted.</param>
    /// <returns>Customer</returns>
    [HttpDelete("customers/{id}")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        await Mediator.Send(new DeleteCustomerCommand(id));

        return NoContent();
    }
}
