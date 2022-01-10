using Api.Domain.Interfaces.Services;
using Domain.Dtos.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Users
{
    public class Whentorunget : TestUsers
    {
        private IUserServices? _service;

        private Mock<IUserServices>? _serviceMock;

        [Fact(DisplayName = "É possivel Executar o Método Get")]
        public async Task E_Possivel_Executar_Metodo_GET()
        {
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(x => x.Get(IdUsuario)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult(null as UserDto));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdUsuario);
            Assert.Null(_record);
        }



    }
}
