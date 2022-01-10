using Api.Domain.Interfaces.Services;
using Domain.Dtos.User;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Users
{
    public class WhentorungetAll : TestUsers
    {
        private IUserServices? _service;

        private Mock<IUserServices>? _serviceMock;

        [Fact(DisplayName = "É possivel Executar o Método GetAll")]
        public async Task E_Possivel_Executar_GetAll()
        {
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listresult = new List<UserDto>();
            _serviceMock = new Mock<IUserServices>();
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(_listresult.AsEnumerable<UserDto>);
            _service = _serviceMock.Object;

            var resultEmpity = await _service.GetAll();
            Assert.Empty(resultEmpity);
            Assert.True(_listresult.Count() == 0);
        }
    }
}
