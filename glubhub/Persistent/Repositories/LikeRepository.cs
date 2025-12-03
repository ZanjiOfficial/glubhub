using glubhub.Data;
using glubhub.Models;
using glubhub.Persistent.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace glubhub.Persistent.Repositories
{
    public class LikeRepository<T> : ILikeRepository<T> where T : Like
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public LikeRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddSync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetByPostAsync(int postId)
        {
            return await _dbSet
                .Where(l => l.PostId == postId)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
