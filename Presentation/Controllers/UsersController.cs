using Application.Dtos.Users;
using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Api.Application.Controllers
{
    public static class UsersController
    {
        public static IEndpointRouteBuilder MapUsersController(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/user", GetAllUsers)
                .WithName("GetAllUsers")
                .WithOpenApi();

            routes.MapGet("/{id}", GetUserById)
                .WithName("GetUserById")
                .WithOpenApi();

            routes.MapPost("/", CreateUser)
                .WithName("CreateUser")
                .WithOpenApi();

            return routes;
        }

        public static async Task<IResult> GetAllUsers([FromServices] IUserServices services)
        {
            var users = await services.GetAll();

            if (users.IsSuccess && users.Errors.Count() > 0)
                return Results.NotFound(users);

            if (!users.IsSuccess && users.Errors.Count() > 0)
                return Results.BadRequest(users);

            return Results.Ok(users);
        }

        public static async Task<IResult> GetUserById([FromServices] IUserServices services, [FromQuery] long id)
        {
            var user = await services.Get(id);
            if (!user.IsSuccess && user.Data == null)
                return Results.NotFound(user);

            return Results.Ok(user);
        }

        public static async Task<IResult> CreateUser([FromServices] IUserServices services, [FromBody] CreateUserDto user)
        {
            var result = await services.Post(user);
            if (result.IsSuccess)
                return Results.CreatedAtRoute("GetUserById", new { id = result.Data.Id }, result);
            else

                return Results.BadRequest(result);
        }
    }
}