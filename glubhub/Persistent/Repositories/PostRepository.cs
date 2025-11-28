using glubhub.Data;
using glubhub.Models;
using Microsoft.EntityFrameworkCore;

public class PostRepository<T> : IPostRepository<T> where T : Post
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public PostRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetByUserAsync(Guid userId)
    {
        return await _dbSet
            .Where(p => p.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await Task.CompletedTask;
    }
}
