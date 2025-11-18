using glubhub.Models;
using glubhub.Data;
using Microsoft.EntityFrameworkCore;
using glubhub.Persistent.Interfaces;

namespace glubhub.Persistent.Repositories
{
    public class WeatherRepository<T> : IWeatherRepository<T> where T : Weather
    {
        private readonly WeatherDbContext _context;
        private readonly DbSet<T> _dbSet;


        public WeatherRepository(WeatherDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task AddSync(T entity)
        {
            _context.AddAsync(entity);
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
