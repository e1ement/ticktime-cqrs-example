using Microsoft.EntityFrameworkCore;
using TickTime.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TickTime.Application.Services
{
    public class Repository
    {
        private RepositoryContext RepositoryContext { get; set; }

        public Repository(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task<List<T>> FindAsync<T>() where T : class
        {
            return await RepositoryContext.Set<T>()
                .Where(_ => true)
                .ToListAsync();
        }

        public async Task<List<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await RepositoryContext.Set<T>()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<T> FindByIdAsync<T>(Guid id) where T : class, IEntity
        {
            return await RepositoryContext.Set<T>()
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync<T>(T entity) where T : class, IEntity
        {
            await RepositoryContext.Set<T>().AddAsync(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : class, IEntity
        {
            RepositoryContext.Set<T>().Update(entity);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task RemoveAsync<T>(Guid id) where T : class, IEntity
        {
            var entity = await RepositoryContext.Set<T>()
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            
            if (entity != null)
            {
                RepositoryContext.Set<T>().Remove(entity);
                await RepositoryContext.SaveChangesAsync();
            }
        }
    }
}
