using System.Collections.Generic;
using System.Threading.Tasks;

namespace eproject2.Reposatory.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(); // ✅ Already Correct
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();

        IEnumerable<T> GetAll(); // ✅ FIX: Changed return type from `object` to `IEnumerable<T>`

    }
}
