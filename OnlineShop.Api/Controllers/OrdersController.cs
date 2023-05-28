using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineShop.Application.Order.Commands.AddOrder;
using OnlineShop.Application.Order.Commands.DeleteOrder;
using OnlineShop.Application.Order.Commands.UpdateOrder;
using OnlineShop.Application.Order.Dto;
using OnlineShop.Application.Order.Queries.GetOrder;
using OnlineShop.Application.Order.Queries.GetOrders;
using OnlineShop.Domain.Common.Pagination;

namespace OnlineShop.Api.Controllers;

public class OrdersController : ApiController
{
    /// <summary>
    /// Retrieves an order with specified id.
    /// </summary>
    /// <param name="id">Id to search for.</param>
    /// <returns>The order with the specified id</returns>
    [HttpGet("orders/{id:int}")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<OrderDto>> GetOrder(int id)
    {
        var result = await Mediator.Send(new GetOrderQuery(id));

        return Ok(result);
    }

    /// <summary>
    /// Retrieves the list of all orders.
    /// </summary>
    /// <returns>The list of customers.</returns>
    [HttpGet("orders")]
    [ProducesResponseType(typeof(PaginatedResult<OrderDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<PaginatedResult<OrderDto>>> GetOrders(int pageNumber, int pageSize)
    {
        var result = await Mediator.Send(new GetOrdersQuery());

        var metadata = new
        {
            result.TotalRecords,
            result.PageSize,
            result.PageNumber,
            result.TotalPages,
            result.HasNext,
            result.HasPrevious
        };

        Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(result);
    }

    /// <summary>
    /// Creates a new Order.
    /// </summary>
    /// <param name="orderInputDto">Input fields.</param>
    /// <returns>Order creation return code</returns>
    [HttpPost("orders")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> AddOrder([FromBody] OrderInputDto orderInputDto)
    {
        await Mediator.Send(new AddOrderCommand(orderInputDto));

        return StatusCode(201);
    }

    /// <summary>
    /// Updates an existing Order.
    /// </summary>
    /// <param name="orderInputDto">Input fields.</param>
    /// <returns>Order update return code</returns>
    [HttpPut("orders")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> UpdateOrder(OrderInputDto orderInputDto)
    {
        await Mediator.Send(new UpdateOrderCommand(orderInputDto));

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing Order.
    /// </summary>
    /// <param name="id">Id of the order to be deleted.</param>
    /// <returns>Order deletion return code</returns>
    [HttpDelete("orders/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> DeleteOrder(int id)
    {
        await Mediator.Send(new DeleteOrderCommand(id));

        return NoContent();
    }
}
