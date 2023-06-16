using Application.Dtos.Municipio;
using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Api.routerslication.Controllers
{
    public static class MunicipiosController
    {
        public static IEndpointRouteBuilder MapMunicipiosController(this IEndpointRouteBuilder routers)
        {
            routers.MapGet("/", GetAllMunicipios);

            routers.MapGet("/{id}", GetMunicipioById)
                .WithName("GetMunicipioWithId");

            routers.MapGet("/Complete/{id}", GetCompleteMunicipioById);

            routers.MapGet("/byIBGE/{codigoIBGE}", GetCompleteMunicipioByIBGE);

            routers.MapPost("/", CreateMunicipio);

            routers.MapPut("/", UpdateMunicipio);

            routers.MapDelete("/{id}", DeleteMunicipio);

            return routers;
        }

        public static async Task<IResult> GetAllMunicipios([FromServices] IMunicipioService municipioService)
        {
            var municipios = await municipioService.GetAll();
            return Results.Ok(municipios);
        }

        public static async Task<IResult> GetMunicipioById([FromServices] IMunicipioService municipioService, [FromQuery] long id)
        {
            var result = await municipioService.GetCompleteById(id);
            if (result == null)
                return Results.NotFound();

            return Results.Ok(result);
        }

        public static async Task<IResult> GetCompleteMunicipioById([FromServices] IMunicipioService municipioService, [FromQuery] long id)
        {
            var result = await municipioService.GetCompleteById(id);
            if (!result.IsSuccess)
                return Results.NotFound();

            return Results.Ok(result.Data);
        }

        public static async Task<IResult> GetCompleteMunicipioByIBGE([FromServices] IMunicipioService municipioService, [FromQuery] int codigoIBGE)
        {
            var result = await municipioService.GetCompleteByIBGE(codigoIBGE);
            if (!result.IsSuccess)
                return Results.NotFound();

            return Results.Ok(result);
        }

        public static async Task<IResult> CreateMunicipio([FromServices] IMunicipioService municipioService, [FromBody] CreateMunicipioDto dtoCreate)
        {
            var result = await municipioService.Post(dtoCreate);
            if (result.IsSuccess)
                return Results.CreatedAtRoute("GetMunicipioWithId", new { id = result.Data.Id }, result);
            else
                return Results.BadRequest();
        }

        public static async Task<IResult> UpdateMunicipio([FromServices] IMunicipioService municipioService, [FromBody] UpdateMunicipioDto dtoUpdate)
        {
            var result = await municipioService.Put(dtoUpdate);
            if (result.IsSuccess)
                return Results.Ok(result.Data);
            else
                return Results.BadRequest();
        }

        public static async Task<IResult> DeleteMunicipio([FromServices] IMunicipioService municipioService, [FromQuery] long id)
        {
            var result = await municipioService.Delete(id);
            if (result.IsSuccess)
                return Results.Ok(result.IsSuccess);
            else
                return Results.BadRequest();
        }
    }
}
