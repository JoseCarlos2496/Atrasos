using Atrasos.Domain.Entities;
using Atrasos.Domain.Interface;
using Atrasos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Atrasos.Infrastructure.Exceptions;

namespace Atrasos.Infrastructure.Repositories
{
    public class BaseRepository<T, I>(AtrasosDBContext db) : IBaseRepository<T, I> where T : BaseEntity<I>
    {

        private readonly AtrasosDBContext _db = db;
        private readonly DbSet<T> _entities = db.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T>? lst = await _entities.OrderBy(x => x.Id).ToListAsync();
            if (!lst.Any()) throw new NotFoundException(Constants.MULTIPLENOTFOUND); 

            return lst;
        }

        public async Task<T> GetByIdAsync(I id)
        {
            T? entity = await _entities.FindAsync(id);

            return entity ?? throw new NotFoundException(Constants.NOTFOUND);
        }

        public async Task<T> AddAsync(T entity)
        {
            _entities.Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _entities.Update(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(I id)
        {
            T entity = await GetByIdAsync(id);

            _entities.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
