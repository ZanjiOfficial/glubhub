using glubhub.Data;
using glubhub.Models;
using glubhub.Persistent.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace glubhub.Persistent.Repositories
{
    public class FishRepository<T> : IFishRepository<T> where T : Fish
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;


        public FishRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task AddSync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
