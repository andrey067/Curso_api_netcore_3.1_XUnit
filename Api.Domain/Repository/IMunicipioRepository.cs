using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IMunicipioRepository
    {
        Task<Municipio> GetCompleteById(long id);
        Task<Municipio> GetCompleteByIBGE(int codIBGE);
    }
}
