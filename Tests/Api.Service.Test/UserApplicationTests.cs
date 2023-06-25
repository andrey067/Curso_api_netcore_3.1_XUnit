using Api.Domain.Entities;
using Application.Dtos.Users;
using Application.Services;
using Application.Test.Fixtures;
using Domain.Dtos.User;
using Domain.Repository;
using Domain.Shared;
using Mapster;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Application.Test
{
    public class UserApplicationTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IRepository<User>> _mockRepositoryBase;
        private UserService _userService;

        public UserApplicationTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockRepositoryBase = new Mock<IRepository<User>>();
            _userService = new UserService(_mockUserRepository.Object, _mockRepositoryBase.Object);
        }

        [Fact(DisplayName = "Delete_ValidId_ReturnsSuccess")]
        public async Task Delete_ValidId_ReturnsSuccess()
        {
            // Arrange
            long id = 1;
            _mockRepositoryBase.Setup(r => r.DeleteAsync(id)).ReturnsAsync(true);

            // Act
            var result = await _userService.Delete(id);

            // Assert
            Assert.True(result.IsSuccess);
        }

        [Fact(DisplayName = "Delete_InvalidId_ReturnsFailure")]
        public async Task Delete_InvalidId_ReturnsFailure()
        {
            // Arrange
            long id = 1;
            _mockRepositoryBase.Setup(r => r.DeleteAsync(id)).ReturnsAsync(false);

            // Act
            var result = await _userService.Delete(id);

            // Assert
            Assert.False(result.IsSuccess);
        }

        [Fact(DisplayName = "Get_ExistingId_ReturnsUserDto")]
        public async Task Get_ExistingId_ReturnsUserDto()
        {
            // Arrange
            long id = 1;
            var user = UserFixture.UserEntitie();
            _mockRepositoryBase.Setup(r => r.SelectAsync(id)).ReturnsAsync(user);

            // Act
            var result = await _userService.Get(id);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(user.Id, result.Data.Id);
            Assert.Equal(user.Name, result.Data.Name);
            Assert.Equal(user.Email, result.Data.Email);
        }

        [Fact(DisplayName = "Get_NonExistingId_ReturnsFailure")]
        public async Task Get_NonExistingId_ReturnsFailure()
        {
            // Arrange
            var error = new Error(typeof(User).Name, error: "Não encontrado");

            long id = 1;
            _mockRepositoryBase.Setup(r => r.SelectAsync(id)).ReturnsAsync(It.IsAny<User>());

            // Act
            var result = await _userService.Get(id);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Errors);
            Assert.IsType<Error[]>(result.Errors);
            Assert.Null(result.Data);
            Assert.Equal(error, result.Errors.First());
        }

        [Fact(DisplayName = "GetAll_ExistingEntities_ReturnsUserDtoList")]
        public async Task GetAll_ExistingEntities_ReturnsUserDtoList()
        {
            // Arrange
            var users = new List<User>
            {
                UserFixture.UserEntitie(),
                UserFixture.UserEntitie()
            };
            _mockRepositoryBase.Setup(r => r.SelectAsyncAll()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAll();

            // Assert
            Assert.True(result.IsSuccess);
            var userDtos = Assert.IsAssignableFrom<IEnumerable<UserDto>>(result.Data);
            Assert.Equal(users.Count, userDtos.Count());
        }

        [Fact(DisplayName = "GetAll_NoEntities_ReturnsEmptyList")]
        public async Task GetAll_NoEntities_ReturnsEmptyList()
        {
            // Arrange
            _mockRepositoryBase.Setup(r => r.SelectAsyncAll()).ReturnsAsync(It.IsAny<IEnumerable<User>>());

            // Act
            var result = await _userService.GetAll();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Null(result.Data);
        }

        [Fact(DisplayName = "Post_ValidCreateUserDto_ReturnsUserDto")]
        public async Task Post_ValidCreateUserDto_ReturnsUserDto()
        {
            // Arrange
            var createUserDto = UserFixture.CreateUserDto();
            var user = UserFixture.UserEntitie();
            _mockRepositoryBase.Setup(r => r.InsertAsync(It.IsAny<User>())).ReturnsAsync(user);

            // Act
            var result = await _userService.Post(createUserDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(user.Id, result.Data.Id);
            Assert.Equal(user.Name, result.Data.Name);
            Assert.Equal(user.Email, result.Data.Email);
        }

        [Fact(DisplayName = "Put_ExistingUpdateUserDto_ReturnsUpdatedUserDto")]
        public async Task Put_ExistingUpdateUserDto_ReturnsUpdatedUserDto()
        {
            // Arrange
            var updateUserDto = UserFixture.UpdateUserDto();
            var user = new User(updateUserDto.Name, updateUserDto.Email);
            _mockRepositoryBase.Setup(r => r.SelectAsync(updateUserDto.Id)).ReturnsAsync(user);
            user.UpdateUpdateAt();
            _mockRepositoryBase.Setup(r => r.UpdateAsync(user)).ReturnsAsync(user);

            // Act
            var result = await _userService.Put(updateUserDto);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(updateUserDto.Name, result.Data.Name);
            Assert.Equal(updateUserDto.Email, result.Data.Email);
            Assert.NotNull(result.Data.UpdateAt);
        }

        [Fact(DisplayName = "Put_NonExistingUpdateUserDto_ReturnsFailure")]
        public async Task Put_NonExistingUpdateUserDto_ReturnsFailure()
        {
            // Arrange
            var error = new Error(typeof(User).Name, error: "Não encontrado");
            var updateUserDto = UserFixture.UpdateUserDto();
            _mockRepositoryBase.Setup(r => r.SelectAsync(updateUserDto.Id)).ReturnsAsync(It.IsAny<User>());

            // Act
            var result = await _userService.Put(updateUserDto);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Errors);
            Assert.IsType<Error[]>(result.Errors);
            Assert.Equal(error, result.Errors.First());
        }
    }
}
