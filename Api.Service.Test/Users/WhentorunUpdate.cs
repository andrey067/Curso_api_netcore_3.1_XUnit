using Api.Domain.Interfaces.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Users
{
    public class WhentorunUpdate : TestUsers
    {
        private IUserServices? _service;
        private Mock<IUserServices>? _serviceMock;

        [Fact(DisplayName = "E possivel executar update")]
        public async Task E_Possivel_Executar_Update()
        {
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(m => m.Post(userCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var resultCreate = await _service.Post(userCreate);
            Assert.NotNull(resultCreate);
            Assert.Equal(IdUsuario, resultCreate.Id);
            Assert.Equal(NomeUsuario, resultCreate.Name);
            Assert.Equal(EmailUsuario, resultCreate.Email);
            Assert.IsType<DateTime>(resultCreate.CreateAt);

            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(userDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(IdUsuario, resultUpdate.Id);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailUsuarioAlterado, resultUpdate.Email);
            Assert.IsType<DateTime>(resultUpdate.UpdateAt);
        }
    }
}
