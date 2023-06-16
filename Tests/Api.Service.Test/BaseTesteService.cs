using Infrastructure.Configurations;
using Mapster;

namespace Api.Service.Test
{
    public abstract class BaseTesteService
    {
        public TypeAdapterConfig MapperConfig { get; }
        public BaseTesteService()
        {
            MapperConfig = new TypeAdapterConfig();
            MapperConfig.Apply(new MapsterConfiguration());
        }
    }

}
