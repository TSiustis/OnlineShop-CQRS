using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Order.Commands.DeleteOrder;
using OnlineShop.Application.Products.Commands.AddProduct;
using OnlineShop.Application.Products.Commands.DeleteProduct;
using OnlineShop.Application.Products.Commands.UpdateProduct;
using OnlineShop.Application.Products.Dto;
using OnlineShop.Application.Products.Queries.GetProduct;
using OnlineShop.Application.Products.Queries.GetProducts;

namespace OnlineShop.Api.Controllers;

public class ProductsController : ApiController
{
    /// <summary>
    /// Retrieves a product with specified id.
    /// </summary>
    /// <param name="id">Id to search for.</param>
    /// <returns>The order with the specified id</returns>
    [HttpGet("products/{id:int}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var result = await Mediator.Send(new GetProductQuery(id));

        return Ok(result);
    }

    /// <summary>
    /// Retrieves the list of all products.
    /// </summary>
    /// <returns>The list of products.</returns>
    [HttpGet("products")]
    [ProducesResponseType(typeof(IList<ProductDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IList<ProductDto>>> GetProducts()
    {
        var result = await Mediator.Send(new GetProductsQuery());

        return Ok(result);
    }

    /// <summary>
    /// Creates a new Product.
    /// </summary>
    /// <param name="productInputDto">Input fields.</param>
    /// <returns>Product</returns>
    [HttpPost("products")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> CreateProduct(ProductInputDto productInputDto)
    {
        await Mediator.Send(new AddProductCommand(productInputDto));

        return StatusCode(201);
    }

    /// <summary>
    /// Updates an existing Product.
    /// </summary>
    /// <param name="productInputDto">Input fields.</param>
    /// <returns>Product</returns>
    [HttpPut("products")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> UpdateProduct(ProductInputDto productInputDto)
    {
        await Mediator.Send(new UpdateProductCommand(productInputDto));

        return NoContent();
    }

    /// <summary>
    /// Deletes an existing Product.
    /// </summary>
    /// <param name="id">Id of the product to be deleted.</param>
    /// <returns>Product</returns>
    [HttpDelete("products/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        await Mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}

