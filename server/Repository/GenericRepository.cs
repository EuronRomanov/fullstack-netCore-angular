using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Interface.Repository;

namespace server.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContex contex;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DataContex contex)
        {
            this.contex=contex;
            _dbSet=contex.Set<T>();
        }
        public async  Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await contex.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
        {
             _dbSet.Remove(entity);
            await contex.SaveChangesAsync();
        }

        public async  Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public  async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
             await contex.SaveChangesAsync();
        }
    }
}