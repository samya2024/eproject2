using eproject2.Data;
using eproject2.Reposatory.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eproject2.Reposatory.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repository = new GenericRepository<T>(_context);
                _repositories.Add(typeof(T), repository);
            }
            return (IGenericRepository<T>)_repositories[typeof(T)];
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
