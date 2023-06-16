using Application.Dtos.Login;
using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Api.Application.Controllers
{
    public static class LoginController
    {
        public static IEndpointRouteBuilder MapLoginController(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/", Login);

            return routes;
        }

        public static async Task<IResult> Login([FromServices] ILoginService loginService, [FromBody] LoginDto loginModel)
        {
            var result = await loginService.FindByLogin(loginModel);
            if (result.IsSuccess)
                return Results.Ok(result.Data);
            else
                return Results.BadRequest();
        }
    }
}
