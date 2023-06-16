using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test
{
    public class TesteLogin : BaseIntegrations
    {
        [Fact(DisplayName = "Teste de Login")]
        public async Task TestDoToken()
        {
            await AdicionarToken();
        }
    }
}
