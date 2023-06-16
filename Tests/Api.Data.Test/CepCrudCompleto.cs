using Domain.Entities;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class CepCrudCompleto : IClassFixture<BaseTests>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRepository<Cep> _repositorybaseCep;
        private readonly IRepository<Municipio> _repositorybaseMunicipio;
        private readonly ICepRepository _cepRepository;
        private Municipio _municipioEntity;

        public CepCrudCompleto(BaseTests dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
            _repositorybaseCep = _serviceProvider.GetRequiredService<IRepository<Cep>>();
            _repositorybaseMunicipio = _serviceProvider.GetRequiredService<IRepository<Municipio>>();
            _cepRepository = _serviceProvider.GetRequiredService<ICepRepository>();
        }

        [Fact(DisplayName = "CRUD de Cep - Inserir")]
        [Trait("CRUD", "CepEntity")]
        public async Task E_Possivel_Inserir_Cep()
        {
            var _registroCriado = await CreateMunicipio();
            Assert.NotNull(_registroCriado);
            Assert.Equal(_municipioEntity.Nome, _registroCriado.Nome);
            Assert.Equal(_municipioEntity.CodIBGE, _registroCriado.CodIBGE);
            Assert.Equal(_municipioEntity.UfId, _registroCriado.UfId);
            Assert.IsType<long>(_registroCriado.Id);

            Cep _entityCep = new("13.481-001", Faker.Address.StreetName(), "0 até 2000", _registroCriado.Id);

            var _registroCriadoCep = await _repositorybaseCep.InsertAsync(_entityCep);
            Assert.NotNull(_registroCriadoCep);
            Assert.Equal(_entityCep.NumeroCep, _registroCriadoCep.NumeroCep);
            Assert.Equal(_entityCep.Logradouro, _registroCriadoCep.Logradouro);
            Assert.Equal(_entityCep.Numero, _registroCriadoCep.Numero);
            Assert.Equal(_entityCep.MunicipioId, _registroCriadoCep.MunicipioId);
            Assert.IsType<long>(_registroCriadoCep.Id);

        }

        [Fact(DisplayName = "CRUD de Cep - Atualizar")]
        [Trait("CRUD", "CepEntity")]
        public async Task E_Possivel_Atualizar_Cep()
        {
            var _registroCriado = await CreateMunicipio();

            Cep _entityCep = new("13.481-001", Faker.Address.StreetName(), "0 até 2000", _registroCriado.Id);

            _entityCep.AlterarLogradouro(Faker.Address.StreetName());
            var _registroAtualizado = await _repositorybaseCep.UpdateAsync(_entityCep);
            Assert.NotNull(_registroAtualizado);
            Assert.Equal(_entityCep.NumeroCep, _registroAtualizado.NumeroCep);
            Assert.Equal(_entityCep.Logradouro, _registroAtualizado.Logradouro);
            Assert.Equal(_entityCep.MunicipioId, _registroAtualizado.MunicipioId);
            Assert.IsType<long>(_registroAtualizado.Id);
        }

        //[Fact(DisplayName = "CRUD de Cep - Selecionar por ID")]
        //[Trait("CRUD", "CepEntity")]
        //public async Task E_Possivel_Selecionar_Cep_Por_ID()
        //{
        //    var _registroSelecionado = await _repositorybaseCep.SelectAsync(_registroAtualizado.Id);
        //    Assert.NotNull(_registroSelecionado);
        //    Assert.Equal(_registroAtualizado.Cep, _registroSelecionado.Cep);
        //    Assert.Equal(_registroAtualizado.Logradouro, _registroSelecionado.Logradouro);
        //    Assert.Equal(_registroAtualizado.Numero, _registroSelecionado.Numero);
        //    Assert.Equal(_registroAtualizado.MunicipioId, _registroSelecionado.MunicipioId);

        //}

        //[Fact(DisplayName = "CRUD de Cep - Selecionar por CEP")]
        //[Trait("CRUD", "CepEntity")]
        //public async Task E_Possivel_Selecionar_Cep_Por_CEP()
        //{
        //    using (var context = _serviceProvider.GetService<BaseTests>())
        //    {
        //        CepImplementation _repositorio = new CepImplementation(context);

        //        var _registroSelecionado = await _repositorio.SelectAsync(_registroAtualizado.Cep);
        //        Assert.NotNull(_registroSelecionado);
        //        Assert.Equal(_registroAtualizado.Cep, _registroSelecionado.Cep);
        //        Assert.Equal(_registroAtualizado.Logradouro, _registroSelecionado.Logradouro);
        //        Assert.Equal(_registroAtualizado.Numero, _registroSelecionado.Numero);
        //        Assert.Equal(_registroAtualizado.MunicipioId, _registroSelecionado.MunicipioId);
        //        Assert.NotNull(_registroSelecionado.Municipio);
        //        Assert.Equal(_entityMunicipio.Nome, _registroSelecionado.Municipio.Nome);
        //        Assert.NotNull(_registroSelecionado.Municipio.Uf);
        //        Assert.Equal("SP", _registroSelecionado.Municipio.Uf.Sigla);
        //    }
        //}

        //[Fact(DisplayName = "CRUD de Cep - Selecionar Todos")]
        //[Trait("CRUD", "CepEntity")]
        //public async Task E_Possivel_Selecionar_Todos_Os_Ceps()
        //{
        //    using (var context = _serviceProvider.GetService<BaseTests>())
        //    {
        //        CepImplementation _repositorio = new CepImplementation(context);

        //        var _todosRegistros = await _repositorio.SelectAsyncAll();
        //        Assert.NotNull(_todosRegistros);
        //        Assert.True(_todosRegistros.Count() > 0);
        //    }
        //}

        //[Fact(DisplayName = "CRUD de Cep - Excluir")]
        //[Trait("CRUD", "CepEntity")]
        //public async Task E_Possivel_Excluir_Cep()
        //{
        //    using (var context = _serviceProvider.GetService<BaseTests>())
        //    {
        //        CepImplementation _repositorio = new CepImplementation(context);

        //        var _removeu = await _repositorio.DeleteAsync(_registroSelecionado.Id);
        //        Assert.True(_removeu);

        //        _todosRegistros = await _repositorio.SelectAsyncAll();
        //        Assert.NotNull(_todosRegistros);
        //        Assert.True(_todosRegistros.Count() == 0);
        //    }
        //}

        private async Task<Municipio> CreateMunicipio()
        {
            _municipioEntity = new Municipio(Faker.Address.City(), Faker.RandomNumber.Next(10000, 99999999), 1);
            return await _repositorybaseMunicipio.InsertAsync(_municipioEntity);
        }
    }
}

