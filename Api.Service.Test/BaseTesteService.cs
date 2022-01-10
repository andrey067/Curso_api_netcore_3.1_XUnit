using AutoMapper;
using CrossCutting.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Test
{
    public abstract class BaseTesteService
    {
        public IMapper Mapper { get; set; }

        public BaseTesteService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ModelToEntityProfile());
                    cfg.AddProfile(new DtoToModelProfile());
                    cfg.AddProfile(new EntityToDtoProfile());
                });
                return config.CreateMapper();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
