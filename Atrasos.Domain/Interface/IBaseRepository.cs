﻿using Atrasos.Domain.Entities;

namespace Atrasos.Domain.Interface
{
    public interface IBaseRepository<T, I> where T : BaseEntity<I>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(I id);
        public Task<bool> UpdateAsync(T entity);
        public Task<T> AddAsync(T entity);
        public Task<bool> DeleteAsync(I id);
    }
}
