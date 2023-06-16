namespace Api.Service.Test.Mapster
{
    //public class CepMapper : BaseTesteService
    //{
    //    [Fact(DisplayName = "É Possível Mapear os Modelos de Cep")]
    //    public void E_Possivel_Mapear_os_Modelos_Cep()
    //    {
    //        var model = new CepUpdateResultDto
    //        {
    //            Id = Guid.NewGuid(),
    //            Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
    //            Logradouro = Faker.Address.StreetName(),
    //            Numero = "",
    //            UpdateAt = DateTime.UtcNow,
    //            MunicipioId = Guid.NewGuid()
    //        };

    //        var listaEntity = new List<CepEntity>();
    //        for (int i = 0; i < 5; i++)
    //        {
    //            var item = new CepEntity(Faker.RandomNumber.Next(1, 10000).ToString(), )
    //            {                    
    //                Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
    //                Logradouro = Faker.Address.StreetName(),
    //                Numero = Faker.RandomNumber.Next(1, 10000).ToString(),
    //                CreateAt = DateTime.UtcNow,
    //                UpdateAt = DateTime.UtcNow,
    //                MunicipioId = Guid.NewGuid(),
    //                Municipio = new Municipio
    //                {
    //                    Id = Guid.NewGuid(),
    //                    Nome = Faker.Address.UsState(),
    //                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
    //                    UfId = Guid.NewGuid(),
    //                    Uf = new Uf
    //                    {
    //                        Id = Guid.NewGuid(),
    //                        Nome = Faker.Address.UsState(),
    //                        Sigla = Faker.Address.UsState().Substring(1, 3)
    //                    }
    //                }
    //            };
    //            listaEntity.Add(item);
    //        }

    //        // Model => Entity
    //        var entity = model.Adapt<CepEntity>();
    //        Assert.Equal(entity.Id, model.Id);
    //        Assert.Equal(entity.Logradouro, model.Logradouro);
    //        Assert.Equal(entity.Numero, model.Numero);
    //        Assert.Equal(entity.Cep, model.Cep);
    //        Assert.Equal(entity.CreateAt, model.CreateAt);
    //        Assert.Equal(entity.UpdateAt, model.UpdateAt);

    //        // Entity to Dto
    //        var cepDto = entity.Adapt<CepDto>();
    //        Assert.Equal(cepDto.Id, entity.Id);
    //        Assert.Equal(cepDto.Logradouro, entity.Logradouro);
    //        Assert.Equal(cepDto.Numero, entity.Numero);
    //        Assert.Equal(cepDto.Cep, entity.Cep);

    //        var cepDtoCompleto = listaEntity.First().Adapt<CepDto>();
    //        Assert.Equal(cepDtoCompleto.Id, listaEntity.First().Id);
    //        Assert.Equal(cepDtoCompleto.Cep, listaEntity.First().Cep);
    //        Assert.Equal(cepDtoCompleto.Logradouro, listaEntity.First().Logradouro);
    //        Assert.Equal(cepDtoCompleto.Numero, listaEntity.First().Numero);
    //        Assert.NotNull(cepDtoCompleto.Municipio);
    //        Assert.NotNull(cepDtoCompleto.Municipio.Uf);

    //        var listaDto = listaEntity.Adapt<List<CepDto>>();
    //        Assert.True(listaDto.Count == listaEntity.Count);
    //        for (int i = 0; i < listaDto.Count; i++)
    //        {
    //            Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
    //            Assert.Equal(listaDto[i].Cep, listaEntity[i].Cep);
    //            Assert.Equal(listaDto[i].Logradouro, listaEntity[i].Logradouro);
    //            Assert.Equal(listaDto[i].Numero, listaEntity[i].Numero);
    //        }

    //        var cepDtoCreateResult = entity.Adapt<CepCreateResultDto>();
    //        Assert.Equal(cepDtoCreateResult.Id, entity.Id);
    //        Assert.Equal(cepDtoCreateResult.Cep, entity.Cep);
    //        Assert.Equal(cepDtoCreateResult.Logradouro, entity.Logradouro);
    //        Assert.Equal(cepDtoCreateResult.Numero, entity.Numero);
    //        Assert.Equal(cepDtoCreateResult.CreateAt, entity.CreateAt);

    //        var cepDtoUpdateResult = entity.Adapt<CepUpdateResultDto>();
    //        Assert.Equal(cepDtoUpdateResult.Id, entity.Id);
    //        Assert.Equal(cepDtoUpdateResult.Cep, entity.Cep);
    //        Assert.Equal(cepDtoUpdateResult.Logradouro, entity.Logradouro);
    //        Assert.Equal(cepDtoCreateResult.Numero, entity.Numero);
    //        Assert.Equal(cepDtoUpdateResult.UpdateAt, entity.UpdateAt);

    //        // Dto to Model
    //        cepDto.Numero = "";
    //        var cepModel = cepDto.Adapt<CepEntity>();
    //        Assert.Equal(cepModel.Id, cepDto.Id);
    //        Assert.Equal(cepModel.Cep, cepDto.Cep);
    //        Assert.Equal(cepModel.Logradouro, cepDto.Logradouro);
    //        Assert.Equal("S/N", cepModel.Numero);

    //        var cepDtoCreate = cepModel.Adapt<CepCreateDto>();
    //        Assert.Equal(cepDtoCreate.Cep, cepModel.Cep);
    //        Assert.Equal(cepDtoCreate.Logradouro, cepModel.Logradouro);
    //        Assert.Equal(cepDtoCreate.Numero, cepModel.Numero);

    //        var cepDtoUpdate = cepModel.Adapt<CepUpdateDto>();
    //        Assert.Equal(cepDtoUpdate.Id, cepModel.Id);
    //        Assert.Equal(cepDtoUpdate.Cep, cepModel.Cep);
    //        Assert.Equal(cepDtoUpdate.Logradouro, cepModel.Logradouro);
    //        Assert.Equal(cepDtoUpdate.Numero, cepModel.Numero);
    //    }
    //}

}
