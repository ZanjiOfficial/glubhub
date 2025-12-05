using glubhub.Data;
using glubhub.Models;
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
            _dbSet = _context.Set<T>();
        }


        public async Task<T?> GetByUserAndPostAsync(Guid userId, int postId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(l => l.UserId == userId && l.PostId == postId);
        }

        public async Task<IEnumerable<T>> GetByPostsForUserAsync(Guid userId, IEnumerable<int> postIds)
        {
            return await _dbSet
                .Where(l => l.UserId == userId && postIds.Contains(l.PostId))
                .ToListAsync();
        }

        public async Task AddSync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task<IEnumerable<T>> GetByPostsAsync(IEnumerable<int> postIds)
        {
            return await _dbSet
                .Where(l => postIds.Contains(l.PostId))
                .ToListAsync();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
