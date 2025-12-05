using glubhub.Data;
using glubhub.Models;
using glubhub.Persistent.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace glubhub.Persistent.Repositories
{
    public class CommentsRepository<T> : ICommentsRepository<T> where T : Comments
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;


        public CommentsRepository(ApplicationDbContext context)
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
        public async Task<IEnumerable<T>> GetByPostAsync(int postId)
        {
            return await _dbSet.Where(c => c.PostId == postId).ToListAsync();
        }

        public Task<IEnumerable<T>> GetByPostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
