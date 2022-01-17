using Xunit;
using System;
using System.Linq;
using Domain.Entities;
using Api.Data.Context;
using Data.Implementations;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test
{
    public class UfGets : BaseTest, IClassFixture<DbTeste>
    {
        private IServiceProvider _serviceProvider;
        public UfGets(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Gets UF")]
        [Trait("GETs", "UfEntity")]
        public async Task E_Possivel_Realizar_Gets_UF()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UfImplementation _repository = new UfImplementation(context);
                UfEntity _entity = new UfEntity
                {
                    Id = new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                    Sigla = "MS",
                    Nome = "Mato Grosso do Sul"
                };

                var registroExiste = await _repository.ExistAsync(_entity.Id);
                Assert.True(registroExiste);

                var registroSelecionado = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(registroSelecionado);
                Assert.Equal(_entity.Id, registroSelecionado.Id);
                Assert.Equal(_entity.Nome, registroSelecionado.Nome);
                Assert.Equal(_entity.Sigla, registroSelecionado.Sigla);

                var todosRegistros = await _repository.SelectAsyncAll();
                Assert.NotNull(todosRegistros);
                Assert.True(todosRegistros.Count() == 27);
            }
        }
    }
}
