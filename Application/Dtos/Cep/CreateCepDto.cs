namespace Application.Dtos.Cep
{
    public record struct CreateCepDto(string NumeroCep, string Logradouro, string? Numero, long MunicipioId);
}
