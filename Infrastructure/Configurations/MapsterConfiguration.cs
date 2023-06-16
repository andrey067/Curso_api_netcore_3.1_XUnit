using Api.Domain.Entities;
using Domain.Dtos.Cep;
using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;
using Domain.Dtos.User;
using Domain.Entities;
using Mapster;

namespace Infrastructure.Configurations
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.ForType<CepDto, Cep>();
            config.ForType<MunicipioDto, Municipio>();
            config.ForType<UfDto, Uf>();
            config.ForType<UserDto, User>();
        }
    }
}
