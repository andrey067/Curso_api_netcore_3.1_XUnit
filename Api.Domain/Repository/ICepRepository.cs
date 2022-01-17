using Domain.Entities;
using Api.Domain.Interfaces;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ICepRepository : IRepository<CepEntity>
    {
        Task<CepEntity> SelectAsync(string cep);
    }
}
