namespace Application.Dtos.Municipio
{
    public record struct UpdateMunicipioDto(long municipioId, string nome, int codIBGE, long UfId) { }
}
