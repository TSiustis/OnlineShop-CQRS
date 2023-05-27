using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Customer.Commands.AddCustomer;
using OnlineShop.Application.Customer.Commands.DeleteCustomer;
using OnlineShop.Application.Customer.Commands.UpdateCustomer;
using OnlineShop.Application.Customer.Dto;
using OnlineShop.Application.Customer.Queries.GetCustomer;
using OnlineShop.Application.Customer.Queries.GetCustomers;
using OnlineShop.Domain.Common.Pagination;

namespace OnlineShop.Api.Controllers;

public class CustomersController : ApiController
{

    /// <summary>
    /// Retrieves a customer with specified id.
    /// </summary>
    /// <param name="id">Id to search for.</param>
    /// <returns>The customer with the specified id</returns>
    [HttpGet("customers/{id:int}")]
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
    {
        var result = await Mediator.Send(new GetCustomerQuery(id));

        return Ok(result);
    }

    /// <summary>
    /// Retrieves the list of all customers.
    /// </summary>
    /// <returns>The list of customers.</returns>
    [HttpGet("customers")]
    [ProducesResponseType(typeof(PaginatedResult<CustomerDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<PaginatedResult<CustomerDto>>> GetCustomers(int pageNumber, int pageSize)
    {
        var result = await Mediator.Send(new GetCustomersQuery());

        return Ok(result);
    }

    /// <summary>
    /// Creates a new Customer.
    /// </summary>
    /// <param name="customerInputDto">Input fields.</param>
    /// <returns>Customer create return code</returns>
    [HttpPost("customers")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> AddCustomer(CustomerInputDto customerInputDto)
    {
        await Mediator.Send(new AddCustomerCommand(customerInputDto));

        return StatusCode(201);
    }

    /// <summary>
    /// Updates an existing Customer.
    /// </summary>
    /// <param name="customerInputDto">Input fields.</param>
    /// <returns>Customer update return code </returns>
    [HttpPut("customers")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> UpdateCustomer(CustomerInputDto customerInputDto)
    {
        await Mediator.Send(new UpdateCustomerCommand(customerInputDto));

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing Customer.
    /// </summary>
    /// <param name="id">Id of the customer to be deleted.</param>
    /// <returns>Customer deletion return code</returns>
    [HttpDelete("customers/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        await Mediator.Send(new DeleteCustomerCommand(id));

        return NoContent();
    }
}
