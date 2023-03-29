using Microsoft.EntityFrameworkCore;
using SeguroAutoAPI.DataAccess.Context;
using SeguroAutoAPI.DataAccess.Models;
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
            if (typeof(T) == typeof(Poliza))
            {
                var polizaSet = _dbSet as DbSet<Poliza>;
                var polizas = await polizaSet.Include(p => p.Coberturas).ToListAsync();
                return polizas as IEnumerable<T>;
            }
            else
            {
                return await _dbSet.ToListAsync();
            }
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            if (typeof(T) == typeof(Poliza))
            {
                var polizaSet = _dbSet as DbSet<Poliza>;
                var poliza = await polizaSet.Include(p => p.Coberturas).FirstOrDefaultAsync(p => p.Id == id);
                return poliza as T;
            }
            else
            {
                return await _dbSet.FindAsync(id);
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
