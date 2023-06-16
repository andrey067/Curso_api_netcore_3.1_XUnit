namespace Application.Dtos.Cep
{
    public record struct UpdateCepDto(long Id, string NumeroCep, string Logradouro, string Numero, long MunicipioId);
}
