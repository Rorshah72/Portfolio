﻿using Microsoft.EntityFrameworkCore;
using Portfolio.Services.CoreAPI.Data;

namespace Portfolio.Services.CoreAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CoreDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(CoreDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
