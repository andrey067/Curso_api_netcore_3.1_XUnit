using Application.Dtos.Cep;
using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Api.Application.Controllers
{
    public static class CepsController
    {
        public static IEndpointRouteBuilder MapCepController(this IEndpointRouteBuilder routes)
        {
            routes.MapGet("/{id}", GetCepById).WithName("GetCepById");

            routes.MapGet("/byCep/{cep}", GetbyCep).WithName("GetByCep");

            routes.MapPost("/", Post);

            routes.MapPut("/", Put);

            routes.MapDelete("/{id}", Put);

            return routes;
        }

        public static async Task<IResult> GetCepById([FromServices] ICepService service, [FromQuery] long id)
        {
            var result = await service.Get(id);
            if (!result.IsSuccess)
                return Results.NotFound();

            return Results.Ok(result.Data);
        }

        public static async Task<IResult> GetbyCep([FromServices] ICepService service, [FromQuery] string cep)
        {
            var result = await service.GetByCep(cep);
            if (!result.IsSuccess)
                return Results.NotFound();

            return Results.Ok(result);
        }

        public static async Task<IResult> Post([FromServices] ICepService service, [FromBody] CreateCepDto dtoCreate)
        {
            var result = await service.Post(dtoCreate);
            if (result.IsSuccess) return Results.CreatedAtRoute("GetCepWithId", new { id = result.Data.Id }, result);

            return Results.BadRequest();
        }

        public static async Task<IResult> Put([FromServices] ICepService service, [FromBody] UpdateCepDto dtoUpdate)
        {
            var result = await service.Put(dtoUpdate);
            if (result.IsSuccess) return Results.Ok(result);

            return Results.BadRequest();
        }

        public static async Task<IResult> Delete([FromServices] ICepService service, [FromQuery] long id) => Results.Ok(await service.Delete(id));
    }
}
