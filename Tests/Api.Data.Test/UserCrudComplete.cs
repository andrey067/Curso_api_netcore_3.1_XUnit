using Api.Domain.Entities;
using Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UserCrudTests : IClassFixture<BaseTests>
    {
        private IServiceProvider _serviceProvider;
        private IRepository<User> _userRepository;
        private IUserRepository _customUserRepository;

        public UserCrudTests(BaseTests dbTeste)
        {
            _serviceProvider = dbTeste.serviceProvider;
            _userRepository = _serviceProvider.GetRequiredService<IRepository<User>>();
            _customUserRepository = _serviceProvider.GetRequiredService<IUserRepository>();
        }

        [Fact(DisplayName = "Create User")]
        [Trait("CRUD", "UserEntity")]
        public async Task Create_User()
        {
            var entity = new User(Faker.Internet.Email(), Faker.Name.FullName());

            var createdRecord = await _userRepository.InsertAsync(entity);

            Assert.NotNull(createdRecord);
            Assert.Equal(entity.Email, createdRecord.Email);
            Assert.Equal(entity.Name, createdRecord.Name);
            Assert.IsType<long>(createdRecord.Id);
        }

        [Fact(DisplayName = "Update User")]
        [Trait("CRUD", "UserEntity")]
        public async Task Update_User()
        {
            var entity = new User(Faker.Internet.Email(), Faker.Name.FullName());
            var createdRecord = await _userRepository.InsertAsync(entity);

            entity.AlterarUsuario(Faker.Name.First(), Faker.Internet.FreeEmail());
            var updatedRecord = await _userRepository.UpdateAsync(entity);

            Assert.NotNull(updatedRecord);
            Assert.NotNull(updatedRecord.UpdateAt);
            Assert.IsType<long>(createdRecord.Id);
            Assert.Equal(entity.Name, updatedRecord.Name);
        }

        [Fact(DisplayName = "Get User")]
        [Trait("CRUD", "UserEntity")]
        public async Task Get_User()
        {
            var entity = new User(Faker.Internet.Email(), Faker.Name.FullName());
            var createdRecord = await _userRepository.InsertAsync(entity);

            var retrievedRecord = await _userRepository.SelectAsync(entity.Id);

            Assert.NotNull(retrievedRecord);
            Assert.Equal(createdRecord.Id, retrievedRecord.Id);
            Assert.Equal(createdRecord.Name, retrievedRecord.Name);
            Assert.Equal(createdRecord.Email, retrievedRecord.Email);
        }

        [Fact(DisplayName = "Check User Existence")]
        [Trait("CRUD", "UserEntity")]
        public async Task Check_User_Existence()
        {
            var entity = new User(Faker.Internet.Email(), Faker.Name.FullName());
            var createdRecord = await _userRepository.InsertAsync(entity);

            bool recordExists = await _userRepository.ExistAsync(createdRecord.Id);

            Assert.True(recordExists);
        }

        [Fact(DisplayName = "Select All Users")]
        [Trait("CRUD", "UserEntity")]
        public async Task Select_All_Users()
        {
            var allRecords = await _userRepository.SelectAsyncAll();

            Assert.NotNull(allRecords);
            Assert.True(allRecords.Count() > 1);
        }

        [Fact(DisplayName = "Remove User")]
        [Trait("CRUD", "UserEntity")]
        public async Task Remove_User()
        {
            var entity = new User(Faker.Internet.Email(), Faker.Name.FullName());
            var createdRecord = await _userRepository.InsertAsync(entity);

            var removeResult = await _userRepository.DeleteAsync(createdRecord.Id);

            Assert.True(removeResult);

            bool recordExistsAfterRemoval = await _userRepository.ExistAsync(createdRecord.Id);

            Assert.False(recordExistsAfterRemoval);
        }

        [Fact(DisplayName = "Find User By Login")]
        [Trait("CRUD", "UserEntity")]
        public async Task Find_User_By_Login()
        {
            var userDefault = await _customUserRepository.FindByLogin("audrey@gmail.com");

            Assert.NotNull(userDefault);
            Assert.Equal("Administrador", userDefault.Name);
            Assert.Equal("audrey@gmail.com", userDefault.Email);
        }
    }
}
