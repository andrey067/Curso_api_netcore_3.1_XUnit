using Domain.Dtos;
using Domain.Interfaces.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Login
{
    public class WhentorunFindByLogin
    {

        private ILoginService? _service;
        private Mock<ILoginService>? _serviceMock;

        [Fact(DisplayName = "É possivel executar metodo FindByLogin")]
        public async Task E_possovel_Executar_FingByLogin()
        {
            var email = Faker.Internet.Email();
            var objectReturn = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expirationDate = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = Faker.Internet.UserName(),
                message = "Usuário Logado com sucesso"
            };

            var loginDto = new LoginDto
            {
                Email = email,
            };
            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objectReturn);
            _service = _serviceMock.Object;
            
            object result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
            
            Assert.Equal(objectReturn.userName, result.GetType().GetProperty("userName")?.GetValue(result));
        }
    }
}
