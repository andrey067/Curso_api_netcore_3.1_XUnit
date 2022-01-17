using Api.Domain.Entities;
using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
            CreateMap<UfModel, UfEntity>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioEntity>().ReverseMap();
            CreateMap<CepModel, CepEntity>().ReverseMap();
        }
    }
}
