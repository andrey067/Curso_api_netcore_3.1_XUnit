using Domain.Entities;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class MunicipioCrudTests : IClassFixture<BaseTests>
    {
        private IServiceProvider _serviceProvider;
        private IRepository<Municipio> _repositorybase;
        private IMunicipioRepository _municipioRepository;
        private Municipio _municipioEntity;

        public MunicipioCrudTests(BaseTests dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
            _repositorybase = _serviceProvider.GetRequiredService<IRepository<Municipio>>();
            _municipioRepository = _serviceProvider.GetRequiredService<IMunicipioRepository>();

            _municipioEntity = new Municipio(Faker.Address.City(), Faker.RandomNumber.Next(10000, 99999999), 1);
        }

        [Fact(DisplayName = "Create Municipio")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task Create_Municipio()
        {
            var createdRecord = await _repositorybase.InsertAsync(_municipioEntity);

            Assert.NotNull(createdRecord);
            Assert.Equal(_municipioEntity.Nome, createdRecord.Nome);
            Assert.Equal(_municipioEntity.CodIBGE, createdRecord.CodIBGE);
            Assert.Equal(_municipioEntity.UfId, createdRecord.UfId);
            Assert.IsType<long>(createdRecord.Id);
        }

        [Fact(DisplayName = "Update Municipio")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task Update_Municipio()
        {
            var createdRecord = await _repositorybase.InsertAsync(_municipioEntity);

            _municipioEntity.AlterarNome(Faker.Address.City());
            _municipioEntity.AlterarUf(2);

            var updatedRecord = await _repositorybase.UpdateAsync(_municipioEntity);

            Assert.NotNull(updatedRecord);
            Assert.Equal(_municipioEntity.Nome, updatedRecord.Nome);
            Assert.Equal(_municipioEntity.CodIBGE, updatedRecord.CodIBGE);
            Assert.Equal(_municipioEntity.UfId, updatedRecord.UfId);
            Assert.Equal(createdRecord.Id, updatedRecord.Id);
        }

        [Fact(DisplayName = "Check Municipio Existence")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task Check_Municipio_Existence()
        {
            var createdRecord = await _repositorybase.InsertAsync(_municipioEntity);

            bool recordExists = await _repositorybase.ExistAsync(createdRecord.Id);

            Assert.True(recordExists);
        }

        [Fact(DisplayName = "Get Municipio")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task Get_Municipio()
        {
            var createdRecord = await _repositorybase.InsertAsync(_municipioEntity);

            var retrievedRecord = await _repositorybase.SelectAsync(createdRecord.Id);

            Assert.NotNull(retrievedRecord);
            Assert.Equal(createdRecord.Nome, retrievedRecord.Nome);
            Assert.Equal(createdRecord.CodIBGE, retrievedRecord.CodIBGE);
            Assert.Equal(createdRecord.UfId, retrievedRecord.UfId);
            Assert.Null(retrievedRecord.Uf);

            var retrievedRecordByIBGE = await _municipioRepository.GetCompleteByIBGE(createdRecord.CodIBGE);

            Assert.NotNull(retrievedRecordByIBGE);
            Assert.Equal(createdRecord.Nome, retrievedRecordByIBGE.Nome);
            Assert.Equal(createdRecord.CodIBGE, retrievedRecordByIBGE.CodIBGE);
            Assert.Equal(createdRecord.UfId, retrievedRecordByIBGE.UfId);
            Assert.NotNull(retrievedRecordByIBGE.Uf);

            var retrievedRecordById = await _municipioRepository.GetCompleteById(createdRecord.Id);

            Assert.NotNull(retrievedRecordById);
            Assert.Equal(createdRecord.Nome, retrievedRecordById.Nome);
            Assert.Equal(createdRecord.CodIBGE, retrievedRecordById.CodIBGE);
            Assert.Equal(createdRecord.UfId, retrievedRecordById.UfId);
            Assert.NotNull(retrievedRecordById.Uf);
        }

        [Fact(DisplayName = "Select All Municipios")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task Select_All_Municipios()
        {
            var allRecords = await _repositorybase.SelectAsyncAll();

            Assert.NotNull(allRecords);
            Assert.True(allRecords.Count() > 0);
        }

        [Fact(DisplayName = "Remove Municipio")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task Remove_Municipio()
        {
            var createdRecord = await _repositorybase.InsertAsync(_municipioEntity);

            var removeResult = await _repositorybase.DeleteAsync(createdRecord.Id);

            Assert.True(removeResult);

            var allRecords = await _repositorybase.SelectAsyncAll();

            Assert.NotNull(allRecords);
            Assert.True(allRecords.Count() == 0);
        }
    }
}
