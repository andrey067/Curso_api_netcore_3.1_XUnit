using Api.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);

        Task<T> UpdateAsync(T item);

        Task<bool> DeleteAsync(long id);

        Task<T> SelectAsync(long id);

        Task<IEnumerable<T>> SelectAsyncAll();

        Task<bool> ExistAsync(long id);
        DbSet<T> GetDbSet();
    }
}
