using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.GenericRepository
{
    public interface ISvGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        IQueryable<T> Query();
    }
}
