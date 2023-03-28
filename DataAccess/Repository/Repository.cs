﻿using Microsoft.EntityFrameworkCore;
using SeguroAutoAPI.DataAccess.Context;
using SeguroAutoAPI.DataAccess.Repository.Contracts;

namespace SeguroAutoAPI.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SeguroAutoContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(SeguroAutoContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
