using System;
using System.Threading.Tasks;

namespace eproject2.Reposatory.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task SaveChangesAsync();
    }
}
