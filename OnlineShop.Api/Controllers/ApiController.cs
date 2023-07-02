using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.Filters;

namespace OnlineShop.Api.Controllers;

[ApiController]
//[Authorize]
[Produces("application/json")]
[Route("api/")]
[ServiceFilter(typeof(ApiExceptionFilterAttribute))]
public abstract class ApiController : ControllerBase
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}

