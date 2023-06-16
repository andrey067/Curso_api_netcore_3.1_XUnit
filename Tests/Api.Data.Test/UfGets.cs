using Domain.Entities;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UfGets : IClassFixture<BaseTests>
    {
        private IServiceProvider _serviceProvider;
        private IRepository<Uf> _repositorybase;
        private IUfRepository _ufRepository;
        public UfGets(BaseTests dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
            _repositorybase = _serviceProvider.GetRequiredService<IRepository<Uf>>();
            _ufRepository = _serviceProvider.GetRequiredService<IUfRepository>();
        }

        [Fact(DisplayName = "Gets UF")]
        [Trait("GETs", "UfEntity")]
        public async Task E_Possivel_Realizar_Gets_UF()
        {
            var _entity = await _ufRepository.FindBySigla("MS");

            var registroSelecionado = await _repositorybase.SelectAsync(_entity.Id);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(_entity.Id, registroSelecionado.Id);
            Assert.Equal(_entity.Nome, registroSelecionado.Nome);
            Assert.Equal(_entity.Sigla, registroSelecionado.Sigla);

            var todosRegistros = await _repositorybase.SelectAsyncAll();
            Assert.NotNull(todosRegistros);
            Assert.True(todosRegistros.Count() == 27);
        }
    }
}
