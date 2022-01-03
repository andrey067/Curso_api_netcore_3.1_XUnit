using Api.Data.Context;
using Api.Domain.Entities;
using Data.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UserCrudComplete : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;
        public UserCrudComplete(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                UserEntity _entity = new UserEntity()
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };
                //Create User
                var _registroCriado = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                //UpdateUser
                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.NotNull(_registroAtualizado.UpdateAt);
                Assert.False(_registroAtualizado.Id == Guid.Empty);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);

                //GetUser
                var _registroBuscado = await _repository.SelectAsync(_entity.Id);
                Assert.NotNull(_registroBuscado);
                Assert.Equal(_registroAtualizado.Name, _registroBuscado.Name);
                Assert.Equal(_registroAtualizado.Email, _registroBuscado.Email);

                //ExistUser
                bool registerExist = await _repository.ExistAsync(_registroAtualizado.Id);
                Assert.True(registerExist);


                //SelectAll
                var _AllRegister = await _repository.SelectAsyncAll();
                Assert.NotNull(_AllRegister);
                Assert.True(_AllRegister.Count() > 1);

                //Remove 
                var _removeRegister = await _repository.DeleteAsync(_registroAtualizado.Id);
                Assert.True(_removeRegister);
                bool existRegister = await _repository.ExistAsync(_registroAtualizado.Id);
                Assert.False(existRegister);

                //FindByLogin
                var userDefault = await _repository.FindByLogin("audrey@gmail.com");
                Assert.NotNull(userDefault);
                Assert.Equal("Administrador", userDefault.Name);
                Assert.Equal("audrey@gmail.com", userDefault.Email);
            }
        }
    }
}
