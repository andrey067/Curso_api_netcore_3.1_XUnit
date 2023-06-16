using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICepRepository
    {
        Task<Cep> SelectByCepAsync(string cep);
    }
}
