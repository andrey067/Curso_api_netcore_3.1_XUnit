using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUfRepository
    {
        Task<Uf> FindBySigla(string sigla);
    }
}
