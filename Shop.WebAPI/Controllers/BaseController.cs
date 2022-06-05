using Microsoft.AspNetCore.Mvc;
using MediatR;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;


namespace Shop.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator mediator;
        protected IMediator Mediator => mediator??= HttpContext.RequestServices.GetService<IMediator>();


        internal   Guid UserId=>!User.Identity.IsAuthenticated
            ?Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
