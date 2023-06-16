using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Api.Application.Controllers
{
    public static class UfController
    {
        public static IEndpointRouteBuilder MapUfController(this IEndpointRouteBuilder routers)
        {
            routers.MapGet("/", GetAllUfs);

            routers.MapGet("/{id}", GetUfById);

            return routers;
        }

        public static async Task<IResult> GetAllUfs([FromServices] IUfService service)
        {
            var ufs = await service.GetAll();
            return Results.Ok(ufs);
        }

        public static async Task<IResult> GetUfById([FromServices] IUfService service, [FromQuery] long id)
        {
            var result = await service.GetById(id);
            if (!result.IsSuccess)
                return Results.NotFound();

            return Results.Ok(result.Data);
        }
    }

}
