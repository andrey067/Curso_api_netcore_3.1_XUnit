using Api.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Users
{
    public class WhentorunCreate : TestUsers
    {
        private IUserServices? _service;

        private Mock<IUserServices>? _serviceMock;

        [Fact(DisplayName = "É possivel executar o metodo Create")]
        public async Task E_Possivel_Executar_Metodo_Create()
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
        }

    }
}
